<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs"
	Inherits="CHSNS.Web.Views.Shared.LoginControl" %>
<span id="loginmsg"></span>
<div id="loginpanel">
	<h3>
		用户登录：</h3>
	<div id="loginForm">
		<p>
			<label class="label">
				Email：</label>
			<input class="inputtext" maxlength="80" onkeydown="EnterTo('Password',event)" type="text"
				name="Email" id="Email" value="" />
		</p>
		<p>
			<label class="label">
				密码：</label>
			<input class="inputtext" maxlength="32" onkeydown="EnterTo('Auto',event)" type="password"
				name="Password" id="Password" value="" />
		</p>
		<p>
			<input type="checkbox" onkeydown="EnterTo('SubmitL',event)" value="true" name="Auto"
				id="Auto" />&nbsp;下次自动登录
		</p>
		<p>
			<input type="button" onclick="Login()" value="登录" class="subbutton" name="SubmitL" />
			<a href="/help/getcode.aspx">忘了密码?</a></p>
	</div>
	<a href="<%=Url.Action("Start", "Reg")%>" class="portal"><span>注册</span></a> <a href="<%=Url.Action("Resend", "Reg")%>"
		class="portal"><span>没有收到验证邮件吗</span></a>
</div>

<script type="text/javascript">
	function Login() {
		var LoginMsg = function(m) { showMessage("#loginmsg", m, 3000); };
		var U = $v("#Email");
		if (!Regtest("#Email", /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*|\d+/)) {
			LoginMsg('请输入正确的用户名.');
			return;
		}
		var P = $v("#Password");
		if (P.length < 4) {
			LoginMsg('密码最短长度为4.');
			return;
		}
		$.post('<%=Url.Action("Login","Identity") %>', { "u": U, "p": P, "a": $("#Auto").attr("checked") }, function(r) {
			if (r != "false") {
				//$h("#linkList2", r); ;
				location = '<%=Url.Action("Index","Event") %>';
			}
			else {
				LoginMsg('您的用户名或密码不正确.');
			}
		});
		$h("#loginmsg", '正在验证信息...');
	}
</script>

