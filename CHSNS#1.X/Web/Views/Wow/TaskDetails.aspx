<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Task>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%
    var d = new Dictionary<int, string>();
    d.Add(0, "�ȴ���");
    d.Add(1, "��ͨ�����");
    d.Add(2, "��ֹ");
     %>
     <%
    var td = new Dictionary<int, string>();
    td.Add(0, "�ȴ���");
    td.Add(1, "�����");
    td.Add(2, "�ѽ���");
     %>
    <h2>��Ҫ�μ�</h2>

    <fieldset>
        <legend>��Ҫ�μ�</legend>
        <p>
            ����: 
            <%= Html.Encode(Model.Title) %>
        </p>
        <p>
            ����: 
            <%= Html.Encode(Model.PersonCount) %>
        </p>
        <p>
            ʱ��: 
            <%= Html.Encode(Model.BeginTime) %>
        </p>
        <p>
            ��ϸ: 
            <%= Html.Encode(Model.Description) %>
        </p>
        <p>
            TaskType: 
            <%= Html.Encode(Model.TaskType) %>
        </p>
        <p>
            GB: 
            <%= Html.Encode(Model.GB) %>
        </p>
        <p>
            Status: 
            <%= Html.Encode(td[Model.Status]) %>
        </p>
    </fieldset>
    <%
        using (var w = new CHSNS.Web.WOWDataContext())
        {
            var ws = w.Worker.Where(t => t.TaskID == Model.ID);
     %>
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
    <% foreach (var item in ws)
       { %>
        <tr>
            <td>
                <%= Html.ActionLink("�鿴��ϸ��Ϣ", "WorkDetails", new { id = item.ID })%>
            </td>
            <td>
                <%= Html.Encode(item.Description)%><br />
            </td>
            <td>
                <%= Html.Encode(item.EvaluationWork)%>
            </td>
            <td>
                <%= Html.Encode(d[item.Status])%>
            </td>
        </tr>
    
    <% } %>

    </table>
    <%} if (CH.Context.User.UserID != Model.CreateUserID)
      { %>
    <form action="<%=Url.Action("JoinTask") %>" method="post">
    <%=Html.DropDownList("wid")%>
    <%=Html.Hidden("tid", Model.ID)%>
    <input type="submit" value="�ύ" />
    
    �������û�з����򹤼ƻ���<%=Html.ActionLink("�������", "AddWork", new { taskid = Model.ID })%>
    </form>
<%}else{
      %>
      <%=Html.ActionLink("��ɽ���", "PayTask", new { id=Model.ID})%>
      <%} %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

