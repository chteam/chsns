namespace ChAlumna.components
{
	using System;
	using System.Data;
	using System.Collections.Generic;
	using ChAlumna.Controllers;
	using CHSNS;

	public class ProfileEditChild : BaseViewComponent
	{
		string _template = "basic";
		DataRowCollection _Source = null;
		
		private DataRowCollection Source {
			get { return _Source; }
			set { _Source = value; }
		}
		public string Template {
			get { return _template; }
			set { _template = value.ToLower(); }
		}
		public override void Initialize() {
			if (ComponentParams.Contains("template")) {
				Template = ComponentParams["template"].ToString();
			}
			Dictionary p = new Dictionary();
			p.Add("@userid", ChUser.Current.Userid);
			switch (Template) {
				case "school":
					Source = DataBaseExecutor.GetRows("MySchoolSelect", p);
					break;
				case "contact":
					Source = DataBaseExecutor.GetRows("MyContactSelect", p);
					break;
				case "personalinfo":
				case "personal":
					Template = "personalinfo";
					Source = DataBaseExecutor.GetRows("MyPersonalSelect", p);
					break;
				case "magicbox":
					Source = DataBaseExecutor.GetRows("MyMagicBoxSelect", p);
					break;
				case "upload":
					break;
				default://basic
					Source = DataBaseExecutor.GetRows("MyBasicSelect", p);
					break;
			}
			base.Initialize();
		}
		public override void Render() {
			if (Source != null && Source.Count != 0)
				Context.ContextVars.Add("Source", Source[0]);
			this.RenderView("ProfileEditChild", Template);
		}
	}
}
