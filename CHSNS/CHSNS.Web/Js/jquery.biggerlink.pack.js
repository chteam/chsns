// Version 1.0 - October 19, 2007
// Requires http://jquery.com version 1.2.1
(function($){$.fn.biggerlink=function(a){var b={hoverclass:'hover',clickableclass:'hot',follow:true};if(a){$.extend(b,a)}$(this).filter(function(){return $('a',this).length>0}).addClass(b.clickableclass).each(function(i){$(this).attr('title',$('a[title]:first',this).attr('title'));$(this).mouseover(function(){window.status=$('a:first',this).attr('href');$(this).addClass(b.hoverclass)}).mouseout(function(){window.status='';$(this).removeClass(b.hoverclass)}).bind('click',function(){$(this).find('a:first').trigger('click')}).find('a').bind('focus',function(){$(this).parents('.'+b.clickableclass).addClass(b.hoverclass)}).bind('blur',function(){$(this).parents('.'+b.clickableclass).removeClass(b.hoverclass)}).end().find('a:first').bind('click',function(e){if(b.follow==true){window.location=this.href}e.stopPropagation()}).end().find('a',this).not(':first').bind('click',function(){$(this).parents('.'+b.clickableclass).find('a:first').trigger('click');return false})});return this}})(jQuery);