<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="formset"><legend>�޸�����</legend>
        <form action="" method="post">
        <p>
            <label>������</label><input type="password" name="oldpassword" id="oldpassword" /></p>
        <p>
            <label>������</label><input type="password" name="password" id="password" /></p>
        <p>
            <label>������</label><input type="password" name="repassword" id="repassword" /></p>
        <p>
            <input type="submit" value="�ύ" /></p>
        </form>
    </fieldset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
