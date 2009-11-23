/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />
function Admin_Isstar_Add(userid){
	ChAlumna.Profile.Admin_Isstar_Add(userid,function(r){
		alertEx('设置成功');
	},onfail);
}
function Admin_Isstar_Remove(userid){
	ChAlumna.Profile.Admin_Isstar_Remove(userid,function(r){
		alertEx('设置成功');
	},onfail);
}
function Admin_Class_Request_Delete(groupid){
	ChAlumna.Group.Class_Request_Delete(groupid,function(r){
		alertEx('设置成功');
	},onfail);
}
function Admin_Class_Request_Allow(groupid,userid){
	ChAlumna.Group.Class_Request_Allow(groupid,userid,function(r){
	if(r)
		alertEx('设置成功');
		else
		alertEx('设置失败');
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
var showInfo=function(obj, objleftoffset,objtopoffset, title, info , objheight, showtype ,objtopfirefoxoffset){
   var p = getPosition(obj);
   if((showtype==null)||(showtype =="")) {showtype =="up";}
   $('hintiframe'+showtype).style.height= objheight + "px";
   $('hintinfo'+showtype).innerHTML = info;
   $('hintdiv'+showtype).style.display='block';
   
   if(objtopfirefoxoffset != null && objtopfirefoxoffset !=0 && !isie())
   {
        $('hintdiv'+showtype).style.top=p['y']+parseInt(objtopfirefoxoffset)+"px";
   }else{
        if(objtopoffset == 0){ 
			if(showtype=="up"){
				 $('hintdiv'+showtype).style.top=p['y']-$('hintinfo'+showtype).offsetHeight-40+"px";
			}else{
				 $('hintdiv'+showtype).style.top=p['y']+obj.offsetHeight+5+"px";
			}
        }else{
			$('hintdiv'+showtype).style.top=p['y']+objtopoffset+"px";
        }
   }
   $('hintdiv'+showtype).style.left=p['x']+objleftoffset+"px";
};
