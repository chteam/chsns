
using System.Configuration;
using CHSNS.Models;

namespace CHSNS.Operator {
	public class BaseOperator{//} : IOperator {
        public CHSNSDBDataContext DBExtInstance {
            get {
                var db = new CHSNSDBDataContext(
                    ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString
                    ){DeferredLoadingEnabled = false};
                return db;
            }
        }

		#region IOperator 成员
        //public BaseOperator(IDBManager id) {
        //    DBExt = id;
        //    //DataBaseExecutor = id.DataBaseExecutor;
        //}
        //public IDBManager DBExt { get; set; }
        //public HttpContextBase HttpContext
        //{
        //    get { return DBExt.Context.HttpContext; }
        //}

        //public SiteConfig Site {
        //    get {
        //        return DBExt.Context.Site;
        //    }
        //}
//		public DataBaseExecutor DataBaseExecutor { get; set; }
        //protected IUser CHUser { get { return DBExt.Context.User; } }
        //protected ICookies CHCookies { get { return DBExt.Context.Cookies; } }
		#endregion
	}
}
