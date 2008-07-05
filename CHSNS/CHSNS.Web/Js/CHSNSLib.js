/// <reference path="jquery-1.2.3-intellisense.js" />
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
