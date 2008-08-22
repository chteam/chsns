<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Utility.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Utility" %>

<%if(CHUser.IsLogin){%>
<span class="My_Menu">
<%=Html.ActionLink("首页","Index","Home") %>
<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
<%=Html.ActionLink("注销","Logout","Home") %>
</span>
<%}else{ %>

<a href="/">首页</a>
<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
<%} %>