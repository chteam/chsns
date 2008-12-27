using System;
using System.Linq;
using System.Web.Mvc;
using CHSNS.Filter;
using CHSNS.Models;
using CHSNS.Tools;
using System.Transactions;
using CHSNS.Config;
using CHSNS.ModelPas;
namespace CHSNS.Controllers {

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
				Title = user.Name + "����־";
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
			NoteDetailsPas note;
			using (var ts = DBExt.ContextTransaction()) {
				note = DBExt.Note.Details(id);
				var cl = DBExt.Comment.CommentList(id, CommentType.Note).Pager(1,
					SiteConfig.Current.Note.CommentEveryPage
					).OrderBy(c => c.Comment.ID);
				ViewData["commentlist"] = cl;
				ts.Commit();
			}
			if (note.User.ID != CHUser.UserID) {
				int r = DBExt.Note.AddViewCount(id);
				if (r != 1) throw new Exception("��������ȷ");
			}
			Title = note.Note.Title;
			ViewData["NowPage"] = 1;
			ViewData["PageCount"] = note.User.Count;
			return View(note);
		}
		[AcceptVerbs(HttpVerbs.Get)]
		[LoginedFilter]
		public ActionResult Edit(long? id){
			using (var ts = new TransactionScope()) {
				Note n = null;
				if (id.HasValue) {
					//�༭
					n = DBExt.Note.Details(id.Value).Note;
					Title = "�޸���־";
				}
				else {
					Title = "������־";
				}
				ts.Complete();
				return View(n);
			}
		}

		[AcceptVerbs("post")]
		[LoginedFilter]
		public ActionResult Edit(long? id, Note n) {
			using (var ts = new TransactionScope()) {
				if (n.Title.Length < 1 || n.Body.Length < 10) {
					Message = ("��������ȷ����־����");
					return View(n);
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
		[LoginedFilter]
		public ActionResult Delete(long id) {
			using (var ts = new TransactionScope()) {
				DBExt.Note.Delete(id, CHUser.UserID);
				ts.Complete();
				return Content("");
			}
		}

		/// <summary>
		/// ȫ�����µ�note
		/// </summary>
		/// <returns></returns>
		public ActionResult News() {
			Title = "��־��ҳ";
			return View(DBExt.Note.GetLastNotes());
		}
	}
}
