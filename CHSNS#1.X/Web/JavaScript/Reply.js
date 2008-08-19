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
	$v('TBody',"@"+username+"\n");
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
	GetVm("/html/Reply.ashx","logid="+logid+"&body="+tbody+"&replyid="+replyid+"&isreply="+isreply+"&ownerid="+ownerid+"&type="+type,function(r){
		var rcount=0;//删除留言的返回事件
		if($("rCount"))
			rcount=parseInt($h("rCount"));
		if($("rCount"))
			$h("rCount",rcount+1);
		if(logid==0)
			$h("talk",r.get_responseData()+$h("talk"));
		else
			$h("talk",$h("talk")+r.get_responseData());
		$v('Bup',buptext);
		$('Bup').disabled=false;
		cancelLeaveWord();
	});
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
	$ws('Comment.asmx/SeeReply','{"id":'+id+'}',function(r){
		hideLayer("comment_see_"+id);
	});
}
function onSeeAll(){
	$ws('Comment.asmx/SeeAll','',function(){
		setpage($v("HdPage"));
		alertEx('设置成功');
	});
}