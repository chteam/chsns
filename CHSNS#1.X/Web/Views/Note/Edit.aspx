<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CHSNS.Models.Note>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		�༭</h2>
	<%
		Note n = ViewData.Model ?? new Note(); %>
	<fieldset>
		<legend>��������־</legend>
		<form action="" method="post" onsubmit="sub(this);return false;">
		<b>����:</b>
		<input id="Title" name="n.Title" type="text" style="width: 400px" value="<%=n.Title??"" %>" /><br />
		<b>����:</b><span id="Bodymsg" class="error"></span>
		<br />
		<textarea cols="83" id="Body" name="n.Body" rows="12"><p><%=n.Body??"" %></p></textarea>
		<%=ViewData["ID"]!=null?Html.Hidden("ID"):"" %>
		<input class="subbutton" value="����" type="submit" />
		</form>
	</fieldset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("wysiwyg") %>
	<%=Html.CSSLink("wysiwyg") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		function sub(t) {
			if (v_empty("#Title", "���ⲻ��Ϊ��") && v_empty("#Body", "���ݲ���Ϊ��"))
				t.submit();
		}
		$(function() {
			$('#Body').wysiwyg();
		});
	</script>

</asp:Content>
