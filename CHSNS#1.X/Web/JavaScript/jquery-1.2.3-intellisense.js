/*                 JQuery header comments
 *          for Visual Studio IntelliSense support
 * 
 * **************************************************************
 * ************ CONTAINS NO FUNCTIONAL JQUERY CODE **************
 * **************************************************************
 * 
 * Generated with InfoBasis JQuery IntelliSense Header Generator
 * 
 * Sources:
 *     API version: 1.2.3
 *     Documentation version: 1.1.2
 * 
 * JQuery is Copyright (c) John Resig (jquery.com)
 */


jQuery = $ = function (expr, context) {
	/// <summary>
	/// 1: $(expr, context) - 
	///[short] This function accepts a string containing a CSS or
	///basic XPath selector which is then used to match a set of elements.
	///[desc] This function accepts a string containing a CSS or
	///basic XPath selector which is then used to match a set of elements.
	///
	///The core functionality of jQuery centers around this function.
	///Everything in jQuery is based upon this, or uses this in some way.
	///The most basic use of this function is to pass in an expression
	///(usually consisting of CSS or XPath), which then finds all matching
	///elements.
	///
	///By default, if no context is specified, $() looks for DOM elements within the context of the
	///current HTML document. If you do specify a context, such as a DOM
	///element or jQuery object, the expression will be matched against
	///the contents of that context.
	///
	///See [[DOM/Traversing/Selectors]] for the allowed CSS/XPath syntax for expressions.An expression to search with(optional) A DOM Element, Document or jQuery to use as contextFinds all p elements that are children of a div element.Searches for all inputs of type radio within the first form in the documentThis finds all div elements within the specified XML document.
	/// 2: $(html) - 
	///[short] Create DOM elements on-the-fly from the provided String of raw HTML.
	///[desc] Create DOM elements on-the-fly from the provided String of raw HTML.A string of HTML to create on the fly.Creates a div element (and all of its contents) dynamically, 
	///and appends it to the body element. Internally, an
	///element is created and its innerHTML property set to the given markup.
	///It is therefore both quite flexible and limited.
	/// 3: $(elems) - 
	///[short] Wrap jQuery functionality around a single or multiple DOM Element(s).
	///[desc] Wrap jQuery functionality around a single or multiple DOM Element(s).
	///
	///This function also accepts XML Documents and Window objects
	///as valid arguments (even though they are not DOM Elements).DOM element(s) to be encapsulated by a jQuery object.Sets the background color of the page to black.Hides all the input elements within a form
	/// 4: $(fn) - 
	///[short] A shorthand for $(document).
	///[desc] A shorthand for $(document).ready(), allowing you to bind a function
	///to be executed when the DOM document has finished loading. This function
	///behaves just like $(document).ready(), in that it should be used to wrap
	///other $() operations on your page that depend on the DOM being ready to be
	///operated on. While this function is, technically, chainable - there really
	///isn't much use for chaining against it.
	///
	///You can have as many $(document).ready events on your page as you like.
	///
	///See ready(Function) for details about the ready event.The function to execute when the DOM is ready.Executes the function when the DOM is ready to be used.Uses both the shortcut for $(document).ready() and the argument
	///to write failsafe jQuery code using the $ alias, without relying on the
	///global alias.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr">
	/// 1: expr - An expression to search with
	/// 2: html - A string of HTML to create on the fly.
	/// 3: elems - DOM element(s) to be encapsulated by a jQuery object.
	/// 4: fn - The function to execute when the DOM is ready.
	/// </param>
	/// <param name="context" optional="true">
	/// 1: context - (optional) A DOM Element, Document or jQuery to use as context
	/// </param>
	/// <field name="jquery" type="String">The current version of jQuery.</field>
	/// <field name="length" type="Number">The number of elements currently matched.</field>
};

