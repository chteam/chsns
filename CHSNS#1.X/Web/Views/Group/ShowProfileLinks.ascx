<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl<System.Data.DataRowCollection>" %>
<%foreach (DataRow dr in ViewData.Model) {%>
<a href="/Group.aspx?id=<%=dr["groupid"]%>&amp;">
	<%=dr["groupname"]%></a>
<%} %> 