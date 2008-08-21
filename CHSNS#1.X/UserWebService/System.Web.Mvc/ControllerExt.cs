using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHSNS {
	public static class ControllerExt {
		public static string QueryString(this Controller c,string QueryStringName) {
			if (string.IsNullOrEmpty(c.Request.QueryString[QueryStringName]))
				return string.Empty;
			else
				return c.Request.QueryString[QueryStringName].ToLower();
		}
		public static int QueryNum(this Controller c, string QueryStringName) {
			if (string.IsNullOrEmpty(c.QueryString(QueryStringName)))
				return 0;
			return Convert.ToInt32(c.QueryString(QueryStringName));
		}
		public static long QueryLong(this Controller c, string QueryStringName) {
			if (string.IsNullOrEmpty(c.QueryString(QueryStringName)))
				return 0;
			return Convert.ToInt64(c.QueryString(QueryStringName));
		}
	}
}
