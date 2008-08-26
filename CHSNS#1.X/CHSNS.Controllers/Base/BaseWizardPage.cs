
using System.Web.Mvc;
using CHSNS.Config;
using CHSNS.Models;
namespace CHSNS.Controllers {

	//[Helper(typeof(ChHelper))]
	abstract public class BaseWizardPage : Controller {
		CHSNSDBContext _DB = null;
		protected CHSNSDBContext DB {
			get {
				if (_DB == null) {
					_DB = new CHSNSDBContext(
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
