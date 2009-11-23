<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<ViewListPas>" %>
<div class="viewlist">
	<ul>
		<%
			ViewListPas vl = ViewData.Model;
			int row = 0;
			foreach (UserItemPas dr in vl.Rows) {
				if (row == vl.EveryRow) {
					row = 0;
		%>
	</ul>
	<ul>
		<%
			}
				row++;
		%>
		<li class="viewitem" style="text-align: center;">
			<div class="face-small face">
			<a href="<%=Url.UserPage(dr.Id) %>"
			style="background-image: url(<%=Path.GetFace(dr.Id,ThumbType.Small) %>);"/>
			</div>
			<span class="name">
				<%=Html.UserPageLink(dr.Id,dr.Name) %></span> </li>
		<%} %>
	</ul>
</div>
