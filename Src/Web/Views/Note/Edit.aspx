<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Note>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <%--<%=Html.Script(Links.Scripts.wysiwyg_js) %>--%>
    <%=Html.CSSLink("wysiwyg/wysiwyg")%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        �༭</h2>
    <fieldset>
        <legend>��������־</legend>
        <%using (Html.BeginForm())
          { %>
        <p>
            <label>
                ����:</label>
            <%=Html.TextBoxFor(c => c.Title, new { style = "width:400px" })%>
        </p>
        <p>
            <label>
                ����:</label>
            <%=Html.TextBoxFor(c => c.Body, new { cols = "120", rows = "12", style = "width:400px;height:70px" })%>
        </p>
        <p>
            <input class="subbutton" value="����" type="submit" />
        </p>
        <%} %>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
    <script type="text/javascript">
        function sub(t) {
            if (v_empty("#Title", "���ⲻ��Ϊ��") && v_empty("#Body", "���ݲ���Ϊ��"))
                t.submit();
        }
        $(function () {
           ..// $('#Body').wysiwyg();
        });
    </script>
</asp:Content>
