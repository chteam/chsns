<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event.ascx.cs" Inherits="CHSNS.Web.Views.User.Event" %>

	<% foreach (CHSNS.Models.Event e in ViewData.Model) { %>
	<li class="evt" id="evt_<%=e.ID %>">
	<a class="evt_del" href="<%=e.ID %>" style="width:26px">&nbsp;&nbsp;&nbsp;&nbsp;</a>
	<%Html.RenderPartial("EventTemplate/" + e.TemplateName, e);%>
</li>
		
	<%} %>

