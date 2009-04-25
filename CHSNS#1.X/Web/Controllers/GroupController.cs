using System.Collections.Generic;
	using CHSNS.Model;
using System.Web.Mvc;
using System.Transactions;
using CHSNS.Abstractions;

namespace CHSNS.Controllers {

	[LoginedFilter]
	public class GroupController : BaseController {
		#region 主页
        public ActionResult Index(long id, int? p)
        {
            InitPage(ref p);

            #region 群信息和用户

            var g = DbExt.Group.Get(id);
            Validate404(g);
            var u = DbExt.Group.GetGroupUser(id, CHUser.UserID);
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

            ViewData["MemberList"] = DbExt.View.ViewList(6, 2, g.ID, 6);
            ViewData["ViewList"] = DbExt.View.ViewList(1, 6, g.ID, 6);

            ViewData["Applycount"] = DbExt.Group.WaitJoinCount(id);

            var adminList = DbExt.Group.GetAdmins(id);
            ViewData["adminlist"] = adminList;

            #endregion

            var posts = DbExt.Note.GetNotes(id, NoteType.GroupPost, p.Value, 20);
            ViewData["posts"] = posts;
            return View(g);
        }

	    #endregion

        public ActionResult List(long? uid, int? p)
        {
            InitPage(ref p);
            uid = uid ?? CHUser.UserID;
            Title = "群列表";
            return View(DbExt.Group.GetList(uid.Value, p.Value, 10));
        }

	    #region Create
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Create() {
			Title = "新建群";
			ViewData["category"] = ConfigSerializer.GetConfig("Category").ToSelectList(c => c.Value, c => c.Text);
			return View();
		}
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string name) {
            Message = "创建成功";
            DbExt.Group.Add(name, CHUser.UserID);
            return this.RedirectToReferrer();
        }
		#endregion

		#region 管理
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Manage(long id)
        {
            //TODO:限制访问人员
            return ManageResult(DbExt.Group.Get(id));
        }

	    [NonAction]
		ActionResult ManageResult(IGroup g) {
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
        public ActionResult Manage(long id, GroupImplement group) {
            //TODO:限制访问人员
            DbExt.Group.Update(id, group);
            return RedirectToAction("Manage", new{id});
        }

	    #endregion

		#region 用户管理
		public ActionResult ManageUser(long id) {
			Title = "用户管理";
		    ViewData["list"] = DbExt.Group.GetGroupUser(id);
            
			return View();
		}
		#endregion

		#region 帖子
        public ActionResult Details(long id){
            var note = DbExt.Note.Details(id, NoteType.GroupPost);
            var cl = DbExt.Comment.CommentList(id, CommentType.Note, 1,CHContext.Site);
            ViewData["commentlist"] = cl;
            Title = note.Note.Title;
            //	ViewData["NowPage"] = 1;
            //		ViewData["PageCount"] = note.User.Count;
            return View(note);
        }

	    [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Post(long? id, NoteImplement post) {
			using (var ts = new TransactionScope()) {
				if (post.Title.Length < 1 || post.Body.Length < 1) {
					Message = "请输入正确的日志内容";
					return this.RedirectToReferrer();
				}
				post.Type = (int)NoteType.GroupPost;
                post.UserID = CHContext.User.UserID;
				if (id.HasValue) {
					post.ID = id.Value;
					DbExt.Note.Edit(post);
				} else {
					DbExt.Note.Add(post,CHUser);
				}
				ts.Complete();
				return this.RedirectToReferrer();
			}
		}
		#endregion
		/*public void ClassList() {

			Dictionary dict = new Dictionary();
			dict.Add("@userid", CHSNSUser.Current.UserID);
			ViewData.Add("rows",DataBaseExecutor.GetRows(
				"GetRelationClass", dict));
		}
		
		public void CreateClass() {
			Dictionary dict=new Dictionary();
			dict.Add("@userid",CHSNSUser.Current.UserID);
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
