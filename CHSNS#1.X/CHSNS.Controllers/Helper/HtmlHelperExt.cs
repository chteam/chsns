using System.Web.Mvc;

namespace CHSNS.Helper {
	public static class HtmlHelperExt {
		public static string UserPageLink(this HtmlHelper Html, long userid, string text) {
			return Html.ActionLink(text, "Index", "User", new { userid }, null);
		}
		public static string FriendLink(this HtmlHelper Html, long userid, string text) {
			return Html.ActionLink(text, "Index", "Friend", new { userid }, null);
		}
		public static string FriendLink(this HtmlHelper Html, long userid) {
			return Html.FriendLink(userid, "好友");
		}
		public static string BlogLink(this HtmlHelper Html, long userid, string text) {
			return Html.ActionLink(text, "Index", "Blog", new { userid }, null);
		}
		public static string BlogLink(this HtmlHelper Html, long userid) {
			return Html.BlogLink(userid, "博客");
		}
		public static string AlbumLink(this HtmlHelper Html, long userid, string text) {
			return Html.ActionLink(text, "Index", "Album", new { userid }, null);
		}
		public static string AlbumLink(this HtmlHelper Html, long userid) {
			return Html.AlbumLink(userid, "相册");
		}

		public static string UserEditLink(this HtmlHelper Html, string mode, string text) {
			return Html.ActionLink(text, "Edit", "User", new { mode }, null);
		}
	}
}
