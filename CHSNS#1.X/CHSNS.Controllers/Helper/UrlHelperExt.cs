using System;
using System.Web.Mvc;

namespace CHSNS.Helper {
	public static class UrlHelperExt {
		public static String UserPage(this UrlHelper Url, long userid) {
			return Url.Action("Index", "User", new { userid });
		}
		public static String FriendPage(this UrlHelper Url, long userid) {
			return Url.Action("Index", "Friend", new { userid });
		}
	}
}