/// <reference path="jquery-1.2.3-intellisense.js" />
//common function
var isnull=function(v){return !(typeof v!=="undefined"&&v!=null);}
var $v=function(i,v){if(isnull(v)) return $(i).val();else $(i).val(v);};
var $h=function(i,v){if(isnull(v)){return $(i).html();}else{$(i).html(v);}};

//menu
var chmenu=function(x) { 
	$(x).each(function(i){
		$(this).click(function() { 
			$(this).mouseover(function(){ 
				$(this).click(function(){
				    $(this).removeClass("sfhover");
				});
				$(this).addClass("sfhover");
			});
			$(this).addClass("sfhover");
		})
		.mousedown(function(){$(this).addClass("sfhover");})
		.mouseup(function(){$(this).addClass("sfhover");})
		.mouseout(function(){$(this).removeClass("sfhover");});
	}); 
};

//Enter focus
function EnterTo(n,event){
  if(event.keyCode == 13){ 
	$("input[name="+n+"]").focus();
  }
}
//message show 
var showMessage=function(id,m,timeout){//show Message
	var timeoutSeed;
	if($(id)){
		$h(id,m);
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
	}else alertEx(m);
};
function Msg(id,m){showMessage(id,m,1000);}

//Jquery ext
$.fn.serialize = function(){
	var s = [];
	$('input[@name], select[@name], textarea[@name]', this).each(function (){
		if(this.disabled || (this.type == 'checkbox' || this.type == 'radio') && !this.checked)
			return;
		if (this.type == 'select-multiple'){
			var n = this.name;
			$('option:selected', this).each(function(){
				s.push(n + '=' + this.value);
			});
		}
		else
			s.push(this.name + '=' + this.value);
	});
	return s.join('&');
};
$.postJSON = function(u, d, callback,iscache) {
    $.ajax({  
		url:u,
		cache: iscache==null||!iscache?true:iscache,
		type:"post",
		dataType:"json",
		data:d,
		success:callback
	});  
};

var BindSelect=function(id,o,t,v){
	if(!t) t="Text";
	if(!v) v="Value";
	var s=$(id).get(0);
	s.options.length=1;
	if(null==o)return;
	for(var i = 0; i < o.length; ++ i)
		s.options.add(new Option(o[i][t],o[i][v]));
};

var alertEx=function(s){
	$("#dialog").dialog({ 
    modal:true, 
    overlay:{ 
        opacity: 0.5, 
        background: "black" 
    }}).html(s);
};

//valitate
var Regtest=function(id,reg){return reg.test($v(id));};
function FormMsg(i,m,p){//i:id without msg,m:message,p:id withmsg or define self
	if(p==null) p=i+"msg";
	var l=$(p);
	if(!l.length){
		l= jQuery("<span></span>").attr("id",p.substr(1,p.length-1)).addClass("error");
		$(i).after(l);
	}
	l.html(m).fadeIn();
	$(i).focus();
}
var validate_regex=function(id,reg,ae,m,p){
//id:id of input,reg:regex,ae:alloweEmpty,m:msg,p:element show errormsg
	var ie=false;//is empty
	if(!ae)ie=isEmpty(id);
	var b=!reg.test($v(id))||ie;
	FormMsg(id,b?m:'',p);
	return !b;
};
var validate_empty=function(id,m,p){
	var b=isEmpty(id);
	FormMsg(id,b?m:'',p);
	return !b;
};
var validate_date=function(id,m,p){
	var b = /Invalid|NaN/.test(new Date($(id).val()));
	FormMsg(id,b?m:'',p);
	return !b;
};

var validate_equals=function(id1,id2,m,p){//id2 is the span that show error
	var b=$v(id1)!=$v(id2);
	FormMsg(id,b?m:'',p);
	return !b;
};
var isEmpty=function(_){
	if($(_))return $.trim($v(_)).length<1;
	return true;
};
var isNum=function(_){
	if(!_) return false;
	var s=/^\d+(\.\d+)?$/;
	if(!s.test(_)) return false;
	try{
	if(parseFloat(_)!=_) return false;
	}catch(ex){return false;}
	return true;
};

