<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Web.Character>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm("EditRole","Wow")) {%>

        <fieldset class="formset">
            <legend>��ɫ</legend>
           
                <%= Html.Hidden("ID") %>
                 <%= Html.Hidden("c.UID",CH.Context.User.UserID ) %>
            <p>
                <label for="Name">��ɫ��:</label>
                <%= Html.TextBox("c.Name") %>
                <%= Html.ValidationMessage("c.Name", "*")%>
            </p>
            <p>
                <label for="Race">����:</label>
                <%= Html.TextBox("c.Race")%>
                <%= Html.ValidationMessage("c.Race", "*")%>
            </p>
            <p>
                <label for="RealM">������:</label>
                <%= Html.TextBox("c.RealM")%>
                <%= Html.ValidationMessage("c.RealM", "*")%>
            </p>
            <p>
                <label for="Level">�ȼ�:</label>
                <%= Html.TextBox("c.Level")%>
                <%= Html.ValidationMessage("c.Level", "*")%>
            </p>
            <p>
                <label for="BattleGroup">ս��:</label>
                <%= Html.TextBox("c.BattleGroup")%>
                <%= Html.ValidationMessage("c.BattleGroup", "*")%>
            </p>
            <p>
                <label for="Class">ְҵ:</label>
                <%= Html.TextBox("c.Class")%>
                <%= Html.ValidationMessage("c.Class", "*")%>
            </p>
            <p>
                <label for="Faction">��Ӫ:</label>
                <%= Html.TextBox("c.Faction")%>
                <%= Html.ValidationMessage("c.Faction", "*")%>
            </p>
                <%= Html.Hidden("c.lastLoginDate")%>
                
            <p>
                <label for="Gend">�Ա�:</label>
                <%= Html.TextBox("c.Gend")%>
                <%= Html.ValidationMessage("c.Gend", "*")%>
            </p>
            <p>
                <input type="submit" value="�ύ" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("�����б�", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>

