/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

/// <reference path="basic.js" />
// 本文件需要MicrosoftAjax.js支持
//邹 健
//20070728 2008 2 10
//分页JS
var PageSet_getNumbyId=function(id,def){//返回一个HIDE中存的数学值，def为非法情况下的默认值
	if(id==""||$get(id)==null||$get(id).value=="")
		return def;
	else
		 return parseInt($get(id).value);
};
var PageSet_chSetPage=function(id1,id2,nowPageid,allCountid,everyPageid,pageclick){
//========================这两个理论上为span
//id1主翻按钮
//id2次翻页按钮
//==============================这三个为hide
//nowPageid存当前载入页的hide
//allCountid存所有条数
//everyPageid：存每页的条数的hide
//pageclick is event
if(!pageclick) pageclick="setpage";
var hcount=PageSet_getNumbyId(allCountid,20);
var everypage=PageSet_getNumbyId(everyPageid,20);
var hpage=PageSet_getNumbyId(nowPageid,1);
var pc = parseInt((hcount+everypage) / everypage);//计算总条数
if (pc <=1) {
hideLayer(id1);
hideLayer(id2);
return;}else{
showLayer(id1);
showLayer(id2);
}
var selecttemp='<span class="this-page">{0}</span>';
var breaktemp='<span class="break">...</span>';
var unselecttemp='<a href="javascript:'+pageclick+'({0})" title="第{0}页" class="page-size{2}">{1}</a>';
//初始化
var alltext=new String();
var temp;
if(hpage > 1){
	if (hpage - 2 > 1){
		temp=String.format(unselecttemp,"1","« 第一页","");
		alltext=alltext+temp;
		alltext=alltext+breaktemp;
	}
	temp=String.format(unselecttemp,hpage - 1,"< 上一页","");
	alltext=alltext+temp;
}

for(i = 2;i<=6;i++){
	if((hpage + i - 4) >= 1 && (hpage + i - 4) <= pc){
		if (4==i){
			temp=String.format(selecttemp,hpage);
			alltext=alltext+temp;
		}else{
			temp=String.format(unselecttemp,hpage + i - 4,hpage + i - 4,Math.abs(i-4));
			alltext=alltext+temp;
		}
	}
}
if(hpage < pc){
	temp=String.format(unselecttemp,1+hpage,"下一页 >","");
	alltext=alltext+temp;
	if(hpage + 2 < pc){
		alltext=alltext+breaktemp;
		temp=String.format(unselecttemp,pc,"最后页 »","");
		alltext=alltext+temp;
	}
}
        
PageSet_chshowpage(id1,alltext);
PageSet_chshowpage(id2,alltext);
return;
}

function PageSet_chshowpage(id,text){
	if(id==""||$get(id)==null)
		return;
	else
		$get(id).innerHTML=text;
	return;
}
var pagefun=function(){
PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
};