<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<span id="loginmsg"></span>
<div id="loginpanel">
	<h3>
		用户登录：</h3>
	<div id="loginForm">
		<p>
			<label class="label">
				账号：</label>
			<input class="inputtext" maxlength="80" onkeydown="EnterTo('#login_p',event)" type="text" id="login_u" value="" />
		</p>
		<p>
			<label class="label">
				密码：</label>
			<input class="inputtext" maxlength="32" onkeydown="EnterTo('#login_a',event)" type="password" id="login_p" value="" />
		</p>
		<p>
			<input type="checkbox" onkeydown="EnterTo('#login_s',event)" value="true" id="login_a" />&nbsp;下次自动登录
		</p>
		<p>
			<input type="button" onclick="Login()" value="登录" class="subbutton" id="login_s" />
			<a href="/help/getcode.aspx">忘了密码?</a></p>
	</div>
	<a href="<%=Url.Action("Agreement", "Account")%>" class="portal"><span>注册</span></a>
	<a href="<%=Url.Action("Remail", "Account")%>" class="portal"><span>没有收到验证邮件吗</span></a>
</div>

<script type="text/javascript">
	var Login = function() {
		var msg = function(m) { showMessage("#loginmsg", m); };
		var U = $v("#login_u");
		if (U.length < 4) {
			msg('请输入正确的用户名.');
			return;
		}
		var P = $v("#login_p");
		if (P.length < 4) {
			msg('密码最短长度为4.');
			return;
		}
		$.post('<%=Url.Action("Login","Account") %>', { "u": U, "p": P, "a": $("#login_a").attr("checked") }, function(r) {
			if (r != "false") {
				location = '<%=Url.Action("Index","Event") %>';
			}
			else {
				msg('您的用户名或密码不正确.');
			}
		});
		$h("#loginmsg", '正在验证信息...');
	};
</script>

