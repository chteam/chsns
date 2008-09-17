/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 22:39
 * 
 * 
 */
using CHSNS.Filter;
using System.Linq;
namespace CHSNS.Controllers {
	//using CHSNS.Data;
	using System.Web.Mvc;
	using System.Transactions;
	using System.Collections.Generic;

	/// <summary>
	/// Description of EventController.
	/// </summary>
	[LoginedFilter]
	public class EventController : BaseController {
		public ActionResult Index() {
			using (new TransactionScope())
			{
				ViewData["newview"] = DBExt.View.ViewList(2, 3, CHUser.UserID, 6);
				ViewData["lastview"] = DBExt.View.ViewList(0, 3, CHUser.UserID, 6);
				ViewData["Page_Title"] = "事件";
				return View(DBExt.Gather.EventGather(CHUser.UserID));
			}
		} 
		#region 组件
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
			var ret = File.ReadAllText(Path.EventSystemTemplatePath(name));
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
			ListItem li = new ListItem()
			{
				Text = t,
				Value = v
			};
			var x = ConfigSerializer.Load<List<ListItem>>("SystemTemplate");
			if (x.Where(q => q.Value == li.Value).Count() != 1)
			{
				x.Add(li);
				ConfigSerializer.Serializer(x, "SystemTemplate");
				ConfigSerializer.Clear("SystemTemplate");
				File.SaveAllText(Path.EventSystemTemplatePath(li.Value), c);
			}
			else {
				return Content("Error");
			}
			return Content("添加成功");
		}
		#endregion

	}
}
