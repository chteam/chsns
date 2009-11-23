<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowList.ascx.cs" Inherits="CHSNS.Web.Views.Comment.ShowList" %>
<% 
	CommentListPas cl = ViewData.Model;
	if (cl.Count > cl.EveryPage) {
%>
<div class="page" id="PageUp">
</div>
<%} %>
<div id="Comment">
	<ol id="talk">
		<%foreach (DataRow dr in cl.Rows) { %>
		<li class="odd" id="reply<%=dr["id"]%>">
			<div class="comment">
				<div class="picture">
					<a href="/User.aspx?userid=<%=dr["userid"]%>" title="点击查看用户信息">
						<%=Html.Image(Url.CH().Path.GetFace_Small(dr["userid"]), dr["name"].ToString())%>
					</a>
				</div>
				<div class="author">
					<span class="floor">
						<%if (cl.ShowType == 1 && cl.Rows.Contains("RowNo")) { %>
						<%=dr["RowNo"] %>楼
						<%} %>
					</span><a href="/User.aspx?userid=<%=dr["userid"]%>" title="点击人名查看">
						<%=dr["name"] %></a> <span class="time">
							<%=Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm") %></span>
					<%if (!(Convert.ToInt64(dr["UserId"]) == CHUser.UserID)) {%>
					<span class="reply"><a href="#userTalk" onclick="onReplyClick('<%=dr["name"]%>','<%=dr["userid"]%>'); return false;">
						回复</a></span>
					<%} %>
					<%if (!Convert.ToBoolean(dr["isDel"])) {
		   if (Convert.ToInt64(dr["UserId"]) == CHUser.UserID ||
			   Convert.ToInt64(dr["Ownerid"]) == CHUser.UserID) {
					%>
					<span class="remove"><a href="#" onclick="onDeleteReply(<%=dr["id"]%>,<%=dr["userid"]%>);return false;">
						删除</a> </span>
					<%}
	   }%>
					<%if (Convert.ToInt64(dr["UserId"]) != CHUser.UserID &&
		  Convert.ToInt64(dr["Ownerid"]) == CHUser.UserID
	&& !Convert.ToBoolean(dr["issee"])
		) {
		   if (Convert.ToInt64(dr["UserId"]) != CHUser.UserID) {
					%>
					<span class="pipe">|</span>
					<%} %>
					<span id="comment_see_<%=dr["id"]%>" class="setsee"><a href="javascript:onSeeReply(<%=dr["id"]%>);">
						置为已读</a></span>
					<%} %>
				</div>
				<div class="content">
					<p>
						<%if (!Convert.ToBoolean(dr["isDel"])) { %>
						<%=dr["body"]%>
						<%} else { %>
						已经删除
						<%} %>
					</p>
				</div>
			</div>
		</li>
		<%} %>
	</ol>
</div>
<%	if (cl.Count > cl.EveryPage) {%>
<div class="page" id="PageDown">
</div>
<%} %>
<%=Html.Hidden("HdPage",cl.Nowpage.ToString()) %>
<%=Html.Hidden("HdCount", cl.Count.ToString())%>
<%=Html.Hidden("HdEveryPage", cl.EveryPage.ToString())%>
<%=Html.Hidden("Hdisreply", false.ToString())%>
<%=Html.Hidden("Hdreplyid", "0")%>

<script type="text/javascript">
<%//显示相应的层
if(cl.ShowType!=1){ %>
if ($("#<%=cl.CountElement %>")!=null){
	$("#<%=cl.CountElement %>").html("<%=cl.Count %>");
}
<%} %>
<%if(cl.CountElement!=""){ %>
pagefun();
<%} %>
</script>

