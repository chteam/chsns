/*===================================================
成幻校友录 群列表
2007 08 27
邹 健
===================================================*/
function CreateGroup(){
    if(W_Match("cgname")) {//与水印匹配
        alertEx("请输入群名");
        return;
    }
    var _=$get("cgname").value;
	ChAlumna.Group.CreateGroup(_,$get("cgcategory").value,function(_r){
	        var id=parseInt(_r);
	        if(isNaN(id))
	            alertEx(_r);
	        else{
			    window.location="/ManageGroup.aspx?id="+id;
			}
		},onfail);
}
function showGroupmsg(m){
showMessage("GroupStatus",m,3000);
}
var isRss=false;
function ActiveTabChanged(sender, e) {
var i=$find('chcontent').get_activeTabIndex();
setTab(i);
//$find('chcontent').get_tabs()[2].set_enabled(true);
}
function setpage(p){
$get("HdPage").value=p;
$get("MyGroupItems").innerHTML="<li>正在读取数据</li>";
PageMethods.GetGroupList($get("HdPage").value,10,0,function(_r){		
			$get("MyGroupItems").innerHTML=_r.ResponseText;
			$get("HdCount").value=_r.Count;
			PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
		},onfail);
}
function setTab(i){
	hideLayer("PageUp");
	hideLayer("PageDown");
	switch(i){
	case 0:

	if (isRss) return;
	GetVm("/html/rsslist.ashx","count=20",function(r){
		$("chRss").innerHTML=r.get_responseData();
		isRss=true;
	});
	break;
	case 1:
		showLayer("PageUp");
		showLayer("PageDown");
		setpage(1);
	break;
	case 2:
		PageMethods.GetGroupList(1,10,1,function(_r){
			$get("AllGroupItems").innerHTML=_r.ResponseText.trim()==""?"<li>没有符合的数据</li>":_r.ResponseText;
			var dt = new Date(); 
			showGroupmsg("读取完成" + dt.localeFormat("MM月dd日 HH:mm:ss .fff"));
		},onfail);
	break;
	case 3:
		PageMethods.GetNewGroupPage(function(_r){
		
			$get("chNewGroup").innerHTML=_r;
			var dt = new Date(); 
			showGroupmsg("读取完成" + dt.localeFormat("MM月dd日 HH:mm:ss .fff"));
			InitEditW("cgname","请输入群名称");
		},onfail);
	break;
	}
}