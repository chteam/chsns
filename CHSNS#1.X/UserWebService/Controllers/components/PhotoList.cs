namespace ChAlumna.Controllers.components
{
	using System;
	using System.Data;
	public class PhotoList : BaseViewComponent
	{
		//DataRowCollection _rows;
		string _template = "PhotoItem";
		int _nowpage = 1;
		int _everypage = 16;
		long _albumid;
		long _ownerid;
		public override void Initialize() {
		//    if (ComponentParams.Contains("source"))
		//        _rows = ComponentParams["source"] as DataRowCollection;
			if (ComponentParams.Contains("template"))
				_template = ComponentParams["template"].ToString();
			if (ComponentParams.Contains("nowpage"))
				int.TryParse(ComponentParams["nowpage"].ToString(), out _nowpage);
			if (ComponentParams.Contains("everypage"))
				int.TryParse(ComponentParams["everypage"].ToString(), out _everypage);
			if (ComponentParams.Contains("albumid"))
				long.TryParse(ComponentParams["albumid"].ToString(), out _albumid);
			if (ComponentParams.Contains("ownerid"))
				long.TryParse(ComponentParams["ownerid"].ToString(), out _ownerid);

			base.Initialize();

		}
		public override void Render() {
			Photos p = new Photos();

			Context.ContextVars["Rows"] =
				p.PhotosRows(_albumid, _ownerid, _nowpage, _everypage);
			Context.ContextVars["Ownerid"] = _ownerid;
			this.RenderView("PhotoList", _template);
		}
	}
}
