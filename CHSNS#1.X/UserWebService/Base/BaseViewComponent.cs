

namespace ChAlumna.Controllers
{
    using Castle.MonoRail.Framework;
	using ChAlumna.Models;
	using ChAlumna.Config;
	using CHSNS;
	using System;
	[Helper(typeof(ChHelper))]
	abstract public class BaseViewComponent : ViewComponent, ICHSNSDB
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
		#region ICHSNSDB ≥…‘±

		public CHSNS.Data.DBExt DBExt {
			get {
				return new CHSNS.Data.DBExt(this);
			}
			set {
				throw new NotImplementedException();
			}
		}
		DataBaseExecutor _DataBaseExecutor = null;
		public DataBaseExecutor DataBaseExecutor {
			get {
				if (_DataBaseExecutor == null) {
					_DataBaseExecutor = new DataBaseExecutor(
						new SqlDataOpener(
						SiteConfig.SiteConnectionString)
						);
				}
				return _DataBaseExecutor;
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}
