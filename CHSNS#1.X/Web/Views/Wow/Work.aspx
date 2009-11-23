<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CHSNS.Web.Worker>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%
    var d = new Dictionary<int, string>();
    d.Add(0, "等待中");
    d.Add(1, "已通过审核");
    d.Add(2, "终止");
     %>
    <h2>打工区</h2>

    <table class="table">
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
                <%= Html.ActionLink("查看详细信息", "WorkDetails", new { id=item.ID }) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %><br />
            </td>
            <td>
                <%= Html.Encode(item.EvaluationWork) %>
            </td>
            <td>
                <%= Html.Encode(d[item.Status]) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
       <%=Html.ActionLink("返回Ｇ团招募", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

