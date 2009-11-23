/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="../WebServices/Invite.asmx/jsdebug" />


function SendEmail(){
	if(isEmpty("email")) return;
	Chsword.Invite.SendInviteMail($get("email").value,$v("mailtext"),function(r){
		if(r)
			alertEx("发送成功");
		else
			alertEx("发送失败");
	},onfail);
}
