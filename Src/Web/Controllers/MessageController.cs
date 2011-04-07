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
    [Authorize]
    public partial class MessageController : BaseController
    {
        public virtual ActionResult InBox(int? p)
        {
            Title = "收件箱";
            return InBoxList(p);
        }
        [HttpPost]
        public virtual ActionResult InBoxList(int? p)
        {
            InitPage(ref p);
          //  InitPage(ref ep, 10);
            var m = Services.Message.GetInbox(CHUser.UserId, p.Value,WebContext.Site);
            ViewData["NowPage"] = p;
            ViewData["PageCount"] = m.TotalPages;
            return View(m);
        }
        public virtual ActionResult OutBox(int? p, int? ep)
        {
            Title = "发件箱";
            return OutBoxList(p);
        }

        [HttpPost]
        public virtual ActionResult OutBoxList(int? p)
        {
            InitPage(ref p);
           // InitPage(ref ep, 10);
            var m = Services.Message.GetOutbox(CHUser.UserId, p.Value, WebContext.Site);
            ViewData["NowPage"] = p;
            ViewData["PageCount"] = m.TotalPages;
            return View(m);
        }

        [HttpPost]
        public virtual ActionResult Delete(long id, int t)
        {
            Services.Message.Delete(id, (MessageBoxType)t, CHUser.UserId);
            //CHStatic.Clear();
            return Content("");
        }
        public virtual ActionResult Details(long id)
        {
            var m = Services.Message.Details(id, CHUser.UserId);
            Title = m.Message.Title;
            //	CHStatic.Clear();
            return View(m);
        }
        public virtual ActionResult Write(long toid, string toname)
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
            Services.Message.Add(m,WebContext);

        }
        [HttpPost]
        public virtual ActionResult Save()
        {
            SavaProc();
            return RedirectToAction("OutBox");
        }

        [HttpPost]
        public virtual ActionResult SaveAjax()
        {
            SavaProc();
            return new EmptyResult();
        }
    }
}
