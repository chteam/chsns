
using System.Web.Mvc;
using CHSNS.Config;
using CHSNS.Models;
namespace CHSNS.Controllers {

	//[Helper(typeof(ChHelper))]
	abstract public class BaseWizardPage : Controller {
		ChAlumnaDBDataContext _DB = null;
		protected ChAlumnaDBDataContext DB {
			get {
				if (_DB == null) {
					_DB = new ChAlumnaDBDataContext(
				  SiteConfig.SiteConnectionString
					);
				}
				return _DB;
			}
		}
		//protected IDictionary ViewData {
		//    get {
		//        return this.PropertyBag;
		//    }
		//    set {
		//        this.PropertyBag = value;
		//    }
		//}
		//protected IDictionary TempData {
		//    get {
		//        return this.Flash;
		//    }
		//}
	}
}
