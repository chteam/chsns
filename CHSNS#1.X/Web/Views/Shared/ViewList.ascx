<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewList.ascx.cs" Inherits="CHSNS.Web.Views.Shared.ViewList" %>
<div class="userviewlist">
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
		<li class="userviewinfo" style="text-align: center;">
			<div class="userviewicon">
			<a href="<%=Url.UserPage(dr.ID) %>"
			style="background-image: url(<%=Path.GetFace(dr.ID,ImgSizeType.Small) %>);"/>
			</div>
			<span class="userviewname">
				<%=Html.UserPageLink(dr.ID,dr.Name) %></span> </li>
		<%} %>
	</ul>
</div>
