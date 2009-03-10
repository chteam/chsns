<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
	if (CH.Context.User.IsLogin) {%>
		<h3>
			菜单</h3>
		<ul id="MyApplication" class="app_list">
			    <li id="Li1"  class=" s_icon">
				<%=Html.ActionLink("G团招募", "Index", "GTuan")%>
			</li>
					    <li id="Li2"  class="s_icon">
				<%=Html.ActionLink("自强组队", "Index", "Wow")%>
			</li>
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