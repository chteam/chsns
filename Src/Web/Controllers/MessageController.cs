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
        public ActionResult InBox(int? p)
        {
            Title = "收件箱";
            return InBoxList(p);
        }
        [HttpPost]
        public ActionResult InBoxList(int? p)
        {
            InitPage(ref p);
          //  InitPage(ref ep, 10);
            var m = DataExt.Message.GetInbox(CHUser.UserId, p.Value,CHContext.Site);
            ViewData["NowPage"] = p;
            ViewData["PageCount"] = m.TotalPages;
            return View(m);
        }
        public ActionResult OutBox(int? p, int? ep)
        {
            Title = "发件箱";
            return OutBoxList(p);
        }

        [HttpPost]
        public ActionResult OutBoxList(int? p)
        {
            InitPage(ref p);
           // InitPage(ref ep, 10);
            var m = DataExt.Message.GetOutbox(CHUser.UserId, p.Value, CHContext.Site);
            ViewData["NowPage"] = p;
            ViewData["PageCount"] = m.TotalPages;
            return View(m);
        }

        [HttpPost]
        public ActionResult Delete(long id, int t)
        {
            DataExt.Message.Delete(id, (MessageBoxType)t, CHUser.UserId);
            //CHStatic.Clear();
            return Content("");
        }
        public ActionResult Details(long id)
        {
            var m = DataExt.Message.Details(id, CHUser.UserId);
            Title = m.Message.Title;
            //	CHStatic.Clear();
            return View(m);
        }
        public ActionResult Write(long toid, string toname)
        {
            Title = "写站内信";
            return View(new UserItemPas
            {
                Id = toid,
                Name = Server.UrlDecode(toname)
            });
        }
        [NonAction]
        void SavaProc()
        {

            var m = new Message
            {
                FromId = CHUser.UserId,
                SendTime = DateTime.Now
            };
            UpdateModel(m, new[] { "Title", "Body", "ToID" });
            DataExt.Message.Add(m,CHContext);

        }
        [HttpPost]
        public ActionResult Save()
        {
            SavaProc();
            return RedirectToAction("OutBox");
        }

        [HttpPost]
        public ActionResult SaveAjax()
        {
            SavaProc();
            return new EmptyResult();
        }
    }
}
