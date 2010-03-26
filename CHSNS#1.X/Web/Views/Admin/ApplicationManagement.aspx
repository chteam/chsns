﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="ApplicationManagement.aspx.cs" Inherits="CHSNS.Web.Views.Admin.ApplicationManagement" %>

<%@ Import Namespace="CHSNS.Helepr"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>

</h1>
<%
	Html.Grid<CHSNS.Config.ApplicationItem>(
		"Model",
		new Hash(),
		c =>
			{
				c.For(p => p.ID, "ID");
				c.For(p => p.FullName, "全名");
				c.For(p => p.IsTrue ? "正常" : "锁定", "状态");
				c.For("操作").Do(p =>
				               	{%>
				<td>修改 删除</td>	
			<%
				               	});
			});
%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>