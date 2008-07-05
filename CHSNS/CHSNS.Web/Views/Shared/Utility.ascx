<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Utility.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Utility" %>
<%--#if($ChHelper.ChUser.isLogined)
<span class="My_Menu">
$url.link($ChHelper.ChUser.UserName, "%{area='',controller='event',action='index'}")
<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
$url.link("退出", "%{area='',controller='home',action='Logout'}")
</span>
#else--%>

<a href="/">首页</a>
<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>