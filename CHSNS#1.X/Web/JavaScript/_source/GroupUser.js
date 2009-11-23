/*===================================================
成幻校友录 用户处理,班级用户处理
2007 08 31
邹 健
===================================================*/
var $cgt=Chsword.GroupUserType;
function OutGroup(_){//在List页面的退出，要有额外操作
    var b=confirm('确定要退出本群吗？');
	if(b){
	    PageMethods.OptionGroupUser(_,0,$cgt.Leave,function(_r){
	    if (_r=="您已经退出本群"){
	        alertEx(r);
	        $get("GroupItems"+_).innerHTML='';
	    }else alertEx(_r);},onfail);
	}
}
function JoinClass(_){//加入班级
	var bl=confirm("确定要加此班级吗？");
	if(bl)PageMethods.OptionGroupUser(_,0,$cgt.JoinClass,function(r){alertEx(r);},onfail);
}
function Takein(_){//groupid
	PageMethods.OptionGroupUser(_,0,$cgt.Takein,function(r){alertEx(r);
	var a=$get("RssTake");
	a.innerText="取消订阅";
	a.href="javascript:Takeout("+_+");";
	},onfail);
}
function Takeout(_){//groupid
	var bl=confirm("确定要取消订阅吗？");
	if(bl)
	PageMethods.OptionGroupUser(_,0,$cgt.Takeout,function(r){alertEx(r);
	var a=$get("RssTake");
	a.innerText="订阅本群";
	a.href="javascript:Takein("+_+");";
	},onfail);
}
function Joinin(_){//groupid
	var bl=confirm("确定要加入本群吗？");
	if(bl)
	PageMethods.OptionGroupUser(_,0,$cgt.Join,function(r){alertEx(r);},onfail);
}
function Leave(_){//groupid
	var bl=confirm("确定要退出本群吗？");
	if(bl)
	PageMethods.OptionGroupUser(_,0,$cgt.Leave,function(r){alertEx(r);},onfail);
}

function ApplyAdmin(_){
PageMethods.OptionGroupUser(_,0,$cgt.ApplyMaster,function(r){alertEx(r);},onfail);
}

function Class_Cancle(groupid){
	ChAlumna.Group.Class_Cancle(groupid,function(r){
	if(r){
	alertEx("成功取消");
	hideLayer("MyClass_item_"+groupid);
	}else{
	alertEx("您不是该群成员");
	}
	},onfail);
}