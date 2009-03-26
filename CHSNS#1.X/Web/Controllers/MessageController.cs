/*
 * 邹健 08-1-24
 * 09 03 27
 */


using System;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;
namespace CHSNS.Controllers
{

    /// <summary>
    /// 站内信
    /// </summary>
    [LoginedFilter]
    public class MessageController : BaseController
    {
        public ActionResult InBox(int? p, int? ep)
        {
            Title = "收件箱";
            return InBoxList(p, ep);
        }
        [AcceptVerbs("Post")]
        public ActionResult InBoxList(int? p, int? ep)
        {
            InitPage(ref p);
            InitPage(ref ep, 10);
            var m = DBExt.Message.GetInbox(CHUser.UserID, p.Value, ep.Value);
            ViewData["NowPage"] = p;
            ViewData["PageCount"] = m.TotalPages;
            return View(m);
        }
        public ActionResult OutBox(int? p, int? ep)
        {
            Title = "发件箱";
            return OutBoxList(p, ep);
        }

        [AcceptVerbs("Post")]
        public ActionResult OutBoxList(int? p, int? ep)
        {
            InitPage(ref p);
            InitPage(ref ep, 10);
            var m = DBExt.Message.GetOutbox(CHUser.UserID, p.Value, ep.Value);
            ViewData["NowPage"] = p;
            ViewData["PageCount"] = m.TotalPages;
            return View(m);
        }

        [AcceptVerbs("Post")]
        public ActionResult Delete(long id, int t)
        {
            DBExt.Message.Delete(id, (MessageBoxType)t, CHUser.UserID);
            //CHStatic.Clear();
            return Content("");
        }
        public ActionResult Details(long id)
        {
            var m = DBExt.Message.Details(id, CHUser.UserID);
            Title = m.Message.Title;
            //	CHStatic.Clear();
            return View(m);
        }
        public ActionResult Write(long toid, string toname)
        {
            Title = "写站内信";
            return View(new UserItemPas
            {
                ID = toid,
                Name = Server.UrlDecode(toname)
            });
        }
        [NonAction]
        void SavaProc()
        {

            var m = new Message
            {
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
