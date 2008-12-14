using System.Collections.Generic;
using CHSNS.Config;
using CHSNS.Filter;
using System.Web.Mvc;

namespace CHSNS.Controllers {
	[AdminFilter]
	public class AdminController : BaseController {
		public ActionResult Index() {
			Title = "CHSNS#管理平台首页";
			return View();
		}
		#region 应用程序

		public ActionResult ApplicationManagement(int? p)
		{
			InitPage(ref p);
			Title = "应用程序管理";
			var ais = ConfigSerializer.Load<SystemApplicationConfig>("SystemApplication");
			var li = new PagedList<ApplicationItem>(ais.Items, p.Value, 10);
			return View(li);
		}
		#endregion

		public ActionResult About() {
			return View();
		}
	}
}
