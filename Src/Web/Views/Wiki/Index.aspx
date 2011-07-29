<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CHSNS.Wiki" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%
        var entry = View.Entry;
        var version = View.Version;
        var ext = View.Ext ?? new EntryExt();
    %>
    <div id="entryContent">
        <div>
            <div style="float: right">
                <%if (User.IsInRole("Admin"))
                  { %>
                操作：
                <%=Html.ActionLink("编辑", "Edit", new { id = entry.Id })%>
                <%=Html.ActionLink("新建", "Edit", "Entry")%>
                <%} %>
            </div>
            <%if (entry.IsDisplayTitle)
              {%>
            <h2>
                <%=version.Title%></h2>
            <%
                }%></div>
        <div class="body">
            <p>
                <%=WikiEngine.Explain( version.Description)%></p>
        </div>
    </div>
    <div id="entryTools">
        <p>
            <%=Html.ActionLink("Version", "Historylist", new { id = entry.Id })%>
            <span>(<%=entry.EditCount%>)</span>
        </p>
        <%if (ext.Tags != null && ext.Tags.Count > 0)
          {  %>
        <ul>
            <li><span>标签：</span><%=string.Join(",", (ext.Tags??new List<string>()).ToArray())%>
            </li>
        </ul>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
