<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Note>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <%--<%=Html.Script(Links.Scripts.wysiwyg_js) %>--%>
    <%=Html.CSSLink("wysiwyg/wysiwyg")%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        编辑</h2>
    <fieldset>
        <legend>发布新日志</legend>
        <%using (Html.BeginForm())
          { %>
        <p>
            <label>
                标题:</label>
            <%=Html.TextBoxFor(c => c.Title, new { style = "width:400px" })%>
        </p>
        <p>
            <label>
                内容:</label>
            <%=Html.TextBoxFor(c => c.Body, new { cols = "120", rows = "12", style = "width:400px;height:70px" })%>
        </p>
        <p>
            <input class="subbutton" value="发送" type="submit" />
        </p>
        <%} %>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
    <script type="text/javascript">
        function sub(t) {
            if (v_empty("#Title", "标题不能为空") && v_empty("#Body", "内容不能为空"))
                t.submit();
        }
        $(function () {
           ..// $('#Body').wysiwyg();
        });
    </script>
</asp:Content>
