﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Single.Master"
 AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<div class="notes">
		恭喜您,注册成功,<%=Html.ActionLink("请登录",MVC.Account.LogOn()) %>
	</div>
		
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
