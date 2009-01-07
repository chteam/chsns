using System.Web.Mvc;

namespace CHSNS.Controllers
{
	
//	[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
//	[DefaultAction("Index")]
	public class HomeController : BaseController
	{
		//[Cache(HttpCacheability.Public, Duration = 360, VaryByParams = "id,name")]
        public ActionResult Index() {
            //ViewData["viewlist"] = DBExt.View.ViewList(3, 3, 0, 6);
            Title = "首页";
            return View("Index");
        }
		public void Logout() {
			CHCookies.Clear();
			CHUser.Clear();
			RedirectToAction("index");
		}
		protected override void HandleUnknownAction(string actionName) {
			View(actionName).ExecuteResult(ControllerContext);
		}
	}
}
