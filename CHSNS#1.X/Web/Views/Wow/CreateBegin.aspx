<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>�����û�</h2>
    <form action="" method="post" class="formset">
    <p>
        <label>��ɫ�ǳ�</label>
        <input type="text" name="RoleName" /></p>
    <p>
        <label>���ڷ�����</label>
        <%=Html.DropDownList("ServerName") %>����<input type="text" name="ServerNameTxt" /></p>
    <p>
        <input type="submit" value="�ύ" /></p>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
