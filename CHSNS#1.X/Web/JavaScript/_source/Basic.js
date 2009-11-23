/// <reference name="MicrosoftAjax.debug.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

/*===================================================
ChAlumna JavaScript Basic Library
2007 12 16 zoujian
===================================================*/
var isIE=function(){return Sys.Browser.agent==Sys.Browser.InternetExplorer;};
if(!isIE()){
    HTMLElement.prototype.__defineGetter__("innerText", 
        function(){return this.textContent;}
    );
    HTMLElement.prototype.__defineSetter__("innerText", 
        function(v){this.textContent=v;}
    );
}
if(typeof(HTMLElement)!="undefined"&&!window.opera){
		HTMLElement.prototype.__defineGetter__("outerHTML",function(){  
		var a=this.attributes,str="<"+this.tagName,i=0;
			for(;i<a.length;i++){
				if(a[i].specified){str+="   "+a[i].name+'="'+a[i].value+'"';}
			}
          if(!this.canHaveChildren){return str+"   />";}
          return str+">"+this.innerHTML+"</"+this.tagName+">";
      });
      HTMLElement.prototype.__defineSetter__("outerHTML",function(s){
		var d= document.createElement("DIV");
		d.innerHTML=s;  
		for(var i=0;i<d.childNodes.length;i++){
			this.parentNode.insertBefore(d.childNodes[i],this);  
		}
		this.parentNode.removeChild(this);  
      });   
      HTMLElement.prototype.__defineGetter__("canHaveChildren",function(){  
            return !/^(area|base|basefont|col|frame|hr|img|br|input|isindex|link|meta|param)$/.test(this.tagName.toLowerCase());  
      });
}
var $=$get;
var $v=function(i,v){if(v){$(i).value=v;}else{return $(i).value;}};
var $s=function(i){return $(i).style;};
var $h=function(i,v){if(typeof v!=="undefined"&&v!=null){$(i).innerHTML=v;}else{return $(i).innerHTML;}};
var isExists=function(v){return typeof v!=="undefined"&&v!=null;};
var showMessage=function(id,message,timeout){//show Message
	var timeoutSeed;
	if($(id)){
		$h(id,message);
		if(timeout==null)timeout=3000;
		if (timeoutSeed){
			window.clearTimeout(timeoutSeed);
		}
		timeoutSeed = window.setTimeout(
			function(){
				$h(id,""); 
			},
			timeout || 3500
		);
	}else alertEx(message);
};
//Layer Opteration
var showLayer=function(_,m){//show
	if($(_)){
		if(isExists(m)){
			$s(_).display=m;
		}else{
			$s(_).display="block";
		}
	}
};
var hideLayer=function(_){//hide
	if($(_)){
			$s(_).display="none";
	}
};
//Html Operation
var setfocus=function(_){//????
	if($(_)){
		var c = $(_);
		if (c.type != "hidden" && !c.disabled){
			c.focus();
		}
	}
};
var OpenSearch=function(p){
	window.open('/Search.aspx?' + encodeURIComponent(p));
};
var ButtonBack=function(){history.go(-1);};
var SearchEnter=function(e,i){
	if(e.keyCode == 13){
		HomeSearch((i==null)?'search_username':i);
	}
};
var HomeSearch=function(i){
	location='/Search.aspx?action=name&username='+$v(i);
}
//child is empty then hide parent
var ShoworHide=function(_,i){
	if(!isExists(i))i = "ch"+_;
	if($(i)&&$(_))
		if (!$h(i)||$h(i).trim()=='')
				hideLayer(_);
};
var SetActiveText=function(i){Sys.UI.DomElement.addCssClass(i,"activetab");};
//------------------------------------------------Ajax Tool kit
var InitTabP=function(_){//
	Sys.Application.add_init(function(){
		$create(AjaxControlToolkit.TabPanel,
		{"headerTab":$("tab"+_)},
		null, {"owner":"chcontent"},
		$("ch"+_));
	});
};
var InitTabC=function(_,change){//
	Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.TabContainer,
		{"activeTabIndex":_,
		"clientStateField":$("ClientState")},
		 {"activeTabChanged":change==null?ActiveTabChanged:change},
		 null, $("chcontent"));
	});
};
var Tabs=function(){
	if(!$find('chcontent')) return;
	var i=$find('chcontent');
	Tabs=function(){
		return i;
	};
	return Tabs();
};
var InitCalendar=function(_){
	Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.CalendarBehavior, {"button":$(_+"but"),"format":"yyyy-MM-dd","id":"CalendarExtender"+_}, null, null, $(_));
	});
};
var InitEditW=function(_i,_n){
	//Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.TextBoxWatermarkBehavior, {"ClientStateFieldID":"","WatermarkCssClass":"watermarked","WatermarkText":_n,"id":"Watermark"+_i}, null, null, $(_i));
	//});
};
var InitModalPopup=function(_){
	Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.ModalPopupBehavior, {"BackgroundCssClass":"modalBackground","CancelControlID":"message_cancel","PopupControlID":_,"dynamicServicePath":"/default.aspx","id":"ModalPopup"+_}, null, null, $("extendDiv4"));
	});
};
var InitAutoComplete=function(_,Method,context){//_ is text box id,context
    $create(AjaxControlToolkit.AutoCompleteBehavior,
    {	"completionInterval":400,
		"completionSetCount":10,
		"delimiterCharacters":"",
		"minimumPrefixLength":1,
		"id":"autoComplete"+_,
		"serviceMethod":Method,
		"servicePath":"WebServices/AutoComplete.asmx",
		"useContextKey":(context!=null),
		"contextKey":(context==null)?"":context
		}, null, null, $(_));
};
var InitShadow=function (_){
	Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.DropShadowBehavior,
		{"Opacity":0.75,"Radius":10,"Rounded":false,
		"TrackPosition":true,"id":"DropShadow"+_}, null, null, $(_));
	});
};
function InitDropDown(tid){
if($(tid))
//Sys.Application.add_init(function() {
    $create(AjaxControlToolkit.DropDownBehavior,
    {"dropDownControl":$(tid+"_Items"),
	"highlightBackgroundColor":"#5c75aa",
    "dropArrowBackgroundColor":"#5c75aa",
    "id":"DropDownBehavior_"+tid},
    null, null, $(tid));
  ///  });
}
function InitRoundCorners(id){
	Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.RoundedCornersBehavior,
		{"Radius":10,"id":"RoundedCornersBehavior"+id}, null, null, $(id));
	});
}
var ModalPopup=function(){
	var mp=$find("ModalPopupmessage");
	ModalPopup=function(){
		return mp;
	};
	return ModalPopup();
};
var showModalPopup=function(){
    ModalPopup().show();
    setfocus("message_button");
};
var hideModalPopup=function(){
	$h("message_body","");
    ModalPopup().hide();
};
var setModalPopup=function(_,but_text,but_click){
	var h=$("message_body");
	var b=$("message_button");
	setModalPopup=function(_,but_text,but_click){
			showModalPopup();
			if(but_text!=null)
				b.value=but_text;
			$clearHandlers(b);
			if(but_click!=null){	
				$addHandler(b,"click",but_click);
			}
			if(h.innerHTML.length>300)
				h.innerHTML='';
			h.innerHTML=String.format("{0}<br />{1}",h.innerHTML,_);
    };
    return setModalPopup(_,but_text,but_click);
};
//Ext
var alertEx=function(_){
    setModalPopup(_);
};
var W_Match=function(_){//
  return ($find("Watermark"+_).get_WatermarkText()==$v(_))||($v(_)=="");
};
var $get_WText=function(_){
  return $find("Watermark"+_).get_Text();
};
function InitDragItem(_){
	Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.DraggableListItem, {
		"handle":$(_),
		"id":"DraggableListItem"+_}, null, null, 
		$(_));
	});
}

