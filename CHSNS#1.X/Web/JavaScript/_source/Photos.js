/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />
/// <reference path="http://localhost/WebServices/Photos.asmx/jsdebug" />
/// <reference path="PageSet.js" />


//public protype
var get_Albumid=function(){
	var Albumid=$get("HdAlbumid").value;
	get_Albumid=function(){
		return Albumid;
	};
	return get_Albumid();
};
var set_Albumid=function(value){
	$get("HdAlbumid").value=value;
};
//photos
var $AblumItem,$PhotoItem;


var setPhototab=function(_){
	if(Tabs())
		Tabs().get_tabs()[1].set_enabled(_==1);
	switch(_){
		case 0:
			PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage","Albumpage");
			break;
		case 1:
			//showCreate();
			hideLayer("tabSet");
			break;
	}
}
var Albumpage=function(p){//鄱页
	$get("HdPage").value=p;
	if ($AblumItem==null){
		GetTemplate("Albumitem",function(r){
		    var edit='<li>|</li><li><a href="javascript:ShowEdit({0});">编辑</a></li><li>|</li><li><a href="javascript:DeleteAlbum({0});">删除</a></li>';
			$AblumItem=r.replace("$Albumitem$","");
			if($get("HdOwnerid").value==get_Viewerid()){
				$AblumItem=$AblumItem.replace('$Edit$',edit);
			}else{
				$AblumItem=$AblumItem.replace('$Edit$','');
			}
			set_Ablumslist();
		});
	}else{
		set_Ablumslist();
	}
};
var set_Ablumslist=function(){
	ChAlumna.Photos.AlbumsTable($get("HdOwnerid").value,$get("HdPage").value,6,function(r){
		var builder = new Sys.StringBuilder("");
		var rows = r.rows;
		if(!rows) {
			builder.append("列表为空");
			return;
		}
		for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
			builder.append(
				String.format($AblumItem,
				rows[rowIndex]["id"],
				rows[rowIndex]["Count"],
				rows[rowIndex]["Albumname"],
				rows[rowIndex]["Description"],
				rows[rowIndex]["Addtime"].format("yy年MM月dd日"),
				rows[rowIndex]["Location"],
				String.format("{0}{1}.jpg",
				ClientUserThumbFolder($get("HdOwnerid").value),
				GetFileNameWithoutExtension(rows[rowIndex]["faceurl"])
				),
				$get("HdOwnerid").value
				)
			);
		}
		$get("Albumitem").innerHTML=builder;
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage","Albumpage");
	},onfail);
};
var PhotosChangeTab=function(sender,e){//Photos.aspx change tabs
	var i=Tabs().get_activeTabIndex();
	setPhototab(i);
};
var showCreate=function(){
	Tabs().get_tabs()[1].set_enabled(true);
	$get("fl_neworedit").innerHTML="新建相册";
	Tabs().set_activeTabIndex(1);
	$get("f_pshowlevel").value=0;
	$clearHandlers($get("f_pok"));
	$addHandler($get("f_pok"),"click",CreateAlbum);
};
var CreateAlbum=function(){
	if(isEmpty("f_pname")){
		showMessage("msgf_pname","请输入相册名称");
		return;
	}
	ChAlumna.Photos.Album_Add($get("f_pname").value,$get("f_plocal").value,$get("f_pdesc").value,$get("f_pshowlevel").value,function(r){
		alertEx(r);
		Albumpage($get("HdPage").value);
		Tabs().set_activeTabIndex(0);
	},onfail
	);
};
var ShowEdit=function(_){
	set_Albumid(_);
	$get("f_pname").value=$get("Album_Name"+_).innerHTML;
	$get("f_plocal").value=$get("Album_Loca"+_).innerHTML;
	$get("f_pdesc").value=$get("Album_Desc"+_).innerHTML;
	$get("fl_neworedit").innerHTML="编辑相册 - "+$get("f_pname").value;
	Tabs().set_activeTabIndex(1);
	$get("f_pshowlevel").value=0;
	$clearHandlers($get("f_pok"));
	$addHandler($get("f_pok"),"click",EditAlbum);
};
var EditAlbum=function(){
	if(isEmpty("f_pname")){
		showMessage("msgf_pname","请输入相册名称");
		return;
	}
	ChAlumna.Photos.Album_Update(get_Albumid(),$get("f_pname").value,$get("f_plocal").value,$get("f_pdesc").value,$get("f_pshowlevel").value,function(r){
		alertEx(r);
		Albumpage($get("HdPage").value);
		Tabs().set_activeTabIndex(0);
	},onfail
	);
};
var pCancle=function(){
	Tabs().set_activeTabIndex(0);
};
var DeleteAlbum=function(i){
	if(confirm("您要删除这个相册吗?")){
		ChAlumna.Photos.Album_Remove(i,function(r){
			alertEx(r);
			hideLayer("Album_li"+i);
		},onfail);
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage","Albumpage");
	}
};


