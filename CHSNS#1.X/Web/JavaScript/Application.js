/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />

function initThisPage(){
	Sys.Application.add_init(function() {
	var b=$get("MyApplication");
	var a=b.getElementsByTagName("li");
	var l=a.length;
	var i=0;
	for(i=0;i<l;++i){
		hideLayer("Applist_"+a[i].id+"_add");
		showLayer("Applist_"+a[i].id+"_del","inline");
		InitDragItem(a[i].id);
		}
	}
	);
	InitDragWatcher("MyApplication","ReorderList_Item");
}
function AddtoMenu(id,name,url){
	if($get(id)) {alertEx("您已经添加过此程序");return;}
	var b=$get("MyApplication");
	var a=b.getElementsByTagName("li");
	for(var i=0;i<a.length;i++)
		$find("DraggableListItem"+a[i].id).dispose();
	$find("ReorderListItemExMyApplication").dispose();
	$get("MyApplication").innerHTML=$get("MyApplication").innerHTML+String.format(
	"<li id='{0}'><a href='{1}'>{2}</a></li>",id,url,name);
	initThisPage();
	hideLayer("Applist_"+id+"_add");
	showLayer("Applist_"+id+"_del","inline");
}
function DelfromMenu(id){
	var d=$get(id);
	d.parentNode.removeChild(d);
	hideLayer("Applist_"+id+"_del");
	showLayer("Applist_"+id+"_add","inline");
}

function ActiveTabChanged(sender, e) {
	var i=Tabs().get_activeTabIndex();
	setTab(i);
}

