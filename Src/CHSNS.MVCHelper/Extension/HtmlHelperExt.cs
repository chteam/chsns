

namespace CHSNS.Helper {
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    //using Microsoft.Web.Mvc;
    using System.Web;

    public static class HtmlHelperExt {

        #region note
        public static MvcHtmlString NoteEdit(this HtmlHelper Html, long id, string text) {
            return Html.ActionLink(text, "Edit", "Note", new { id }, null);
        }

        public static MvcHtmlString NoteList(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Note", new { userid }, null);
        }
        public static MvcHtmlString NoteDetails(this HtmlHelper Html, string title, long id, DateTime dt)
        {
            return Html.ActionLink(title, "Details", "Note", new { id, y = dt.Year, m = dt.Month, d = dt.Day }, null)
                ;
        }
        #endregion

        #region message
        public static MvcHtmlString WriteMessage(this HtmlHelper Html, string text, long toid, string toname)
        {
            return Html.ActionLink(text, "Write", "Message", new { toid, toname = HttpUtility.UrlEncode(toname) }, null);
        }
        public static MvcHtmlString WriteMessage(this HtmlHelper Html, long toid, string toname)
        {
            return Html.WriteMessage("发站内信", toid, toname);
        }

        public static MvcHtmlString MessageDetails(this HtmlHelper Html, string title, long id)
        {
            return Html.ActionLink(title, "Details", "Message", new { id }, null);
        }
        #endregion

        #region comment
        public static MvcHtmlString ReplyList(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Reply", "Comment", new { userid }, null);
        }
        #endregion

        public static MvcHtmlString UserPageLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "User", new { userid }, null);
        }
        public static MvcHtmlString FriendLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Friend", new { userid }, null);
        }
        public static MvcHtmlString FriendLink(this HtmlHelper Html, long userid)
        {
            return Html.FriendLink(userid, "好友");
        }
        public static MvcHtmlString BlogLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Blog", new { userid }, null);
        }
        public static MvcHtmlString BlogLink(this HtmlHelper Html, long userid)
        {
            return Html.BlogLink(userid, "博客");
        }
        public static MvcHtmlString AlbumLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Album", new { userid }, null);
        }
        public static MvcHtmlString AlbumLink(this HtmlHelper Html, long userid)
        {
            return Html.AlbumLink(userid, "相册");
        }

        public static MvcHtmlString UserEditLink(this HtmlHelper html, string mode, string text) {
            return html.ActionLink(text, mode, "User");
        } 

        public static string EncodeBR(this HtmlHelper Html, string text) {
            return Html.Encode(text).Replace("\n", "<br/>");
        }
    }
}
