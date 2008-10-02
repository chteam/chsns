﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Utility.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Utility" %>
<div class="untityright link">
	<%if (CHUser.IsLogin) {%>
	<span class="menu"><a href="###" class="menu_title">应用</a>
		<ul class="menu_network">
			<li><a href="/SuperNoteRandom.aspx">视频</a></li>
			<li><a href="/NewLogBook.aspx">日志</a></li>
			<li><a href="/AlbumRandom.aspx">相册</a></li>
			<li><a href="/GroupList.aspx?tabs=2">群组</a></li>
		</ul>
	</span>
	<%=Html.ActionLink("事件","Index","Event") %>
	<%if (CHStatic.FriendRequestCount == 0) { %>
	<%=Html.ActionLink("好友", "Index", "Friend")%>
	<%}
   else { %>
	<%=Html.ActionLink(string.Format("好友({0})", CHStatic.FriendRequestCount), "Request", "Friend")%>
	<%}%>
	<span class="menu"><a href="###" class="menu_title">您好！<%=CHUser.Username %></a>
		<ul class="menu_network">
			<li>
				<%=Html.ActionLink("我的页面", "Index", "User")%></li>
			<li>
				<%=Html.UserEditLink("BaseInfo","基本信息")%></li>
			<li>
				<%=Html.UserEditLink("School" ,"学校信息")%>
			</li>
			<li>
				<%=Html.UserEditLink( "upload","头像")%>
			</li>
			<li>
				<%=Html.UserEditLink("magicbox","魔法盒")%>
			</li>
			<li>
				<%=Html.ActionLink("隐私设置", "Setting", "User")%></li>
			<li>
				<%=Html.ActionLink("密码修改", "Setting", "User", new { tabs = 1 },null)%>
			</li>
		</ul>
	</span>
	<%=Html.ActionLink("首页","Index","Home") %>
	<%if (CHStatic.UnReadMessageCount == 0) { %>
	<%=Html.ActionLink("站内信","Inbox","Message") %>
	<%}
   else { %>
	<%=Html.ActionLink(string.Format("站内信({0})", CHStatic.UnReadMessageCount), "Inbox", "Friend")%>
	<%}%>
	<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
	<%=Html.ActionLink("注销","Logout","Account") %>
	<%}
   else { %>
	<a href="/">首页</a> <a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
	<%} %>
</div>
