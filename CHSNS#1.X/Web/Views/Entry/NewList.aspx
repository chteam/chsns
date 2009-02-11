<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<PagedList<EntryPas>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>词条管理</h2>
            <%Html.RenderPartial("ManageToc"); %>
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
                <%if (CH.Context.User.Status.Contains(RoleType.Creater, RoleType.Editor			  )){%>
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
