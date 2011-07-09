<%@ Control AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<EventLog>>"
    Language="C#" %>

	<% foreach (EventLog e in ViewData.Model) { %>
	<li class="evt" id="evt_<%=e.Id %>">
	<a class="evt_del" href="<%=e.Id %>" style="width:26px">&nbsp;&nbsp;&nbsp;&nbsp;</a>
	<%Html.RenderPartial("EventTemplate/" + e.TemplateName, e);%>
</li>
		
	<%} %>

