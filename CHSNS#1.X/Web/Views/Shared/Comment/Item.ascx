<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Comment.Item" %>
<%
	foreach (ReplyPas dr in ViewData.Model) { %>
<li class="odd" id="reply<%=dr.Reply.ID%>">
	<div class="comment">
		<div class="picture">
		
			<a href="<%=Url.UserPage(dr.Sender.ID) %>">
				<%=Html.Image(Url.CH().Path.GetFace_Small(dr.Sender.ID), dr.Sender.Name)%>
			</a>
		</div>
		<div class="author">
		<%=Html.UserPageLink(dr.Sender.ID,dr.Sender.Name)%>
				
				<span class="time">
					<%=dr.Reply.AddTime.ToString("MM-dd HH:mm") %></span>
			<%if (dr.Sender.ID != CHUser.UserID) {%>
			<span class="reply">
<a href="#userTalk" onclick="onReplyClick('<%=dr.Sender.Name%>','<%=dr.Sender.ID%>'); return false;">回复</a></span>
			<%}
		if (!dr.Reply.IsDel) {
			if (dr.Sender.ID == CHUser.UserID ||
			 dr.Reply.UserID == CHUser.UserID) {
			%>
			<span class="remove">
			<a href="#" onclick="onDeleteReply(<%=dr.Reply.ID%>,<%=dr.Sender.ID%>);return false;">
				删除</a> </span>
			<%}
	 }%>
			<%if (dr.Sender.ID != CHUser.UserID &&
		  dr.Reply.UserID == CHUser.UserID
	&& !dr.Reply.IsSee
		) {
		 if (dr.Sender.ID != CHUser.UserID) {
			%>
			<span class="pipe">|</span>
			<%} %>
			<span id="comment_see_<%=dr.Reply.ID%>" class="setsee"><a href="javascript:onSeeReply(<%=dr.Reply.ID%>);">
				置为已读</a></span>
			<%} %>
		</div>
		<div class="content">
			<p>
				<%if (!dr.Reply.IsDel) { %>
				<%=dr.Reply.Body%>
				<%} else { %>
				已经删除
				<%} %>
			</p>
		</div>
	</div>
</li>
<%} %>