<%@ Control Language="C#" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<NotePas>>" %>
<%foreach(NotePas n in ViewData.Model){ %>
<li class="useritem" id="Items<%=n.Id %>">
	<div class="title">
	<%=Html.NoteDetails(n.Title,n.Id ,n.AddTime) %></div>
	<div class="text">
		<p><%=n.Body %><%=Html.NoteDetails("[查看全文]",n.Id,n.AddTime ) %>
		</p>
	</div>
	<div class="right option">
		<span class="time"><%=n.AddTime .ToString("yyyy-MM-dd hh:mm") %> </span>
		<%=n.WriteName %>
		阅读(<%=n.ViewCount %>)
		|
		评论(<%=n.CommentCount %>)
		<%
			if (n.UserId == CH.Context.User.UserID){
%>
		|
		<%=Html.NoteEdit(n.Id, "编辑")%>
		<a href="<%=n.Id %>" class="delete">删除</a>
		<%
			}
%>
	</div>
</li>
<%} %>