$.prototype = {
	offset: function(){},
	dequeue: function(a){},
	stop: function(b,c){},
	queue: function(a,b){},
	animate: function (params, speed, easing, callback) {
	/// <summary>
	/// 
	///[short] A function for making your own, custom animations.
	///[desc] A function for making your own, custom animations. The key aspect of
	///this function is the object of style properties that will be animated,
	///and to what end. Each key within the object represents a style property
	///that will also be animated (for example: "height", "top", or "opacity").
	///
	///Note that properties should be specified using camel case
	///eg. marginLeft instead of margin-left.
	///
	///The value associated with the key represents to what end the property
	///will be animated. If a number is provided as the value, then the style
	///property will be transitioned from its current state to that new number.
	///Otherwise if the string "hide", "show", or "toggle" is provided, a default
	///animation will be constructed for that property.A set of style attributes that you wish to animate, and to what end.(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) The name of the easing effect that you want to use (Plugin Required).(optional) A function to be executed whenever the animation completes.An example of using an 'easing' function to provide a different style of animation. This will only work if you have a plugin that provides this easing function (Only 'linear' is provided by default, with jQuery).
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="params">A set of style attributes that you wish to animate, and to what end.</param>
	/// <param name="speed" optional="true">(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
	/// <param name="easing" optional="true">(optional) The name of the easing effect that you want to use (Plugin Required).</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the animation completes.</param>
},
	fadeTo: function (speed, opacity, callback) {
	/// <summary>
	/// 
	///[short] Fade the opacity of all matched elements to a specified opacity and firing an
	///optional callback after completion.
	///[desc] Fade the opacity of all matched elements to a specified opacity and firing an
	///optional callback after completion.
	///
	///Only the opacity is adjusted for this animation, meaning that
	///all of the matched elements should already have some form of height
	///and width associated with them.A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).The opacity to fade to (a number from 0 to 1).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed">A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
	/// <param name="opacity">The opacity to fade to (a number from 0 to 1).</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the animation completes.</param>
},
	fadeOut: function (speed, callback) {
	/// <summary>
	/// 
	///[short] Fade out all matched elements by adjusting their opacity and firing an
	///optional callback after completion.
	///[desc] Fade out all matched elements by adjusting their opacity and firing an
	///optional callback after completion.
	///
	///Only the opacity is adjusted for this animation, meaning that
	///all of the matched elements should already have some form of height
	///and width associated with them.(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed" optional="true">(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the animation completes.</param>
},
	fadeIn: function (speed, callback) {
	/// <summary>
	/// 
	///[short] Fade in all matched elements by adjusting their opacity and firing an
	///optional callback after completion.
	///[desc] Fade in all matched elements by adjusting their opacity and firing an
	///optional callback after completion.
	///
	///Only the opacity is adjusted for this animation, meaning that
	///all of the matched elements should already have some form of height
	///and width associated with them.(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed" optional="true">(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the animation completes.</param>
},
	slideToggle: function (speed, callback) {
	/// <summary>
	/// 
	///[short] Toggle the visibility of all matched elements by adjusting their height and firing an
	///optional callback after completion.
	///[desc] Toggle the visibility of all matched elements by adjusting their height and firing an
	///optional callback after completion.
	///
	///Only the height is adjusted for this animation, causing all matched
	///elements to be hidden in a "sliding" manner.(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed" optional="true">(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the animation completes.</param>
},
	slideUp: function (speed, callback) {
	/// <summary>
	/// 
	///[short] Hide all matched elements by adjusting their height and firing an
	///optional callback after completion.
	///[desc] Hide all matched elements by adjusting their height and firing an
	///optional callback after completion.
	///
	///Only the height is adjusted for this animation, causing all matched
	///elements to be hidden in a "sliding" manner.(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed" optional="true">(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the animation completes.</param>
},
	slideDown: function (speed, callback) {
	/// <summary>
	/// 
	///[short] Reveal all matched elements by adjusting their height and firing an
	///optional callback after completion.
	///[desc] Reveal all matched elements by adjusting their height and firing an
	///optional callback after completion.
	///
	///Only the height is adjusted for this animation, causing all matched
	///elements to be revealed in a "sliding" manner.(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed" optional="true">(optional) A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the animation completes.</param>
},
	_toggle: function(){},
	hide: function (speed, callback) {
	/// <summary>
	/// 1: hide() - 
	///[short] Hides each of the set of matched elements if they are shown.
	///[desc] Hides each of the set of matched elements if they are shown.
	/// 2: hide(speed, callback) - 
	///[short] Hide all matched elements using a graceful animation and firing an
	///optional callback after completion.
	///[desc] Hide all matched elements using a graceful animation and firing an
	///optional callback after completion.
	///
	///The height, width, and opacity of each of the matched elements 
	///are changed dynamically according to the specified speed.A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed" optional="true">
	/// 2: speed - A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
	/// </param>
	/// <param name="callback" optional="true">
	/// 2: callback - (optional) A function to be executed whenever the animation completes.
	/// </param>
},
	show: function (speed, callback) {
	/// <summary>
	/// 1: show() - 
	///[short] Displays each of the set of matched elements if they are hidden.
	///[desc] Displays each of the set of matched elements if they are hidden.
	/// 2: show(speed, callback) - 
	///[short] Show all matched elements using a graceful animation and firing an
	///optional callback after completion.
	///[desc] Show all matched elements using a graceful animation and firing an
	///optional callback after completion.
	///
	///The height, width, and opacity of each of the matched elements 
	///are changed dynamically according to the specified speed.A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).(optional) A function to be executed whenever the animation completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="speed" optional="true">
	/// 2: speed - A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
	/// </param>
	/// <param name="callback" optional="true">
	/// 2: callback - (optional) A function to be executed whenever the animation completes.
	/// </param>
},
	ajaxSend: function (callback) {
	/// <summary>
	/// 
	///[short] Attach a function to be executed before an AJAX request is sent.
	///[desc] Attach a function to be executed before an AJAX request is sent.
	///
	///The XMLHttpRequest and settings used for that request are passed
	///as arguments to the callback.The function to execute.Show a message before an AJAX request is sent.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="callback">The function to execute.</param>
},
	ajaxSuccess: function (callback) {
	/// <summary>
	/// 
	///[short] Attach a function to be executed whenever an AJAX request completes
	///successfully.
	///[desc] Attach a function to be executed whenever an AJAX request completes
	///successfully.
	///
	///The XMLHttpRequest and settings used for that request are passed
	///as arguments to the callback.The function to execute.Show a message when an AJAX request completes successfully.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="callback">The function to execute.</param>
},
	ajaxError: function (callback) {
	/// <summary>
	/// 
	///[short] Attach a function to be executed whenever an AJAX request fails.
	///[desc] Attach a function to be executed whenever an AJAX request fails.
	///
	///The XMLHttpRequest and settings used for that request are passed
	///as arguments to the callback. A third argument, an exception object,
	///is passed if an exception occured while processing the request.The function to execute.Show a message when an AJAX request fails.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="callback">The function to execute.</param>
},
	ajaxComplete: function (callback) {
	/// <summary>
	/// 
	///[short] Attach a function to be executed whenever an AJAX request completes.
	///[desc] Attach a function to be executed whenever an AJAX request completes.
	///
	///The XMLHttpRequest and settings used for that request are passed
	///as arguments to the callback.The function to execute.Show a message when an AJAX request completes.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="callback">The function to execute.</param>
},
	ajaxStop: function (callback) {
	/// <summary>
	/// 
	///[short] Attach a function to be executed whenever all AJAX requests have ended.
	///[desc] Attach a function to be executed whenever all AJAX requests have ended.The function to execute.Hide a loading message after all the AJAX requests have stopped.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="callback">The function to execute.</param>
},
	ajaxStart: function (callback) {
	/// <summary>
	/// 
	///[short] Attach a function to be executed whenever an AJAX request begins
	///and there is none already active.
	///[desc] Attach a function to be executed whenever an AJAX request begins
	///and there is none already active.The function to execute.Show a loading message whenever an AJAX request starts
	///(and none is already active).
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="callback">The function to execute.</param>
},
	serializeArray: function(){},
	serialize: function () {
	/// <summary>
	/// 
	///[short] Serializes a set of input elements into a string of data.
	///[desc] Serializes a set of input elements into a string of data.
	///This will serialize all given elements.
	///
	///A serialization similar to the form submit of a browser is
	///provided by the [http://www.malsup.com/jquery/form/ Form Plugin].
	///It also takes multiple-selects 
	///into account, while this method recognizes only a single option.Serialize a selection of input elements to a string
	/// </summary>
	/// <returns type="String"></returns>
},
	error: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the error event of each matched element.
	///[desc] Bind a function to the error event of each matched element.A function to bind to the error event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the error event on each of the matched elements.</param>
},
	keyup: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the keyup event of each matched element.
	///[desc] Bind a function to the keyup event of each matched element.A function to bind to the keyup event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the keyup event on each of the matched elements.</param>
},
	keypress: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the keypress event of each matched element.
	///[desc] Bind a function to the keypress event of each matched element.A function to bind to the keypress event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the keypress event on each of the matched elements.</param>
},
	keydown: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the keydown event of each matched element.
	///[desc] Bind a function to the keydown event of each matched element.A function to bind to the keydown event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the keydown event on each of the matched elements.</param>
},
	submit: function (fn) {
	/// <summary>
	/// 1: submit(fn) - 
	///[short] Bind a function to the submit event of each matched element.
	///[desc] Bind a function to the submit event of each matched element.A function to bind to the submit event on each of the matched elements.Prevents the form submission when the input has no value entered.
	/// 2: submit() - 
	///[short] Trigger the submit event of each matched element.
	///[desc] Trigger the submit event of each matched element. This causes all of the functions
	///that have been bound to that submit event to be executed, and calls the browser's
	///default submit action on the matching element(s). This default action can be prevented
	///by returning false from one of the functions bound to the submit event.
	///
	///Note: This does not execute the submit method of the form element! If you need to
	///submit the form via code, you have to use the DOM method, eg. $("form")[0].submit();Triggers all submit events registered to the matched form(s), and submits them.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn" optional="true">
	/// 1: fn - A function to bind to the submit event on each of the matched elements.
	/// </param>
},
	select: function (fn) {
	/// <summary>
	/// 1: select(fn) - 
	///[short] Bind a function to the select event of each matched element.
	///[desc] Bind a function to the select event of each matched element.A function to bind to the select event on each of the matched elements.
	/// 2: select() - 
	///[short] Trigger the select event of each matched element.
	///[desc] Trigger the select event of each matched element. This causes all of the functions
	///that have been bound to that select event to be executed, and calls the browser's
	///default select action on the matching element(s). This default action can be prevented
	///by returning false from one of the functions bound to the select event.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn" optional="true">
	/// 1: fn - A function to bind to the select event on each of the matched elements.
	/// </param>
},
	change: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the change event of each matched element.
	///[desc] Bind a function to the change event of each matched element.A function to bind to the change event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the change event on each of the matched elements.</param>
},
	mouseout: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the mouseout event of each matched element.
	///[desc] Bind a function to the mouseout event of each matched element.A function to bind to the mouseout event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the mouseout event on each of the matched elements.</param>
},
	mouseover: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the mouseover event of each matched element.
	///[desc] Bind a function to the mouseover event of each matched element.A function to bind to the mousedown event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the mousedown event on each of the matched elements.</param>
},
	mousemove: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the mousemove event of each matched element.
	///[desc] Bind a function to the mousemove event of each matched element.A function to bind to the mousemove event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the mousemove event on each of the matched elements.</param>
},
	mouseup: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the mouseup event of each matched element.
	///[desc] Bind a function to the mouseup event of each matched element.A function to bind to the mouseup event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the mouseup event on each of the matched elements.</param>
},
	mousedown: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the mousedown event of each matched element.
	///[desc] Bind a function to the mousedown event of each matched element.A function to bind to the mousedown event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the mousedown event on each of the matched elements.</param>
},
	dblclick: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the dblclick event of each matched element.
	///[desc] Bind a function to the dblclick event of each matched element.A function to bind to the dblclick event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the dblclick event on each of the matched elements.</param>
},
	click: function (fn) {
	/// <summary>
	/// 1: click(fn) - 
	///[short] Bind a function to the click event of each matched element.
	///[desc] Bind a function to the click event of each matched element.A function to bind to the click event on each of the matched elements.
	/// 2: click() - 
	///[short] Trigger the click event of each matched element.
	///[desc] Trigger the click event of each matched element. This causes all of the functions
	///that have been bound to thet click event to be executed.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn" optional="true">
	/// 1: fn - A function to bind to the click event on each of the matched elements.
	/// </param>
},
	unload: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the unload event of each matched element.
	///[desc] Bind a function to the unload event of each matched element.A function to bind to the unload event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the unload event on each of the matched elements.</param>
},
	scroll: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the scroll event of each matched element.
	///[desc] Bind a function to the scroll event of each matched element.A function to bind to the scroll event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the scroll event on each of the matched elements.</param>
},
	resize: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to the resize event of each matched element.
	///[desc] Bind a function to the resize event of each matched element.A function to bind to the resize event on each of the matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to bind to the resize event on each of the matched elements.</param>
},
	load: function (fn, params, callback) {
	/// <summary>
	/// 1: load(fn) - 
	///[short] Bind a function to the load event of each matched element.
	///[desc] Bind a function to the load event of each matched element.A function to bind to the load event on each of the matched elements.
	/// 2: load(url, params, callback) - 
	///[short] Load HTML from a remote file and inject it into the DOM.
	///[desc] Load HTML from a remote file and inject it into the DOM.
	///
	///Note: Avoid to use this to load scripts, instead use $.getScript.
	///IE strips script tags when there aren't any other characters in front of it.The URL of the HTML file to load.(optional) A set of key/value pairs that will be sent as data to the server.(optional) A function to be executed whenever the data is loaded (parameters: responseText, status and response itself).Same as above, but with an additional parameter
	///and a callback that is executed when the data was loaded.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">
	/// 1: fn - A function to bind to the load event on each of the matched elements.
	/// 2: url - The URL of the HTML file to load.
	/// </param>
	/// <param name="params" optional="true">
	/// 2: params - (optional) A set of key/value pairs that will be sent as data to the server.
	/// </param>
	/// <param name="callback" optional="true">
	/// 2: callback - (optional) A function to be executed whenever the data is loaded (parameters: responseText, status and response itself).
	/// </param>
},
	focus: function (fn) {
	/// <summary>
	/// 1: focus(fn) - 
	///[short] Bind a function to the focus event of each matched element.
	///[desc] Bind a function to the focus event of each matched element.A function to bind to the focus event on each of the matched elements.
	/// 2: focus() - 
	///[short] Trigger the focus event of each matched element.
	///[desc] Trigger the focus event of each matched element. This causes all of the functions
	///that have been bound to thet focus event to be executed.
	///
	///Note: This does not execute the focus method of the underlying elements! If you need to
	///focus an element via code, you have to use the DOM method, eg. $("#myinput")[0].focus();
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn" optional="true">
	/// 1: fn - A function to bind to the focus event on each of the matched elements.
	/// </param>
},
	blur: function (fn) {
	/// <summary>
	/// 1: blur(fn) - 
	///[short] Bind a function to the blur event of each matched element.
	///[desc] Bind a function to the blur event of each matched element.A function to bind to the blur event on each of the matched elements.
	/// 2: blur() - 
	///[short] Trigger the blur event of each matched element.
	///[desc] Trigger the blur event of each matched element. This causes all of the functions
	///that have been bound to that blur event to be executed, and calls the browser's
	///default blur action on the matching element(s). This default action can be prevented
	///by returning false from one of the functions bound to the blur event.
	///
	///Note: This does not execute the blur method of the underlying elements! If you need to
	///blur an element via code, you have to use the DOM method, eg. $("#myinput")[0].blur();
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn" optional="true">
	/// 1: fn - A function to bind to the blur event on each of the matched elements.
	/// </param>
},
	ready: function (fn) {
	/// <summary>
	/// 
	///[short] Bind a function to be executed whenever the DOM is ready to be
	///traversed and manipulated.
	///[desc] Bind a function to be executed whenever the DOM is ready to be
	///traversed and manipulated. This is probably the most important 
	///function included in the event module, as it can greatly improve
	///the response times of your web applications.
	///
	///In a nutshell, this is a solid replacement for using window.onload, 
	///and attaching a function to that. By using this method, your bound function 
	///will be called the instant the DOM is ready to be read and manipulated, 
	///which is when what 99.99% of all JavaScript code needs to run.
	///
	///There is one argument passed to the ready event handler: A reference to
	///the jQuery function. You can name that argument whatever you like, and
	///can therefore stick with the $ alias without risk of naming collisions.
	///
	///Please ensure you have no code in your <body> onload event handler, 
	///otherwise $(document).ready() may not fire.
	///
	///You can have as many $(document).ready events on your page as you like.
	///The functions are then executed in the order they were added.The function to be executed when the DOM is ready.Uses both the [[Core#.24.28_fn_.29|shortcut]] for $(document).ready() and the argument
	///to write failsafe jQuery code using the $ alias, without relying on the
	///global alias.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">The function to be executed when the DOM is ready.</param>
},
	hover: function (over, out) {
	/// <summary>
	/// 
	///[short] A method for simulating hovering (moving the mouse on, and off,
	///an object).
	///[desc] A method for simulating hovering (moving the mouse on, and off,
	///an object). This is a custom method which provides an 'in' to a 
	///frequent task.
	///
	///Whenever the mouse cursor is moved over a matched 
	///element, the first specified function is fired. Whenever the mouse 
	///moves off of the element, the second specified function fires. 
	///Additionally, checks are in place to see if the mouse is still within 
	///the specified element itself (for example, an image inside of a div), 
	///and if it is, it will continue to 'hover', and not move out 
	///(a common error in using a mouseout event handler).The function to fire whenever the mouse is moved over a matched element.The function to fire whenever the mouse is moved off of a matched element.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="over">The function to fire whenever the mouse is moved over a matched element.</param>
	/// <param name="out">The function to fire whenever the mouse is moved off of a matched element.</param>
},
	toggle: function (even, odd) {
	/// <summary>
	/// 1: toggle(even, odd) - 
	///[short] Toggle between two function calls every other click.
	///[desc] Toggle between two function calls every other click.
	///Whenever a matched element is clicked, the first specified function 
	///is fired, when clicked again, the second is fired. All subsequent 
	///clicks continue to rotate through the two functions.
	///
	///Use unbind("click") to remove.The function to execute on every even click.The function to execute on every odd click.
	/// 2: toggle() - 
	///[short] Toggles each of the set of matched elements.
	///[desc] Toggles each of the set of matched elements. If they are shown,
	///toggle makes them hidden. If they are hidden, toggle
	///makes them shown.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="even" optional="true">
	/// 1: even - The function to execute on every even click.
	/// </param>
	/// <param name="odd" optional="true">
	/// 1: odd - The function to execute on every odd click.
	/// </param>
},
	triggerHandler: function(c,a,b){},
	trigger: function (type, data) {
	/// <summary>
	/// 
	///[short] Trigger a type of event on every matched element.
	///[desc] Trigger a type of event on every matched element. This will also cause
	///the default action of the browser with the same name (if one exists)
	///to be executed. For example, passing 'submit' to the trigger()
	///function will also cause the browser to submit the form. This
	///default action can be prevented by returning false from one of
	///the functions bound to the event.
	///
	///You can also trigger custom events registered with bind.An event type to trigger.(optional) Additional data to pass as arguments (after the event object) to the event handlerExample of how to pass arbitrary data to an event
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="type">An event type to trigger.</param>
	/// <param name="data" optional="true">(optional) Additional data to pass as arguments (after the event object) to the event handler</param>
},
	unbind: function (type, fn) {
	/// <summary>
	/// 
	///[short] The opposite of bind, removes a bound event from each of the matched
	///elements.
	///[desc] The opposite of bind, removes a bound event from each of the matched
	///elements.
	///
	///Without any arguments, all bound events are removed.
	///
	///If the type is provided, all bound events of that type are removed.
	///
	///If the function that was passed to bind is provided as the second argument,
	///only that specific event handler is removed.(optional) An event type(optional) A function to unbind from the event on each of the set of matched elements
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="type" optional="true">(optional) An event type</param>
	/// <param name="fn" optional="true">(optional) A function to unbind from the event on each of the set of matched elements</param>
},
	one: function (type, data, fn) {
	/// <summary>
	/// 
	///[short] Binds a handler to a particular event (like click) for each matched element.
	///[desc] Binds a handler to a particular event (like click) for each matched element.
	///The handler is executed only once for each element. Otherwise, the same rules
	///as described in bind() apply.
	///	 The event handler is passed an event object that you can use to prevent
	///default behaviour. To stop both default action and event bubbling, your handler
	///has to return false.
	///
	///In most cases, you can define your event handlers as anonymous functions
	///(see first example). In cases where that is not possible, you can pass additional
	///data as the second paramter (and the handler function as the third), see 
	///second example.An event type(optional) Additional data passed to the event handler as event.dataA function to bind to the event on each of the set of matched elements
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="type">An event type</param>
	/// <param name="data" optional="true">(optional) Additional data passed to the event handler as event.data</param>
	/// <param name="fn">A function to bind to the event on each of the set of matched elements</param>
},
	bind: function (type, data, fn) {
	/// <summary>
	/// 
	///[short] Binds a handler to a particular event (like click) for each matched element.
	///[desc] Binds a handler to a particular event (like click) for each matched element.
	///The event handler is passed an event object that you can use to prevent
	///default behaviour. To stop both default action and event bubbling, your handler
	///has to return false.
	///
	///In most cases, you can define your event handlers as anonymous functions
	///(see first example). In cases where that is not possible, you can pass additional
	///data as the second parameter (and the handler function as the third), see 
	///second example.An event type(optional) Additional data passed to the event handler as event.dataA function to bind to the event on each of the set of matched elementsPass some additional data to the event handler.Cancel a default action and prevent it from bubbling by returning false
	///from your function.Cancel only the default action by using the preventDefault method.Stop only an event from bubbling by using the stopPropagation method.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="type">An event type</param>
	/// <param name="data" optional="true">(optional) Additional data passed to the event handler as event.data</param>
	/// <param name="fn">A function to bind to the event on each of the set of matched elements</param>
},
	width: function (val) {
	/// <summary>
	/// 1: width() - 
	///[short] Get the current computed, pixel, width of the first matched element.
	///[desc] Get the current computed, pixel, width of the first matched element.
	///   returns String
	/// 2: width(val) - 
	///[short] Set the CSS width of every matched element.
	///[desc] Set the CSS width of every matched element. If no explicit unit
	///was specified (like 'em' or '%') then "px" is added to the width.Set the CSS property to the specified value.
	///   returns jQuery
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="val" optional="true">
	/// 2: val - Set the CSS property to the specified value.
	/// </param>
},
	height: function (val) {
	/// <summary>
	/// 1: height() - 
	///[short] Get the current computed, pixel, height of the first matched element.
	///[desc] Get the current computed, pixel, height of the first matched element.
	///   returns String
	/// 2: height(val) - 
	///[short] Set the CSS height of every matched element.
	///[desc] Set the CSS height of every matched element. If no explicit unit
	///was specified (like 'em' or '%') then "px" is added to the width.Set the CSS property to the specified value.
	///   returns jQuery
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="val" optional="true">
	/// 2: val - Set the CSS property to the specified value.
	/// </param>
},
	empty: function () {
	/// <summary>
	/// 
	///[short] Removes all child nodes from the set of matched elements.
	///[desc] Removes all child nodes from the set of matched elements.
	/// </summary>
	/// <returns type="jQuery"></returns>
},
	remove: function (expr) {
	/// <summary>
	/// 
	///[short] Removes all matched elements from the DOM.
	///[desc] Removes all matched elements from the DOM. This does NOT remove them from the
	///jQuery object, allowing you to use the matched elements further.
	///
	///Can be filtered with an optional expressions.(optional) A jQuery expression to filter elements by.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr" optional="true">(optional) A jQuery expression to filter elements by.</param>
},
	toggleClass: function (cssClass) {
	/// <summary>
	/// 
	///[short] Adds the specified class if it is not present, removes it if it is
	///present.
	///[desc] Adds the specified class if it is not present, removes it if it is
	///present.A CSS class with which to toggle the elements
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="cssClass">A CSS class with which to toggle the elements</param>
},
	removeClass: function (cssClass) {
	/// <summary>
	/// 
	///[short] Removes all or the specified class(es) from the set of matched elements.
	///[desc] Removes all or the specified class(es) from the set of matched elements.(optional) One or more CSS classes to remove from the elements
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="cssClass" optional="true">(optional) One or more CSS classes to remove from the elements</param>
},
	addClass: function (cssClass) {
	/// <summary>
	/// 
	///[short] Adds the specified class(es) to each of the set of matched elements.
	///[desc] Adds the specified class(es) to each of the set of matched elements.One or more CSS classes to add to the elements
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="cssClass">One or more CSS classes to add to the elements</param>
},
	removeAttr: function (name) {
	/// <summary>
	/// 
	///[short] Remove an attribute from each of the matched elements.
	///[desc] Remove an attribute from each of the matched elements.The name of the attribute to remove.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="name">The name of the attribute to remove.</param>
},
	replaceAll: function(){},
	insertAfter: function (content) {
	/// <summary>
	/// 
	///[short] Insert all of the matched elements after another, specified, set of elements.
	///[desc] Insert all of the matched elements after another, specified, set of elements.
	///This operation is, essentially, the reverse of doing a regular
	///$(A).after(B), in that instead of inserting B after A, you're inserting
	///A after B.Content to insert the selected element after.Same as $("#foo").after("p")
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to insert the selected element after.</param>
},
	insertBefore: function (content) {
	/// <summary>
	/// 
	///[short] Insert all of the matched elements before another, specified, set of elements.
	///[desc] Insert all of the matched elements before another, specified, set of elements.
	///This operation is, essentially, the reverse of doing a regular
	///$(A).before(B), in that instead of inserting B before A, you're inserting
	///A before B.Content to insert the selected element before.Same as $("#foo").before("p")
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to insert the selected element before.</param>
},
	prependTo: function (content) {
	/// <summary>
	/// 
	///[short] Prepend all of the matched elements to another, specified, set of elements.
	///[desc] Prepend all of the matched elements to another, specified, set of elements.
	///This operation is, essentially, the reverse of doing a regular
	///$(A).prepend(B), in that instead of prepending B to A, you're prepending
	///A to B.Content to prepend to the selected element to.Prepends all paragraphs to the element with the ID "foo"
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to prepend to the selected element to.</param>
},
	appendTo: function (content) {
	/// <summary>
	/// 
	///[short] Append all of the matched elements to another, specified, set of elements.
	///[desc] Append all of the matched elements to another, specified, set of elements.
	///This operation is, essentially, the reverse of doing a regular
	///$(A).append(B), in that instead of appending B to A, you're appending
	///A to B.Content to append to the selected element to.Appends all paragraphs to the element with the ID "foo"
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to append to the selected element to.</param>
},
	contents: function(b){},
	children: function (expr) {
	/// <summary>
	/// 
	///[short] Get a set of elements containing all of the unique children of each of the
	///matched set of elements.
	///[desc] Get a set of elements containing all of the unique children of each of the
	///matched set of elements.
	///
	///This set can be filtered with an optional expression that will cause
	///only elements matching the selector to be collected.(optional) An expression to filter the child Elements withFind all children of each div.Find all children with a class "selected" of each div.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr" optional="true">(optional) An expression to filter the child Elements with</param>
},
	siblings: function (expr) {
	/// <summary>
	/// 
	///[short] Get a set of elements containing all of the unique siblings of each of the
	///matched set of elements.
	///[desc] Get a set of elements containing all of the unique siblings of each of the
	///matched set of elements.
	///
	///Can be filtered with an optional expressions.(optional) An expression to filter the sibling Elements withFind all siblings of each div.Find all siblings with a class "selected" of each div.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr" optional="true">(optional) An expression to filter the sibling Elements with</param>
},
	prevAll: function(b){},
	nextAll: function(b){},
	prev: function (expr) {
	/// <summary>
	/// 
	///[short] Get a set of elements containing the unique previous siblings of each of the
	///matched set of elements.
	///[desc] Get a set of elements containing the unique previous siblings of each of the
	///matched set of elements.
	///
	///Use an optional expression to filter the matched set.
	///
	///	Only the immediately previous sibling is returned, not all previous siblings.(optional) An expression to filter the previous Elements withFind the very previous sibling of each paragraph.Find the very previous sibling of each paragraph that has a class "selected".
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr" optional="true">(optional) An expression to filter the previous Elements with</param>
},
	next: function (expr) {
	/// <summary>
	/// 
	///[short] Get a set of elements containing the unique next siblings of each of the
	///matched set of elements.
	///[desc] Get a set of elements containing the unique next siblings of each of the
	///matched set of elements.
	///
	///It only returns the very next sibling for each element, not all
	///next siblings.
	///
	///You may provide an optional expression to filter the match.(optional) An expression to filter the next Elements withFind the very next sibling of each paragraph.Find the very next sibling of each paragraph that has a class "selected".
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr" optional="true">(optional) An expression to filter the next Elements with</param>
},
	parents: function (expr) {
	/// <summary>
	/// 
	///[short] Get a set of elements containing the unique ancestors of the matched
	///set of elements (except for the root element).
	///[desc] Get a set of elements containing the unique ancestors of the matched
	///set of elements (except for the root element).
	///
	///The matched elements can be filtered with an optional expression.(optional) An expression to filter the ancestors withFind all parent elements of each span.Find all parent elements of each span that is a paragraph.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr" optional="true">(optional) An expression to filter the ancestors with</param>
},
	parent: function (expr) {
	/// <summary>
	/// 
	///[short] Get a set of elements containing the unique parents of the matched
	///set of elements.
	///[desc] Get a set of elements containing the unique parents of the matched
	///set of elements.
	///
	///You may use an optional expression to filter the set of parent elements that will match.(optional) An expression to filter the parents withFind the parent element of each paragraph.Find the parent element of each paragraph with a class "selected".
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr" optional="true">(optional) An expression to filter the parents with</param>
},
	extend: function(){},
	removeData: function(a){},
	data: function(d,b){},
	andSelf: function(){},
	map: function(b){},
	slice: function(){},
	eq: function (pos) {
	/// <summary>
	/// 
	///[short] Reduce the set of matched elements to a single element.
	///[desc] Reduce the set of matched elements to a single element.
	///The position of the element in the set of matched elements
	///starts at 0 and goes to length - 1.The index of the element that you wish to limit to.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="pos">The index of the element that you wish to limit to.</param>
},
	replaceWith: function(a){},
	html: function (val) {
	/// <summary>
	/// 1: html() - 
	///[short] Get the html contents of the first matched element.
	///[desc] Get the html contents of the first matched element.
	///This property is not available on XML documents.
	///   returns String
	/// 2: html(val) - 
	///[short] Set the html contents of every matched element.
	///[desc] Set the html contents of every matched element.
	///This property is not available on XML documents.Set the html contents to the specified value.
	///   returns jQuery
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="val" optional="true">
	/// 2: val - Set the html contents to the specified value.
	/// </param>
},
	val: function (val) {
	/// <summary>
	/// 1: val() - 
	///[short] Get the content of the value attribute of the first matched element.
	///[desc] Get the content of the value attribute of the first matched element.
	///
	///Use caution when relying on this function to check the value of
	///multiple-select elements and checkboxes in a form. While it will
	///still work as intended, it may not accurately represent the value
	///the server will receive because these elements may send an array
	///of values. For more robust handling of field values, see the
	///[http://www.malsup.com/jquery/form/#fields fieldValue function of the Form Plugin].
	///   returns String
	/// 2: val(val) - 
	///[short] 	Set the value attribute of every matched element.
	///[desc] 	Set the value attribute of every matched element.Set the property to the specified value.
	///   returns jQuery
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="val" optional="true">
	/// 2: val - Set the property to the specified value.
	/// </param>
},
	hasClass: function(a){},
	is: function (expr) {
	/// <summary>
	/// 
	///[short] Checks the current selection against an expression and returns true,
	///if at least one element of the selection fits the given expression.
	///[desc] Checks the current selection against an expression and returns true,
	///if at least one element of the selection fits the given expression.
	///
	///Does return false, if no element fits or the expression is not valid.
	///
	///filter(String) is used internally, therefore all rules that apply there
	///apply here, too.The expression with which to filterReturns true, because the parent of the input is a form elementReturns false, because the parent of the input is a p element
	/// </summary>
	/// <returns type="Boolean"></returns>
	/// <param name="expr">The expression with which to filter</param>
},
	add: function (expr) {
	/// <summary>
	/// 1: add(expr) - 
	///[short] Adds more elements, matched by the given expression,
	///to the set of matched elements.
	///[desc] Adds more elements, matched by the given expression,
	///to the set of matched elements.An expression whose matched elements are addedCompare the above result to the result of <code>$('p')</code>,
	///which would just result in <code><nowiki>[ <p>Hello</p> ]</nowiki></code>.
	///Using add(), matched elements of <code>$('span')</code> are simply
	///added to the returned jQuery-object.
	/// 2: add(html) - 
	///[short] Adds more elements, created on the fly, to the set of
	///matched elements.
	///[desc] Adds more elements, created on the fly, to the set of
	///matched elements.A string of HTML to create on the fly.
	/// 3: add(elements) - 
	///[short] Adds one or more Elements to the set of matched elements.
	///[desc] Adds one or more Elements to the set of matched elements.One or more Elements to add
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr">
	/// 1: expr - An expression whose matched elements are added
	/// 2: html - A string of HTML to create on the fly.
	/// 3: elements - One or more Elements to add
	/// </param>
},
	not: function (el) {
	/// <summary>
	/// 1: not(el) - 
	///[short] Removes the specified Element from the set of matched elements.
	///[desc] Removes the specified Element from the set of matched elements. This
	///method is used to remove a single Element from a jQuery object.An element to remove from the setRemoves the element with the ID "selected" from the set of all paragraphs.
	/// 2: not(expr) - 
	///[short] Removes elements matching the specified expression from the set
	///of matched elements.
	///[desc] Removes elements matching the specified expression from the set
	///of matched elements. This method is used to remove one or more
	///elements from a jQuery object.An expression with which to remove matching elementsRemoves the element with the ID "selected" from the set of all paragraphs.
	/// 3: not(elems) - 
	///[short] Removes any elements inside the array of elements from the set
	///of matched elements.
	///[desc] Removes any elements inside the array of elements from the set
	///of matched elements. This method is used to remove one or more
	///elements from a jQuery object.
	///
	///Please note: the expression cannot use a reference to the
	///element name. See the two examples below.A set of elements to remove from the jQuery set of matched elements.Removes all elements that match "div p.selected" from the total set of all paragraphs.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="el">
	/// 1: el - An element to remove from the set
	/// 2: expr - An expression with which to remove matching elements
	/// 3: elems - A set of elements to remove from the jQuery set of matched elements.
	/// </param>
},
	filter: function (expression) {
	/// <summary>
	/// 1: filter(expression) - 
	///[short] Removes all elements from the set of matched elements that do not
	///match the specified expression(s).
	///[desc] Removes all elements from the set of matched elements that do not
	///match the specified expression(s). This method is used to narrow down
	///the results of a search.
	///
	///Provide a comma-separated list of expressions to apply multiple filters at once.Expression(s) to search with.Selects all paragraphs and removes those without a class "selected".Selects all paragraphs and removes those without class "selected" and being the first one.
	/// 2: filter(filter) - 
	///[short] Removes all elements from the set of matched elements that do not
	///pass the specified filter.
	///[desc] Removes all elements from the set of matched elements that do not
	///pass the specified filter. This method is used to narrow down
	///the results of a search.A function to use for filteringRemove all elements that have a child ol element
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expression">
	/// 1: expression - Expression(s) to search with.
	/// 2: filter - A function to use for filtering
	/// </param>
},
	clone: function (deep) {
	/// <summary>
	/// 
	///[short] Clone matched DOM Elements and select the clones.
	///[desc] Clone matched DOM Elements and select the clones. 
	///
	///This is useful for moving copies of the elements to another
	///location in the DOM.(Optional) Set to false if you don't want to clone all descendant nodes, in addition to the element itself.Clones all b elements (and selects the clones) and prepends them to all paragraphs.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="deep" optional="true">(Optional) Set to false if you don't want to clone all descendant nodes, in addition to the element itself.</param>
},
	find: function (expr) {
	/// <summary>
	/// 
	///[short] Searches for all elements that match the specified expression.
	///[desc] Searches for all elements that match the specified expression.
	///This method is a good way to find additional descendant
	///elements with which to process.
	///
	///All searching is done using a jQuery expression. The expression can be
	///written using CSS 1-3 Selector syntax, or basic XPath.An expression to search with.Starts with all paragraphs and searches for descendant span
	///elements, same as $("p span")
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="expr">An expression to search with.</param>
},
	end: function () {
	/// <summary>
	/// 
	///[short] Revert the most recent 'destructive' operation, changing the set of matched elements
	///to its previous state (right before the destructive operation).
	///[desc] Revert the most recent 'destructive' operation, changing the set of matched elements
	///to its previous state (right before the destructive operation).
	///
	///If there was no destructive operation before, an empty set is returned.
	///
	///A 'destructive' operation is any operation that changes the set of
	///matched jQuery elements. These functions are: <code>add</code>,
	///<code>children</code>, <code>clone</code>, <code>filter</code>,
	///<code>find</code>, <code>not</code>, <code>next</code>,
	///<code>parent</code>, <code>parents</code>, <code>prev</code> and <code>siblings</code>.Selects all paragraphs, finds span elements inside these, and reverts the
	///selection back to the paragraphs.
	/// </summary>
	/// <returns type="jQuery"></returns>
},
	after: function (content) {
	/// <summary>
	/// 
	///[short] Insert content after each of the matched elements.
	///[desc] Insert content after each of the matched elements.Content to insert after each target.Inserts some HTML after all paragraphs.Inserts an Element after all paragraphs.Inserts a jQuery object (similar to an Array of DOM Elements) after all paragraphs.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to insert after each target.</param>
},
	prepend: function (content) {
	/// <summary>
	/// 
	///[short] Prepend content to the inside of every matched element.
	///[desc] Prepend content to the inside of every matched element.
	///
	///This operation is the best way to insert elements
	///inside, at the beginning, of all matched elements.Content to prepend to the target.Prepends some HTML to all paragraphs.Prepends an Element to all paragraphs.Prepends a jQuery object (similar to an Array of DOM Elements) to all paragraphs.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to prepend to the target.</param>
},
	append: function (content) {
	/// <summary>
	/// 
	///[short] Append content to the inside of every matched element.
	///[desc] Append content to the inside of every matched element.
	///
	///This operation is similar to doing an appendChild to all the
	///specified elements, adding them into the document.Content to append to the targetAppends some HTML to all paragraphs.Appends an Element to all paragraphs.Appends a jQuery object (similar to an Array of DOM Elements) to all paragraphs.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to append to the target</param>
},
	wrap: function (html) {
	/// <summary>
	/// 1: wrap(html) - 
	///[short] Wrap all matched elements with a structure of other elements.
	///[desc] Wrap all matched elements with a structure of other elements.
	///This wrapping process is most useful for injecting additional
	///stucture into a document, without ruining the original semantic
	///qualities of a document.
	///
	///This works by going through the first element
	///provided (which is generated, on the fly, from the provided HTML)
	///and finds the deepest ancestor element within its
	///structure - it is that element that will en-wrap everything else.
	///
	///This does not work with elements that contain text. Any necessary text
	///must be added after the wrapping is done.A string of HTML, that will be created on the fly and wrapped around the target.
	/// 2: wrap(elem) - 
	///[short] Wrap all matched elements with a structure of other elements.
	///[desc] Wrap all matched elements with a structure of other elements.
	///This wrapping process is most useful for injecting additional
	///stucture into a document, without ruining the original semantic
	///qualities of a document.
	///
	///This works by going through the first element
	///provided and finding the deepest ancestor element within its
	///structure - it is that element that will en-wrap everything else.
	///
	///This does not work with elements that contain text. Any necessary text
	///must be added after the wrapping is done.A DOM element that will be wrapped around the target.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="html">
	/// 1: html - A string of HTML, that will be created on the fly and wrapped around the target.
	/// 2: elem - A DOM element that will be wrapped around the target.
	/// </param>
},
	wrapInner: function(a){},
	wrapAll: function(b){},
	text: function (val) {
	/// <summary>
	/// 1: text() - 
	///[short] Get the text contents of all matched elements.
	///[desc] Get the text contents of all matched elements. The result is
	///a string that contains the combined text contents of all matched
	///elements. This method works on both HTML and XML documents.Gets the concatenated text of all paragraphs
	/// 2: text(val) - 
	///[short] Set the text contents of all matched elements.
	///[desc] Set the text contents of all matched elements.
	///
	///Similar to html(), but escapes HTML (replace "<" and ">" with their
	///HTML entities).The text value to set the contents of the element to.Sets the text of all paragraphs.Sets the text of all paragraphs.
	/// </summary>
	/// <returns type="String"></returns>
	/// <param name="val" optional="true">
	/// 2: val - The text value to set the contents of the element to.
	/// </param>
},
	css: function (name, value) {
	/// <summary>
	/// 1: css(name) - 
	///[short] Access a style property on the first matched element.
	///[desc] Access a style property on the first matched element.
	///This method makes it easy to retrieve a style property value
	///from the first matched element.The name of the property to access.Retrieves the color style of the first paragraphRetrieves the font-weight style of the first paragraph.
	///   returns String
	/// 2: css(properties) - 
	///[short] Set a key/value object as style properties to all matched elements.
	///[desc] Set a key/value object as style properties to all matched elements.
	///
	///This serves as the best way to set a large number of style properties
	///on all matched elements.Key/value pairs to set as style properties.Sets color and background styles to all p elements.
	///   returns jQuery
	/// 3: css(key, value) - 
	///[short] Set a single style property to a value, on all matched elements.
	///[desc] Set a single style property to a value, on all matched elements.
	///If a number is provided, it is automatically converted into a pixel value.The name of the property to set.The value to set the property to.Changes the color of all paragraphs to redChanges the left of all paragraphs to "30px"
	///   returns jQuery
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="name">
	/// 1: name - The name of the property to access.
	/// 2: properties - Key/value pairs to set as style properties.
	/// 3: key - The name of the property to set.
	/// </param>
	/// <param name="value" optional="true">
	/// 3: value - The value to set the property to.
	/// </param>
},
	attr: function (name, value) {
	/// <summary>
	/// 1: attr(name) - 
	///[short] Access a property on the first matched element.
	///[desc] Access a property on the first matched element.
	///This method makes it easy to retrieve a property value
	///from the first matched element.
	///
	///If the element does not have an attribute with such a
	///name, undefined is returned.The name of the property to access.Returns the src attribute from the first image in the document.
	/// 2: attr(properties) - 
	///[short] Set a key/value object as properties to all matched elements.
	///[desc] Set a key/value object as properties to all matched elements.
	///
	///This serves as the best way to set a large number of properties
	///on all matched elements.Key/value pairs to set as object properties.Sets src and alt attributes to all images.
	///   returns jQuery
	/// 3: attr(key, value) - 
	///[short] Set a single property to a value, on all matched elements.
	///[desc] Set a single property to a value, on all matched elements.
	///
	///Note that you can't set the name property of input elements in IE.
	///Use $(html) or .append(html) or .html(html) to create elements
	///on the fly including the name property.The name of the property to set.The value to set the property to.Sets src attribute to all images.
	///   returns jQuery
	/// 4: attr(key, value) - 
	///[short] Set a single property to a computed value, on all matched elements.
	///[desc] Set a single property to a computed value, on all matched elements.
	///
	///Instead of supplying a string value as described
	///[[DOM/Attributes#attr.28_key.2C_value_.29|above]],
	///a function is provided that computes the value.The name of the property to set.A function returning the value to set. Scope: Current element, argument: Index of current elementSets title attribute from src attribute.Enumerate title attribute.
	///   returns jQuery
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="name">
	/// 1: name - The name of the property to access.
	/// 2: properties - Key/value pairs to set as object properties.
	/// 3: key - The name of the property to set.
	/// 4: key - The name of the property to set.
	/// </param>
	/// <param name="value" optional="true">
	/// 3: value - The value to set the property to.
	/// 4: value - A function returning the value to set. Scope: Current element, argument: Index of current element
	/// </param>
},
	index: function (subject) {
	/// <summary>
	/// 
	///[short] Searches every matched element for the object and returns
	///the index of the element, if found, starting with zero.
	///[desc] Searches every matched element for the object and returns
	///the index of the element, if found, starting with zero. 
	///Returns -1 if the object wasn't found.Object to search forReturns the index for the element with ID foobarReturns the index for the element with ID foo within another elementReturns -1, as there is no element with ID bar
	/// </summary>
	/// <returns type="Number"></returns>
	/// <param name="subject">Object to search for</param>
},
	pushStack: function (elems) {
	/// <summary>
	/// 
	///[short] Set the jQuery object to an array of elements, while maintaining
	///the stack.
	///[desc] Set the jQuery object to an array of elements, while maintaining
	///the stack.An array of elements
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="elems">An array of elements</param>
},
	get: function (num) {
	/// <summary>
	/// 1: get() - 
	///[short] Access all matched DOM elements.
	///[desc] Access all matched DOM elements. This serves as a backwards-compatible
	///way of accessing all matched elements (other than the jQuery object
	///itself, which is, in fact, an array of elements).
	///
	///It is useful if you need to operate on the DOM elements themselves instead of using built-in jQuery functions.Selects all images in the document and returns the DOM Elements as an Array
	///   returns Array<Element>
	/// 2: get(num) - 
	///[short] Access a single matched DOM element at a specified index in the matched set.
	///[desc] Access a single matched DOM element at a specified index in the matched set.
	///This allows you to extract the actual DOM element and operate on it
	///directly without necessarily using jQuery functionality on it.Access the element in the Nth position.Selects all images in the document and returns the first one
	///   returns Element
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="num" optional="true">
	/// 2: num - Access the element in the Nth position.
	/// </param>
},
	size: function () {
	/// <summary>
	/// 
	///[short] Get the number of elements currently matched.
	///[desc] Get the number of elements currently matched. This returns the same
	///number as the 'length' property of the jQuery object.
	/// </summary>
	/// <returns type="Number"></returns>
},
	init: function(d,b){},
	setArray: function (elems) {
	/// <summary>
	/// 
	///[short] Set the jQuery object to an array of elements.
	///[desc] Set the jQuery object to an array of elements. This operation is
	///completely destructive - be sure to use .pushStack() if you wish to maintain
	///the jQuery stack.An array of elements
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="elems">An array of elements</param>
},
	length: {},
	prevObject: {},
	jquery: {},
	before: function (content) {
	/// <summary>
	/// 
	///[short] Insert content before each of the matched elements.
	///[desc] Insert content before each of the matched elements.Content to insert before each target.Inserts some HTML before all paragraphs.Inserts an Element before all paragraphs.Inserts a jQuery object (similar to an Array of DOM Elements) before all paragraphs.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="content">Content to insert before each target.</param>
},
	domManip: function (args, table, dir, fn) {
	/// <summary>
	/// 
	///[desc] Insert TBODY in TABLEs if one is not found.If dir<0, process args in reverse order.The function doing the DOM manipulation.
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="args"></param>
	/// <param name="table">Insert TBODY in TABLEs if one is not found.</param>
	/// <param name="dir">If dir<0, process args in reverse order.</param>
	/// <param name="fn">The function doing the DOM manipulation.</param>
},
	each: function (fn) {
	/// <summary>
	/// 
	///[short] Execute a function within the context of every matched element.
	///[desc] Execute a function within the context of every matched element.
	///This means that every time the passed-in function is executed
	///(which is once for every element matched) the 'this' keyword
	///points to the specific DOM element.
	///
	///Additionally, the function, when executed, is passed a single
	///argument representing the position of the element in the matched
	///set (integer, zero-index).A function to executeIterates over two images and sets their src property
	/// </summary>
	/// <returns type="jQuery"></returns>
	/// <param name="fn">A function to execute</param>
}
};

