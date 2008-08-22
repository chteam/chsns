﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublicMenu.ascx.cs"
	Inherits="CHSNS.Web.Views.Shared.PublicMenu" %>
<%if (CHUser.IsLogin) { %>
<ul>
	<li class="menuli">
	<%=Html.ActionLink("我的页面", "Index", "User")%>
	</li>
	<li class="menuli"><a href="#" class="menu_title">查看</a>
		<ul class="menu_network">
			<li><%=Html.ActionLink("事件","Index","Event") %></li>
			<li><a href="/Message.aspx?mode=inbox">小条</a></li>
			<li><%=Html.ActionLink("好友请求", "FriendRequest", "User")%></li>
		</ul>
	</li>
	<li class="menuli"><a href="#" class="menu_title">应用</a>
		<ul class="menu_network">
			<li><a href="/SuperNoteRandom.aspx">视频</a></li>
			<li><a href="/NewLogBook.aspx">日志</a></li>
			<li><a href="/AlbumRandom.aspx">相册</a></li>
			<li><a href="/GroupList.aspx?tabs=2">群组</a></li>
		</ul>
	</li>
	<li class="menuli"><a href="#" class="menu_title">设置</a>
		<ul class="menu_network">
			<li><a href="/EditMyinfo.aspx">基本信息</a></li>
			<li><a href="/EditMyinfo.aspx?mode=school">学校信息</a></li>
			<li><a href="/EditMyinfo.aspx?mode=upload">头像</a></li>
			<li><a href="/EditMyinfo.aspx?mode=magicbox">魔法盒</a></li>
			<li><a href="/setting.aspx">隐私设置</a></li>
			<li><a href="/setting.aspx?tabs=1">密码修改</a></li>
		</ul>
	</li>
</ul>
<script type="text/javascript">
	chmenu("publicmenu");
</script>
<% 
	}
%>