<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<PagedList<EntryPas>>" %>
<%@ Import Namespace="CHSNS.Models.Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        词条管理</h2>
    <%Html.RenderPartial("ManageToc"); %>
    <table class="table">
        <tr>
            <th class="flush_center">
                <input type="checkbox" />
            </th>
            <th>
                序号
            </th>
            <th>
                词条名称
            </th>
            <th>
                添加时间
            </th>
            <th>
                编辑次数
            </th>
            <th>
                原因
            </th>
            <th>
                状态/操作
            </th>
        </tr>
        <%
            foreach (var e in ViewData.Model)
            {
        %>
        <tr>
            <td>
                <input type="checkbox" />
            </td>
            <td>
                <%=e.Id %>
            </td>
            <td>
                <%=Html.ActionLink(e.Title??"Empty Title", "Index","Entry", new{url=e.Url.Trim()},null)%>
                [<%=Html.ActionLink("管理历史", "AdminHistoryList", new { url = e.Url.Trim() }, null)%>]
            </td>
            <td>
                <%=e.AddTime.ToString("yyyy-MM-dd hh:mm:ss") %>
            </td>
            <td>
                <a href="#">
                    <%=e.EditCount %></a>
            </td>
            <td>
                <%=e.Reason %>
            </td>
            <td>
                <%=e.Status%>
                <%if (new[] { RoleType.Creater, RoleType.Editor }.Contains((RoleType)CH.Context.User.Status))
                  {%>
                <%=(e.Status != (int)WikiVersionStatus.Common) ? Html.ActionLink("通过审核", "Pass", new { id = e.Id }).ToHtmlString() : ""%>
                <%=(e.Status != (int)WikiVersionStatus.Lock) ? Html.ActionLink("锁定", "Lock", new { id = e.Id }).ToHtmlString() : ""%>
                <%} %>
                <%=Html.ActionLink("删除词条及全版本", "Delete",new { id=e.Id})%>
            </td>
        </tr>
        <%} %>
    </table>
    <%Html.RenderPartial("Pager", ViewData);%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
