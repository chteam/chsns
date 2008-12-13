using CHSNS.Filter;
using System.Web.Mvc;

namespace CHSNS.Controllers {
	[AdminFilter]
	public class AdminController : BaseController {
		public ActionResult Index() {
			Title = "CHSNS#管理平台首页";
			return View();
		}

		public ActionResult ApplicationManagement() {
			Title = "应用程序管理";
			
			return View();
		}

		public ActionResult About() {
			return View();
		}
	}
}
