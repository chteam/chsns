using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CHSNS.Helper {
	public static class UrlHelperExt {
		#region Group
		public static string LinkGroupIndex(this UrlHelper url, long id) {
			return url.Action("Index", "Group", new { id }, null);
		}
		public static string LinkGroupManage(this UrlHelper url, long id) {
			return url.Action("Manage", "Group", new { id }, null);
		}
		public static string GroupPost(this UrlHelper url, long id, DateTime dt) {
			return url.Action("Details", "Group"
				, new { id, y = dt.Year, m = dt.Month, d = dt.Day });
		}
		#endregion

		public static String UserPage(this UrlHelper url, long userid) {
			return url.Action("Index", "User", new { userid });
		}
		public static String FriendPage(this UrlHelper url, long userid) {
			return url.Action("Index", "Friend", new { userid });
		}
	}
}