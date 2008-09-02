using System;
using CHSNS;
using CHSNS.Config;
using CHSNS.Models;
using System.Web.Mvc;
namespace CHSNS.Controllers {
	//[Layout("basemaster")]

	//[Helper(typeof(ChHelper))]
	//[HandleError]
	abstract public class BaseBlockController : Controller {
		public Boolean IsPost {
			get {
				return Request.Form.Count != 0;
			}
		}
		
		CHSNSDBDataContext _DB;
		protected CHSNSDBDataContext DB {
			get {
				if (_DB == null) {
					_DB = DBExt.DB;
				}
				return _DB;
			}
		}

		#region ICHSNSDB ≥…‘±

		private Data.DBExt _dbext;
		protected Data.DBExt DBExt {
			get {
				if(_dbext==null)
					_dbext = new Data.DBExt();
				return _dbext;
			}
			set {
				throw new NotImplementedException();
			}
		}
		DataBaseExecutor _DataBaseExecutor;
		protected DataBaseExecutor DataBaseExecutor {
			get {
				if (_DataBaseExecutor == null) {
					_DataBaseExecutor = DBExt.DataBaseExecutor;
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
