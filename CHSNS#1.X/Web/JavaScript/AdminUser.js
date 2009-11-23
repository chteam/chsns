/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />
function Admin_Isstar_Add(userid){
	ChAlumna.Profile.Admin_Isstar_Add(userid,function(r){
		alert('设置成功');
	},onfail);
}
function Admin_Isstar_Remove(userid){
	ChAlumna.Profile.Admin_Isstar_Remove(userid,function(r){
		alert('设置成功');
	},onfail);
}
function Admin_Class_Request_Delete(groupid){
	ChAlumna.Group.Class_Request_Delete(groupid,function(r){
		alert('设置成功');
	},onfail);
}
function Admin_Class_Request_Allow(groupid,userid){
	ChAlumna.Group.Class_Request_Allow(groupid,userid,function(r){
	if(r)
		alert('设置成功');
		else
		alert('设置失败');
	},onfail);
}
var getPosition=function (o){
	var r = new Array();
	r['x'] = o.offsetLeft;
	r['y'] = o.offsetTop;
	while(o = o.offsetParent){
		r['x'] += o.offsetLeft;
		r['y'] += o.offsetTop;
	}
	return r;
};
var hideInfo=function(){
    $('hintdivup').style.display='none';
    $('hintdivdown').style.display='none';
};