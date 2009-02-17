<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Task>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>��������</h2>

    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) {%>

        <fieldset class=formset>
            <legend>��������</legend>
            <p>
                <label for="Title">���ͱ���:</label>
                <%= Html.TextBox("t.Title") %>
                <%= Html.ValidationMessage("t.Title", "*") %>
            </p>
            <p>
                <label for="PersonCount">��������:</label>
                <%= Html.TextBox("t.PersonCount") %>
                <%= Html.ValidationMessage("t.PersonCount", "*") %>
            </p>
            <p>
                <label for="BeginTime">��ʼʱ��:</label>
                <%= Html.TextBox("t.BeginTime") %>
                <%= Html.ValidationMessage("t.BeginTime", "*") %>
            </p>
            <p>
                <label for="Description">��ϸ��Ϣ:</label>
                <%= Html.TextArea("t.Description") %>
                <%= Html.ValidationMessage("t.Description", "*") %>
            </p>
            <p>
                <label for="TaskType">����:</label>
                <%= Html.DropDownList("t.TaskType", 
                    CH.Context.ConfigSerializer.Load<List<SelectListItem>>("WowTaskType"))%>
            </p>
            <p>
                <label for="GB">���㻨�ѣǣ�:</label>
                <%= Html.TextBox("t.GB") %>
                <%= Html.ValidationMessage("t.GB", "*") %>
            </p>
            <p>
                <input type="submit" value="�ύ" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("���أ�����ļ", "Index") %>
         <%=Html.ActionLink("�ҵ�����", "TaskList")%>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("calendar")%></asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">
$('#t_BeginTime').datepicker();
</script>
</asp:Content>

