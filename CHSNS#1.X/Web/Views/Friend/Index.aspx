﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Index.aspx.cs" Inherits="CHSNS.Web.Views.Friend.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("PageSet") %>
	<%=Html.Script("friend")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="UserListMsg">
	</div>
	<h2>
		<%=ViewData["Name"]%>的好友</h2>
	<a href="/Invite.aspx">邀请朋友加入</a> 
	
	(共有<span id="FriendCount" class="count"><%=ViewData["PageCount"]%></span>个好友)
	<div class="ch_content">
		<div id="PageUp" class="page">
		</div>
		<ol id="UserListItems" class="userlist">
			<%
				Html.RenderPartial("FriendList", ViewData["source"]); %>
		</ol>
		<div id="PageDown" class="page">
		</div>
	</div>
	<%=Html.Hidden("PageCount")%>
	<%=Html.Hidden("NowPage") %>
	<%=Html.Hidden("EveryPage","10") %>

	<script type="text/javascript">
		var setpage = function(p) {
			$.post("<%=Url.Action("FriendList") %>", {"p":p,"userid":<%=ViewData.Model.UserID %>}, function(r) {
				$h("#UserListItems",r);
				pagefun();
			});
		};
		pagefun();
	</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
