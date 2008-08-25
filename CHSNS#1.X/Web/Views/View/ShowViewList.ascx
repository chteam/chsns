<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowViewList.ascx.cs"
	Inherits="CHSNS.Web.Views.View.ShowViewList" %>
<div class="userviewlist">
	<ul>
		<%
			ViewListPas vl = ViewData.Model;
			int row = 0;
			foreach (DataRow dr in vl.Rows) {
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
					<a href="/User.aspx?userid=<%=dr["userid"]%>&amp;">
						<%=Html.Image(Url.CH().Path.GetFace_Small(dr["userid"]), dr["name"].ToString())%>
					</a>
				</div>
			</div>
			<span class="userviewname"><a href="/User.aspx?userid=<%=dr["userid"]%>&amp;">
				<%=dr["name"]%></a></span> </li>
		<%} %>
	</ul>
</div>
