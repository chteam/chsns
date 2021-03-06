﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
 Inherits="System.Web.Mvc.ViewPage" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<% var e = ViewData["Source"] as IEnumerable< EntryPas>; %>

        <div id="divide">
    <span class="Tit"><%=e.First().Title %></span> <span class="f14">共被编辑 <%=e.First().EditCount%> 次</span></div>
    <h2>
    <%=Html.ActionLink(e.First().Title, "Index", new { title = e.First().Title.Trim() })%></h2>
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
        <%foreach (var i in e)
          { %>
        <tr>
            <td class="ln25 f14" align="center">
               <%-- &nbsp;<input type="checkbox" name="cb" value="2821210" onclick="VidMgr.select(this)" />&nbsp;--%>
            </td>
            <td class="ln25">&nbsp;</td>
            <td class="ln25 f14">
            <%=i.AddTime.ToString("yyyy-MM-dd hh:mm:ss") %>版本&nbsp;&nbsp;
            <%=Html.ActionLink("查看", MVC.Entry.History(i.Id), new { title = "点此查看历史版本" })%>
            </td>
            <td class="ln25 f14" align="right">
                &nbsp;
            </td>
            <td class="ln25 f14">
            <%=Html.UserPageLink(i.User.Id,i.User.Name)%>
            </td>
            <td class="ln25 f14">
               <%=i.Reason %>
            </td>
        </tr>
        <%} %>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
