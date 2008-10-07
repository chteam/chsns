using System;

using System.Web.Mvc;
using CHSNS.Extension;
using CHSNS.Filter;
using CHSNS.Models;
using CHSNS.Tools;
using System.Transactions;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class NoteController : BaseController {
		public ActionResult Index(long? userid, int? p) {
			using (var ts = new TransactionScope()) {
				if (!userid.HasValue) userid = CHUser.UserID;
				if (!p.HasValue || p == 0) p = 1;
				var user = DBExt.UserInfo.GetUser(
					userid.Value,
					c => new UserCountPas {
						ID = c.UserID,
						Name = c.Name,
						Count = c.NoteCount
					});
				ViewData["username"] = user.Name;
				ViewData["userid"] = user.ID;
				ViewData["PageCount"] = user.Count;
				ViewData["NowPage"] = p.Value;
				ViewData["Page_Title"] = user.Name + "的日志";
				var ret = NoteList(p.Value, 10, userid.Value);
				ts.Complete();
				return ret;
			}
		}
		/// <summary>
		/// Notes the list.
		/// </summary>
		/// <param name="p">The p.</param>
		/// <param name="ep">The ep.</param>
		/// <param name="userid">The userid.</param>
		/// <returns></returns>
		[AcceptVerbs("Post")]
		public ActionResult NoteList(int p, int ep, long userid) {
				var d = DBExt.Note.GetNotes(userid).Pager(p, ep);
				return View(d);
		}
		public ActionResult Details(long id) {
			using (var ts = new TransactionScope()) {
				var note = DBExt.Note.Details(id);
				// TODO:ViewCount++
				ViewData["Page_Title"] = note.Note.Title;
				ViewData["NowPage"] = 1;
				ViewData["PageCount"] = note.User.Count;
				ViewData["commentlist"] = DBExt.Comment.CommentList(id, CommentType.Note).Pager(1, 100);
				ts.Complete();
				return View(note);
			}
		}
		public ActionResult Edit(long? id) {
			using (var ts = new TransactionScope()) {
				if (id.HasValue) {//编辑
					var mod = DBExt.Note.Details(id.Value).Note;
					ViewData["Title"] = mod.Title;
					ViewData["Body"] = mod.Body;
					ViewData["ID"] = id.Value;
					ViewData["Page_Title"] = "修改日志";
				}
				else {
					ViewData["Page_Title"] = "发新日志";
				}
				return View();
			}
		}
		[AcceptVerbs("post")]
		public ActionResult Save(long? id) {
			using (var ts = new TransactionScope()) {
				var n = new Note();
				UpdateModel(n, new[] { "Title", "Body" });
				if (n.Title.Length < 1 || n.Body.Length < 10) {
					throw new Exception("请输入正确的日志内容");
				}
				if (id.HasValue) {
					n.ID = id.Value;
					DBExt.Note.Edit(n, CHUser.UserID);
				}
				else {
					DBExt.Note.Add(n, CHUser.UserID);
				}
				ts.Complete();
				return RedirectToAction("Index");
			}
		}
		/// <summary>
		/// Delete the Note
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		[AcceptVerbs("post")]
		public ActionResult Delete(long id) {
			using (var ts = new TransactionScope()) {
				DBExt.Note.Delete(id, CHUser.UserID);
				ts.Complete();
				return Content("");
			}
		}



		public ActionResult New() {
			//	Chsword.Reader.LogBook rl = new Chsword.Reader.LogBook("LogBook", 0, Viewerid);
			//ChAlumna.Controllers.components.NoteList nl = new ChAlumna.Controllers.components.NoteList();

			//	_sbout = new StringBuilder(rl.ShowAll(rl.ShowPage(rl.GetLogBookTable(1, 0)), 1));
			//this.Context.CurrentUser.Identity.Name
			ViewData.Add("type", this.QueryNum("type"));//0 new[最新] 1 push[推荐] 
			return View();
		}
	}
}
