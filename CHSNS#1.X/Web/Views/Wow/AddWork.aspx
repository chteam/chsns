<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Worker>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) {%>

        <fieldset class=formset>
            <legend>我要打工</legend>
            <%=Html.Hidden("t.TaskID") %>
            <p>
                <label for="Description">打工说明:</label>
                <%= Html.TextArea("t.Description") %>
                <%= Html.ValidationMessage("t.Description", "*")%>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
     <%=Html.ActionLink("返回Ｇ团招募", "Index") %>
     <%=Html.ActionLink("我的打工计划", "WorkList")%>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

