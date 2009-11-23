/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

///////////////////////////////////////////////////////////////////////////////
// LogBook.js 操作成幻校友录日志
// 邹健 2007 08 17
// LE:10 11
//
////////////////////////////////////////////////////////////////////////////////
var $isEdit=false;
function PushLogBook(Logid){//此ID为Logid
	var pc=$get("PushCommand");
	pc.innerHTML='正在提交请求...';
	var lm=new Chsword.Datamodel.LogBookModel();
	lm.Logid=Logid;
	PageMethods.OptionLogBook(lm,Chsword.OptionType.Push,function(r){
		if (r==""){
			var count=0;
			if($get("PushCount"+Logid)!=null){
				count=parseInt($get("PushCount"+Logid).innerHTML);
				$get("PushCount"+Logid).innerHTML=count+1;
			}
			pc.innerHTML="我已推荐过。";
		}else
			pc.innerHTML=r;
	});
	return;
}
function addRow(_,groupid,subject)
{
	var tb = document.getElementById("Subjectlist");
	var tbd = tb.getElementsByTagName("tbody")[0];
	var tr = document.createElement("tr");
	tr=tbd.insertRow(tb.getElementsByTagName("img").length);
	tr.appendChild(CreateTd("tit",String.format("<a href='/Note.aspx?id={0}&Groupid={1}&'>{2}</a>",_,groupid,subject)));
	tr.appendChild(CreateTd(null,"本人"));
	tr.appendChild(CreateTd(null,"0"));
	tr.appendChild(CreateTd(null,"0"));
	tr.appendChild(CreateTd(null,"<br /><br />"));
	if(tbd.getElementsByTagName("tr").length>20)
	tbd.removeChild(tbd.getElementsByTagName("tr")[20]);
}
function CreateTd(_,c){//_classname,c is connent
	var t = document.createElement("td");
	if(_)t.className=_;
	if(c)t.innerHTML=c;
	return t;
}
function PublishLog(groupid) {
	var _subject=$get('subject').value;
	if (''==_subject) {
		alertEx("请输入帖子标题");
		return 0;
	}
	var oEditor = FCKeditorAPI.GetInstance('tbody');
	var _body=oEditor.GetXHTML(true);//$get('tBody_ID').getHTML();
	if (''==_body) {
		alertEx("请输入帖子内容");
		return 0;
	}
	var right=0;
	if($get("Right"))right=$get("Right").value;
	ChAlumna.NoteBook.Note_Add(groupid,_subject,_body,right,function(r){
		if (isNum(r)){
			alertEx("发帖成功");
			addRow(r,groupid,_subject);
			$get('subject').value="";
			oEditor.SetHTML("");
			}
		else{
			alertEx(r);
		}
		location.href="#groupForum";
	},onfail);
}
function GroupMsg(msg){
	showMessage("Alert",msg, 3000)
}
function DeleteLogBook(logid,groupid){
	alertEx("正在删除...");
	var lm=new Chsword.Datamodel.LogBookModel();
	lm.Groupid=groupid;
	lm.Logid=logid;
	PageMethods.OptionLogBook(lm,Chsword.OptionType.Delete, function(r){
		setModalPopup(r,'返回上一页',function(){location.href=document.referrer;});
	},onfail);
}
function showEditNote(){
	if($isEdit)return;
	var html=$get('showbody').innerHTML;
	$get('showbody').innerHTML='<textarea id="tbody" rows="2" cols="20"></textarea>';
	$get('tbody').value=html;
	var fck = new FCKeditor('tbody') ;
	if($get("Hdisrich").value=='false')
		fck.ToolbarSet='Basic';
	fck.Width = '100%' ;
	fck.Height = '200' ;
	fck.ReplaceTextarea() ;
	showLayer('showbutton');
	$isEdit=true;
}
function EditNote(){
	var ofck = FCKeditorAPI.GetInstance('tbody');
	var mybody=ofck.GetXHTML(true);
	if (''==mybody) {
		alertEx("请输入帖子内容");
		return 0;
	}
	var right;
	if($get("Right"))
		right=$get("Right").value;
	else
		right=0;
	alertEx("正在向服务器提交修改...");
	ChAlumna.NoteBook.Note_Edit($groupid,$logid,mybody,right,function(r){
		alertEx(r);
		$get('showbody').innerHTML=mybody;
		hideLayer('showbutton');
		$isEdit=false;
	},onfail);
}
function Note_top(){
	ChAlumna.NoteBook.Note_Top($logid,$groupid, function(r){
		if(r){
			alertEx("设置成功");
			$get("notetop").href="javascript:Note_untop();"
			$get("notetop").innerHTML="取消置顶"
		}
		else
		alertEx("本帖不可操作");
		
	},onfail);
}
function Note_untop(){
	ChAlumna.NoteBook.Note_unTop($logid,$groupid, function(r){
		if(r){
			alertEx("设置成功");
			$get("notetop").href="javascript:Note_top();"
			$get("notetop").innerHTML="将本文置顶"
		}
		else
		alertEx("本帖不可操作");
	},onfail);
}