/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 23:44
 * 
 * 
 */

namespace ChAlumna.Controllers.components
{
    using Castle.MonoRail.Framework;
    using Castle.MonoRail.Framework.Helpers;
	/// <summary>
	/// Description of ViewList.
	/// </summary>
	public class Pager: BaseViewComponent
	{
		IPaginatedPage _rows;
		public override void Initialize()
		{
            if (ComponentParams.Contains("source")) {
                _rows = ComponentParams["source"] as IPaginatedPage;
            }
			base.Initialize();
		}
		public override void Render()
		{
            Context.ContextVars.Add("rows", _rows);
            this.RenderView("", "Pager");
		}
	}
}
