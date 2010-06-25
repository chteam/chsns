using System.Collections.Generic;
	using CHSNS.Model;
using System.Web.Mvc;
using System.Transactions;
using CHSNS.Models;


namespace CHSNS.Controllers {

	[LoginedFilter]
    public partial class GroupController : BaseController
    {
		#region 主页
        public virtual ActionResult Index(long id, int? p)
        {
            InitPage(ref p);

            #region 群信息和用户

            var g = DataExt.Group.Get(id);
            Validate404(g);
            var u = DataExt.Group.GetGroupUser(id, CHUser.UserId);
            Validate404(u);
            ViewData["guser"] = u;
            Title = g.Name;

            #endregion

            #region 权限计算

            int ret = g.ShowLevel;
            if (u != null && u.Status != (byte) GroupUserStatus.Wait)
            {
                ret = 0;
            }
            if (CHUser.IsAdmin)
            {
                ret = 0;
            }

            var userlevel = 0;
            if (CHUser.IsAdmin)
            {
                ret = 0;
                userlevel = 255;
            }
            else
            {
                if (u != null) userlevel = u.Status;
            }
            ViewData["right"] = userlevel;
            ViewData["showlevel"] = ret;

            #endregion

            #region 统计

            ViewData["MemberList"] = DataExt.View.ViewList(6, 2, g.Id, 6);
            ViewData["ViewList"] = DataExt.View.ViewList(1, 6, g.Id, 6);

            ViewData["Applycount"] = DataExt.Group.WaitJoinCount(id);

            var adminList = DataExt.Group.GetAdmins(id);
            ViewData["adminlist"] = adminList;

            #endregion

            var posts = DataExt.Note.GetNotes(id, NoteType.GroupPost, p.Value, 20);
            ViewData["posts"] = posts;
            return View(g);
        }

	    #endregion

        public virtual ActionResult List(long? uid, int? p)
        {
            InitPage(ref p);
            uid = uid ?? CHUser.UserId;
            Title = "群列表";
            return View(DataExt.Group.GetList(uid.Value, p.Value, 10));
        }

	    #region Create
		[AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Create()
        {
			Title = "新建群";
			ViewData["category"] = ConfigSerializer.GetConfig("Category").ToSelectList(c => c.Value, c => c.Text);
			return View();
		}
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(string name)
        {
            Message = "创建成功";
            DataExt.Group.Add(name, CHUser.UserId);
            return this.RedirectToReferrer();
        }
		#endregion

		#region 管理
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Manage(long id)
        {
            //TODO:限制访问人员
            return ManageResult(DataExt.Group.Get(id));
        }

	    [NonAction]
		ActionResult ManageResult(Group g) {
			Validate404(g);
			Title = g.Name + "管理";
			ViewData["group.ShowLevel"] = new SelectList(
				ConfigSerializer.Load<List<ListItem>>("Group/ShowLevel"),
				"Value", "Text", g.ShowLevel);
			ViewData["group.JoinLevel"] = new SelectList(
				ConfigSerializer.Load<List<ListItem>>("Group/JoinLevel"),
				"Value", "Text", g.JoinLevel);
			ViewData["group"] = g;
			return View();
		}

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Manage(long id, Group group)
        {
            //TODO:限制访问人员
            DataExt.Group.Update(id, group);
            return RedirectToAction("Manage", new{id});
        }

	    #endregion

		#region 用户管理
        public virtual ActionResult ManageUser(long id)
        {
			Title = "用户管理";
		    ViewData["list"] = DataExt.Group.GetGroupUser(id);
            
			return View();
		}
		#endregion

		#region 帖子
        public virtual ActionResult Details(long id)
        {
            var note = DataExt.Note.Details(id, NoteType.GroupPost);
            var cl = DataExt.Comment.CommentList(id, CommentType.Note, 1,CHContext.Site);
            ViewData["commentlist"] = cl;
            Title = note.Note.Title;
            //	ViewData["NowPage"] = 1;
            //		ViewData["PageCount"] = note.User.Count;
            return View(note);
        }

	    [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Post(long? id, Note post)
        {
			using (var ts = new TransactionScope()) {
				if (post.Title.Length < 1 || post.Body.Length < 1) {
					Message = "请输入正确的日志内容";
					return this.RedirectToReferrer();
				}
				post.Type = (int)NoteType.GroupPost;
                post.UserId = CHContext.User.UserId;
				if (id.HasValue) {
					post.Id = id.Value;
					DataExt.Note.Edit(post);
				} else {
					DataExt.Note.Add(post,CHUser);
				}
				ts.Complete();
				return this.RedirectToReferrer();
			}
		}
		#endregion
		/*public void ClassList() {

			Dictionary dict = new Dictionary();
			dict.Add("@userid", CHSNSUser.Current.UserId);
			ViewData.Add("rows",DataBaseExecutor.GetRows(
				"GetRelationClass", dict));
		}
		
		public void CreateClass() {
			Dictionary dict=new Dictionary();
			dict.Add("@userid",CHSNSUser.Current.UserId);
			DataRowCollection rows = DataBaseExecutor.GetRows(
				"SchoolInfo", dict);
			if (rows.Count != 0) {
				ViewData.Add("University", rows[0]["University"]);
				ViewData.Add("Xueyuan", rows[0]["XueYuan"]);
				ViewData.Add("Grade", rows[0]["Grade"]);
			}
		}

		public ActionResult ShowGroupList(string template,long Ownerid,
			int groupclass,int Npage,int Epage,int type) {
			return View(template, DataBaseExecutor.GetRows("GroupList",
				"@userid", Ownerid
				, "@page", Npage
				, "@everypage", Epage
				, "@GroupClass", groupclass
				, "@type", type
				));
		}*/
	}
}
