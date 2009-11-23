using System;
using CHSNS;
using CHSNS.Config;

namespace Chsword {
	public class WebServices : System.Web.Services.WebService{
		#region ICHSNSDB 成员

		private CHSNS.Data.DBExt _dbext;
		public CHSNS.Data.DBExt DBExt {
			get {
				if (_dbext == null)
					_dbext = new CHSNS.Data.DBExt();
				return _dbext;
			}
			set {
				throw new NotImplementedException();
			}
		}
		public DataBaseExecutor DataBaseExecutor {
			get {
				return DBExt.DataBaseExecutor;
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}
