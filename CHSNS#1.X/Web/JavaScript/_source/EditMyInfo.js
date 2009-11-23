/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference path="basic.js" />


var EditInfoBool=new Array();
function ActiveTabChanged(sender, e) {
	var i=Tabs().get_activeTabIndex();
	setTab(i);
}
function setTab(i){
	var n;
	switch(i){
		case 0:n="Basic";break;
		case 1:n="School";break;
		case 2:n="Contact";break;
		case 3:n="Personal";break;
		case 4:n="MagicBox";break;
		case 5:n="UpLoad";break;
	}
	if(EditInfoBool[i]) return;
	GetVm("/html/ProfileEdit.ashx","template="+n,function(r){
		if (r.get_responseAvailable()){
			$("ch"+n).innerHTML=r.get_responseData();
			EditInfoBool[i]=true;
			if (i==0){
			    InitCalendar("Birthday");
			}
			if(i<4){Init_Profile(n.toLowerCase());}
			if(i==5){
				uploadcreate($('uploadfield'),1,"type=userface","upload");
			}
		}
		});
}
function showEditmsg(m){
	showMessage("Status",m);
}
function ChangeProvince(){
	var pid=$v("Province");
	if (pid<1) return;
	PageMethods.GetCityList(pid,function(r){
		$("CityPanel").innerHTML="<select id=\"City\" class=\"select\">"+r+"</select>";
	},onfail);
}
function SubmitInfo(_){
	var d;
	switch(_){
		case "basic":
			if(isEmpty("Name")){
				alertEx("请填写您的姓名");return;
			}
			if($v("Province")==0){
				alertEx("请选择省");return;
				}
			d={"name":$v("Name"),"birthday":$v("Birthday"),"sex":$v("Sex"),"province":$v("Province"),"city":$v("City"),"showlevel":$v(_+"_slider")};
			break;
		case "school":
			d={"xueyuan":$v("Xueyuan"),"grade":$v("Grade"),"qinshi":$v("Qinshi"),"showlevel":$v(_+"_slider")};
			break;
		case "contact":
			d={"telphone":$v("Telphone"),"mobiephone":$v("Mobiephone"),
			"msn":$v("Msn"),"qq":$v("Qq"),"website":$v("Website"),"showlevel":$v(_+"_slider")};
			break;
		case "personal":
			d={"lovelike":$v("Lovelike"),"lovebook":$v("Lovebook"),"lovemusic":$v("Lovemusic"),
			"lovemovie":$v("Lovemovie"),"lovesports":$v("Lovesports"),"lovegame":$v("Lovegame"),
			"lovecomic":$v("Lovecomic"),
			"joinsociety":$v("Joinsociety"),"showlevel":$v(_+"_slider")};
			break;
		case "magicbox":
			d={"magicbox":$v("Magicbox")};
		break;
		case "update":
		break;
		default:
			d={"none":""};
			break;
	}
	alertEx("正在提交...");
	PageMethods.SaveMyInfo(d,_,function(r){
			if(r=="turn"){
				if(Tabs().get_activeTabIndex()!=3){
					setModalPopup("保存成功,请点击[下一步]","下一步",toschool);
				}else{
					setModalPopup("保存成功,请点击[下一步]设置您的班级","下一步",toclass);
				}
				return;
			}
			if(r=="")
				alertEx("保存成功");
			else
				alertEx(r);
			if(_=="magicboxclear")
				$("Magicbox").value="";
	},onfail);
}

var toschool=function(){
	Tabs().set_activeTab(Tabs().getNextTab());
}
var toclass=function(){
	window.location.href="/ClassList.aspx";
}


function Init_Profile(id){
	if($(id+"_slider")){
		Sys.Application.add_init(function() {
			$create(AjaxControlToolkit.SliderBehavior,
			{"Minimum":0,
			"Maximum":200,
			"Steps":5,
			"TooltipText":"拖动设置隐私级别 由低-高",
			"id":id+"_Slider1"},
			null, null, $(id+"_slider"));
			set_SliderText(id);
			$find(id+"_Slider1").add_valueChanged(function(){set_SliderText(id);});
		});
	}
}
var set_SliderText=function(id){
	var res_SliderText={"200":"只有我","150":"我的好友","100":"同校","50":"所有大学生+好友","0":"所有人"};
	$(id+"_slider_BoundControl").innerHTML=String.format("[{0}]可以查看此部分",res_SliderText[$v(id+"_slider")]);
};