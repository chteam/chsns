<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Details.aspx.cs" Inherits="CHSNS.Web.Views.Note.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%
		Note n = ViewData.Model.Note;
		UserItemPas u = ViewData.Model.User;
	%>
	<div class="ch_content" style="margin: 5px">
		<div class="title">
			<%=Html.NoteDetails(n.Title,n.ID ,n.AddTime) %></div>
		<div class="text">
			<%=n.Body %></div>
		<div class="right option">
			<span class="time">
				<%=n.AddTime .ToString("yyyy-MM-dd hh:mm") %>
			</span>
			<%=Html.NoteList( u.ID,u.Name+"的日志") %>
			<%=Html.UserPageLink(u.ID,u.Name) %>
			阅读(<%=n.ViewCount %>) 评论(<%=n.CommentCount %>) 推荐(<%=n.PushCount %>)
					<%
			if (n.UserID == CHUser.UserID){
%>
		
		<%=Html.NoteEdit(n.ID, "编辑")%>
		<%
			}
%>
		</div>
	</div>
	
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
