<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<EntryIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%
        var entry = Model.Entry;
        var version = Model.Version;
        var ext = Model.Ext ?? new EntryExt();
    %>
    <div id="entryContent">
        <%if (entry.IsDisplayTitle)
          {%>
        <h2>
            <%=version.Title%></h2>
        <%
            }%>
        <div class="body">
            <p>
                <%=version.Description%></p>
        </div>
    </div>
    <div id="entryTools">
        <p>
            <%=Html.ActionLink("Version", "Historylist", new { id = entry.Id })%>
            <span>(<%=entry.EditCount%>)</span>
            <%if (User.IsInRole("admin"))
              { %>
            操作：
            <%=Html.ActionLink("编辑", "Edit", new { id = entry.Id })%>
            <%=Html.ActionLink("新建", "Edit", "Entry")%>
            <%} %>
        </p>
        <ul>
            <li><span>标签：</span><%=string.Join(",", (ext.Tags.ToNotNull()).ToArray())%>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
