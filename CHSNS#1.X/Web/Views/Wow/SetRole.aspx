`<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CHSNS.Web.Character>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>�����ҵ�Ĭ�Ͻ�ɫ</h2>

    <table class=".table">
        <tr>
            <th>
            </th>
            <th>
                ����
            </th>
            <th>
                ��Ӫ
            </th>
            <th>
                ������
            </th>
            <th>
                �ȼ�
            </th>
            <th>
                ս��
            </th>
            <th>
                ְҵ
            </th>
            <th>
                ����
            </th>
            <th>
                lastLoginDate
            </th>
            <th>
                �Ա�
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("�޸Ľ�ɫ", "EditRole", new {  id=item.ID }) %> |
                <%= ViewData["cid"]!=null&&ViewData["cid"].Equals(item.ID)?"Ĭ�Ͻ�ɫ":Html.ActionLink("����Ϊ�ҵĽ�ɫ", "SetRole", new { id = item.ID })%>
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
        <%= Html.ActionLink("����Ӧ��", "Index") %>   <%=Html.ActionLink("�½���ɫ","EditRole") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

