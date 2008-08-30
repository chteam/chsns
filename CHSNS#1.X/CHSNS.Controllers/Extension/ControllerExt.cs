using System;
using System.Web.Mvc;

namespace CHSNS.Extension
{
	public static class ControllerExt {
		public static string QueryString(this Controller c,string QueryStringName)
		{
			return string.IsNullOrEmpty(c.Request.QueryString[QueryStringName]) ? string.Empty : c.Request.QueryString[QueryStringName].ToLower();
		}

		public static int QueryNum(this Controller c, string QueryStringName)
		{
			return string.IsNullOrEmpty(c.QueryString(QueryStringName)) ? 0 : Convert.ToInt32(c.QueryString(QueryStringName));
		}

		public static long QueryLong(this Controller c, string QueryStringName)
		{
			return string.IsNullOrEmpty(c.QueryString(QueryStringName)) ? 0 : Convert.ToInt64(c.QueryString(QueryStringName));
		}
	}
}