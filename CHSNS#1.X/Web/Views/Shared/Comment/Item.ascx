<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Comment.Item" %>
<%
	foreach (ReplyPas dr in ViewData.Model) { %>
<li id="Item<%=dr.Reply.ID%>" class="useritem">
	<div class="comment">
		<div class="image">
			<a href="<%=this.Url.UserPage(dr.Sender.ID) %>">
				<%=Html.Image(Url.CH().Path.GetFace_Small(dr.Sender.ID), dr.Sender.Name)%>
			</a>
		</div>
		<div class="author">
		<%=Html.UserPageLink(dr.Sender.ID,dr.Sender.Name)%>
				
				<span class="time">
					<%=dr.Reply.AddTime.ToString("MM-dd HH:mm") %></span>
			<%if (dr.Sender.ID != CHUser.UserID) {%>
			<span class="reply">
<a href="javascript:void(0);" onclick="WillReply('<%=dr.Sender.Name%>','<%=dr.Sender.ID%>');">回复</a></span>
			<%}
		if (!dr.Reply.IsDel) {
			if (dr.Reply.UserID == CHUser.UserID||CHUser.IsAdmin) {
			%>
			<a href="<%=dr.Reply.ID%>" class="delete">删除</a>
			<%}
	 }%>
		</div>
		
			<p>
				<%if (!dr.Reply.IsDel) { %>
				<%=Html.EncodeBR(dr.Reply.Body)%>
				<%} else { %>
				已经删除
				<%} %>
			</p>
	</div>
</li>
<%} %>