$.extend = function (prop, prop1, propN) {
	/// <summary>
	/// 1: $.extend(prop) - 
	///[short] Extends the jQuery object itself.
	///[desc] Extends the jQuery object itself. Can be used to add functions into
	///the jQuery namespace and to [[Plugins/Authoring|add plugin methods]] (plugins).The object that will be merged into the jQuery objectAdds two plugin methods.Adds two functions into the jQuery namespace
	/// 2: $.extend(target, prop1, propN) - 
	///[short] Extend one object with one or more others, returning the original,
	///modified, object.
	///[desc] Extend one object with one or more others, returning the original,
	///modified, object. This is a great utility for simple inheritance.The object to extendThe object that will be merged into the first.(optional) More objects to merge into the firstMerge settings and options, modifying settingsMerge defaults and options, without modifying the defaults
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="prop">
	/// 1: prop - The object that will be merged into the jQuery object
	/// 2: target - The object to extend
	/// </param>
	/// <param name="prop1" optional="true">
	/// 2: prop1 - The object that will be merged into the first.
	/// </param>
	/// <param name="propN" optional="true">
	/// 2: propN - (optional) More objects to merge into the first
	/// </param>
};

$.noConflict = function () {
	/// <summary>
	/// 
	///[short] Run this function to give control of the $ variable back
	///to whichever library first implemented it.
	///[desc] Run this function to give control of the $ variable back
	///to whichever library first implemented it. This helps to make 
	///sure that jQuery doesn't conflict with the $ object
	///of other libraries.
	///
	///By using this function, you will only be able to access jQuery
	///using the 'jQuery' variable. For example, where you used to do
	///$("div p"), you now must do jQuery("div p").Maps the original object that was referenced by $ back to $Reverts the $ alias and then creates and executes a
	///function to provide the $ as a jQuery alias inside the functions
	///scope. Inside the function the original $ object is not available.
	///This works well for most plugins that don't rely on any other library.
	/// </summary>
};

