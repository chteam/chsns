using System.Web.Mvc;
using CHSNS.Controllers;

namespace CHSNS.Web.Controllers {
    public partial class AdController : BaseController
    {
		public void Index() { }
        public virtual ActionResult Ad()
        {
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
