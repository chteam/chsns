<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<style type="text/css">
.edit{float:right}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
	Html.RenderPartial("Toc");
	var list = (ViewData["list"] as IEnumerable<UserCountPas>).ToNotNull();
	 %>
	<form action="" method="post" class="ch_content formset">
	<%if (list.Where(c => c.Count == (int)GroupUserStatus.Lock).Count() > 0) { %>
	<h3>
		审核</h3>
	<ol>
		<%foreach (UserCountPas u in list.Where(c => c.Count == (int)GroupUserStatus.Lock)) { %>
		<li id="user<%=u.ID %>">
		<span class="edit">群主 </span>
		<%=Html.UserPageLink(u.ID,u.Name) %>
		</li>
		<%} %>
	</ol>
	<%} %>
	<h3>
		管理员</h3>
	<ol>
		<%foreach (UserCountPas u in list.Where(c => c.Count == (int)GroupUserStatus.Ceater)) { %>
<li id="user<%=u.ID %>">
		<span class="edit">群主 </span>
		<%=Html.UserPageLink(u.ID,u.Name) %>
		</li>
		<%}foreach (UserCountPas u in list.Where(c => c.Count == (int)GroupUserStatus.Admin)) { %>
<li id="user<%=u.ID %>">
		<span class="edit">管理员 设为普通用户</span>
		<%=Html.UserPageLink(u.ID,u.Name) %>
		</li>
		<%} %>
	</ol>

	<h3>
		群成员</h3>
	<ol>
		<%foreach (UserCountPas u in list.Where(c => c.Count == (int)GroupUserStatus.Common)) { %>
		<li id="user<%=u.ID %>">
		<span class="edit">删除 升为管理员 </span>
		<%=Html.UserPageLink(u.ID,u.Name) %></li>
		<%} %>
	</ol>
	</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
