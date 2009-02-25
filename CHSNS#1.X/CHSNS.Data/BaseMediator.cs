﻿namespace CHSNS.Data {
	public class BaseMediator : IMediator {

		#region IMediator 成员
		public BaseMediator(IDBManager id) {
			DBExt = id;
			DataBaseExecutor = id.DataBaseExecutor;
		}
		public IDBManager DBExt { get; set; }

		public DataBaseExecutor DataBaseExecutor { get; set; }
        protected IUser CHUser { get { return DBExt.Context.User; } }
        protected ICookies CHCookies { get { return DBExt.Context.Cookies; } }
		#endregion
	}
}