$.isFunction = function(a){};

$.isXMLDoc = function(a){};

$.globalEval = function(a){};

$.nodeName = function(b,a){};

$.cache = {};

$.data = function(c,d,b){};

$.removeData = function(c,b){};

$.each = function (obj, fn) {
	/// <summary>
	/// 
	///[short] A generic iterator function, which can be used to seamlessly
	///iterate over both objects and arrays.
	///[desc] A generic iterator function, which can be used to seamlessly
	///iterate over both objects and arrays. This function is not the same
	///as $().each() - which is used to iterate, exclusively, over a jQuery
	///object. This function can be used to iterate over anything.
	///
	///The callback has two arguments:the key (objects) or index (arrays) as first
	///the first, and the value as the second.The object, or array, to iterate over.The function that will be executed on every object.This is an example of iterating over the items in an array,
	///accessing both the current item and its index.This is an example of iterating over the properties in an
	///Object, accessing both the current item and its key.
	/// </summary>
	/// <returns type="Object"></returns>
	/// <param name="obj">The object, or array, to iterate over.</param>
	/// <param name="fn">The function that will be executed on every object.</param>
};

$.prop = function(b,a,c,i,d){};

$.className = {};

$.swap = function(b,c,a){};

$.css = function(d,e,c){};

$.curCSS = function(e,k,j){};

