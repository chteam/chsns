namespace ChAlumna.Controllers.components
{
	using System;
	using System.Data;
	using Castle.MonoRail.Framework;

	public class OptionList : BaseViewComponent
	{
		object _selected;
		DataRowCollection _Source;
		string _id = "id";
		string _text = "name";
		public override void Initialize() {
			if (ComponentParams.Contains("selected")) {
				_selected = ComponentParams["selected"].ToString();
			}
			if (ComponentParams.Contains("id")) {
				_id = ComponentParams["id"].ToString();
			}
			if (ComponentParams.Contains("text")) {
				_text = ComponentParams["text"].ToString();
			}
			if (ComponentParams.Contains("Source")) {
				_Source = ComponentParams["Source"] as DataRowCollection;
			}
			
			base.Initialize();
		}
		public override void Render() {
			Context.ContextVars.Add("selected", _selected);
			Context.ContextVars.Add("Source", _Source);
			Context.ContextVars.Add("Text", _text);
			Context.ContextVars.Add("Id", _id);
			this.RenderView("System", "Option");
		}
	}
}
