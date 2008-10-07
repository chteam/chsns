<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentList.ascx.cs" Inherits="CHSNS.Web.Views.Note.CommentList" %>
<ul id="ReplyItems" class="userlist">
	<%
		Html.RenderPartial("Comment/Item", ViewData["commentlist"]);
	%>
</ul>
<div id="PageDown" class="page">
</div>
<%=Html.Hidden("PageCount")%>
<%=Html.Hidden("NowPage") %>
<%=Html.Hidden("EveryPage","100") %>