﻿
using System.Web;

namespace CHSNS.Service {
	public class BaseService : IService {

		#region IService 成员
		public BaseService(IDBManager id) {
			DBExt = id;
			DataBaseExecutor = id.DataBaseExecutor;
		}
		public IDBManager DBExt { get; set; }
        public HttpContextBase HttpContext
        {
            get { return DBExt.Context.HttpContext; }
        }
		public DataBaseExecutor DataBaseExecutor { get; set; }
        protected IUser CHUser { get { return DBExt.Context.User; } }
        protected ICookies CHCookies { get { return DBExt.Context.Cookies; } }
		#endregion
	}
}
