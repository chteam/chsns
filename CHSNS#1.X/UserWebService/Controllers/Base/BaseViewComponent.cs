

namespace ChAlumna.Controllers
{
    using Castle.MonoRail.Framework;
	using ChAlumna.Models;
	using ChAlumna.Config;
	[Helper(typeof(ChHelper))]
	abstract public class BaseViewComponent : ViewComponent
	{
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
	}
}
