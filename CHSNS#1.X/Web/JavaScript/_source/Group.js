/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />

/*===================================================
成幻校友录 群
2007 08 22
邹 健
===================================================*/
var $cgt=Chsword.GroupUserType;
function DeleteGroup(_){
	if(confirm("确定要解散本群吗？"))
	PageMethods.OptionGroupUser(_,0,$cgt.Leave,function(r){
	setModalPopup(r,"返回",function(){location.href=document.referrer;});},onfail);
}