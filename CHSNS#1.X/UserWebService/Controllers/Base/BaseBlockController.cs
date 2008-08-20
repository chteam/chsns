namespace ChAlumna.Controllers
{
	//[Layout("basemaster")]
	using System;
	using System.Collections;
	using Castle.MonoRail.Framework;
	using ChAlumna;
	using ChAlumna.Config;
	using ChAlumna.Models;
	using CHSNS;
	[Helper(typeof(ChHelper))]
	abstract public class BaseBlockController : SmartDispatcherController,ICHSNSDB
	{
		protected string QueryString(string QueryStringName) {
			if (string.IsNullOrEmpty(Params[QueryStringName]))
				return string.Empty;
			else
				return Params[QueryStringName].ToLower();
		}
		protected int QueryNum(string QueryStringName) {
			if (string.IsNullOrEmpty(QueryString(QueryStringName)))
				return 0;
			return Convert.ToInt32(QueryString(QueryStringName));
		}
		protected long QueryLong(string QueryStringName) {
			if (string.IsNullOrEmpty(QueryString(QueryStringName)))
				return 0;
			return Convert.ToInt64(QueryString(QueryStringName));
		}
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
		//protected MsSqlDB 
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
