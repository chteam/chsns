using System;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using System.Web;
namespace CHSNS.Helper {
	public static class HtmlHelperExt {
		#region note
		public static string NoteEdit(this HtmlHelper Html, long id, string text) {
			return Html.ActionLink(text, "Edit", "Note", new { id }, null);
		}

		public static string NoteList(this HtmlHelper Html, long userid, string text) {
			return Html.ActionLink(text, "Index", "Note", new { userid }, null);
		}
		public static string NoteDetails(this HtmlHelper Html, string title, long id, DateTime dt) {
			return Html.ActionLink(title, "Details", "Note", new { id, y = dt.Year, m = dt.Month, d = dt.Day }, null);
		}
		#endregion
		#region message
		public static string WriteMessage(this HtmlHelper Html, string text, long toid, string toname) {
			return Html.ActionLink(text, "Write", "Message", new { toid, toname = HttpUtility.UrlEncode(toname) }, null);
		}
		public static string WriteMessage(this HtmlHelper Html, long toid, string toname) {
			return Html.WriteMessage("发站内信", toid, toname);
		}

		public static string MessageDetails(this HtmlHelper Html, string title, long id) {
			return Html.ActionLink(title, "Details", "Message", new { id }, null);
		}
		#endregion
		#region comment
		public static string ReplyList(this HtmlHelper Html, long userid, string text) {
			return Html.ActionLink(text, "Reply", "Comment", new { userid }, null);
		}
		#endregion
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

		public static string EncodeBR(this HtmlHelper Html, string text) {
			return Html.Encode(text).Replace("\n", "<br/>");
		}
		public static string ImageInStyle(this HtmlHelper Html, string fn) {
			return Html.Image(string.Format("{0}Style/{1}/images/{2}", CHSite.BaseConfig.Path
					, CHSite.BaseConfig.Style, fn));
		}
	}
}
