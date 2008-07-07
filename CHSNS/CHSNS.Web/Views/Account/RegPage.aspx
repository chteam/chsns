﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Single.Master" AutoEventWireup="true"
	CodeBehind="RegPage.aspx.cs" Inherits="CHSNS.Web.Views.Account.RegPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">

	<script type="text/javascript">
var IsRegValition=function(){
	if(!(validate_regex("#Email",/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)
	&&validate_equals("#Email","#reEmail")
	&&validate_regex("#Password",/[\w\W]{4,32}/)
	&&validate_equals("#Password","#rePassword")
	&&validate_empty("#NickName"))) return false;
	if($get("#reg_check_id").checked){//打算添密码保护的情况下
		if(!(validate_empty('#Question')
		&&validate_empty("#Answer"))) return false;
	}else{
	$v("#Question","");
	$v("#Answer","");
	}
	return true;
};
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="toc">
		<ul id="tabs">
			<li class="status">第二步 - 注册账号</li>
		</ul>
	</div>
	<form id="registerForm" action="<%=Url.Action("SaveReg") %>" method='post' onsubmit="return IsRegValition();">
	<%if (TempData.ContainsKey("errors")) { %>
	<div class="notes">
		<%=TempData["errors"] %></div>
	<%} %>
	<fieldset>
		<legend>Email (登录时使用)</legend>
		<ul>
			<li>
				<label>
					Email：</label>
				<%=Html.TextBox("Email",new{@class="inputtext" ,tabindex="4", maxlength="80" })%>
				- 例如：abc@126.com <span id="Emailmsg" style="visibility: hidden">请填写正确邮箱</span></li>
			<li>
				<label>
					确认Email：</label>
				<%=Html.TextBox("reEmail", new { @class = "inputtext", tabindex = "5", maxlength = "80" })%>
				- 请输入上面的EMAIL地址 <span id="reEmailmsg" style="visibility: hidden">请确认两次Email一致</span>
			</li>
		</ul>
	</fieldset>
	<fieldset>
		<legend>密码 (登录时使用)</legend>
		<ul>
			<li>
				<label>
					密码：</label>
				<%=Html.TextBox("Password", new { @class = "inputtext", tabindex = "6" , maxlength="32" })%>
				- 由6-20字母或数字组成 <span id="Passwordmsg" style="visibility: hidden">密码必须由6-20个字符组成</span></li>
			<li>
				<label>
					确认密码：</label>
				<%=Html.TextBox("rePassword", new { @class = "inputtext", tabindex = "7" , maxlength="32" })%>
				- 请在输入一遍 <span id="rePasswordmsg" style="visibility: hidden">请确认两次密码一致</span></li>
		</ul>
	</fieldset>
	<fieldset>
		<legend>基本信息(确认身份时使用)</legend>
		<ul>
			<li>
				<label>
					姓名：</label>
				<%=Html.TextBox("NickName", new { @class="inputtext",tabindex="8", maxlength="12" })%>
				- 请填写您的真实姓名以便审核通过 <span id="account.namemsg" style="visibility: hidden">请填写您的姓名</span>
				<input type="hidden" name="profile.field" value="255" />
			</li>
			<%--			#*<li>
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
			title="选填项" tabindex="9" id="reg_check_id" /></legend>
		<ul id="reg_port_id" style="display: none">
			<li>
				<label>
					问题：</label>
					<%=Html.TextBox("Question", new { @class="inputtext", maxlength="32", tabindex="10"})%>
				- 请填写密码保护问题 <span id="Questionmsg" style="visibility: hidden">请填写回答</span></li>
			<li>
				<label>
					回答：</label>
<%=Html.TextBox("Answer", new { @class="inputtext", maxlength="32", tabindex="11"})%>
				- 请填写密码保护回答 <span id="Answermsg" style="visibility: hidden">请填写问题</span></li>
		</ul>
	</fieldset>
	<ul>
		<li><span class="submit">
			<input type="button" value="上一步" class="subbutton" tabindex="20" onclick="location=<%=Url.Action("Agreement") %>" />
			<input type="submit" value="下一步" class="subbutton" tabindex="21" />
		</span></li>
	</ul>
	<div id="registratormsg">
	</div>
	</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">

	<script type="text/javascript">
$("#Useremail").focus();
	</script>

</asp:Content>
