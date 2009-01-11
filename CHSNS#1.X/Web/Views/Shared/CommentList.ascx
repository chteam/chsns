<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
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