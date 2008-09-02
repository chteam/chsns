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
				<div>
					<a href="/User.aspx?userid=<%=dr.UserID%>&amp;">
						<%=Html.Image(Url.CH().Path.GetFace_Small(dr.UserID), dr.Name)%>
					</a>
				</div>
			</div>
			<span class="userviewname"><a href="/User.aspx?userid=<%=dr.UserID%>&amp;">
				<%=dr.Name%></a></span> </li>
		<%} %>
	</ul>
</div>
