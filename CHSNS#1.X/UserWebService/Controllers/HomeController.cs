namespace ChAlumna.Controllers
{
	using Castle.MonoRail.Framework;
	[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
	[DefaultAction("Index")]
	public class HomeController : BaseController
	{
		//[Cache(HttpCacheability.Public, Duration = 360, VaryByParams = "id,name")]
		public void index() {
			//	ViewData.Add("userid", "asdasd");
		}
		public void Logout() {
			Identity identity = new Identity();
			identity.Logout();
			RedirectToAction("index");
		}
		public void Error() { 
		
		}
	}
}
