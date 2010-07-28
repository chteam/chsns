<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<% 
    if (Page.User.Identity.IsAuthenticated)
    {%>
        <h3>
            菜单</h3>
        <ul id="MyApplication" class="app_list">
            <%
                foreach (CHSNS.Config.ApplicationItem app in
                    ConfigSerializer.Instance.Load<CHSNS.Config.SystemApplicationConfig>
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