$.clean = function(l,h){};

$.attr = function(d,e,c){};

$.trim = function (str) {
	/// <summary>
	/// 
	///[short] Remove the whitespace from the beginning and end of a string.
	///[desc] Remove the whitespace from the beginning and end of a string.The string to trim.
	/// </summary>
	/// <returns type="String"></returns>
	/// <param name="str">The string to trim.</param>
};

$.makeArray = function(b){};

$.inArray = function(b,a){};

$.merge = function (first, second) {
	/// <summary>
	/// 
	///[short] Merge two arrays together, removing all duplicates.
	///[desc] Merge two arrays together, removing all duplicates.
	///
	///The result is the altered first argument with
	///the unique elements from the second array added.The first array to merge, the unique elements of second added.The second array to merge into the first, unaltered.Merges two arrays, removing the duplicate 2Merges two arrays, removing the duplicates 3 and 2
	/// </summary>
	/// <returns type="Array"></returns>
	/// <param name="first">The first array to merge, the unique elements of second added.</param>
	/// <param name="second">The second array to merge into the first, unaltered.</param>
};

$.unique = function(a){};

$.grep = function (array, fn, inv) {
	/// <summary>
	/// 
	///[short] Filter items out of an array, by using a filter function.
	///[desc] Filter items out of an array, by using a filter function.
	///
	///The specified function will be passed two arguments: The
	///current array item and the index of the item in the array. The
	///function must return 'true' to keep the item in the array, 
	///false to remove it.The Array to find items in.The function to process each item against.Invert the selection - select the opposite of the function.
	/// </summary>
	/// <returns type="Array"></returns>
	/// <param name="array">The Array to find items in.</param>
	/// <param name="fn">The function to process each item against.</param>
	/// <param name="inv">Invert the selection - select the opposite of the function.</param>
};

