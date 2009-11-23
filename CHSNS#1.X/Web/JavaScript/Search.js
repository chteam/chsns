/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />

/*===================================================
成幻校友录 搜索
2007 08 21 /10 28
邹 健 this called S
===================================================
*/
var groupname;
function searchUser(){
	var reg_email=/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
	var reg_userid=/\d{3,11}/;
	var bo=false;
	if(!W_Match("name","任意输入一项即可搜索")){
		bo=true;
	}
	if(reg_userid.test($v("userid"))){
		bo=true;
	}
	if(reg_email.test($v("email"))){
		bo=true;
	}
	if(!W_Match("university","任意输入一项即可搜索")){
		bo=true;
	}
	if(!bo)
	    alertEx('请填写至少一条查询条件');
	else{
		ChangeHdShow(0);
		var d={"username":$get_WText("name","任意输入一项即可搜索"),"userid":$get_WText("userid","任意输入一项即可搜索"),"email":$get_WText("email","任意输入一项即可搜索"),"university":$get_WText("university","任意输入一项即可搜索")};
		PageMethods.SearchUser(d,$v("HdPage"),$v("HdEveryPage"),"",getSearch,onfail);
	}
}
function setpage(p){
	$v("HdPage",p);
	if($v("HdShow")==0){
		var d={"uid":QueryString("uid"),"xid":QueryString("xid"),"qid":QueryString("qid"),"grade":QueryString("grade")};
		PageMethods.SearchUser(d,$v("HdPage"),$v("HdEveryPage"),"",getSearch,onfail);
	}else{
		PageMethods.SearchGroup(groupname,$get("HdPage").value,$get("HdEveryPage").value,getSearch,onfail);
	}
}
function ActiveTabChanged(sender, e) {
if(Tabs().get_activeTabIndex()==3)
	pagefun();
if(Tabs().get_activeTabIndex()==2)
	GetVm("/html/g.ashx","template=searchclass",function(r){
			$("chSearchClass").innerHTML=r.get_responseData();
		});
}

function SearchGroup(){
groupname=$get("groupname").value;
if(!W_Match("groupname","任意输入一项即可搜索")){
	ChangeHdShow(1);
	setpage(1);
	}
}
function ChangeHdShow(_){
	$get("HdShow").value=_;
}
function getSearch(_r){
	$find('chcontent').set_activeTabIndex(3);
	$get("ResultItems").innerHTML=_r.ResponseText.trim()==""?"<li>没有符合的数据</li>":_r.ResponseText;
	$get("ResultCount").innerHTML=_r.Count;
	$get("HdCount").value=_r.Count;
	pagefun();
}
function pchange(pid,uid){
		var selu=$get(uid);
		selu.options.length=0;
		var ind=$get(pid).selectedIndex;
		Chsword.AutoSelect.UniversityList($get(pid)[ind].text,function(r){
			if($get(pid).options[0].text=="请选择")
				$get(pid).removeChild($get(pid).options[0]);
			var rows = r.rows;
			for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
				selu.options.add(new Option(rows[rowIndex]["School"],rows[rowIndex]["id"]));
			}
			unichange(uid,'sc_Xueyuan');
		},onfail);
}
function unichange(uid,xid){
		var selx=$get(xid);
		selx.options.length=1;
		var ind=$get(uid).selectedIndex;
		Chsword.AutoSelect.XueyuanList($get(uid)[ind].text,function(r){
			if($get(uid).options[0].text=="请选择")
				$get(uid).removeChild($get(uid).options[0]);
				if(r==null)return;
			var rows = r.rows;
			if(rows==null)return;
			for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
				selx.options.add(new Option(rows[rowIndex]["XueYuan"],rows[rowIndex]["id"]));
			}
		},onfail);
}
function getsclist(){
	var d={"uid":$v("sc_University"),"xid":$v("sc_Xueyuan"),"grade":$v("sc_Grade")};
	ChAlumna.Search.SearchClassItems(d,function(r){
			var rows = r.rows;
			$get('Search_Class_Item').innerHTML='';
			if(rows==null){
			$get('Search_Class_Item').innerHTML='<li>没有符合项</li>';
			return;
			}
			for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
				$get('Search_Class_Item').innerHTML+=String.format('<li><a href="/group.aspx?id={0}&">{1}</a></li>',rows[rowIndex]["id"],rows[rowIndex]["GroupName"]);
			}
		},onfail);
}