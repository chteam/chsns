using CHSNS.Controllers;
namespace CHSNS.Controllers.Components {
	public class ad : BaseViewComponent {
		public override void Render() {
			//��ֵ�����View
			//ApplicationMenuViewBuilder amvb = new ApplicationMenuViewBuilder();
			//this.Context.ContextVars["myapp"] = amvb.ToString();
			//��ʾ��Ӧ��View
			this.RenderView("","ad");

		}
	}
}
