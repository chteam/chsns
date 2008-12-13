<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="ApplicationManagement.aspx.cs" Inherits="CHSNS.Web.Views.Admin.ApplicationManagement" %>

<%@ Import Namespace="CHSNS.Helepr"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>

</h1>
<%
	Html.Grid<CHSNS.Config.ApplicationItem>(
		"Model", 
		new Hash(empty => "There are no people", style => "width: 100%"),
		column => {
			column.For(p => p.ID, "ID Number");
			column.For(p => p.FullName);
			column.For("Custom Column").Do(p => { %>
				<td>A custom column...</td>	
			<% });
		}
	);
%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
