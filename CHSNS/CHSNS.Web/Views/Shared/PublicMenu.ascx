<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublicMenu.ascx.cs"
	Inherits="CHSNS.Web.Views.Shared.PublicMenu" %>
<%if (CHUser.IsLogin) { %>
<ul>
	<li class="menuli">
		<%--$url.link("我的页面", "%{area='',controller='user',action='index'}","%{class='menu_mypage'}")--%>
	</li>
	<li class="menuli"><a href="#" class="menu_title">查看</a>
		<ul class="menu_network">
					<%
						foreach (ISystemApplication ip in UnitySingleton.CurrentSystemApplication.Where(c => c.Position == 3)) {
			%>
			<li>
				<%=Html.ActionLink(ip.Name, "Setting", ip.ControllerName)%></li>
			<%
				}
			%>
		</ul>
	</li>
	<li class="menuli"><a href="#" class="menu_title">应用</a>
		<ul class="menu_network">
			<%
				foreach (ISystemApplication ip in UnitySingleton.CurrentSystemApplication.Where(c => c.Position == 2)) {
			%>
			<li>
				<%=Html.ActionLink(ip.Name, "Setting", ip.ControllerName)%></li>
			<%
				}
			%>
		</ul>
	</li>
	<li class="menuli"><a href="#" class="menu_title">设置</a>
		<ul class="menu_network">
			<%
				foreach (ISystemApplication ip in UnitySingleton.CurrentSystemApplication.Where(c => c.Position == 1)) {
			%>
			<li>
			<%=Html.ActionLink<HomeController>(i=>i.Setting(ip.ControllerName),ip.Name)  %>
				<%--<%=Html.ActionLink(ip.Name, "Setting", ip.ControllerName)%>--%></li>
			<%
				}
			%>
		</ul>
	</li>
</ul>
<% 
	}
%>