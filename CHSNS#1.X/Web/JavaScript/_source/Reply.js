/*===================================================
成幻校友录 回复与留言
2007 07 28
邹 健
===================================================*/
var IsReplyPost=false;
//删除留言函数
function onDeleteReply(id,uid){//删除留言
	var bl=confirm("确定删除本留言吗？");
	if(bl){
	PageMethods.DeleteReply(id,function(r) {//删除留言的返回事件
		var rcount=0;
		if($("rCount")){
			rcount=$h("rCount");
		}
		if(r==""){
			if(rcount>0){
				$h("rCount",rcount-1);
			}
			showMessage("ReplyMsg","已经删除");
			$("reply"+id).outerHTML='';
		}else
		   alertEx(r);
	},onfail);
	}
}

function onReplyClick(username,id){
	showLayer('starttalkForm');
	hideLayer('starttalk');
	visible=true;
	$v('TBody',"\u56de\u590d"+username+"\uff1a");
	$v('Hdreplyid',id);
	$v('Hdisreply',"true");
	$('TBody').focus();
}
function cancelLeaveWord() {
	hideLayer("starttalkForm"); 
	showLayer("starttalk");
	$("TBody").value=""; 
	$v("Hdreplyid",0);
	$v("Hdisreply","false");
	visible=false; 
	setfocus("starttalkBtn");
}


//点我要留言时的反应
function iwillReply(){
	showLayer('starttalkForm');
	hideLayer('starttalk');
	visible=true;
	$('TBody').focus();
}
//回复留言
function ReplyReply(ownerid,logid,type){
	if ($v('TBody')==""){
		return;
	}
	var IsReplyPost;
	if(IsReplyPost) return;
	IsReplyPost=true;
	var buptext=$v('Bup');
	$v('Bup',"正在提交,请稍等...");
	$('Bup').disabled=true;
	var tbody=$v('TBody');
	var replyid=$v('Hdreplyid');
	var isreply=$v('Hdisreply');
	if (logid==null) logid=0;
	if (type==null) type=0;
	PageMethods.ReplyReply(logid,tbody,replyid ,isreply,ownerid,type,function(r) {//删除留言的返回事件
	var rcount=0;
	if($("rCount"))
		rcount=parseInt($h("rCount"));
	if (r=='0'||r=='undefine')
		showMessage("ReplyMsg","留言时服务器发生异常");
	else{
		if($("rCount"))
			$h("rCount",rcount+1);
		if(logid==0)
			$h("talk",r+$h("talk"));
		else
			$h("talk",$h("talk")+r);
	}
	$v('Bup',buptext);
	$('Bup').disabled=false;
	cancelLeaveWord();
	},onfail);
	isreply = "false";
	replyid.Value = 0;
	tbody = '';
	IsReplyPost=false;
}


function CtrlEnterReply(Logid,event){
  if((event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83) ){ 
	ReplyLogBook(Logid);
  }
}
function CtrlEnterReplyUser(ownerid,event){
  if((event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83) ){ 
	ReplyReply(ownerid);
  }
}
function onSeeReply(id){
	ChAlumna.Comment.SeeReply(id,function(r){
		if(r){
		hideLayer("comment_see_"+id);
		}
	},onfail);
}
function onSeeAll(){
	ChAlumna.Comment.SeeAll(function(r){
		if(r){
			setpage($v("HdPage"));
			alertEx('设置成功');
		}
	},onfail);
}