//end photos





function ActiveTabChanged(sender, e) {
	var i=Tabs().get_activeTabIndex();
	setTab(i);
}

var setTab=function (_){
	if(Tabs())
		Tabs().get_tabs()[1].set_enabled(_==1);
	switch(_){
		case 0:
			PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
			break;
		case 1:
			break;
	}
};
var setpage=function (p){
	$get("HdPage").value=p;
/*	if ($PhotoItem==null){
		GetTemplate("Photoitem",function(r){
		    var edit='<a href="javascript:DeletePhoto({0},\'{4}\');">删除</a>';
			$PhotoItem=r.replace("$Photoitem$","");
			if($get("HdOwnerid").value==get_Viewerid()){
				$PhotoItem=$PhotoItem.replace('$Edit$',edit);
			}else{
				$PhotoItem=$PhotoItem.replace('$Edit$','');
			}
			set_Photoslist();
		});
	}else{*/
		set_Photoslist();
//	}
};
var set_Photoslist=function(){
		GetVm("/html/PhotoList.ashx","ownerid="+$v("HdOwnerid")+"&nowpage="+$v("HdPage")+"&albumid="+get_Albumid(),function(r){
$get("Photoitem").innerHTML=r.get_responseData();
PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
		}
		);
	/*ChAlumna.Photos.PhotosRows(get_Albumid(),$v("HdOwnerid"),$v("HdPage"),16,function(r){
		var builder = new Sys.StringBuilder("");
		var rows = r.rows;
		if(!rows) {
			builder.append("列表为空");
			return;
		}
		for (var rowIndex = 0; rowIndex < rows.length; ++ rowIndex) {
			builder.append(
				String.format($PhotoItem,
				rows[rowIndex]["id"],
               	rows[rowIndex]["Photoname"],
               	rows[rowIndex]["Addtime"].format("yy年MM月dd日"),
				String.format("{0}{1}.jpg",
				ClientUserThumbFolder($get("HdOwnerid").value),
				GetFileNameWithoutExtension(rows[rowIndex]["Path"])
				),
				String.format("{0}{1}",
				ClientUserPhotosFolder($get("HdOwnerid").value),
				rows[rowIndex]["Path"]
				)
				)
			);
		}
		$get("Photoitem").innerHTML=builder;
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
	},onfail);*/
};
var ShowUpload=function(){
	showModalPopup();
	uploadcreate($get('message_body'),null,"albumid="+get_Albumid(),"photoupload");
};


var showPic=function(_){
	$get("chSee").innerHTML=String.format('<ul><li><a href="javascript:Tabs().set_activeTabIndex(0);"><img src="{0}" alt="点击返回相册" style="max-width:400px;" />点击返回相册</a></li></ul>',_);
	setTab(1);
	Tabs().set_activeTabIndex(1);
	hideLayer("tabSee");
};

var uploadsuccess = function(showul,itemid){
    $get("uploading"+itemid).innerHTML=("文件上传成功.");
	$get("chSee").innerHTML=showul;
    setpage($get("HdPage").value);
    Tabs().set_activeTabIndex(1);
};

var DeletePhoto=function(id,path){
	if(confirm("您要删除这个照片吗?")){
		ChAlumna.Photos.Photo_Remove(id,path,function(r){
			hideLayer("Photo_li"+id);
			alertEx(r);
		},onfail);
		PageSet_chSetPage("PageUp","PageDown","HdPage","HdCount","HdEveryPage");
	}
};
var Photo_Cover=function(id){
	ChAlumna.Photos.Photo_Cover(id,function(r){
			if(r){
				alertEx("设置成功");
			}
			else{
				alertEx("设置失败");
			}
	},onfail);
};