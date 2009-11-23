/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />

/*===================================================
成幻校友录 注册
2007 08 22
邹 健
===================================================*/
function SetSubmitEnable(sender,args){
	//$find("submitReg").get_element().disabled=!sender.get_isValid();
}
var IsValition=function(){
	if(!(validate_regex("Useremail",/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)
	&&validate_equals("Useremail","reUseremail")
	&&validate_regex("Password",/[\w\W]{4,32}/)
	&&validate_equals("Password","rePassword")
	&&validate_empty("Username"))) return false;
	if($get("reg_check_id").checked){//打算添密码保护的情况下
		if(!(validate_empty('Question')
		&&validate_empty("Answer"))) return false;
	}else{
	$get("Question").value="";
	$get("Answer").value="";
	}
	$get("reg_agreemsg").style.visibility="hidden";
	if(!$get("reg_agree").checked){
		$get("reg_agreemsg").style.visibility="visible";
		return false;
	}
	return true;
}
function Registrator(){
if(!IsValition()) return ;
	alertEx("正在向服务器提交信息...");
	ChAlumna.Identity.Registrator(//string Name,string Email, string Password,string Question,string Answer
		$get("Username").value,
		$get("Useremail").value,
		$get("Password").value,
		$get("Question").value,
		$get("Answer").value,
		function(r){
			if(r)
				setModalPopup("注册成功,请进行资料设置","进行下一步",function(){window.location.href="/registrator.aspx";});
			else
				alertEx("对不起此邮箱已经注册过了.");
		},onfail);
	alertEx("正在验证您的信息,请稍候...");
}
function RegMsg(id,m){
	showMessage(id+"msg",String.format("<span style='color:red'>{0}</span>",m),1000,false);
}

function pchange(){
		var selu=$get("University");
		selu.options.length=0;
		var ind=$get("Province").selectedIndex;
		Chsword.AutoSelect.UniversityList($get("Province")[ind].text,function(r){
			if($get("Province").options[0].text=="请选择")
				$get("Province").removeChild($get("Province").options[0]);
			var rows = r.rows;
			for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
				selu.options.add(new Option(rows[rowIndex]["School"],rows[rowIndex]["School"]));
			}
			unichange();
		},onfail);
}
function unichange(){
		var selx=$get("Xueyuan");
		selx.options.length=0;
		var ind=$get("University").selectedIndex;
		Chsword.AutoSelect.XueyuanList($get("University")[ind].text,function(r){
			if($get("University").options[0].text=="请选择")
				$get("University").removeChild($get("University").options[0]);
				if(r==null)return;
			var rows = r.rows;
			if(rows==null)return;
			for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
				selx.options.add(new Option(rows[rowIndex]["XueYuan"],rows[rowIndex]["XueYuan"]));
			}
		},onfail);
}
function changeXueyuanMethod(){
	if($get("Xueyuan_select").style.display=="none"){
		showLayer("Xueyuan_select","inline");
		hideLayer("Xueyuan_input");
	}else{
			showLayer("Xueyuan_input","inline");
		hideLayer("Xueyuan_select");
	}
}
function updateField(){

	switch($get("reg_field").value){
	case "1":
		if(!(validate_empty("University")
		&&(validate_empty("Xueyuan")
		||validate_empty("Xueyuan_text"))
		)) return;
		var xue_yuan=($get("Xueyuan_select").style.display=="none")?$get("Xueyuan_text").value:$get("Xueyuan").value;
		alertEx("正在向服务器提交信息...");
		ChAlumna.Identity.UpdateUniversityField(//string uni,string xueyuan
		$get("University").value,
		xue_yuan,
		function(r){
			if(r)
				setModalPopup("此步设置成功,请进行功能设置","进行下一步",function(){window.location.href="/";});
			else
				alertEx("对不起,您已经设置过了,请重新登录,进行体验");
		},onfail);
		alertEx("正在验证您的信息,请稍候...");
	break;
	}

}