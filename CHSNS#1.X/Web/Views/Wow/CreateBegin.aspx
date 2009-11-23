<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>查找用户</h2>
    <form action="" method="post" class="formset">
    <p>
        <label>角色昵称</label>
        <input type="text" name="RoleName" /></p>
    <p>
        <label>所在服务器</label>
        <%=Html.DropDownList("ServerName") %>其它<input type="text" name="ServerNameTxt" /></p>
    <p>
        <input type="submit" value="提交" /></p>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
