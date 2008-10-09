<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteList.ascx.cs" Inherits="CHSNS.Web.Views.Note.NoteList" %>
<%foreach(CHSNS.Models.NotePas n in ViewData.Model){ %>
<li class="useritem" id="Items<%=n.ID %>">
	<div class="title">
	<%=Html.NoteDetails(n.Title,n.ID ,n.AddTime) %></div>
	<div class="text">
		<p><%=n.Body %><%=Html.NoteDetails("[查看全文]",n.ID,n.AddTime ) %>
		</p>
	</div>
	<div class="right option">
		<span class="time"><%=n.AddTime .ToString("yyyy-MM-dd hh:mm") %> </span>
		<%=n.WriteName %>
		阅读(<%=n.ViewCount %>)
		|
		评论(<%=n.CommentCount %>)
		<%
			if (n.UserID == CHUser.UserID){
%>
		|
		<%=Html.NoteEdit(n.ID, "编辑")%>
		<a href="<%=n.ID %>" class="delete">删除</a>
		<%
			}
%>
	</div>
</li>
<%} %>