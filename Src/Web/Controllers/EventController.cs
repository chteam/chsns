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
	[LoginedFilter]
	public class EventController : BaseController {
		#region Action

        public ActionResult Index()
        {
            Title = "事件";
            var m = new EventIndexViewModel{
                                                 //     Events = DBExt.Event.GetFriendEvent(CHUser.UserId, 1, 20),
                                                 LastViews = DbExt.View.ViewList(0, 3, CHUser.UserID, 6),
                                                 NewViews = DbExt.View.ViewList(2, 3, CHUser.UserID, 6),
                                                 Page = DbExt.Gather.EventGather(CHUser.UserID)
                                             };
            return View(m);
        }

		#endregion


		#region Management
		[AdminFilter]
		public ActionResult SystemTemplate() {
			var x = ConfigSerializer.Load<List<ListItem>>("SystemTemplate");
			ViewData["source"] = x;
			return View("Admin/SystemTemplate");
		}
		[AdminFilter]
		public ActionResult GetSystemTemplate(string name)
		{
            var ret = "";// CHSNS.File.ReadAllText(Path.EventSystemTemplatePath(name));
			return Content(Server.HtmlEncode(ret));
		}
		[AdminFilter]
		public ActionResult AddSystemTemplate(string c, string v, string t)
		{
			if (string.IsNullOrEmpty(c) || string.IsNullOrEmpty(v))
				return Content("Error");
			if (!c.Contains("<%@")) {
				c = "<%@ Control Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"System.Web.Mvc.ViewUserControl\" %>" + c;
			}
			var li = new ListItem
			         	{
			         		Text = t,
			         		Value = v
			         	};
			var x = ConfigSerializer.Load<List<ListItem>>("SystemTemplate");
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
