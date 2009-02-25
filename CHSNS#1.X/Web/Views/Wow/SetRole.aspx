`<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CHSNS.Web.Character>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>设置我的默认角色</h2>

    <table class=".table">
        <tr>
            <th>
            </th>
            <th>
                名称
            </th>
            <th>
                阵营
            </th>
            <th>
                服务器
            </th>
            <th>
                等级
            </th>
            <th>
                战场
            </th>
            <th>
                职业
            </th>
            <th>
                种族
            </th>
            <th>
                lastLoginDate
            </th>
            <th>
                性别
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("修改角色", "EditRole", new {  id=item.ID }) %> |
                <%= ViewData["cid"]!=null&&ViewData["cid"].Equals(item.ID)?"默认角色":Html.ActionLink("设置为我的角色", "SetRole", new { id = item.ID })%>
            </td>
          
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Race) %>
            </td>
            <td>
                <%= Html.Encode(item.RealM) %>
            </td>
            <td>
                <%= Html.Encode(item.Level) %>
            </td>
            <td>
                <%= Html.Encode(item.BattleGroup) %>
            </td>
            <td>
                <%= Html.Encode(item.Class) %>
            </td>
            <td>
                <%= Html.Encode(item.Faction) %>
            </td>
            <td>
                <%= Html.Encode(item.lastLoginDate) %>
            </td>
            <td>
                <%= Html.Encode(item.Gend) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("返回应用", "Index") %>   <%=Html.ActionLink("新建角色","EditRole") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

