/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 23:44
 * 2008 1 25
 * 
 */

namespace CHSNS.Controllers.Components
{
  //  using System.Data;
    
    /// <summary>
    /// Description of ViewList.
    /// </summary>
    public class ShowLevel : BaseViewComponent
    {
        string _id;
		byte _selected = 0;
		string _class = "select";
        public override void Initialize() {
            if (ComponentParams.Contains("id")) {
                _id = ComponentParams["id"].ToString();
            }
			if (ComponentParams.Contains("selected")) {
				byte.TryParse(ComponentParams["selected"].ToString(), out _selected);
			}
			if (ComponentParams.Contains("class")) {
				_class = ComponentParams["class"].ToString();
			}
            base.Initialize();
        }
        public override void Render() {
            Context.ContextVars.Add("id", _id);
			Context.ContextVars.Add("class", _class);
			Context.ContextVars.Add("selected", _selected);
            this.RenderView("", "ShowLevel");
        }
    }
}
