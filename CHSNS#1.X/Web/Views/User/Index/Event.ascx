<%@ Control AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<IEvent>>"
    Language="C#" %>

	<% foreach (IEvent e in ViewData.Model) { %>
	<li class="evt" id="evt_<%=e.ID %>">
	<a class="evt_del" href="<%=e.ID %>" style="width:26px">&nbsp;&nbsp;&nbsp;&nbsp;</a>
	<%Html.RenderPartial("EventTemplate/" + e.TemplateName, e);%>
</li>
		
	<%} %>

