<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CHSNS.Web.Worker>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%
    var d = new Dictionary<int, string>();
    d.Add(0, "�ȴ���");
    d.Add(1, "��ͨ�����");
    d.Add(2, "��ֹ");
     %>
    <h2>����</h2>

    <table class="table">
        <tr>
            <th></th>
            <th>
                ��ϸ
            </th>
            <th>
                ����
            </th>
            <th>
                ״̬
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("�鿴��ϸ��Ϣ", "WorkDetails", new { id=item.ID }) %>
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
       <%=Html.ActionLink("���أ�����ļ", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

