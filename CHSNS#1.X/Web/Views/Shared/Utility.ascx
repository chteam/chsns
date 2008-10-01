<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Utility.ascx.cs" Inherits="CHSNS.Web.Views.Shared.Utility" %>
<div class="untityright">
	<%if (CHUser.IsLogin) {%>

		<span class="menu">
		<a href="#" class="menu_title">您好！<%=CHUser.Username %></a>
			<ul class="menu_network">
			<li><%=Html.ActionLink("我的页面", "Index", "User")%></li>
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
	<span class="link">
		<%=Html.ActionLink("首页","Index","Home") %>
		<a href="http://www.eice.com.cn/help.ashx" target="_blank">帮助</a>
		<%=Html.ActionLink("注销","Logout","Account") %>
	</span>
	<%}
   else { %>
	<span class="link"><a href="/">首页</a> <a href="http://www.eice.com.cn/help.ashx"
		target="_blank">帮助</a> </span>
	<%} %>
</div>
