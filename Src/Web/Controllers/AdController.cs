using System.Web.Mvc;
using CHSNS.Controllers;

namespace CHSNS.Web.Controllers {
	public class AdController : BaseController {
		public void Index() { }
		public ActionResult Ad() {
			//public override void Render() {
			//��ֵ�����View
			//ApplicationMenuViewBuilder amvb = new ApplicationMenuViewBuilder();
			//this.Context.ContextVars["myapp"] = amvb.ToString();
			//��ʾ��Ӧ��View
			//this.RenderView("","ad");
			return View("ad");
		}
	}
}
