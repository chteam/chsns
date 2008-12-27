﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
AutoEventWireup="true" ValidateRequest="false"
CodeBehind="Edit.aspx.cs" Inherits="CHSNS.Web.Views.Note.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
	<%=Html.Script("wysiwyg") %>
	<%=Html.CSSLink("wysiwyg") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
	Note n = ViewData.Model ?? new Note(); %>
	<fieldset>
		<legend>发布新日志</legend>
		<form action="" method="post" onsubmit="sub(this);return false;">
		<b>标题:</b>
		<input id="Title" name="n.Title" type="text" style="width: 400px"
		value="<%=n.Title??"" %>" /><br />
		<b>内容:</b><span id="Bodymsg" class="error"></span>
		<br />
		<textarea cols="83" id="Body" name="n.Body" rows="12"><p><%=n.Body??"" %></p></textarea>
		<%=ViewData["ID"]!=null?Html.Hidden("ID"):"" %>
		<input class="subbutton" value="发送" type="submit" />
		</form>
	</fieldset>
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
