using System;
using System.Web.Mvc;

namespace CHSNS.Helper {
	public static class UrlHelperExt {
		#region Group
		public static string LinkGroupIndex(this UrlHelper Url, long id) {
			return Url.Action("Index", "Group", new { id }, null);
		}
		public static string LinkGroupManage(this UrlHelper Url, long id) {
			return Url.Action("Manage", "Group", new { id }, null);
		}
		#endregion

		public static String UserPage(this UrlHelper Url, long userid) {
			return Url.Action("Index", "User", new { userid });
		}
		public static String FriendPage(this UrlHelper Url, long userid) {
			return Url.Action("Index", "Friend", new { userid });
		}
	}
}