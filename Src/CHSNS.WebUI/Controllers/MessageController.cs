using System;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Controllers
{
    using System.ComponentModel.Composition;
    using CHSNS.Service;

    /// <summary>
    /// 站内信
    /// </summary>
    [Authorize]
    public partial class MessageController : BaseController
    {
        [Import]
        public MessageService MessageInfo { get; set; }
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
            var m = MessageInfo.GetInbox(WebUser.UserId, p.Value,WebContext.Site);
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
            var m = MessageInfo.GetOutbox(WebUser.UserId, p.Value, WebContext.Site);
            ViewData["NowPage"] = p;
            ViewData["PageCount"] = m.TotalPages;
            return View(m);
        }

        [HttpPost]
        public virtual ActionResult Delete(long id, int t)
        {
            MessageInfo.Delete(id, (MessageBoxType)t, WebUser.UserId);
            //CHStatic.Clear();
            return Content("");
        }
        public virtual ActionResult Details(long id)
        {
            var m = MessageInfo.Details(id, WebUser.UserId);
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
                FromId = WebUser.UserId,
                SendTime = DateTime.Now
            };
            UpdateModel(m, new[] { "Title", "Body", "ToID" });
            MessageInfo.Add(m,WebContext);

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
