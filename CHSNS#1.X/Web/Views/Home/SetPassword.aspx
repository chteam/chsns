<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="pwresetmain">

		<h2>第2步.修改您的密码</h2>
		<div>
			填写您信箱收到的验证码，并输入您的新密码，然后点击设置密码！密码修改完成...
		</div>
		<div class="pwtext">
		       
				<p><label>帐号[Email]:</label><input id="sp_email" type="text" /></p>
				<p><label>验证码:</label><input id="sp_code" type="text" /></p>
				<p><label>新密码:</label><input id="sp_password" type="password" /></p>
				<p><label>重复新密码:</label><input id="sp_repassword" type="password" /></p><span id="sp_repasswordmsg" style="visibility: hidden"></span>
				
        </div>			
             <div>
				<input type="button" id="sp_sub" value="设置密码" onclick="setPassword();" />
			</div>
	</div>
	<script type="text/javascript">
	function setPassword(){
		if(isEmpty("sp_email")||isEmpty("sp_password")||isEmpty("sp_code")){
		alertEx("请将信息填写完整");
		return;
		}
		if(!validate_equals("sp_password","sp_repassword")){
		alertEx("两次密码输入不一致");
		return;
		}
		$get("sp_sub").disabled=true;
		ChAlumna.Identity.SetPassword($get('sp_email').value,
		$get('sp_password').value,
		$get('sp_code').value,
		function(r){
			if(r){
				alertEx("密码重设成功，请返回登录。"'location="/"');
			}else{
				alertEx("您输入的信息不正确，请查实后再试");
				$get("sp_sub").disabled=false;
			}
		},onfail);
	}
	</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootPlaceHolder" runat="server">
</asp:Content>
