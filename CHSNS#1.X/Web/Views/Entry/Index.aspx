<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<EntryIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
	<%
			var entry = Model.Entry;
			var version = Model.Version;
			var ext = Model.Ext;
	%>
	<div class="left">
		<h4><%=entry.Title%></h4>
		<div class="body">
			<p>
				<%=version.Description%></p>
		</div>
	</div>
	<div class="right">
		<ul>
			<li>
				<%=Html.ActionLink("历史版本", "Historylist", new { id = entry.ID })%>
				<span>(<%=entry.EditCount%>)</span></li>
			<%if (CH.Context.User.IsAdmin) { %>
			<li>
				<%=Html.ActionLink("编辑词条", "Edit", new { id = entry.ID })%>
			</li>
			<li><a href="#">新建词条</a></li>
			<%} %>
		</ul>
		<ul>
			<li><span>标签：</span><%=string.Join(",", ext.Tags.ToArray())%>
			</li>
		</ul>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
