<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Error.aspx.cs" Inherits="CHSNS.Web.Views.Shared.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		对不起，无法访问该页.
	</h2>
	<% if (!ViewContext.HttpContext.IsCustomErrorEnabled) { %>
	<div style="overflow: auto;">
		<%
			Stack<Exception> exceptions = new Stack<Exception>();
			for (Exception ex = ViewData.Model.Exception; ex != null; ex = ex.InnerException) {
				exceptions.Push(ex);
			}
		%>
		
		<%
			foreach (Exception ex in exceptions) {
		%>
		<div class="notes">
			<b>原因为:
				<%//= Html.Encode(ex.GetType().FullName)%></b>
			<%= Html.Encode(ex.Message)%>
		</div>
		<%--<div>
			<pre style="font-size: medium;"><%= Html.Encode(ex.StackTrace)%></pre>
		</div>--%>
		<%
			}  
		%>
	</div>
	<% } %>
</asp:Content>
