

using CHSNS.Models;
using CHSNS.Config;
using CHSNS;
using System;
using System.Web.Mvc;
//[Helper(typeof(ChHelper))]
namespace CHSNS.Controllers {

	abstract public class BaseViewComponent : Controller, ICHSNSDB {
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
		#region ICHSNSDB ��Ա

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