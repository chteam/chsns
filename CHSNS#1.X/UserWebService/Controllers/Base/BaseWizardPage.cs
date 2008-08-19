namespace ChAlumna.Controllers {
	using System.Collections;
	using Castle.MonoRail.Framework;
	using ChAlumna.Config;
	using ChAlumna.Models;
	[Helper(typeof(ChHelper))]
	abstract public class BaseWizardPage : WizardStepPage {
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
		protected IDictionary ViewData {
			get {
				return this.PropertyBag;
			}
			set {
				this.PropertyBag = value;
			}
		}
		protected IDictionary TempData {
			get {
				return this.Flash;
			}
		}
	}
}
