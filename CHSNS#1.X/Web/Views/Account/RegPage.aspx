<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Single.Master" AutoEventWireup="true"
	CodeBehind="RegPage.aspx.cs" Inherits="CHSNS.Web.Views.Account.RegPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<form id="registerForm" action="<%=Url.Action("SaveReg") %>" method='post' onsubmit="IsRegValition(this);return false;">
	<%if (TempData.ContainsKey("errors"))
   { %>
	<div class="notes">
		<%=TempData["errors"] %></div>
	<%} %>
	<fieldset>
		<legend>基本信息</legend>
		<ul>
			<li>
				<label>
					用户名：</label>
				<input class="inputtext" id="Username" maxlength="80" name="Username" type="text">
				- 例如：chsword</li>
			<li>
				<label>
					密码：</label>
				<input class="inputtext" id="Password" maxlength="32" name="Password" type="password">
				- 由6-20字母或数字组成</li>
			<li>
				<label>
					确认密码：</label>
				<input class="inputtext" id="rePassword" maxlength="32" name="rePassword" type="password">
				- 请在输入一遍</li>
			<li>
				<label>
					姓名：</label>
				<input class="inputtext" id="Name" maxlength="12" name="Name" type="text">
				- 请填写您的真实姓名以便审核通过</li>
			<%--	<input name="profile.field" value="255" type="hidden">		#*<li>
				<label>
					我是：</label>
				<select size="1" name="profile.field">
					<option value="1" selected="selected">在校大学生</option>
					<option value="4">已工作</option>
					<option value="2">高中</option>
					<option value="255">其它</option>
					-->
				</select>
			</li>
			*#--%>
		</ul>
	</fieldset>
	<fieldset>
		<legend>密码保护 (找回密码时使用)[选填项]
			<input type="checkbox" onclick="this.checked?$('#reg_port_id').show():$('#reg_port_id').hide();"
				title="选填项" id="reg_check_id" /></legend>
		<ul id="reg_port_id" style="display: none">
			<li>
				<label>
					问题：</label>
				<input class="inputtext" id="Question" maxlength="32" name="Question"
					type="text" />
				- 请填写密码保护问题</li>
			<li>
				<label>
					回答：</label>
				<input class="inputtext" id="Answer" maxlength="32" name="Answer" type="text" />
				- 请填写密码保护回答</li>
		</ul>
	</fieldset>
	<ul>
		<li><span class="submit">
			<input type="button" value="上一步" class="subbutton" tabindex="20" onclick="location=<%=Url.Action("Agreement") %>" />
			<input type="submit" value="下一步" class="subbutton" tabindex="21" />
		</span></li>
	</ul>
	</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
		$("#Username").focus();
		var IsRegValition = function(t) {
			if (v_regex("#Username", /[\w\W]{4,32}/, false, '请填写正确用户名')
	&& v_regex("#Password", /[\w\W]{4,32}/, false, '密码必须由6-20个字符组成')
	&& v_equals("#Password", "#rePassword", '请确认两次密码一致')
	&& v_empty("#Name", '请填写您的姓名')) {
				if ($("#reg_check_id").attr("checked")) {//打算添密码保护的情况下
					if (!(v_empty('#Question', '请填写问题') && v_empty("#Answer", '请填写回答'))) return;
				} else {
					$v("#Question", "");
					$v("#Answer", "");
				}
				$(t).submit();
			}
		};
	</script>
</asp:Content>
