var $isEdit=false;
function PushLogBook(Logid){//此ID为Logid
	var pc=$("PushCommand");
	pc.innerHTML='正在提交请求...';
	var params={logid:Logid};
	$ws('NoteBook.asmx/Note_Push',$toJSON(params),function(r){
		if (r==""){
			var count=0;
			if($get("PushCount"+Logid)!=null){
				count=parseInt($h("PushCount"+Logid));
				$("PushCount"+Logid).innerHTML=count+1;
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
	var params={groupid:groupid,title:_subject,body:_body,showlevel:right,istellme:false,tags:''};
	$ws('NoteBook.asmx/Note_Add',$toJSON(params),function(r){
		alertEx("发帖成功");
		addRow(r,groupid,_subject);
		$('subject').value="";
		oEditor.SetHTML("");
		location="#groupForum";
	});
}
function GroupMsg(msg){
	showMessage("Alert",msg, 3000)
}
function DeleteLogBook(logid,groupid){
	alertEx("正在删除...");	
	var params={logid:logid,groupid:groupid};
	$ws('NoteBook.asmx/Note_Delete',$toJSON(params),function(){
		alertEx('返回上一页','location=document.referrer;');
	});
}
function showEditNote(){
	if($isEdit)return;
	var html=$h('showbody');
	$('showbody').innerHTML='<textarea id="tbody" rows="2" cols="20"></textarea>';
	$('tbody').value=html;
	var fck = new FCKeditor('tbody') ;
	if($v("Hdisrich")=='false')
		fck.ToolbarSet='Basic';
	fck.Width = '100%' ;
	fck.Height = '200' ;
	fck.ReplaceTextarea();
  //  $v("tags",$("full_tags").innerText.replace(/(\s*|\r\n*)/ig,''));
    hideLayer("entrytags");
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

	var params={groupid:$groupid,logid:$logid,body:mybody,showlevel:right,istellme:$("istellme").checked,tags:''};
	$ws('NoteBook.asmx/Note_Edit',$toJSON(params),function(){
		$('showbody').innerHTML=mybody;
		hideLayer('showbutton');
		$isEdit=false;
		alertEx("保存成功");
	});
}
function Note_top(){
	ChAlumna.NoteBook.Note_Top($logid,$groupid, function(r){
		if(r){
			alertEx("设置成功");
			$("notetop").href="javascript:Note_untop();"
			$("notetop").innerHTML="取消置顶"
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