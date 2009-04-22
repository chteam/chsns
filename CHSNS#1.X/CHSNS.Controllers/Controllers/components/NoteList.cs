/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 23:44
 * 
 * 
 */


namespace CHSNS.Controllers.Components
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using Chsword;
	
	/// <summary>
	/// Description of ViewList.
	/// </summary>
	public class NoteList : BaseViewComponent
	{
		DataRowCollection _rows;
		string _template = "full";
		public override void Initialize()
		{
			if (ComponentParams.Contains("source"))
				_rows = ComponentParams["source"] as DataRowCollection;
			if (ComponentParams.Contains("template"))
				_template = ComponentParams["template"].ToString();

			base.Initialize();
		}
		public override void Render()
		{
			this.Context.ContextVars["rows"] = _rows;
			this.RenderView("notelist", _template);
		}

	}
}
