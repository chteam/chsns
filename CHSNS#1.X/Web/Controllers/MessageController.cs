/*
 * 邹健 08-1-24
 */


using System;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Models;
using CHSNS.Tools;

namespace CHSNS.Controllers {
	using Filter;
	using ModelPas;
	[LoginedFilter]
	public class MessageController : BaseController {
		public ActionResult InBox(int? p, int? ep) {
			using (new TransactionScope()) {
				ViewData["PageCount"] = DBExt.Message.InboxCount(CHUser.UserID);
				ViewData["Page_Title"] = "收件箱";
				return InBoxList(p, ep);
			}
		}
		[AcceptVerbs("Post")]
		public ActionResult InBoxList(int? p, int? ep) {
			if (!p.HasValue || p.Value == 0) p = 1;
			if (!ep.HasValue || ep.Value == 0) ep = 10;
			ViewData["NowPage"] = p;
			return View(DBExt.Message.GetInbox(CHUser.UserID).Pager(p.Value, ep.Value));
		}
		public ActionResult OutBox(int? p, int? ep) {
			using (new TransactionScope()) {
				ViewData["PageCount"] = DBExt.Message.OutboxCount(CHUser.UserID);
				ViewData["Page_Title"] = "发件箱";
				return OutBoxList(p, ep);
			}
		}
		[AcceptVerbs("Post")]
		public ActionResult OutBoxList(int? p, int? ep) {
			if (!p.HasValue || p.Value == 0) p = 1;
			if (!ep.HasValue || ep.Value == 0) ep = 10;
			ViewData["NowPage"] = p;
			return View(DBExt.Message.GetOutbox(CHUser.UserID).Pager(p.Value, ep.Value));
		}
		[AcceptVerbs("Post")]
		public ActionResult Delete(long id, int t) {
			DBExt.Message.Delete(id, (MessageBoxType)t, CHUser.UserID);
			CHStatic.Clear();
			return Content("");
		}
		public ActionResult Details(long id) {
			var m = DBExt.Message.Details(id, CHUser.UserID);
			ViewData["Page_Title"] = m.Message.Title;
			CHStatic.Clear();
			return View(m);
		}
		public ActionResult Write(long toid, string toname) {
			ViewData["Page_Title"] = "写站内信";
			return View(new UserItemPas {
				ID = toid,
				Name = Server.UrlDecode(toname)
			});
		}
		[NonAction]
		void SavaProc() {

			var m = new Message {
				FromID = CHUser.UserID,
				SendTime = DateTime.Now
			};
			UpdateModel(m, new[] { "Title", "Body", "ToID" });
			DBExt.Message.Add(m);

		}
		[AcceptVerbs("Post")]
		public ActionResult Save() {
			using (var ts = new TransactionScope()) {
				SavaProc();
				ts.Complete();
				return RedirectToAction("OutBox");
			}
		}
		[AcceptVerbs("Post")]
		public ActionResult SaveAjax() {
			using (var ts = new TransactionScope()) {
				SavaProc();
				ts.Complete();
				return new EmptyResult();
			}
		}
	}
}
