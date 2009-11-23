/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 23:44
 * 
 * 
 */

namespace CHSNS.Controllers.Components
{
    using System.Data;
    
	/// <summary>
	/// Description of ViewList.
	/// </summary>
	public class AlbumItem: BaseViewComponent
	{
		DataRowCollection _rows;
        bool _isedit = false;
		public override void Initialize()
		{
            if (ComponentParams.Contains("source")) {
                _rows = ComponentParams["source"] as DataRowCollection;
            }
            if (ComponentParams.Contains("isedit")) {
                _isedit = bool.Parse(ComponentParams["isedit"].ToString());
            }
			base.Initialize();
		}
		public override void Render()
		{
            Context.ContextVars.Add("rows", _rows);
            Context.ContextVars.Add("isedit", _isedit);
			this.RenderView("","AlbumItem");
		}
	}
}
