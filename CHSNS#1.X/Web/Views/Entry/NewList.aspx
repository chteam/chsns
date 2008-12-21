<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="NewList.aspx.cs" Inherits="CHSNS.Web.Views.Entry.NewList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
        词条管理<a class="searchA" href="#">词条搜索</a>
        <%=Html.ActionLink("添加新词条", "Edit")%><span>共有记录<%=ViewData.Model.TotalCount %>条
            共<%=ViewData.Model.TotalPages %>页 当前第<%=ViewData.Model.CurrentPage %>页</span></h2>
            
    <div class="search">
        <h3>
            词条搜索<a class="close" href="#">×</a></h3>
        <table class="memu_1">
            <tr>
                <td>
                    词条名称：<input name="TextBox2" type="text" id="TextBox2" />
                    所在地区：<select name="DropDownList3" id="DropDownList3">
                    </select>
                    <select name="DropDownList4" id="DropDownList4">
                    </select>
                    <input type="submit" name="Button1" value="搜索" id="Button1" class="button_1" />
                </td>
            </tr>
        </table>
    </div>
    <table class="table">
        <tr>
            <th class="flush_center"><input type="checkbox" /></th>
            <th>序号</th>
            <th>词条名称</th>
            <th>添加时间</th>
            <th>编辑次数</th>
            <th>原因</th>
            <th>状态/操作</th>
        </tr>
        <%
            foreach (var e in ViewData.Model)
            {
            %>
        <tr>
            <td>
                <input type="checkbox" />
            </td>
            <td><%=e.ID %></td>
            <td>
            <%=Html.ActionLink(e.Title, "Index","Entry", new{title=e.Title.Trim()},null)%>
            [<%=Html.ActionLink("管理历史", "AdminHistoryList", new { title = e.Title.Trim() }, null)%>]
            </td>
            <td><%=e.AddTime.ToString("yyyy-MM-dd hh:mm:ss") %></td>
            <td>
                <a href="#"><%=e.EditCount %></a>
            </td>
            <td>
                <%=e.Reason %>
            </td>
            <td>
                 <%=e.Status%>
                <%if (CHUser.Status.Contains(RoleType.Creater, RoleType.Editor			  )){%>
                <%=(e.Status != (int)EntryVersionType.Common) ? Html.ActionLink("通过审核", "Pass", new { id = e.ID }) : ""%>
                <%=(e.Status !=(int) EntryVersionType.Lock) ? Html.ActionLink("锁定", "Lock", new { id = e.ID }) : ""%>
                <%} %>
                <%=Html.ActionLink("删除词条及全版本", "Delete",new { id=e.ID})%>
            </td>
        </tr>
        <%} %>
    </table>
    <%Html.RenderPartial("Pager", ViewData);%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
