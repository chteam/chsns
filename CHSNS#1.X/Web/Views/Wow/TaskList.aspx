<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CHSNS.Web.Task>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>我的招募</h2>

    <table>
        <tr>
            <th></th>
            <th>
                标题
            </th>
            <th>
                限制人数
            </th>
            <th>
                开始时间
            </th>
            <th>
                创建时间
            </th>
            <th>
                详细信息
            </th>
            <th>
                类型
            </th>
            <th>
                GB
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
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.PersonCount) %>
            </td>
            <td>
                <%= Html.Encode(item.BeginTime) %>
            </td>
            <td>
                <%= Html.Encode(item.AddTime) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%=item.TaskType /*Html.Encode( CH.Context.ConfigSerializer.Load<List<SelectListItem>>("WowTaskType").Where(c=>c.Value.Equals()).FirstOrDefault().Text)*/ %>
            </td>
            <td>
                <%= Html.Encode(item.GB) %>
            </td>
            <td>
                <%= Html.Encode(item.Status) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
    <%=Html.ActionLink("返回Ｇ团招募", "Index") %>
        <%= Html.ActionLink("发起悬赏", "AddTask")%>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