$.map = function (array, fn) {
	/// <summary>
	/// 
	///[short] Translate all items in an array to another array of items.
	///[desc] Translate all items in an array to another array of items.
	///
	///The translation function that is provided to this method is 
	///called for each item in the array and is passed one argument: 
	///The item to be translated.
	///
	///The function can then return the translated value, 'null'
	///(to remove the item), or  an array of values - which will
	///be flattened into the full array.The Array to translate.The function to process each item against.Maps the original array to a new one and adds 4 to each value.Maps the original array to a new one and adds 1 to each
	///value if it is bigger then zero, otherwise it's removed-Maps the original array to a new one, each element is added
	///with it's original value and the value plus one.
	/// </summary>
	/// <returns type="Array"></returns>
	/// <param name="array">The Array to translate.</param>
	/// <param name="fn">The function to process each item against.</param>
};

$.browser = {};

$.boxModel = {};

$.props = {};

$.expr = {};

$.parse = {};

$.multiFilter = function(a,c,b){};

$.find = function () {
	/// <summary>
	/// 
	///[desc] 
	/// </summary>
	/// <returns type="Array<Element>"></returns>
};

$.classFilter = function(r,m,a){};

$.filter = function(t,r,h){};

$.dir = function(b,c){};

$.nth = function (cur, num, dir) {
	/// <summary>
	/// 
	///[short] A handy, and fast, way to traverse in a particular direction and find
	///a specific element.
	///[desc] A handy, and fast, way to traverse in a particular direction and find
	///a specific element.The element to search from.The Nth result to match. Can be a number or a string (like 'even' or 'odd').The direction to move in (pass in something like 'previousSibling' or 'nextSibling').
	/// </summary>
	/// <returns type="DOMElement"></returns>
	/// <param name="cur">The element to search from.</param>
	/// <param name="num">The Nth result to match. Can be a number or a string (like 'even' or 'odd').</param>
	/// <param name="dir">The direction to move in (pass in something like 'previousSibling' or 'nextSibling').</param>
};

