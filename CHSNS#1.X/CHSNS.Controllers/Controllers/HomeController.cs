using System.Web.Mvc;
using System;
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
		public ActionResult About() {
			return View();
		}
		public void Logout() {
			Identity identity = new Identity();
			identity.Logout();
			RedirectToAction("index");
		}
	}
}
