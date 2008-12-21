<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="CHSNS.Web.Views.Entry.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
<%=Html.CSSLink("jd") %>
<%=Html.Script("howlking")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarContent" runat="server">
    <%Html.RenderPartial("Toolbar", ViewData); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divide">
        <span>旅游词条列表</span><span class="right">搜索到结果256项，以下是第1-20项</span></div>

    <div class="JD_list">
    <%foreach (var e in ViewData.Model)
      {%>
        <div class="JD_list_item">
            <img alt="uuspark词条" src="/images2/img_3.gif" />
            <div class="msg">
                <h4><%=Html.ActionLink(e.Title.Trim(), "Index", new { title = e.Title.Trim() })%><span>位于:
                    <%=e.Area.Name %>
                    <%=e.AddTime.ToString("yyyy-MM-dd") %></span></h4>
                <p>
                    <% string x=e.Reason.NoHTML();
                       if (x.Length > 100)
                           Response.Write(x.Substring(0, 100));
                       else
                           Response.Write(x);
               %></p>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <%} %>
        <%
      Html.RenderPartial("Pager", ViewData); %>
    </div>

    <div class="AD_1">
        <a href="#">
            <img src="/images2/ad1.gif" /></a> <a href="#">
                <img src="/images2/ad2.gif" /></a>
    </div>
    <!--广告-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
