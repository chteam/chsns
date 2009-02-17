<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
	if (CH.Context.User.IsLogin) {%>
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
		    <li id="Li1"  class=" s_icon">
				<%=Html.ActionLink("角色设置", "Index", "Wow")%>
			</li>
		</ul>
		<a href="/Application.aspx" class="portal"><span>编辑</span></a>
<%
	} else
		Html.RenderPartial("LoginControl");
%>