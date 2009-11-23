using System.Web.Mvc;
namespace CHSNS.Controllers {
	public class AdController : BaseController {
		public void index() { }
		public ActionResult ad() {
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
