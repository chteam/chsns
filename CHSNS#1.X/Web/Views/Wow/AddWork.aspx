<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Worker>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) {%>

        <fieldset class=formset>
            <legend>��Ҫ��</legend>
            <%=Html.Hidden("t.TaskID") %>
            <p>
                <label for="Description">��˵��:</label>
                <%= Html.TextArea("t.Description") %>
                <%= Html.ValidationMessage("t.Description", "*")%>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
     <%=Html.ActionLink("���أ�����ļ", "Index") %>
     <%=Html.ActionLink("�ҵĴ򹤼ƻ�", "WorkList")%>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