$.sibling = function (elem) {
	/// <summary>
	/// 
	///[short] All elements on a specified axis.
	///[desc] All elements on a specified axis.The element to find all the siblings of (including itself).
	/// </summary>
	/// <returns type="Array"></returns>
	/// <param name="elem">The element to find all the siblings of (including itself).</param>
};

$.event = {};

$.isReady = {};

$.readyList = {};

$.ready = function(){};

$.get = function (url, params, callback) {
	/// <summary>
	/// 
	///[short] Load a remote page using an HTTP GET request.
	///[desc] Load a remote page using an HTTP GET request.
	///
	///This is an easy way to send a simple GET request to a server
	///without having to use the more complex $.ajax function. It
	///allows a single callback function to be specified that will
	///be executed when the request is complete (and only if the response
	///has a successful response code). If you need to have both error
	///and success callbacks, you may want to use $.ajax.The URL of the page to load.(optional) Key/value pairs that will be sent to the server.(optional) A function to be executed whenever the data is loaded successfully.
	/// </summary>
	/// <returns type="XMLHttpRequest"></returns>
	/// <param name="url">The URL of the page to load.</param>
	/// <param name="params" optional="true">(optional) Key/value pairs that will be sent to the server.</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the data is loaded successfully.</param>
};

$.getScript = function (url, callback) {
	/// <summary>
	/// 
	///[short] Loads, and executes, a remote JavaScript file using an HTTP GET request.
	///[desc] Loads, and executes, a remote JavaScript file using an HTTP GET request.
	///
	///Warning: Safari <= 2.0.x is unable to evaluate scripts in a global
	///context synchronously. If you load functions via getScript, make sure
	///to call them after a delay.The URL of the page to load.(optional) A function to be executed whenever the data is loaded successfully.
	/// </summary>
	/// <returns type="XMLHttpRequest"></returns>
	/// <param name="url">The URL of the page to load.</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the data is loaded successfully.</param>
};

