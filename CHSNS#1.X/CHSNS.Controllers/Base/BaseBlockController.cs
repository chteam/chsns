using System;
using System.Collections;

using CHSNS;
using CHSNS.Config;
using CHSNS.Models;
using System.Web.Mvc;
namespace CHSNS.Controllers {
	//[Layout("basemaster")]

	//[Helper(typeof(ChHelper))]
	//[HandleError]
	abstract public class BaseBlockController : Controller, ICHSNSDB {
		public Boolean IsPost {
			get {
				return Request.Form.Count != 0;
			}
		}
		
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

		protected override void OnResultExecuted(ResultExecutedContext filterContext) {
			DataBaseExecutor.Dispose();
		}
	}
}
