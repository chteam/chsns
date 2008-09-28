<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyMenu.ascx.cs" Inherits="CHSNS.Web.Views.Shared.MyMenu" %>
<%
	if (CHUser.IsLogin) {%>
<div id="lselect">
<%--	<div id="leftmenu" class="mymenu">
		<ul>
			<li class=""><a href="#" class="menu_title" style="color: #3B5999">查找</a>
				<ul class="menu_network">
					<li><a href="/Search.aspx">查找同学</a></li>
					<li><a href="/Search.aspx?tabs=2">查找班级</a></li>
					<li><a href="/Search.aspx?tabs=1">查找群</a></li>
					<li><a href="/Random.aspx">随便看看</a></li>
				</ul>
			</li>
		</ul>
	</div>
	<div class="qsearch">
		<span class="glass"><a href="javascript:HomeSearch('MyApp_Search_Username');">
			<img src="/images/glass.gif" alt="" /></a></span>
		<input id="MyApp_Search_Username" type="text" onkeydown="SearchEnter(event,'MyApp_Search_Username')" />
	</div>
	<script type="text/javascript">
		chmenu("#leftmenu");
</script>--%>
	<div>
		<h3>
			菜单<a href="/Application.aspx">编辑</a></h3>
		<ul id="MyApplication">
			<%
				foreach (CHSNS.Models.Application app in Url.CH().DB.Application.GetApps(CHCookies.AppsArray)) {
			%>
			<li id="<%=app.ClassName%>">
				<%=Html.ActionLink(app.ShortName,app.Action,app.Controller) %>
			</li>
			<%
				}
			%>
		</ul>
	</div>
</div>



<%
	} else
		Html.RenderPartial("LoginControl");
%>