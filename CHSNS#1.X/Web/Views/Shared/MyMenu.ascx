<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
	if (CH.Context.User.IsLogin) {%>

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

		<h3>
			菜单</h3>
		<ul id="MyApplication" class="app_list">
			<%
                foreach (CHSNS.Config.ApplicationItem app in
                    CH.Context.ConfigSerializer.Load<CHSNS.Config.SystemApplicationConfig>
                    ("SystemApplication").Items)
                {
			%>
			
			<li id="<%=app.CssName%>"  class="<%=app.CssName %> s_icon">
				<%=Html.ActionLink(app.ShortName, app.Action, app.Controller)%>
			</li>
			<%
                }
			%>
		</ul>
		<a href="/Application.aspx" class="portal"><span>编辑</span></a>
<%
	} else
		Html.RenderPartial("LoginControl");
%>