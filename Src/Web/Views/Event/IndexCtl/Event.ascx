<%@ Control Language="C#" AutoEventWireup="true" 
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CHSNS.Models.Event>>" %>
<% foreach (var e in ViewData.Model) { %>
<li class="evt_icon " id="evt_<%=e.Id %>">
	<%Html.RenderPartial("EventTemplate/" + e.TemplateName, e);%>
</li>
<%} %> 
