namespace CHSNS.Controllers.Components
{
	public class TemplateOnly : BaseViewComponent
	{
		string _template = "";
		public override void Initialize() {
			if (ComponentParams.Contains("template"))
				_template = ComponentParams["template"].ToString();
			base.Initialize();
		}
		public override void Render() {
			this.RenderView("html", _template);
		}
	}
}
