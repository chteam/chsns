<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteList.ascx.cs" Inherits="CHSNS.Web.Views.Note.NoteList" %>
<%foreach(CHSNS.Models.Note n in ViewData.Model){ %>
<li class="useritem" id="Items<%=n.ID %>">
	<div class="title">
	<%=Html.NoteDetails(n.Title,n.ID ,n.AddTime) %></div>
	<div class="text">
		<p><%=n.Summary %><%=Html.NoteDetails("[查看全文]",n.ID,n.AddTime ) %>
		</p>
	</div>
	<div class="right option">
		<span class="time"><%=n.AddTime .ToString("yyyy-MM-dd hh:mm") %> </span>
		阅读(<%=n.ViewCount %>)
		|
		评论(<%=n.CommentCount %>)
		|
		推荐(<%=n.PushCount %>)
		<%
			if (n.UserID == CHUser.UserID){
%>
		|
		<%=Html.NoteEdit(n.ID, "编辑")%>
		<%
			}
%>
	</div>
</li>
<%} %>