$.getJSON = function (url, params, callback) {
	/// <summary>
	/// 
	///[short] Load JSON data using an HTTP GET request.
	///[desc] Load JSON data using an HTTP GET request.The URL of the page to load.(optional) Key/value pairs that will be sent to the server.A function to be executed whenever the data is loaded successfully.
	/// </summary>
	/// <returns type="XMLHttpRequest"></returns>
	/// <param name="url">The URL of the page to load.</param>
	/// <param name="params" optional="true">(optional) Key/value pairs that will be sent to the server.</param>
	/// <param name="callback">A function to be executed whenever the data is loaded successfully.</param>
};

$.post = function (url, params, callback) {
	/// <summary>
	/// 
	///[short] Load a remote page using an HTTP POST request.
	///[desc] Load a remote page using an HTTP POST request.The URL of the page to load.(optional) Key/value pairs that will be sent to the server.(optional) A function to be executed whenever the data is loaded successfully.
	/// </summary>
	/// <returns type="XMLHttpRequest"></returns>
	/// <param name="url">The URL of the page to load.</param>
	/// <param name="params" optional="true">(optional) Key/value pairs that will be sent to the server.</param>
	/// <param name="callback" optional="true">(optional) A function to be executed whenever the data is loaded successfully.</param>
};

$.ajaxSetup = function (settings) {
	/// <summary>
	/// 
	///[short] Setup global settings for AJAX requests.
	///[desc] Setup global settings for AJAX requests.
	///
	///See $.ajax for a description of all available options.Key/value pairs to use for all AJAX requestsSets the defaults for AJAX requests to the url "/xmlhttp/",
	///disables global handlers and uses POST instead of GET. The following
	///AJAX requests then sends some data without having to set anything else.
	/// </summary>
	/// <param name="settings">Key/value pairs to use for all AJAX requests</param>
};

$.ajaxSettings = {};

$.lastModified = {};

$.ajax = function (properties) {
	/// <summary>
	/// 
	///[short] Load a remote page using an HTTP request.
	///[desc] Load a remote page using an HTTP request.
	///
	///This is jQuery's low-level AJAX implementation. See $.get, $.post etc. for
	///higher-level abstractions that are often easier to understand and use,
	///but don't offer as much functionality (such as error callbacks).
	///
	///$.ajax() returns the XMLHttpRequest that it creates. In most cases you won't
	///need that object to manipulate directly, but it is available if you need to
	///abort the request manually.
	///
	///'''Note:''' If you specify the dataType option described below, make sure
	///the server sends the correct MIME type in the response (eg. xml as "text/xml").
	///Sending the wrong MIME type can lead to unexpected problems in your script.
	///See [[Specifying the Data Type for AJAX Requests]] for more information.
	///
	///Supported datatypes are (see dataType option):
	///
	///"xml": Returns a XML document that can be processed via jQuery.
	///
	///"html": Returns HTML as plain text, included script tags are evaluated.
	///
	///"script": Evaluates the response as Javascript and returns it as plain text.
	///
	///"json": Evaluates the response as JSON and returns a Javascript Object
	///
	///$.ajax() takes one argument, an object of key/value pairs, that are
	///used to initalize and handle the request. These are all the key/values that can
	///be used:
	///
	///(String) url - The URL to request.
	///
	///(String) type - The type of request to make ("POST" or "GET"), default is "GET".
	///
	///(String) dataType - The type of data that you're expecting back from
	///the server. No default: If the server sends xml, the responseXML, otherwise
	///the responseText is passed to the success callback.
	///
	///(Boolean) ifModified - Allow the request to be successful only if the
	///response has changed since the last request. This is done by checking the
	///Last-Modified header. Default value is false, ignoring the header.
	///
	///(Number) timeout - Local timeout to override global timeout, eg. to give a
	///single request a longer timeout while all others timeout after 1 second.
	///See $.ajaxTimeout() for global timeouts.
	///
	///(Boolean) global - Whether to trigger global AJAX event handlers for
	///this request, default is true. Set to false to prevent that global handlers
	///like ajaxStart or ajaxStop are triggered.
	///
	///(Function) error - A function to be called if the request fails. The
	///function gets passed tree arguments: The XMLHttpRequest object, a
	///string describing the type of error that occurred and an optional
	///exception object, if one occured.
	///
	///(Function) success - A function to be called if the request succeeds. The
	///function gets passed one argument: The data returned from the server,
	///formatted according to the 'dataType' parameter.
	///
	///(Function) complete - A function to be called when the request finishes. The
	///function gets passed two arguments: The XMLHttpRequest object and a
	///string describing the type of success of the request.
	///
	///(Object|String) data - Data to be sent to the server. Converted to a query
	///string, if not already a string. Is appended to the url for GET-requests.
	///See processData option to prevent this automatic processing.
	///
	///(String) contentType - When sending data to the server, use this content-type.
	///Default is "application/x-www-form-urlencoded", which is fine for most cases.
	///
	///(Boolean) processData - By default, data passed in to the data option as an object
	///other as string will be processed and transformed into a query string, fitting to
	///the default content-type "application/x-www-form-urlencoded". If you want to send
	///DOMDocuments, set this option to false.
	///
	///(Boolean) async - By default, all requests are sent asynchronous (set to true).
	///If you need synchronous requests, set this option to false.
	///
	///(Function) beforeSend - A pre-callback to set custom headers etc., the
	///XMLHttpRequest is passed as the only argument.Key/value pairs to initialize the request with.Load and execute a JavaScript file.Save some data to the server and notify the user once its complete.Loads data synchronously. Blocks the browser while the requests is active.
	///It is better to block user interaction by other means when synchronization is
	///necessary.Sends an xml document as data to the server. By setting the processData
	///option to false, the automatic conversion of data to strings is prevented.
	/// </summary>
	/// <returns type="XMLHttpRequest"></returns>
	/// <param name="properties">Key/value pairs to initialize the request with.</param>
};

$.handleError = function(s,a,b,e){};

$.active = {};

$.httpSuccess = function(r){};

$.httpNotModified = function(a,c){};

$.httpData = function(r,b){};

$.param = function(a){};

$.speed = function(b,a,c){};

$.easing = {};

$.timers = {};

$.fx = function(b,c,a){};

$.easing.linear = function(p,n,b,a){};

$.easing.swing = function(p,n,b,a){};

$.ajaxSettings.global = {};

$.ajaxSettings.type = {};

$.ajaxSettings.timeout = {};

$.ajaxSettings.contentType = {};

$.ajaxSettings.processData = {};

$.ajaxSettings.async = {};

$.ajaxSettings.data = {};

$.ajaxSettings.username = {};

$.ajaxSettings.password = {};

$.ajaxSettings.accepts = {};

$.ajaxSettings.accepts.xml = {};

$.ajaxSettings.accepts.html = {};

$.ajaxSettings.accepts.script = {};

$.ajaxSettings.accepts.json = {};

$.ajaxSettings.accepts.text = {};

$.ajaxSettings.accepts._default = {};

$.props.float = {};

$.props.cssFloat = {};

$.props.styleFloat = {};

$.props.innerHTML = {};

$.props.className = {};

$.props.value = {};

$.props.disabled = {};

$.props.checked = {};

$.props.readonly = {};

$.props.selected = {};

$.props.maxlength = {};

$.props.selectedIndex = {};

$.props.defaultValue = {};

$.props.tagName = {};

$.props.nodeName = {};

$.browser.version = {};

$.browser.safari = {};

$.browser.opera = {};

$.browser.msie = {};

$.browser.mozilla = {};

$.className.add = function(c,b){};

$.className.remove = function(c,b){};

$.className.has = function(b,a){};
