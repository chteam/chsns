/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />


var $temp_note,$temp_comment,$chWrite;
var $NoteBool=new Array();
function ActiveTabChanged(sender, e) {
var i=$find('chcontent').get_activeTabIndex();
setTab(i);

}
function setTab(i){
	if(i==2){
		if(!$NoteBool[2])
			$chWrite=$get('chWrite').innerHTML;
		else
			$get('chWrite').innerHTML=	$chWrite;
      var oFCKeditor = new FCKeditor( 'tbody' ) ;
      if($get("Hdisrich").value=="false")
      oFCKeditor.ToolbarSet ='Basic';
      oFCKeditor.Width = '100%' ;
      oFCKeditor.Height = '200' ;
      
      oFCKeditor.ReplaceTextarea() ;
	}
if($NoteBool[i]) return;
var ui=$get("Hdownerid").value;
switch(i){
	case 0:
	ChAlumna.NoteBook.GetHistoryPage(ui,function(r){
		$get("chHistory").innerHTML=r;
	},onfail);
	break;
	case 1:
	ChAlumna.NoteBook.GetCommentPage(ui,function(r){
		$get("chFeedback").innerHTML=r;
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
	},onfail);
	break;
	}
	$NoteBool[i]=true;
	AjaxControlToolkit.Animation.FadeInAnimation.play($get("chcontent"),
 1, 25, 0.2, 1, false);
}

function SaveNote(){//notebook页的发表日志
	var oE = FCKeditorAPI.GetInstance("tbody");
	if($get("subject").value==''){
		$get('Alert').innerHTML="请输入标题";
	return;
	}
	if(oE.GetHTML().length<10){
		$get('Alert').innerHTML="您输入内容的太少";
	return;
	}
	alertEx("正在向服务器提交信息...");
	ChAlumna.NoteBook.Note_Add(0,$get("subject").value,oE.GetXHTML(true),$get("Right").value,function(r){
		alertEx("保存日志成功");
		$get('subject').value="";
		oE.SetHTML("");
		$NoteBool[0]=false;
		$find('chcontent').set_activeTabIndex(0);
	},onfail);
}

function CurrentList(year,month){//当前的年月
	if($get("Summarylistname").innerHTML==String.format("{0}年{1}月",year,month)) return;
	if ($temp_note==null){
		GetTemplate("Note",function(r){
			$temp_note=r.replace("$Summarylist$","");
			showCurrentList(year,month);
		});
	}else{//已经加载模板的情况下
		showCurrentList(year,month);
	}
}
function showCurrentList(year,month){
		var userid=$get("Hdownerid").value;
		ChAlumna.NoteBook.SummaryTable(userid,year,month, function(r){
			var builder = new Sys.StringBuilder("");
			var rows = r.rows;
			//debuger;
			for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
				builder.append(
					String.format($temp_note,
					rows[rowIndex]["AddTime"].format("MM月dd日"),
					rows[rowIndex]["AddTime"].format("yyyy-MM-dd hh:mm"),
					rows[rowIndex]["id"],
					rows[rowIndex]["title"],
					rows[rowIndex]["body"].replace(/(<[^>]+>)/g,''),
					rows[rowIndex]["ViewCount"],
					rows[rowIndex]["CommentCount"], 
					rows[rowIndex]["PushCount"]
					)
				);
			}
			$get("Summarylist").innerHTML=builder;
			$get("Summarylistname").innerHTML=String.format("{0}年{1}月",year,month);
		},onfail);
}
function setpage(_){
	if ($temp_comment==null){
		GetTemplate("NoteBookCommentItem",function(r){
		//Sys.Debug.trace(r);
			$temp_comment=r.replace("$Commentlist$","").replace(/<!--[/!]*?[^<>]*?>$/,'');
			showCommentlist(_);
		});
	}else{//已经加载模板的情况下
		showCommentlist(_);
	}
	

}
function showCommentlist(_){
	$get("HdPage").value=_;
	var userid=$get("Hdownerid").value;
	var p1=$get("HdPage").value;
	var p2=$get("HdEveryPage").value;
	ChAlumna.NoteBook.CommentTable(userid,p1,p2,function(r){
	var builder = new Sys.StringBuilder("");
				var rows = r.rows;
				//debuger;
				for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
					builder.append(
						String.format($temp_comment,
						rows[rowIndex]["addtime"].format("MM-dd hh:mm"),
						rows[rowIndex]["senderid"],
						rows[rowIndex]["name"],
						rows[rowIndex]["body"].replace(/(<[^>]+>)/g,''),
						rows[rowIndex]["title"],
						rows[rowIndex]["logid"]
						)
					);
				}
				$get("Commentlist").innerHTML=builder;
				PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
	},onfail);
}