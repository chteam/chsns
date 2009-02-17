<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CHSNS.Web.Worker>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>我的打工计划</h2>

    <table>
        <tr>
            <th></th>
            <th>
                详细
            </th>
            <th>
                评分
            </th>
            <th>
                状态
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%= Html.Encode(item.EvaluationWork) %>
            </td>
            <td>
                <%= Html.Encode(item.Status) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
     <%=Html.ActionLink("返回Ｇ团招募", "Index") %>
   <%=Html.ActionLink("我要打工", "AddWork")%>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

