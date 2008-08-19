namespace ChAlumna.Controllers.components {
	public class ad : BaseViewComponent {
		public override void Render() {
			//将值传输给View
			//ApplicationMenuViewBuilder amvb = new ApplicationMenuViewBuilder();
			//this.Context.ContextVars["myapp"] = amvb.ToString();
			//显示相应的View
			this.RenderView("","ad");
		}
	}
}
