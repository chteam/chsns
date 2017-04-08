

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CHSNS.Helper {
    using System;
    using Microsoft.AspNetCore.Mvc;
    
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class HtmlHelperExt {

        #region note
        public static IHtmlContent NoteEdit(this HtmlHelper Html, long id, string text) {
            return Html.ActionLink(text, "Edit", "Note", new { id }, null);
        }

        public static IHtmlContent NoteList(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Note", new { userid }, null);
        }
        public static IHtmlContent NoteDetails(this HtmlHelper Html, string title, long id, DateTime dt)
        {
            return Html.ActionLink(title, "Details", "Note", new { id, y = dt.Year, m = dt.Month, d = dt.Day }, null)
                ;
        }
        #endregion

        #region message
        public static IHtmlContent WriteMessage(this HtmlHelper Html, string text, long toid, string toname)
        {
            
            return Html.ActionLink(text, "Write", "Message", new { toid, toname = toname }, null);
        }
        public static IHtmlContent WriteMessage(this HtmlHelper Html, long toid, string toname)
        {
            return Html.WriteMessage("发站内信", toid, toname);
        }

        public static IHtmlContent MessageDetails(this HtmlHelper Html, string title, long id)
        {
            return Html.ActionLink(title, "Details", "Message", new { id }, null);
        }
        #endregion

        #region comment
        public static IHtmlContent ReplyList(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Reply", "Comment", new { userid }, null);
        }
        #endregion

        public static IHtmlContent UserPageLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "User", new { userid }, null);
        }
        public static IHtmlContent FriendLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Friend", new { userid }, null);
        }
        public static IHtmlContent FriendLink(this HtmlHelper Html, long userid)
        {
            return Html.FriendLink(userid, "好友");
        }
        public static IHtmlContent BlogLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Blog", new { userid }, null);
        }
        public static IHtmlContent BlogLink(this HtmlHelper Html, long userid)
        {
            return Html.BlogLink(userid, "博客");
        }
        public static IHtmlContent AlbumLink(this HtmlHelper Html, long userid, string text)
        {
            return Html.ActionLink(text, "Index", "Album", new { userid });
        }
        public static IHtmlContent AlbumLink(this HtmlHelper Html, long userid)
        {
            return Html.AlbumLink(userid, "相册");
        }

        public static IHtmlContent UserEditLink(this HtmlHelper html, string mode, string text) {
            return html.ActionLink(text, mode, "User");
        } 

        public static string EncodeBR(this HtmlHelper Html, string text) {
            return Html.Encode(text).Replace("\n", "<br/>");
        }
    }
}
