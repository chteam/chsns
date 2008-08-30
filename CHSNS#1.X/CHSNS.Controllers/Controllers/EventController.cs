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

	/// <summary>
	/// Description of EventController.
	/// </summary>
	[LoginedFilter]
	public class EventController : BaseController {
		public ActionResult Index() {
			return View(DBExt.Gather.EventGather());
		}

		#region 组件
		public ActionResult Show(long userid, byte type) {
			ViewData["userid"] = userid;
			ViewData["eventrows"] = DataBaseExecutor.GetRows("Event_List"
					, "@userid", userid,
			"@type", type,
			"@page", 1,
			"@everyPage", 10);
			return View();
		}

		#endregion
	}
}
