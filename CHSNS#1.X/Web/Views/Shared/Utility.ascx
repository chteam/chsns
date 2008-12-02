<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="untityright link">
	<%if (CHUser.IsLogin) {%>
	<div class="menu">
	<a href="javascript:void(0);" class="menu_title">应用</a>
		<ul class="menu_network">
			<li><a href="/SuperNoteRandom.aspx">视频</a></li>
			<li>
				<%=Html.ActionLink("日志","News","Note") %></li>
			<li><a href="/AlbumRandom.aspx">相册</a></li>
			<li><a href="/GroupList.aspx?tabs=2">群组</a></li>
		</ul>
	</div>
	<%=Html.ActionLink("事件","Index","Event") %>
	<%=CHStatic.FriendRequestCount == 0?
		Html.ActionLink("好友", "Index", "Friend"):
		Html.ActionLink(string.Format("好友({0})", CHStatic.FriendRequestCount), "Request", "Friend")%>
	<div class="menu"><a href="javascript:void(0);" class="menu_title">您好！<%=CHUser.Username %></a>
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
	</div>
	<%=Html.ActionLink("首页","Index","Home") %>
	<%=(CHStatic.UnReadMessageCount == 0) ?
	Html.ActionLink("站内信","Inbox","Message") :
		Html.ActionLink(string.Format("站内信({0})", CHStatic.UnReadMessageCount), "Inbox", "Message")%>
	<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
	<%=Html.ActionLink("注销","Logout","Account") %>
	<%}
   else { %>
	<a href="/">首页</a>
	<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
	<%} %>
</div>
