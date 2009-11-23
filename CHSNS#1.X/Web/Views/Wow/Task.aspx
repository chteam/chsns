<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CHSNS.Web.Task>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>������</h2>
<%
    var d = new Dictionary<int, string>();
    d.Add(0, "�ȴ���");
    d.Add(1, "�����");
    d.Add(2, "�ѽ���");
     %>
  
    <table class=table>
        <tr>
            <th></th>
            <th>
                ����
            </th>
            <th>
                ��������
            </th>
            <th>
                ��ʼʱ��
            </th>
            <th>
                ����ʱ��
            </th>
            <th>
                ��ϸ��Ϣ
            </th>
            <th>
                ����
            </th>
            <th>
                GB
            </th>
            <th>
                ״̬
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%=Html.ActionLink("��Ҫ����", "TaskDetails", new { id=item.ID                })%>
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

