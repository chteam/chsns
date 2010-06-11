using System.Web.Mvc;
using CHSNS.Controllers;

namespace CHSNS.Web.Controllers {
	public class AdController : BaseController {
		public void Index() { }
		public ActionResult Ad() {
			//public override void Render() {
			//将值传输给View
			//ApplicationMenuViewBuilder amvb = new ApplicationMenuViewBuilder();
			//this.Context.ContextVars["myapp"] = amvb.ToString();
			//显示相应的View
			//this.RenderView("","ad");
			return View("ad");
		}
	}
}
