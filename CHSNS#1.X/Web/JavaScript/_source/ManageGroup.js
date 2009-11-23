var EditInfoBool=new Array();
var $t=Chsword.PageType;
var $cgt=Chsword.GroupUserType;
function setTab(i){
	var n,t;
	switch(i){
		case 0:n="Setting";t=$t.Setting;break;
		case 1:n="Member";t=$t.Member;break;
		case 2:n="Photo";t=$t.Photo;break;
		case 3:n="Disallow";t=$t.Disallow;$get("ch"+n).innerHTML="Building...";return;
	}
	if(EditInfoBool[i]) return;
	$get("ch"+n).innerHTML="正在读取页面...";
	GetVm("/html/GroupManageChild.ashx","template="+n+"&groupid="+groupid,function(r){
			$get("ch"+n).innerHTML=r.get_responseData();
			EditInfoBool[i]=true;
			if(i==2){
				uploadcreate($get('uploadfield'),groupid,"type=groupimg","upload");
			}
		});
}
function ActiveTabChanged(sender, e) {
	var i=$find('chcontent').get_activeTabIndex();
	setTab(i);
}
function showEditmsg(m){
	showMessage("Status",m,3000);
}
function SetGroup(t){
	var g=new Chsword.Datamodel.GroupModel();
	setModalPopup("正在向服务器提交信息...");
	showModalPopup();
	switch(t){
		case $t.Setting:
			g.Groupid=groupid;
			g.Groupname=$get("Groupname").value;
			g.Publish=$get("Publish").value;
			g.Showlevel=parseInt($get("Showlevel").value);
			if($get("Joinlevel"))
			g.Joinlevel=parseInt($get("Joinlevel").value);
			else
			g.Joinlevel=0;
		break;
		case $t.Member:
		alertEx('');
		case $t.Photo:
		case $t.Disallow:
		
	}
	PageMethods.SetGroup(g,t,function(r){
			setModalPopup(r);
	},onfail);
}
function DeleteGroupUser(_){
	var g=new Chsword.Datamodel.GroupModel();
	setModalPopup("正在向服务器提交信息...");
	showModalPopup();
	g.Groupid=groupid;
	g.ViewUserid = _;
	PageMethods.SetGroup(g,$t.Deletemember,function(r){
		setModalPopup(r);
		hideLayer("Member"+_);
	},onfail);
}
function AllowMember(_){//buserid
mg_GroupUser(_,$cgt.AllowMember,"Member");
}
function DisallowMember(_){
mg_GroupUser(_,$cgt.DisallowMember,"Member");
}
function AllowMaster(_){//buserid
mg_GroupUser(_,$cgt.AllowMaster,"Master");
}
function DisallowMaster(_){
mg_GroupUser(_,$cgt.DisallowMaster,"Master");
}
function mg_GroupUser(u,t,d){//u用户,t操作类型,d Divid
	alertEx("正在向服务器提交信息...");
PageMethods.OptionGroupUser(groupid,u,t,function(r){
		setModalPopup(r);
		hideLayer("Apply"+d+u);
},onfail);
}

function TurnCreater(_){//转让群主
	mg_GroupUser(_,$cgt.TurnCreater);
}
function TurnMember(_){//降为成员
	mg_GroupUser(_,$cgt.TurnMember);
}