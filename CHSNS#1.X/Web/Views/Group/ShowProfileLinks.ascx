<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowProfileLinks.ascx.cs"
	Inherits="CHSNS.Web.Views.Group.ShowProfileLinks" %>
<%foreach (DataRow dr in ViewData.Model) {%>
<a href="/Group.aspx?id=<%=dr["groupid"]%>&amp;">
	<%=dr["groupname"]%></a>
<%} %>