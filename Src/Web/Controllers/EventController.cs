using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CHSNS.ViewModel;
/*
* Created by 邹健
* Date: 2007-12-25
* Time: 22:39
*/
namespace CHSNS.Controllers {

    /// <summary>
    /// 事件的控制器
    /// the Controller of Event.
    /// </summary>
    [Authorize]
    public partial class EventController : BaseController
    {
        #region Action

        public virtual ActionResult Index()
        {
            Title = "事件";

            //     Events = DBExt.Event.GetFriendEvent(CHUser.UserId, 1, 20),
            ViewBag.LastViews = ServicesFactory.View.ViewList(0, 3, CHUser.UserId, 6);
            ViewBag.NewViews = ServicesFactory.View.ViewList(2, 3, CHUser.UserId, 6);
            ViewBag.Page = ServicesFactory.Gather.EventGather(CHUser.UserId);
            return View();
        }

        #endregion


        #region Management
        [AdminFilter]
        public virtual ActionResult SystemTemplate()
        {
            var x = ConfigSerializer.Load<List<SelectListItem>>("SystemTemplate");
            ViewData["source"] = x;
            return View("Admin/SystemTemplate");
        }
        [AdminFilter]
        public virtual ActionResult GetSystemTemplate(string name)
        {
            var ret = "";// CHSNS.File.ReadAllText(Path.EventSystemTemplatePath(name));
            return Content(Server.HtmlEncode(ret));
        }
        [AdminFilter]
        public virtual ActionResult AddSystemTemplate(string c, string v, string t)
        {
            if (string.IsNullOrEmpty(c) || string.IsNullOrEmpty(v))
                return Content("Error");
            if (!c.Contains("<%@")) {
                c = "<%@ Control Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"System.Web.Mvc.ViewUserControl\" %>" + c;
            }
            var li = new SelectListItem
                        {
                            Text = t,
                            Value = v
                        };
            var x = ConfigSerializer.Load<List<SelectListItem>>("SystemTemplate");
            if (x.Where(q => q.Value == li.Value).Count() != 1)
            {
                x.Add(li);
                ConfigSerializer.Save(x, "SystemTemplate");
                ConfigSerializer.ClearCache("SystemTemplate");
            //	CHSNS.File.SaveAllText(Path.EventSystemTemplatePath(li.Value), c);
            }
            else {
                return Content("Error");
            }
            return Content("添加成功");
        }
        #endregion

    }
}
