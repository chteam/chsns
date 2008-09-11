/*
 * ×Þ½¡ 08-1-24
 */


using System;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Models;
using CHSNS.Tools;

namespace CHSNS.Controllers {
	using Extension;
	using Filter;
	[LoginedFilter]
	public class MessageController : BaseController {
		public ActionResult InBox(int? p, int? ep) {
			using (new TransactionScope()) {
				ViewData["PageCount"] = DBExt.Message.InboxCount(CHUser.UserID);
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
			DBExt.Message.Delete(id, t, CHUser.UserID);
			return Content("");
		}
		public ActionResult Details(long id) {
			return View(DBExt.Message.Details(id, CHUser.UserID));
		}
		public ActionResult Write(long toid, string toname) {
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
