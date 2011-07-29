<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
<%Html.RenderPartial("ManageToc"); %>
<% var x = ViewData["Source"] as IEnumerable< EntryPas>; %>
    <h2>
    <%=Html.ActionLink(x.First().Title.Trim(), "Index", new { title = x.First().Title.Trim() })%></h2>
       <table class="table">
        <tr>
            <th width="60" class="ln25 f14" nowrap align="center">
               <%-- <input type="submit" value="版本对比" onclick="VidMgr.compare()" />--%>
            </th>
            <th width="20" class="ln25">
                &nbsp;
            </th>
            <th width="270" class="ln25 f14B" nowrap>
                编辑版本
            </th>
            <th class="ln25 f14B" nowrap>
                &nbsp;
            </th>
            <th width="200" class="ln25 f14B" nowrap>贡献者</th>
            <th class="ln25 f14B">
                编辑原因
            </th>
        </tr>
        <%foreach (var e in x)
          { %>
        <tr>
            <td class="ln25 f14" align="center">
               <%-- &nbsp;<input type="checkbox" name="cb" value="2821210" onclick="VidMgr.select(this)" />&nbsp;--%>
            </td>
            <td class="ln25">
                            <%=e.Status%>
                <%=(e.Status != (int)EntryVersionType.Common) ? Html.ActionLink("通过审核", "Pass", new { id = e.Id }) : MvcHtmlString.Empty%>
                <%=(e.Status != (int)EntryVersionType.Lock) ? Html.ActionLink("锁定", "Lock", new { id = e.Id }) : MvcHtmlString.Empty%>
            </td>
            <td class="ln25 f14">
            <%=e.AddTime.ToString("yyyy-MM-dd hh:mm:ss") %>版本&nbsp;&nbsp;
            <%=Html.ActionLink("查看", "History", new { id = e.Id }, new { title = "点此查看历史版本" })%>
            </td>
            <td class="ln25 f14" align="right">
                &nbsp;
            </td>
            <td class="ln25 f14">
            <%=Html.UserPageLink(e.User.Id,e.User.Name)%>
            </td>
            <td class="ln25 f14">
               <%=e.Reason %>
            </td>
        </tr>
        <%} %>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
