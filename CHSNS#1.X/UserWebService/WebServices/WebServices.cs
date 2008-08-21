using System;
using CHSNS;
using CHSNS.Config;

namespace Chsword {
	public class WebServices : System.Web.Services.WebService,ICHSNSDB{
		#region ICHSNSDB 成员

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
