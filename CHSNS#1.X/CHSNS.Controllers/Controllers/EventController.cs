/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 22:39
 * 
 * 
 */
using CHSNS.Filter;

namespace CHSNS.Controllers {
	//using CHSNS.Data;
	using System.Web.Mvc;
	using System.Transactions;

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
		public ActionResult SystemTemplate() {
			return View("Admin/SystemTemplate");
		}
		#endregion

	}
}
