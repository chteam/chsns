using System.Web.Mvc;
namespace CHSNS.Controllers {
	public class AdController : BaseController {
		public void index() { }
		public ActionResult ad() {
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
