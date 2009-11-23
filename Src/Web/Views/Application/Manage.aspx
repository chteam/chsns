<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master"
 AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
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
				<td>修改 <%=Html.ActionLink("删除", "Delete", "Application", new { id=p.ID},null)%></td>	
			<%
				               	});
			});
%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
