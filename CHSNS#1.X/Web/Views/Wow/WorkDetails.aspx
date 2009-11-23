<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Worker>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>WorkDetails</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            ID: 
            <%= Html.Encode(Model.ID) %>
        </p>
        <p>
            UID: 
            <%= Html.Encode(Model.UID) %>
        </p>
        <p>
            TaskID: 
            <%= Html.Encode(Model.TaskID) %>
        </p>
        <p>
            Description: 
            <%= Html.Encode(Model.Description) %>
        </p>
        <p>
            EvaluationWork: 
            <%= Html.Encode(Model.EvaluationWork) %>
        </p>
        <p>
            AddTime: 
            <%= Html.Encode(Model.AddTime) %>
        </p>
        <p>
            EvaluationTask: 
            <%= Html.Encode(Model.EvaluationTask) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

