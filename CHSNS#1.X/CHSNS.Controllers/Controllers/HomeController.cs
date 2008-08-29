using System.Web.Mvc;

namespace CHSNS.Controllers
{
	
//	[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
//	[DefaultAction("Index")]
	public class HomeController : BaseController
	{
		//[Cache(HttpCacheability.Public, Duration = 360, VaryByParams = "id,name")]
		public ActionResult Index() {
			return View("Index");
		}
		public void Logout() {
			ChCookies.Clear();
			CHUser.Clear();
			RedirectToAction("index");
		}
		protected override void HandleUnknownAction(string actionName) {
			View(actionName).ExecuteResult(ControllerContext);
		}
	}
}
