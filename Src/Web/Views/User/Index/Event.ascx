<%@ Control AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Event>>"
    Language="C#" %>

	<% foreach (Event e in ViewData.Model) { %>
	<li class="evt" id="evt_<%=e.Id %>">
	<a class="evt_del" href="<%=e.Id %>" style="width:26px">&nbsp;&nbsp;&nbsp;&nbsp;</a>
	<%Html.RenderPartial("EventTemplate/" + e.TemplateName, e);%>
</li>
		
	<%} %>

