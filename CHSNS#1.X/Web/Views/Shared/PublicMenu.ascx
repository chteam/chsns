<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublicMenu.ascx.cs"
	Inherits="CHSNS.Web.Views.Shared.PublicMenu" %>
<%if (CHUser.IsLogin) { %>

<span class="menu"><a href="#" class="menu_title">查看</a>
	<ul class="menu_network">
		<li>
			<%=Html.ActionLink("事件","Index","Event") %></li>
		<li>
			<%=Html.ActionLink("好友请求", "Request", "Friend")%></li>
	</ul>
</span><span class="menu"><a href="#" class="menu_title">应用</a>
	<ul class="menu_network">
		<li><a href="/SuperNoteRandom.aspx">视频</a></li>
		<li><a href="/NewLogBook.aspx">日志</a></li>
		<li><a href="/AlbumRandom.aspx">相册</a></li>
		<li><a href="/GroupList.aspx?tabs=2">群组</a></li>
	</ul>
</span>
<%=Html.ActionLink("小条","Inbox","Message") %>
<% 
	}
%>