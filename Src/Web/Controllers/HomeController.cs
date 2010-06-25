using System.Web.Mvc;

namespace CHSNS.Controllers
{
	
//	[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
//	[DefaultAction("Index")]
    public partial class HomeController : BaseController
	{
		//[Cache(HttpCacheability.Public, Duration = 360, VaryByParams = "id,name")]
        public virtual ActionResult Index()
        {
            //ViewData["viewlist"] = DBExt.View.ViewList(3, 3, 0, 6);
            Title = "首页";
            return RedirectToAction("index", "Entry", new { title = "index" });
        }
		public void Logout() {
			CHContext.Cookies.Clear();
			CHUser.Clear();
			RedirectToAction("index");
		}
		protected override void HandleUnknownAction(string actionName) {
			View(actionName).ExecuteResult(ControllerContext);
		}
	}
}
