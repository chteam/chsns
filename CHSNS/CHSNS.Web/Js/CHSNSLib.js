/// <reference path="jquery-1.2.3-intellisense.js" />

//common function
var $v=function(i,v){if(typeof v!=="undefined"&&v!=null)$(i).val(v);else return $(i).val();};
var $h=function(i,v){if(typeof v!=="undefined"&&v!=null){$(i).html(v);}else{return $(i).html();}};
//valitate
var Regtest=function(id,reg){return reg.test($v(id));};
var validate_regex=function(id,myreg,allowempty,msg,p){//isnone allow empty
	if(p==null) p=id+"msg";
	$(p).hide();
	var isempty=false;
	if(!allowempty)isempty=isEmpty(id);
	if(!myreg.test($v(id))||isempty){
		if(msg!=null)$h(p,msg);
		$(p).show();
		return false;
	}
	return true;
};
var validate_empty=function(id,msg,p){//p为显示块
	if(p==null) p=id+"msg";
		$(p).hide();
	if(isEmpty(id)){
		if(msg!=null)$h(p,msg);
		$(p).show();
		return false;
	}
	return true;
};
var validate_equals=function(id1,id2,msg,p){//id2 is the span that show error
	if(p==null) p=id2+"msg";
	$(p).hide();
	if($v(id1)!=$v(id2)){
		if(msg!=null) $h(p,msg);
		$(p).show();
		return false;
	}
	return true;
};
var isEmpty=function(_){
	if($(_)){
		return ($.trim($v(_)).length<1);
	}
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
} ;

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

//account
