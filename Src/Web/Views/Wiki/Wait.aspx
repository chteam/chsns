<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
您访问的页面不存在
	<div class="note">当前页面不存在:
	<%=Html.ActionLink("【创建" + ViewContext.RouteData.Values["title"] + "】",
	    "Edit", "Entry", new { url = ViewContext.RouteData.Values["title"] },null)%>
	</div>
</asp:Content> 
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
