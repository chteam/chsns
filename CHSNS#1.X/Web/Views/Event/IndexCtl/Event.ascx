<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CHSNS.Models.Event>>" %>
<% foreach (IEvent e in ViewData.Model) { %>
<li class="evt_icon " id="evt_<%=e.ID %>">
	<%Html.RenderPartial("EventTemplate/" + e.TemplateName, e);%>
</li>
<%} %> 
