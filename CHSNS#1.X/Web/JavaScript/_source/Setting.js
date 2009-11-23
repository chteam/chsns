// JScript 文件
function ActiveTabChanged(sender, e) {
var i=$find('chcontent').get_activeTabIndex();
setTab(i);
}
function ChangePassword(){
	var op=$get("oldpassword").value;
	var np=$get("newpassword").value;
	var rp=$get("newpassword2").value;
	if(rp!=np){alertEx("两次输入的密码不一致");return;}
	if(op.length<1){alertEx("请输入原始密码");return;}
	if(np.length<1){alertEx("请输入新密码");return;}
	PageMethods.ChangePassword(op,np,function(_r){
		if(_r=="")
			alertEx("修改成功");
		else
		alertEx("意外错误");
	},onfail);
}
function ChangeShowLevel(){
	PageMethods.ChangeShowLevel($get("PersonalInfoShowLevel").value,$get("FaceShowLevel").value,$get("AllShowLevel").value,function(_r){
		if(_r=="")
			alertEx("修改成功");
		else
			alertEx("意外错误");
	},onfail);
}

function setTab(i){
	showTabsmsg("正在读取数据...");
	switch(i){
	case 0:
	if($get("chChangeShowLevel").innerHTML.trim()==""){
		GetVm("/html/ChangeShowLevel.ashx","",function(r){
			$get("chChangeShowLevel").innerHTML=r.get_responseData();
			showTabsmsg("读取成功");
		});
	}
	break;
	case 1:
	if($get("chChangePassword").innerHTML.trim()==""){
		GetVm("/html/ChangePassword.ashx","",function(r){
			$get("chChangePassword").innerHTML=r.get_responseData();
			showTabsmsg("读取成功");
		});
	}
	break;
	}
}