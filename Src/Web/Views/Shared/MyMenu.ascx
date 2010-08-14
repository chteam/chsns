<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<ul id="MyApplication" class="app_list">
    <%
        foreach (CHSNS.Config.ApplicationItem app in
            ConfigSerializer.Instance.Load<CHSNS.Config.SystemApplicationConfig>
            ("SystemApplication").Items)
        {
    %>
    <li id="<%=app.CssName%>" class="<%=app.CssName %> s_icon">
        <%=Html.ActionLink(app.ShortName, app.Action, app.Controller)%>
    </li>
    <%
        }
    %>
</ul>
