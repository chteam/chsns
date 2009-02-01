<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CommentPas>>" %>
<%
	if (ViewData.Model != null)
		foreach (CommentPas dr in ViewData.Model) { %>
<li id="Item<%=dr.Comment.ID%>" class="useritem">
	<div class="comment">
		<div class="face face-small">
			<a href="<%=Url.UserPage(dr.Sender.ID) %>" title="<%=dr.Sender.Name %>" style="background-image: url(<%=Path.GetFace(dr.Sender.ID,ThumbType.Small) %>);"></a>
		</div>
		<div class="author">
			<%=Html.UserPageLink(dr.Sender.ID,dr.Sender.Name)%>
			<span class="time">
				<%=dr.Comment.AddTime.ToString("yyyy-MM-dd HH:mm") %></span>
			<%if (dr.Sender.ID != CHUser.UserID) {%>
			<span class="reply"><a href="javascript:void(0);" onclick="WillReply('<%=dr.Sender.Name%>','<%=dr.Sender.ID%>');">
				回复</a></span>
			<%}
	 if (!dr.Comment.IsDel) {
		 if (dr.Comment.OwnerID == CHUser.UserID || CHUser.IsAdmin) {
			%>
			<a href="<%=dr.Comment.ID%>" class="delete">删除</a>
			<%}
	 }%>
		</div>
		<p>
			<%if (!dr.Comment.IsDel) { %>
			<%=Html.EncodeBR(dr.Comment.Body)%>
			<%}
	 else { %>
			已经删除
			<%} %>
		</p>
	</div>
</li>
<%} %>