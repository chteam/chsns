/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />


// 2007 9 20 Le:10 19
var EditInfoBool=new Array();
var $t=Chsword.PageType;
var $ot=Chsword.OptionType;
var $msgt,nnow;
var $msg_inc,$msgsc;//收件箱的个数和发件箱的个数
function setTab(i){
	if(i==2||i==3){
		hideLayer("PageUp");
		hideLayer("PageDown");
	}
	var n,t;
	$common.setVisible($get("tabCompose"), false);
	setRead(false);
	switch(i){
		case 0:nnow="Inbox";$msgt=$t.Inbox;break;
		case 1:nnow="Sent";
		$msgt=$t.Sent;
		break;
		case 2:nnow="Edit";
		//$msgt=$t.Edit;
		$common.setVisible($get("tabCompose"), true);return;
		case 3:nnow="Read";
		//$msgt=$t.Read;
		setRead(true);return;
	}
	if(EditInfoBool[i]){
		if($msg_inc&&$msgt==$t.Inbox)
		$get("HdCount").value=$msg_inc;
		if($msgsc&&$msgt==$t.Sent)
		$get("HdCount").value=$msgsc;
		if($get("HdCount").value>20){
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount",20);
		//return;
		}
	}
	EditInfoBool[i]=true;
	setpage(1);
}
function setpage(_){
	$get("ch"+nnow).innerHTML="正在读取页面...";
	PageMethods.ResponsePage(_,20,$msgt,function(r){
		$get("ch"+nnow).innerHTML=r.ResponseText;
		$get("HdPage").value=_;
		$get("HdCount").value=parseInt(r.Count);
		if($msgt==$t.Inbox)$msg_inc=parseInt(r.Count);
		if($msgt==$t.Sent)$msgsc=parseInt(r.Count);
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount",20);
	},onfail);
	
}
function ShowMessage(_){
var tabs=$find('chcontent');
	var i=tabs.get_activeTabIndex();
	PageMethods.ReadMessage(_,(i==0),function(r){
		$get("Message_author").innerHTML=r.Name;
		$get("Message_author").href=String.format("/User.aspx?userid={0}",r.Toid);
		$get("Message_time").innerHTML=r.Sendtime.format("yyyy-MM-dd HH:mm");
		$get("Message_text").innerHTML=r.Body;
		$get("Message_mode").innerHTML=(i==0)?"来自":"发给";
		if(i==0)//inbox
		{
		showLayer("Message_inshow","inline");
		$get("Message_inshow").href=String.format("javascript:ReplyMessage({0},'{1}')",r.Toid,r.Name);
		}
		else{
			hideLayer("Message_inshow");	
		}
		$get("Message_back").innerHTML=String.format("回{0}件箱",(i==0)?"收":"发");
		$get("Message_back").href=String.format("javascript:$find('chcontent').set_activeTabIndex({0})",i);
		$get("Message_delete").href=String.format("javascript:DeleteMessage({0})",r.Messageid);
		var dt = new Date(); 
		showEditmsg("读取完成" + dt.localeFormat("MM月dd日 HH:mm:ss .fff"));
		tabs.set_activeTabIndex(3);//切换到读取那页
	},onfail);
		$get("HdCount").value=1;
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount",20);
}
function ActiveTabChanged(sender, e) {
	var i=$find('chcontent').get_activeTabIndex();
	setTab(i);
}
function showEditmsg(m){
	showMessage("Status",m,3000);
}

function setRead(v){
	$common.setVisible($get("tabRead"), v);
}
function ReplyMessage(d,n){
	$get("Receive_man").innerHTML=n;
	$get("Receive_man").href=String.format("/User.aspx?userid={0}",d);
	$get("Toid").value=d;
	$get("Toname").value=n;
	$find('chcontent').set_activeTabIndex(2);
	
	$get("HdCount").value=1;
	PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount",20);
}

function SendMessage(){//发送站内小条
	alertEx("正在向服务器提交信息...");
	var mm=new Chsword.Datamodel.MessageModel();
	mm.Title=$get("Ttitle").value;
	mm.Body=$get("Tbody").value;
	mm.Toid=$get("Toid").value;
	PageMethods.OptionMessage(mm,$ot.Add,function(r){
		alertEx(r);
		setInbox();
	},onfail);
}

function DeleteMessage(_){
	alertEx("正在向服务器提交信息...");
	var mm=new Chsword.Datamodel.MessageModel();
	mm.Issent=($msgt!=$t.Inbox);
	mm.Messageid=_;
	PageMethods.OptionMessage(mm,$ot.Delete,function(r){
		setInbox();
		alertEx(r);
	},onfail);
}

function setInbox(){
	var i;
	if($msgt!=$t.Inbox){
		i=1;
	}else{
		i=0;
	}
	$find('chcontent').set_activeTabIndex(i);
	EditInfoBool[i]=false;
	setTab(i);
	PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount",20);
}

function checkFormAll(chk){//对check全选
form = document.getElementById("aspnetForm");
for(var i=0; i<form.elements.length; i++){
if (form.elements[i].type=="checkbox"){
form.elements[i].checked = chk;}}}


var Message_DeleteAll=function(str){
	var tbody=$get("Message_tbody"+str);
	var trs=tbody.getElementsByTagName("tr");
	var Arrnum=Array();
	var id;
	for(var i=0; i<trs.length; i++){
		id=trs[i].id.replace("Message_tr","");
		if($get("MessageCheck"+id).checked){
			Arrnum.push(id);	
		}
	}
	if(Arrnum.length<1){
		alertEx('请至少选择一个要删除的小条');
		return;
	}
	Chsword.Message.Remove_Select(Arrnum.join(','),(str=='Sent')?0:1,function(r){
		alertEx(r);
		setpage($get("HdPage").value);
	},onfail);
};