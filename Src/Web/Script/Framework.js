/*===================================================
CHSNS# JavaScript Basic Library
2007 12 16 zoujian
2007 12 28 zoujian
2008 09 27 zoujian
2009 05 05 zoujian
===================================================*/

var isnull = function(v) { return !(typeof v !== "undefined" && v != null); }
var $v = function(i, v) { if (isnull(v)) return $(i).val(); else $(i).val(v); };
var $h = function(i, v) { if (isnull(v)) { return $(i).html(); } else { $(i).html(v); } };

var showMessage = function(id, m, time) {//show Message
	var ts;
	if ($(id)) {
		$(id).fadeIn().addClass('error').html(m);
		if (!time) time = 3000;
		if (ts) window.clearTimeout(ts);
		ts = window.setTimeout(function() { $(id).fadeOut().html(''); }, time || 3500);
	} else alertEx(m);
};
//Jquery ext
$.fn.serialize = function() {
    var s = [];
    $('input[name], select[name], textarea[name]', this).each(function() {
        if (this.disabled || (this.type == 'checkbox' || this.type == 'radio') && !this.checked)
            return;
        if (this.type == 'select-multiple') {
            var n = this.name;
            $('option:selected', this).each(function() {
                s.push(n + '=' + this.value);
            });
        }
        else
            s.push(this.name + '=' + this.value);
    });
    return s.join('&');
};
$.postJSON = function(u, d, callback, iscache) {$.ajax({url: u,cache: iscache == null || !iscache ? true : iscache,type: "post",dataType:"json",data: d,success: callback});};
//bind
var BindSelect = function (id, o, t, v) {
	if (!t) t = "Text";
	if (!v) v = "Value";
	var s = $(id).get(0);
	s.options.length = 1;
	if (null == o) return;
	for (var i = 0; i < o.length; ++i)
		s.options.add(new Option(o[i][t], o[i][v]));
};
//kit
var alertEx = function(s) {
	jQuery.chbox(s);
};
//-----------------------------------------------PageMothed--------------------------------------------------------------

//Enter focus
var EnterTo = function(n, event) {
	if (event.keyCode == 13)
		$(n[0] == '#' ? n : "input[name=" + n + "]").focus();
};
var CtrlEnter = function(event, fun) {
	if ((event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83))
		fun();
};


//valitate
function FormMsg(i, m, p, f) {//i:id without msg,m:message,p:id withmsg or define self
	if (p == null) p = i + "msg";
	var l = $(p);
	if (!l.length) {
		l = jQuery("<span></span>").attr("id", p.substr(1, p.length - 1).replace("\\", "")).addClass("error");
		$(i).after(l);
	}
	l.html(m).fadeIn();
	if (f == null) f = true;
	//    if (isnull(m)) return;
	if (f) $(i).focus();
}

