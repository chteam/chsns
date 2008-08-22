﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs"
	Inherits="CHSNS.Web.Views.Shared.LoginControl" %>
<span id="loginmsg"></span>
<div id="loginpanel">
	<h3>
		用户登录：</h3>
	<div id="loginForm">
		<p>
			<label class="label" for="Username">
				Email：</label>
			<input name="Username" type="text" id="Username" class="inputtext" onkeydown="EnterUsername(event);" />
		</p>
		<p>
			<label class="label" for="Userpwd">
				密码：</label>
			<input id="Userpwd" type="password" class="inputtext" onkeydown="EnterLogin(event);" />
		</p>
		<p>
			<input name="autoLogin" id="autoLogin" type="checkbox" onkeydown="EnterLogin(event);" /><label for="autoLogin">下次自动登录</label>
		</p>
		<p>
			<input type="button" id="SubmitLogin" onclick="Login();" onkeydown="EnterLogin(event);" value="登录" class="subbutton" /> <a href="/help/getcode.aspx">忘了密码?</a></p>
	</div>
	<%=Html.ActionLink("<span>注册</span>", "Start", "Reg", new { @class = "portal" })%>
<%=Html.ActionLink("<span>没有收到验证邮件吗</span>", "Resend", "Reg", new { @class = "portal" })%>
</div>