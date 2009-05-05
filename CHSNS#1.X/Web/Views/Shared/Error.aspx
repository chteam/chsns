<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<HandleErrorInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>您访问的页面发生错误</h2>
    <div style="overflow: auto;">
        <%
            var exceptions = new Stack<Exception>();
            for (Exception ex = ViewData.Model.Exception; ex != null; ex = ex.InnerException)
            {
                exceptions.Push(ex);
            }
        %>
        <%
            foreach (var ex in exceptions)
            {
%>
        <div class="notes">
            <% //= Html.Encode(ex.GetType().FullName)%>
            <%=ex.Message%>
        </div>
        <%--<div>
<pre style="font-size: medium;"><%= Html.Encode(ex.StackTrace)%></pre>
</div>--%>
        <%
            }
%>
    </div>
</asp:Content>
