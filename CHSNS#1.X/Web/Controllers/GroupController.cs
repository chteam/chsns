	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using System.Linq;
//	using CHSNS.Extension;
	
	using CHSNS.ModelPas;
	using CHSNS.Models;
	using CHSNS.Config;
	using CHSNS;
using System.Web.Mvc;
using System.Transactions;
namespace CHSNS.Controllers {

	[LoginedFilter]
	public class GroupController : BaseController {
		#region 主页
		public ActionResult index(long id, int? p) {
			InitPage(ref p);
			#region 群信息和用户
			Group g = DBExt.DB.Group.Where(c => c.ID == id).FirstOrDefault();
			Validate404(g);
			GroupUser u = DBExt.DB.GroupUser.Where(gu => gu.UserID == CHUser.UserID && gu.GroupID == id).FirstOrDefault();
			Validate404(u);
			ViewData["guser"] = u;
			Title = g.Name;
			#endregion
			#region 权限计算
			var ret = 8; //不允许任何操作
			ret = g.ShowLevel;
			if (u != null && u.Status != (byte)GroupUserStatus.Lock) {
				ret = 0;
			}
			if (CHUser.IsAdmin) {
				ret = 0;
			}

			int userlevel = 0;
			if (CHUser.IsAdmin) {
				ret = 0;
				userlevel = 255;
			} else {
				userlevel = u.Status;
			}
			ViewData["right"] = ret;
			#endregion
			#region 统计
			ViewData["MemberList"] = DBExt.View.ViewList(6, 2, g.ID, 6);
			ViewData["ViewList"] = DBExt.View.ViewList(1, 6, g.ID, 6);
			ViewData["Applycount"] = DBExt.DB.GroupUser.Where(
				c => c.GroupID == id
					 && c.Status.Equals(GroupUserStatus.Lock)
				).Count();
			var adminList = (from gu in DBExt.DB.GroupUser
							 join a in DBExt.DB.Profile on gu.UserID equals a.UserID
							 where gu.GroupID == id
								   && (gu.Status.Equals(GroupUserStatus.Ceater) ||
									   gu.Status.Equals(GroupUserStatus.Admin))
							 orderby gu.Status descending
							 select new UserItemPas {
								 Name = a.Name,
								 ID = a.UserID
							 }).ToList();
			ViewData["adminlist"] = adminList;
			#endregion
			var posts = DBExt.Note.GetNotes(id, NoteType.GroupPost);
			ViewData["posts"] = new PagedList<NotePas>(posts, p.Value, 20);
			return View(g);
		}

		#endregion

		public ActionResult List(long? uid, int? p) {
			InitPage(ref p);
			uid = uid ?? CHContext.User.UserID;
			IQueryable<Group> ret = (from gu in DBExt.DB.GroupUser
									 join g in DBExt.DB.Group on gu.GroupID equals g.ID
									 where gu.UserID == uid.Value
									 select g
									);
			ret = ret.OrderBy(c => c.ID);
			var list = new PagedList<Group>(ret, p.Value, 10);
			Title = "群列表";
			return View(list);
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
			DBExt.DB.Group.InsertOnSubmit(group);
			DBExt.DB.SubmitChanges();
			var gu = new GroupUser {
				GroupID = group.ID,
				Status = (byte)GroupUserStatus.Ceater,
				UserID = CHUser.UserID,
				AddTime = DateTime.Now
			};
			DBExt.DB.GroupUser.InsertOnSubmit(gu);
			DBExt.DB.SubmitChanges();
			return this.RedirectToReferrer();


		}
		#endregion

		#region 管理
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Manage(long id) {
			//TODO:限制访问人员
			var g = DBExt.DB.Group.Where(c => c.ID == id).FirstOrDefault();
			return ManageResult(g);
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
			var g = DBExt.DB.Group.Where(c => c.ID == id).FirstOrDefault();
			Validate404(g);
			g.Name = group.Name;
			g.JoinLevel = group.JoinLevel;
			g.ShowLevel = group.ShowLevel;
			g.Summary = group.Summary ?? "";
			DBExt.DB.SubmitChanges();
			return ManageResult(g);
		}
		#endregion

		#region 用户管理
		public ActionResult ManageUser(long id) {
			Title = "用户管理";
			var list = (from g in DBExt.DB.GroupUser
						join u in DBExt.DB.Profile on g.UserID equals u.UserID
						where g.GroupID == id
						select new UserCountPas {
							ID = u.UserID,
							Name = u.Name,
							Count = g.Status
						});
			ViewData["list"] = list;
			return View();
		}
		#endregion

		#region 帖子
		public ActionResult Details(long id) {
			NoteDetailsPas note;
			note = DBExt.Note.Details(id, NoteType.GroupPost);
            var chsite = HttpContext.Application.CHSite();
			var cl = DBExt.Comment.CommentList(id, CommentType.Note).Pager(1,
                chsite.Note.CommentEveryPage
				).OrderBy(c => c.Comment.ID);
			ViewData["commentlist"] = cl;
			Title = note.Note.Title;
			ViewData["NowPage"] = 1;
			ViewData["PageCount"] = note.User.Count;
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
					DBExt.Note.Add(post);
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
