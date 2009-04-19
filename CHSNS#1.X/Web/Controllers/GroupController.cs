	using System;
	using System.Collections.Generic;
	using System.Linq;
//	using CHSNS.Extension;
	
	using CHSNS.Model;
	using CHSNS.Models;
	using System.Web.Mvc;
using System.Transactions;
namespace CHSNS.Controllers {

	[LoginedFilter]
	public class GroupController : BaseController {
		#region 主页
		public ActionResult Index(long id, int? p) {
			InitPage(ref p); 
			#region 群信息和用户
            Group g;
            GroupUser u;
            using (var db = DBExt.Instance) {
                g = db.Group.Where(c => c.ID == id).FirstOrDefault();
                Validate404(g);
                 u = db.GroupUser.Where(gu => gu.UserID == CHUser.UserID && gu.GroupID == id).FirstOrDefault();
                Validate404(u);
                ViewData["guser"] = u;
                Title = g.Name;
            }
			#endregion
			#region 权限计算

		    int ret = g.ShowLevel;
			if (u != null && u.Status != (byte)GroupUserStatus.Lock) {
				ret = 0;
			}
			if (CHUser.IsAdmin) {
				ret = 0;
			}

			var userlevel = 0;
			if (CHUser.IsAdmin) {
				ret = 0;
				userlevel = 255;
			} else {
			    if (u != null) userlevel = u.Status;
			}
            ViewData["right"] = userlevel;
            ViewData["showlevel"] = ret;
			#endregion
			#region 统计
			ViewData["MemberList"] = DBExt.View.ViewList(6, 2, g.ID, 6);
			ViewData["ViewList"] = DBExt.View.ViewList(1, 6, g.ID, 6);
            using (var db = DBExt.Instance) {
                ViewData["Applycount"] = db.GroupUser.Where(
                    c => c.GroupID == id
                         && c.Status.Equals(GroupUserStatus.Lock)
                    ).Count();
                var adminList = (from gu in db.GroupUser
                                 join a in db.Profile on gu.UserID equals a.UserID
                                 where gu.GroupID == id
                                       && (gu.Status.Equals(GroupUserStatus.Ceater) ||
                                           gu.Status.Equals(GroupUserStatus.Admin))
                                 orderby gu.Status descending
                                 select new UserItemPas {
                                     Name = a.Name,
                                     ID = a.UserID
                                 }).ToList();
                ViewData["adminlist"] = adminList;
            }
			#endregion
            var posts = DBExt.Note.GetNotes(id, NoteType.GroupPost, p.Value, 20);
            ViewData["posts"] = posts;
			return View(g);
		}

		#endregion

        public ActionResult List(long? uid, int? p) {
            InitPage(ref p);
            uid = uid ?? CHUser.UserID;
            using (var db = DBExt.Instance) {
                IQueryable<Group> ret = (from gu in db.GroupUser
                                         join g in db.Group on gu.GroupID equals g.ID
                                         where gu.UserID == uid.Value
                                         select g
                                        );
                ret = ret.OrderBy(c => c.ID);
                var list = new PagedList<Group>(ret, p.Value, 10);
                Title = "群列表";
                return View(list);
            }
        }
		#region Create
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Create() {
			Title = "新建群";
			ViewData["category"] = ConfigSerializer.GetConfig("Category").ToSelectList(c => c.Value, c => c.Text);
			return View();
		}
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string Name) {
            Message = "创建成功";
            var group = new Group {
                Name = Name,
                Type = (byte)GroupType.Common,
                AddTime = DateTime.Now,
                Summary = "",
            };
            using (var db = DBExt.Instance) {
                db.Group.InsertOnSubmit(group);
                db.SubmitChanges();
                var gu = new GroupUser {
                    GroupID = group.ID,
                    Status = (byte)GroupUserStatus.Ceater,
                    UserID = CHUser.UserID,
                    AddTime = DateTime.Now
                };
                db.GroupUser.InsertOnSubmit(gu);
                db.SubmitChanges();
            }
            return this.RedirectToReferrer();


        }
		#endregion

		#region 管理
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Manage(long id) {
			//TODO:限制访问人员
            using (var db = DBExt.Instance) {
                var g = db.Group.Where(c => c.ID == id).FirstOrDefault();
                return ManageResult(g);
            }
			
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
        public ActionResult Manage(long id, Group group) {
            //TODO:限制访问人员
            using (var db = DBExt.Instance) {
                var g = db.Group.Where(c => c.ID == id).FirstOrDefault();
                Validate404(g);
                g.Name = group.Name;
                g.JoinLevel = group.JoinLevel;
                g.ShowLevel = group.ShowLevel;
                g.Summary = group.Summary ?? "";
                db.SubmitChanges();
                return RedirectToAction("Manage", new { id });
            }

        }
		#endregion

		#region 用户管理
		public ActionResult ManageUser(long id) {
			Title = "用户管理";
            using (var db = DBExt.Instance) {
                var list = (from g in db.GroupUser
                            join u in db.Profile on g.UserID equals u.UserID
                            where g.GroupID == id
                            select new UserCountPas {
                                ID = u.UserID,
                                Name = u.Name,
                                Count = g.Status
                            });
                ViewData["list"] = list.ToList();
            }
			return View();
		}
		#endregion

		#region 帖子
        public ActionResult Details(long id){
            var note = DBExt.Note.Details(id, NoteType.GroupPost);
            var cl = DBExt.Comment.CommentList(id, CommentType.Note, 1,CHContext.Site);
            ViewData["commentlist"] = cl;
            Title = note.Note.Title;
            //	ViewData["NowPage"] = 1;
            //		ViewData["PageCount"] = note.User.Count;
            return View(note);
        }

	    [AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Post(long? id, Note post) {
			using (var ts = new TransactionScope()) {
				if (post.Title.Length < 1 || post.Body.Length < 1) {
					Message = "请输入正确的日志内容";
					return this.RedirectToReferrer();
				}
				post.Type = (int)NoteType.GroupPost;
                post.UserID = CHContext.User.UserID;
				if (id.HasValue) {
					post.ID = id.Value;
					DBExt.Note.Edit(post);
				} else {
					DBExt.Note.Add(post,CHUser);
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
