﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="untityright link">
    <%=Html.RouteLink("首页", "index",null)%>
    <%if (Page.User.Identity.IsAuthenticated)
      {%>
    <%=Html.ActionLink("事件","Index","Event") %>
    <%=Page.User.Identity == null?
        Html.ActionLink("好友", "Index", "Friend"):
        Html.ActionLink("好友", "Request", "Friend")%>
    <a href="javascript:void(0);" class="menu_title">您好！<%=Page.User.Identity.Name %></a>
    
    <%=Html.ActionLink("我的页面", "Index", "User")%>
    <%=Html.UserEditLink("BaseInfo","设置")%>
    <%=Html.ActionLink("密码修改", "ChangePassword", "Account")%>
    <%=Html.ActionLink("站内信", "Inbox", "Message")%>
    <%=Html.ActionLink("注销",MVC.Account.LogOff()) %>
    <%} %>
    <a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
</div>