function InitDragWatcher(_,item){
	Sys.Application.add_init(function() {
		$create(AjaxControlToolkit.DragDropWatcher, {
		"ClientStateFieldID":"ctl00_SampleContent_ReorderList1__ClientState",
		"acceptedDataTypes":"HTML_ReorderList1",
		"callbackCssStyle":"callbackStyle",
		"dragDataType":"HTML_ReorderList1",
		"dragMode":1,
		"dropCueTemplate":$(item),
		"id":"ReorderListItemEx"+_,
		"postbackCode":""
		}, null, null, $(_));
	});
}
//-----------------------------------------------PageMothed--------------------------------------------------------------
var onfail=function(_){
	alertEx(chRes.warning + ":" + _.get_message() + "<br />");
	Sys.Debug.traceDump(_.get_stackTrace());
};
//Logina and Logout
function Login(){
	var U=$v("Username");
	if(!Regtest("Username",/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*|\d+/)){
		LoginMsg(chRes.wrongun);
		return;
	}
	var P=$v("Userpwd");
	if(P.length<4){
		LoginMsg(chRes.wrongpw);
		return;
	}
	ChAlumna.Identity.Login(U,P,$("autoLogin").checked,function(r){
		if(r){
			window.location.href="/Event.aspx";
		}
		else{
			LoginMsg(chRes.wrongup);
		}
	},onfail);
	$h("loginmsg",chRes.ving);
}
var EnterUsername=function(event){
  if(event.keyCode == 13){ 
	setfocus("Userpwd");
  }
};
var EnterLogin=function(event){
  if(event.keyCode == 13){ 
	Login();
  }
};

