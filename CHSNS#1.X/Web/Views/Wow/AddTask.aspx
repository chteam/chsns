<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Task>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>发起悬赏</h2>

    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) {%>

        <fieldset class=formset>
            <legend>发起悬赏</legend>
            <p>
                <label for="Title">悬赏标题:</label>
                <%= Html.TextBox("t.Title") %>
                <%= Html.ValidationMessage("t.Title", "*") %>
            </p>
            <p>
                <label for="PersonCount">人数限制:</label>
                <%= Html.TextBox("t.PersonCount") %>
                <%= Html.ValidationMessage("t.PersonCount", "*") %>
            </p>
            <p>
                <label for="BeginTime">开始时间:</label>
                <%= Html.TextBox("t.BeginTime") %>
                <%= Html.ValidationMessage("t.BeginTime", "*") %>
            </p>
            <p>
                <label for="Description">详细信息:</label>
                <%= Html.TextArea("t.Description") %>
                <%= Html.ValidationMessage("t.Description", "*") %>
            </p>
            <p>
                <label for="TaskType">类型:</label>
                <%= Html.DropDownList("t.TaskType", 
                    CH.Context.ConfigSerializer.Load<List<SelectListItem>>("WowTaskType"))%>
            </p>
            <p>
                <label for="GB">打算花费ＧＢ:</label>
                <%= Html.TextBox("t.GB") %>
                <%= Html.ValidationMessage("t.GB", "*") %>
            </p>
            <p>
                <input type="submit" value="提交" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("返回Ｇ团招募", "Index") %>
         <%=Html.ActionLink("我的悬赏", "TaskList")%>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("calendar")%></asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
<script type="text/javascript">
$('#t_BeginTime').datepicker();
</script>
</asp:Content>