var v_len = function(id, m, min, max, p) {
	var b = (min && $h(id).toString().length < min) ||
    (max && $h(id).toString().length > max);
	FormMsg(id, b ? m : '', p);
	return !b;
};
var v_regex = function(id, reg, ae, m, p) {
	//id:id of input,reg:regex,ae:alloweEmpty,m:msg,p:element show errormsg
	var ie = false; //is empty
	if (!ae) ie = isEmpty(id);
	var b = !reg.test($v(id)) || ie;
	FormMsg(id, b ? m : '', p);
	return !b;
};
var v_empty = function(id, m, p) {
	var b = isEmpty(id);
	FormMsg(id, b ? m : '', p);
	return !b;
};
var v_date = function(id, m, p) {
	var b = /Invalid|NaN/.test(new Date($(id).val()));
	FormMsg(id, b ? m : '', p);
	return !b;
};
var v_notin = function(id, l, m, p) {
	var b = false;
	var v = $(id).val();
	for (var i in l) {
		if (l[i].toString() == v) { b = true; break; }
	}
	FormMsg(id, b ? m : '', p);
	return !b;
};
var v_equals = function(id1, id, m, p) {//id2 is the span that show error
	var b = $v(id1) != $v(id);
	FormMsg(id, b ? m : '', p);
	return !b;
};
var isEmpty = function(_) {
	if ($(_)) return $.trim($v(_)).length < 1;
	return true;
};
var isNum = function(_) {
	if (!_) return false;
	var s = /^\d+(\.\d+)?$/;
	if (!s.test(_)) return false;
	try {
		if (parseFloat(_) != _) return false;
	} catch (ex) { return false; }
	return true;
};
//==============================Preview
//menu
var chmenu = function(x) {
    $(x).each(function() {
        $('.menu_title', $(this).parent()).hover(function() {
            $('.menu_network', $(this).parent()).show();
        }, function() {
            $('.menu_network', $(this).parent()).hide();
        });
        $('.menu_network', $(this).parent()).hover(
        function() {
            $('.menu_network', $(this).parent()).show();
        }, function() {
            $('.menu_network', $(this).parent()).hide();
        }
        );
    });
    $(".menu_title", $(x)).each(function() { $(this).append('<image src="/images/menu.gif" />'); });
};
//upload
var uploadcreate = function(el, page, mode, qs) {
    if (qs == null) sq = '';
    var str = "<div class='fileuploadcontrol'><iframe src=\"" + page + "?mode=" + mode +
        "&" + qs + "\" id=\"fileuploadiframe\" frameborder=\"no\" scrolling=\"no\" style=\"width:250px; height:28px;\"></iframe>" +
        "<div class=\"uploading\" id=\"fileuploadingprocessing\" style=\"display:none;\" ></div>" +
        "<div class=\"image\" id=\"panelViewPic\" style=\"display:none;\"></div></div>";
    $(el).html(str);
};
var uploading = function(imgsrc) {//选择文件后的事件,iframe里面调用的
    $("#fileuploadiframe").hide();   
    $("#fileuploadingprocessing").html("<img src='/images/ajax-loader.gif' align='absmiddle' /> 上传中...请稍候").show();
};
var uploaderror = function(e) {
    alertEx(e);
    uploadinit();
};
var uploadinit = function(itemid) {//重新上传方法
    $("#fileuploadingprocessing").hide();
    $("#fileuploadiframe").show();
    $("#panelViewPic").hide();
};
//uploadsuccess在具体页来实现

jQuery.fn.confirm = function(options) {
	options = jQuery.extend({
		msg: '确定 ?',
		stopAfter: 'never',
		wrapper: '<span class="message"></span>',
		eventType: 'click',
		dialogShow: 'show',
		dialogSpeed: '',
		timeout: 0
	}, options);
	options.stopAfter = options.stopAfter.toLowerCase();
	if (!options.stopAfter in ['never', 'once', 'ok', 'cancel']) {
		options.stopAfter = 'never';
	}
	options.buttons = jQuery.extend({
		ok: 'Yes',
		cancel: 'No',
		wrapper: '<a href="#"></a>',
		separator: '/'
	}, options.buttons);

	// Shortcut to eventType.
	var type = options.eventType;

	return this.each(function() {
		var target = this;
		var $target = jQuery(target);
		var timer;
		var saveHandlers = function() {
			var events = jQuery.data(target, 'events');
			if (!events) {
				// There are no handlers to save.
				return;
			}
			target._handlers = new Array();
			for (var i in events[type]) {
				target._handlers.push(events[type][i]);
			}
		}

		// Create ok button, and bind in to a click handler.
		var $ok = jQuery(options.buttons.wrapper)
      .append(options.buttons.ok)
      .click(function() {
      	// Check if timeout is set.
      	if (options.timeout != 0) {
      		clearTimeout(timer);
      	}
      	$target.unbind(type, handler);
      	$target.show();
      	$dialog.hide();
      	// Rebind the saved handlers.
      	if (target._handlers != undefined) {
      		jQuery.each(target._handlers, function() {
      			$target.click(this);
      		});
      	}
      	// Trigger click event.
      	$target.click();
      	if (options.stopAfter != 'ok' && options.stopAfter != 'once') {
      		$target.unbind(type);
      		// Rebind the confirmation handler.
      		$target.one(type, handler);
      	}
      	return false;
      })

		var $cancel = jQuery(options.buttons.wrapper).append(options.buttons.cancel).click(function() {
			// Check if timeout is set.
			if (options.timeout != 0) {
				clearTimeout(timer);
			}
			if (options.stopAfter != 'cancel' && options.stopAfter != 'once') {
				$target.one(type, handler);
			}
			$target.show();
			$dialog.hide();
			return false;
		});

		if (options.buttons.cls) {
			$ok.addClass(options.buttons.cls);
			$cancel.addClass(options.buttons.cls);
		}

		var $dialog = jQuery(options.wrapper)
    .append(options.msg)
    .append($ok)
    .append(options.buttons.separator)
    .append($cancel);
		var handler = function() {
			jQuery(this).hide();

			// Do this check because of a jQuery bug
			if (options.dialogShow != 'show') {
				$dialog.hide();
			}

			$dialog.insertBefore(this);
			// Display the dialog.
			$dialog[options.dialogShow](options.dialogSpeed);
			if (options.timeout != 0) {
				// Set timeout
				clearTimeout(timer);
				timer = setTimeout(function() { $cancel.click(); $target.one(type, handler); }, options.timeout);
			}
			return false;
		};
		saveHandlers();
		$target.unbind(type);
		target._confirm = handler
		target._confirmEvent = type;
		$target.one(type, handler);
	});
};


