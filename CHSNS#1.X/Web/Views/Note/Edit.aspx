<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<INote>"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		编辑</h2>
	<%
		INote n = ViewData.Model; %>
	<fieldset>
		<legend>发布新日志</legend>
		<form action="" method="post" onsubmit="sub(this);return false;" class="formset">
		<p>
		<label>标题:</label>
		<input id="Title" name="n.Title" type="text" style="width: 400px" value="<%=n.Title??"" %>" />
		</p>
		
		<p><label>内容:</label>
		<textarea cols="120" id="Body" name="n.Body" rows="12"><p><%=n.Body??"" %></p></textarea>
		<%=ViewData["ID"]!=null?Html.Hidden("ID"):"" %><span id="Bodymsg" class="error"></span>
		</p>
		<p>
		<input class="subbutton" value="发送" type="submit" />
		</p>
		</form>
	</fieldset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

	<%=Html.Script("wysiwyg") %>
	<%=Html.CSSLink("wysiwyg/wysiwyg")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		function sub(t) {
			if (v_empty("#Title", "标题不能为空") && v_empty("#Body", "内容不能为空"))
				t.submit();
		}
		$(function() {
			$('#Body').wysiwyg();
		});
	</script>

</asp:Content>
