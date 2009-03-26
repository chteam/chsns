/*
 * �޽� 08-1-24
 * 09 03 27
 */


using System;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;
namespace CHSNS.Controllers {

    /// <summary>
    /// վ����
    /// </summary>
	[LoginedFilter]
	public class MessageController : BaseController {
		public ActionResult InBox(int? p, int? ep) {
				ViewData["PageCount"] = DBExt.Message.InboxCount(CHUser.UserID);
				Title = "�ռ���";
				return InBoxList(p, ep);
			
		}
		[AcceptVerbs("Post")]
		public ActionResult InBoxList(int? p, int? ep) {
            InitPage(ref p);
            InitPage(ref ep, 10);
			ViewData["NowPage"] = p;
			return View(DBExt.Message.GetInbox(CHUser.UserID).Pager(p.Value, ep.Value));
		}
        public ActionResult OutBox(int? p, int? ep)
        {
            ViewData["PageCount"] = DBExt.Message.OutboxCount(CHUser.UserID);
            Title = "������";
            return OutBoxList(p, ep);
        }

	    [AcceptVerbs("Post")]
        public ActionResult OutBoxList(int? p, int? ep)
        {
            InitPage(ref p);
            InitPage(ref ep, 10);
            ViewData["NowPage"] = p;
            return View(DBExt.Message.GetOutbox(CHUser.UserID).Pager(p.Value, ep.Value));
        }

	    [AcceptVerbs("Post")]
		public ActionResult Delete(long id, int t) {
			DBExt.Message.Delete(id, (MessageBoxType)t, CHUser.UserID);
			//CHStatic.Clear();
			return Content("");
		}
		public ActionResult Details(long id) {
			var m = DBExt.Message.Details(id, CHUser.UserID);
			Title = m.Message.Title;
		//	CHStatic.Clear();
			return View(m);
		}
		public ActionResult Write(long toid, string toname) {
			Title = "дվ����";
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
        public ActionResult Save()
        {
            SavaProc();
            return RedirectToAction("OutBox");
        }

        [AcceptVerbs("Post")]
        public ActionResult SaveAjax()
        {
            SavaProc();
            return new EmptyResult();
        }
	}
}