function LoginMsg(m){
	showMessage("loginmsg",m,3000);
}
function Logout(){
	ChAlumna.Identity.Logout(function(){
		window.location="/";
	},onfail);
}
function showTabsmsg(m){
    showMessage("TabsStatus",m,3000);
}

//valitate
function Regtest(id,reg){
	return reg.test($v(id));
}
var validate_regex=function(id,myreg,allowempty,msg,p){//isnone allow empty
	if(p==null) p=id+"msg";
	$s(p).visibility="hidden";
	var isempty=false;
	if(!allowempty){
		isempty=isEmpty(id);
	}
	if(!myreg.test($v(id))||isempty){
		if(msg!=null){
			$h(p,msg);
		}
		$s(p).visibility="visible";
		return false;
	}
	return true;
};
var validate_empty=function(id,msg,p){//pÎªÏÔÊ¾¿é
	if(p==null) p=id+"msg";
	$s(p).visibility="hidden";
	if(isEmpty(id)){
		if(msg!=null){
			$h(p,msg);
		}
		$s(p).visibility="visible";
		return false;
	}
	return true;
};
var validate_equals=function(id1,id2,msg,p){//id2 is the span that show error
	if(p==null) p=id2+"msg";
	$s(p).visibility="hidden";
	if($v(id1)!=$v(id2)){
		if(msg!=null){
			$h(p,msg);
		}
		$s(p).visibility="visible";
		return false;
	}
	return true;
};
var isEmpty=function(_){
	if($(_)){
		return ($v(_).trim().length<1);
	}
	return true;
};
var isNum=function(_){
  if(!_) return false;
  var strP=/^\d+(\.\d+)?$/;
  if(!strP.test(_)) return false;
  try{
  if(parseFloat(_)!=_) return false;
  }catch(ex){return false;}
  return true;
};
//==============================Preview
function InitHistory(){
	if(isIE()){//in Ie do it from iframe
	    var i = document.createElement("<iframe id=\"__historyFrame\" style='display:none;' src='/Template/History.htm' scrolling='no' frameborder='0' />");
	    $h("extendDiv6",i);
	}
	Sys.Application.add_init(function() {
		  var h = Sys.Application.get_history();
		  h.setServerId("History1", "History1");
	});
}

//Cache in Client
var GetVm=function(page,query,onsuccess){
	var request=new Sys.Net.WebRequest();
	request.set_url(page);
	request.set_httpVerb("POST");
	request.add_completed(onsuccess);
	request.set_body(query);
	request.invoke(); 
};
var GetTemplate=function(_,onsuccess,Context){//_is the template name 2007 9 26 zsword
    ChAlumna.Identity.GetTemplate(_,onsuccess,onfail,Context);
};
function GetConfig(fn,name){
	if(isEmpty(fn)){
		ChAlumna.Identity.GetConfig(name,onsuccess,onfail,Context);
	}else{
		ChAlumna.Identity.GetConfig(fn,name,onsuccess,onfail,Context);
	}
}
function QueryString(fieldName){  
  var urlString = document.location.search;//urlString??info=1&name=2
  if(urlString != null){
          var typeQu = fieldName+"=";
          var urlEnd = urlString.indexOf(typeQu);//find the postion of info=1, is 1
		if(urlEnd != -1){
               var paramsUrl = urlString.substring(urlEnd+typeQu.length);//paramsUrl=1&name=2
               var isEnd =  paramsUrl.indexOf('&');
               if(isEnd != -1){
                    return paramsUrl.substring(0, isEnd);//info=1
                }else{
                    return paramsUrl;//only 1 param
                }
         }else 
             return "";//there's no info=1
    }else
        return "";//no Url with params
}
var get_Viewerid=function(){
	var viewerid=$v("Hduserid");
	if($v("Hduserid")=="")
	viewerid=0;
	get_Viewerid=function(){
		return viewerid;
	};
	return get_Viewerid();
};
//Path part
var ClientUserFolder=function(userid){
	var u=new String(userid);
	return String.format(
	"/userFiles/{0}/{1}/{2}/{3}/", 
	u.substring(u.length - 2,u.length - 1), 
	u.substring(u.length - 1,u.length),
	u.substring(u.length - 3,u.length - 2),
	u);
};
var ClientUserThumbFolder=function(userid){
	return String.format("{0}Thumb/",ClientUserFolder(userid));
};
var ClientUserPhotosFolder=function(userid){
	return String.format("{0}Photos/",ClientUserFolder(userid));
};
var GetFileNameWithoutExtension=function(path){
    if (path == null){return null;}
    var length = path.lastIndexOf('.');
    if (length == -1){return path;}
    return path.substring(0, length);
};
var SendMessage=function(i,n){
	window.open(String.format('/Message.aspx?mode=compose&ToId={0}&Toname={1}&',i,encodeURIComponent(n)));
	return;
};