//snsbox is a dialog
(function($) {
	$.chbox = function(data, klass) {
		$.chbox.loading()

		if (data.ajax) fillchboxFromAjax(data.ajax)
		else if (data.image) fillchboxFromImage(data.image)
		else if (data.div) fillchboxFromHref(data.div)
		else if ($.isFunction(data)) data.call($)
		else $.chbox.reveal(data, klass)
	}

	/*
	* Public, $.chbox methods
	*/

	$.extend($.chbox, {
		settings: {
			opacity: 0,
			overlay: true,
			loadingImage: '/images/chbox/loading.gif',
			closeImage: '/images/chbox/closelabel.gif',
			imageTypes: ['png', 'jpg', 'jpeg', 'gif'],
			chboxHtml: '\
    <div id="chbox" style="display:none;"> \
      <div class="popup"> \
        <table> \
          <tbody> \
            <tr> \
              <td class="tl"/><td class="b"/><td class="tr"/> \
            </tr> \
            <tr> \
              <td class="b"/> \
              <td class="body"> \
                <div class="content"> \
                </div> \
                <div class="footer"> \
                  <a href="#" class="close"> \
                    <img src="/images/chbox/closelabel.gif" title="close" class="close_image" /> \
                  </a> \
                </div> \
              </td> \
              <td class="b"/> \
            </tr> \
            <tr> \
              <td class="bl"/><td class="b"/><td class="br"/> \
            </tr> \
          </tbody> \
        </table> \
      </div> \
    </div>'
		},

		loading: function() {
			init()
			if ($('#chbox .loading').length == 1) return true
			showOverlay()

			$('#chbox .content').empty()
			$('#chbox .body').children().hide().end().
        append('<div class="loading"><img src="' + $.chbox.settings.loadingImage + '"/></div>')

			$('#chbox').css({
				top: getPageScroll()[1] + (getPageHeight() / 10),
				left: 385.5
			}).show()

			$(document).bind('keydown.chbox', function(e) {
				if (e.keyCode == 27) $.chbox.close()
				return true
			})
			$(document).trigger('loading.chbox')
		},

		reveal: function(data, klass) {
			$(document).trigger('beforeReveal.chbox')
			if (klass) $('#chbox .content').addClass(klass)
			$('#chbox .content').append(data)
			$('#chbox .loading').remove()
			$('#chbox .body').children().fadeIn('normal')
			$('#chbox').css('left', $(window).width() / 2 - ($('#chbox table').width() / 2))
			$(document).trigger('reveal.chbox').trigger('afterReveal.chbox')
		},

		close: function() {
			$(document).trigger('close.chbox')
			return false
		}
	})

	/*
	* Public, $.fn methods
	*/

	$.fn.chbox = function(settings) {
		init(settings)

		function clickHandler() {
			$.chbox.loading(true)

			// support for rel="chbox.inline_popup" syntax, to add a class
			// also supports deprecated "chbox[.inline_popup]" syntax
			var klass = this.rel.match(/chbox\[?\.(\w+)\]?/)
			if (klass) klass = klass[1]

			fillchboxFromHref(this.href, klass)
			return false
		}

		return this.click(clickHandler)
	}

	/*
	* Private methods
	*/

	// called one time to setup chbox on this page
	function init(settings) {
		if ($.chbox.settings.inited) return true
		else $.chbox.settings.inited = true

		$(document).trigger('init.chbox')
		makeCompatible()

		var imageTypes = $.chbox.settings.imageTypes.join('|')
		$.chbox.settings.imageTypesRegexp = new RegExp('\.' + imageTypes + '$', 'i')

		if (settings) $.extend($.chbox.settings, settings)
		$('body').append($.chbox.settings.chboxHtml)

		var preload = [new Image(), new Image()]
		preload[0].src = $.chbox.settings.closeImage
		preload[1].src = $.chbox.settings.loadingImage

		$('#chbox').find('.b:first, .bl, .br, .tl, .tr').each(function() {
			preload.push(new Image())
			preload.slice(-1).src = $(this).css('background-image').replace(/url\((.+)\)/, '$1')
		})

		$('#chbox .close').click($.chbox.close)
		$('#chbox .close_image').attr('src', $.chbox.settings.closeImage)
	}

	// getPageScroll() by quirksmode.com
	function getPageScroll() {
		var xScroll, yScroll;
		if (self.pageYOffset) {
			yScroll = self.pageYOffset;
			xScroll = self.pageXOffset;
		} else if (document.documentElement && document.documentElement.scrollTop) {	 // Explorer 6 Strict
			yScroll = document.documentElement.scrollTop;
			xScroll = document.documentElement.scrollLeft;
		} else if (document.body) {// all other Explorers
			yScroll = document.body.scrollTop;
			xScroll = document.body.scrollLeft;
		}
		return new Array(xScroll, yScroll)
	}

	// Adapted from getPageSize() by quirksmode.com
	function getPageHeight() {
		var windowHeight
		if (self.innerHeight) {	// all except Explorer
			windowHeight = self.innerHeight;
		} else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
			windowHeight = document.documentElement.clientHeight;
		} else if (document.body) { // other Explorers
			windowHeight = document.body.clientHeight;
		}
		return windowHeight
	}

	// Backwards compatibility
	function makeCompatible() {
		var $s = $.chbox.settings

		$s.loadingImage = $s.loading_image || $s.loadingImage
		$s.closeImage = $s.close_image || $s.closeImage
		$s.imageTypes = $s.image_types || $s.imageTypes
		$s.chboxHtml = $s.chbox_html || $s.chboxHtml
	}

	// Figures out what you want to display and displays it
	// formats are:
	//     div: #id
	//   image: blah.extension
	//    ajax: anything else
	function fillchboxFromHref(href, klass) {
		// div
		if (href.match(/#/)) {
			var url = window.location.href.split('#')[0]
			var target = href.replace(url, '')
			$.chbox.reveal($(target).clone().show(), klass)

			// image
		} else if (href.match($.chbox.settings.imageTypesRegexp)) {
			fillchboxFromImage(href, klass)
			// ajax
		} else {
			fillchboxFromAjax(href, klass)
		}
	}

	function fillchboxFromImage(href, klass) {
		var image = new Image()
		image.onload = function() {
			$.chbox.reveal('<div class="image"><img src="' + image.src + '" /></div>', klass)
		}
		image.src = href
	}

	function fillchboxFromAjax(href, klass) {
		$.get(href, function(data) { $.chbox.reveal(data, klass) })
	}

	function skipOverlay() {
		return $.chbox.settings.overlay == false || $.chbox.settings.opacity === null
	}

	function showOverlay() {
		if (skipOverlay()) return

		if ($('chbox_overlay').length == 0)
			$("body").append('<div id="chbox_overlay" class="chbox_hide"></div>')

		$('#chbox_overlay').hide().addClass("chbox_overlayBG")
      .css('opacity', $.chbox.settings.opacity)
      .click(function() { $(document).trigger('close.chbox') })
      .fadeIn(200)
		return false
	}

	function hideOverlay() {
		if (skipOverlay()) return

		$('#chbox_overlay').fadeOut(200, function() {
			$("#chbox_overlay").removeClass("chbox_overlayBG")
			$("#chbox_overlay").addClass("chbox_hide")
			$("#chbox_overlay").remove()
		})

		return false
	}

	/*
	* Bindings
	*/

	$(document).bind('close.chbox', function() {
		$(document).unbind('keydown.chbox')
		$('#chbox').fadeOut(function() {
			$('#chbox .content').removeClass().addClass('content')
			hideOverlay()
			$('#chbox .loading').remove()
		})
	})

})(jQuery);

//双击编辑功能

var dc_edit = function(text, edit, time, onblur) {
	text = $(text);
	edit = $(edit);
	time = $(time);
	if (!text || !edit) return;
	text.dblclick(function() {
	edit.val($.trim(text.html()) == "闲着" ? '' : $.trim(text.html())).show().focus();
		text.hide();
	});
	edit.blur(function() {
		var b = $.trim(edit.val()) != $.trim(text.html());
		text.html(edit.val());
		if (time) time.html("刚刚");
		if ($.trim(text.html()) == '')
			text.html("闲着");
		edit.hide();
		text.show();
		if (b) onblur(edit.val());
	}).keydown(function(event) {
		if (event.keyCode == 13) {
			event.preventDefault();
			edit.blur();
		}
	});
};

