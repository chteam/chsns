// Name:        PreviewScript.debug.js
// Assembly:    Microsoft.Web.Preview
// Version:     1.2.61025.0
// FileVersion: 1.2.61025.0
//-----------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------
// PreviewScript.js
// Microsoft AJAX Value Add Framework.



Type.registerNamespace('Sys.Preview');



if (!Sys.Serialization.JavaScriptSerializer._dateRegEx) {
    Sys.Serialization.JavaScriptSerializer._dateRegEx = new RegExp('(^|[^\\\\])\\"\\\\/Date\\((-?[0-9]+)\\)\\\\/\\"', 'g');
    Sys.Serialization.JavaScriptSerializer._jsonRegEx = new RegExp('[^,:{}\\[\\]0-9.\\-+Eaeflnr-u \\n\\r\\t]', 'g');
    Sys.Serialization.JavaScriptSerializer._jsonStringRegEx = new RegExp('"(\\\\.|[^"\\\\])*"', 'g');
    
    Sys.Serialization.JavaScriptSerializer.deserialize = function Sys$Serialization$JavaScriptSerializer$deserialize(data, secure) {
        /// <param name="data" type="String"></param>
        /// <param name="secure" type="Boolean" optional="true"></param>
        /// <returns></returns>
        var e = Function._validateParams(arguments, [
            {name: "data", type: String},
            {name: "secure", type: Boolean, optional: true}
        ]);
        if (e) throw e;

        
        if (data.length === 0) throw Error.argument('data', Sys.Res.cannotDeserializeEmptyString);
        try {    
            var exp = data.replace(Sys.Serialization.JavaScriptSerializer._dateRegEx, "$1new Date($2)");
            
            if (secure && Sys.Serialization.JavaScriptSerializer._jsonRegEx.test(
                 exp.replace(Sys.Serialization.JavaScriptSerializer._jsonStringRegEx, ''))) throw null;

            return eval('(' + exp + ')');
        }
        catch (e) {
             throw Error.argument('data', Sys.Res.cannotDeserializeInvalidJson);
        }
    }
}




Sys.Preview.HistoryEventArgs = function Sys$Preview$HistoryEventArgs(state) {
    /// <param name="state" type="Object"></param>
    var e = Function._validateParams(arguments, [
        {name: "state", type: Object}
    ]);
    if (e) throw e;

    Sys.Preview.HistoryEventArgs.initializeBase(this);
    this._state = state;
}

    function Sys$Preview$HistoryEventArgs$get_state() {
        /// <value type="Object"></value>
        if (arguments.length !== 0) throw Error.parameterCount();
        return this._state;
    }
Sys.Preview.HistoryEventArgs.prototype = {
    get_state: Sys$Preview$HistoryEventArgs$get_state
}
Sys.Preview.HistoryEventArgs.registerClass('Sys.Preview.HistoryEventArgs', Sys.EventArgs);

Sys.Preview._History = function Sys$Preview$_History() {
    Sys.Preview._History.initializeBase(this);
    
    this._appLoadHandler = null;
    this._beginRequestHandler = null;
    this._clientId = null;
    this._currentEntry = '';
    this._emptyPageUrl = null;
    this._endRequestHandler = null;
    this._history = null;
    this._historyFrame = null;
    this._historyInitialLength = 0;
    this._historyLength = 0;
    this._iframeLoadHandler = null;
    this._ignoreIFrame = false;
    this._ignoreTimer = false;
    this._historyPointIsNew = false;
    this._state = {};
    this._timerCookie = 0;
    this._timerHandler = null;
    this._uniqueId = null;
}

    function Sys$Preview$_History$get_stateString() {
        /// <value type="String"></value>
        if (arguments.length !== 0) throw Error.parameterCount();
        var hash = (Sys.Browser.agent === Sys.Browser.Safari && this._history) ?
            this._history[window.history.length - this._historyInitialLength]:
            window.location.hash;
        var entry = decodeURIComponent(hash || '');
        if ((entry.length > 0) && (entry.charAt(0) === '#')) {
            entry = entry.substring(1);
        }
        return entry;
    }
    function Sys$Preview$_History$add_navigate(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().addHandler("navigate", handler);
    }
    function Sys$Preview$_History$remove_navigate(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().removeHandler("navigate", handler);
    }

    function Sys$Preview$_History$addHistoryPoint(state, title) {
        /// <param name="state" type="Object"></param>
        /// <param name="title" type="String" optional="true" mayBeNull="true"></param>
        var e = Function._validateParams(arguments, [
            {name: "state", type: Object},
            {name: "title", type: String, mayBeNull: true, optional: true}
        ]);
        if (e) throw e;


        var initialState = this._state;
        for (var key in state) {
            var value = state[key];
            if (value === null) {
                if (typeof(initialState[key]) !== 'undefined') {
                    delete initialState[key];
                }
            }
            else {
                initialState[key] = value;
            }
        }
        var entry = Sys.Serialization.JavaScriptSerializer.serialize(initialState);
        this._ignoreIFrame = true;
        this._historyPointIsNew = true;
        this._setState(entry, title);
    }
    function Sys$Preview$_History$dispose() {
        if (this._appLoadHandler) {
            Sys.Application.remove_load(this._appLoadHandler);
            delete this._appLoadHandler;
        }
        if (this._historyFrame) {
            Sys.UI.DomEvent.removeHandler(this._historyFrame, 'load', this._iframeLoadHandler);
            delete this._iframeLoadHandler;
            delete this._historyFrame;
        }
        if (this._timerCookie) {
            window.clearTimeout(this._timerCookie);
            delete this._timerCookie;
        }
        if (this._endRequestHandler) {
            Sys.WebForms.PageRequestManager.getInstance().remove_endRequest(this._endRequestHandler);
            delete this._endRequestHandler;
        }
        if (this._beginRequestHandler) {
            Sys.WebForms.PageRequestManager.getInstance().remove_beginRequest(this._beginRequestHandler);
            delete this._beginRequestHandler;
        }
        Sys.Preview._History.callBaseMethod(this, 'dispose');
    }
    function Sys$Preview$_History$initialize() {
        Sys.Preview._History.callBaseMethod(this, 'initialize');
        
        this._appLoadHandler = Function.createDelegate(this, this._onApplicationLoaded);
        Sys.Application.add_load(this._appLoadHandler);
    }
    function Sys$Preview$_History$setServerId(clientId, uniqueId) {
        /// <param name="clientId" type="String"></param>
        /// <param name="uniqueId" type="String"></param>
        var e = Function._validateParams(arguments, [
            {name: "clientId", type: String},
            {name: "uniqueId", type: String}
        ]);
        if (e) throw e;

        this._clientId = clientId;
        this._uniqueId = uniqueId;
    }
    function Sys$Preview$_History$setServerState(value) {
        this._state.__s = value;
    }

    function Sys$Preview$_History$_navigate(entry) {

        var state = {};
        if (entry) {
            try {
                state = Sys.Serialization.JavaScriptSerializer.deserialize(entry, true);
            } catch(e) {
            }
        }
        
        if (this._uniqueId) {
            var oldServerEntry = this._state.__s || '';
            var newServerEntry = state.__s || '';
            if (newServerEntry !== oldServerEntry) {
                __doPostBack(this._uniqueId, newServerEntry);
                this._state = state;
                return;
            }
        }
        this._setState(entry);
        this._state = state;
        this._raiseNavigate();
    }
    function Sys$Preview$_History$_onApplicationLoaded(sender, args) {
        Sys.Application.remove_load(this._appLoadHandler);
        delete this._appLoadHandler;

        if (Sys.WebForms) {
                                    var elt = document.createElement('DIV');
            elt.id = this._clientId;
            elt.style.display = 'none';
            document.body.appendChild(elt);
                        this._beginRequestHandler = Function.createDelegate(this, this._onPageRequestManagerBeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(this._beginRequestHandler);
            this._endRequestHandler = Function.createDelegate(this, this._onPageRequestManagerEndRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(this._endRequestHandler);
        }
        
        if (Sys.Browser.agent === Sys.Browser.InternetExplorer) {
            
            var frameId = '__historyFrame';
            var frame = document.getElementById(frameId);
            if (!frame) throw Error.invalidOperation("For the history feature to work in IE, the page must have an iframe with id '__historyFrame' and src set to point to a page that sets its title to the 'title' querystring parameter when loaded.");
            var src = frame.src;
            this._emptyPageUrl = src + (src.indexOf('?') === -1 ? '?' : '&') + '_state=';
            this._historyFrame = frame;
                        if (frame.readyState === 'loading') {
                this._ignoreIFrame = true;
            }
            
            this._iframeLoadHandler = Function.createDelegate(this, this._onIFrameLoad);
            Sys.UI.DomEvent.addHandler(this._historyFrame, 'load', this._iframeLoadHandler);
        }
        if (Sys.Browser.agent === Sys.Browser.Safari) {
            this._history = [window.location.hash];
            this._historyInitialLength = window.history.length;
        }
        
        this._timerHandler = Function.createDelegate(this, this._onIdle);
        this._timerCookie = window.setTimeout(this._timerHandler, 100);
        
        var loadedEntry = this.get_stateString();
        if (loadedEntry !== this._currentEntry) {
            this._navigate(loadedEntry);
        }
    }
    function Sys$Preview$_History$_onIdle() {
        delete this._timerCookie;
        
        var entry = this.get_stateString();
        if (entry !== this._currentEntry) {
            if (!this._ignoreTimer) {
                this._historyPointIsNew = false;
                this._navigate(entry);
                this._historyLength = window.history.length;
            }
        }
        else {
            this._ignoreTimer = false;
        }
        this._timerCookie = window.setTimeout(this._timerHandler, 100);
    }
    function Sys$Preview$_History$_onIFrameLoad() {
        if (!this._ignoreIFrame) {
            var entry = this._historyFrame.contentWindow.location.search;
            var statePos = entry.indexOf('_state=');
            if ((statePos !== -1) && (statePos + 7 < entry.length)) {
                entry = entry.substring(statePos + 7);
                var next = entry.indexOf('&');
                if (next !== -1) {
                    entry = entry.substring(0, next);
                }
            }
            else {
                entry = '';
            }
            this._historyPointIsNew = false;
            this._navigate(entry);
        }
        this._ignoreIFrame = false;
    }
    function Sys$Preview$_History$_onPageRequestManagerBeginRequest(sender, args) {
        this._ignoreTimer = true;
    }
    function Sys$Preview$_History$_onPageRequestManagerEndRequest(sender, args) {
        var dataItem = args.get_dataItems()[this._clientId], title;


        if (typeof(dataItem) !== 'undefined') {
            var state = dataItem[0];
            title = dataItem[1];
            this.setServerState(state);
            this._historyPointIsNew = true;
        }
        else {
            this._ignoreTimer = false;
        }
        var entry = Sys.Serialization.JavaScriptSerializer.serialize(this._state);
        if (entry === '{}') {
            entry = '';
        }
        if (entry != this._currentEntry) {
            this._ignoreTimer = true;
            this._setState(entry, title);
            this._raiseNavigate();
        }
    }
    function Sys$Preview$_History$_raiseNavigate() {

        var h = this.get_events().getHandler("navigate");
        var args = new Sys.Preview.HistoryEventArgs(this._state);
        if (h) {
            h(this, args);
        }
        if (window.pageNavigate) {
            window.pageNavigate(this, args);
        }
    }
    function Sys$Preview$_History$_setState(entry, title) {
        if (entry !== this._currentEntry) {
            if (this._historyFrame && this._historyPointIsNew) {
                var newFrameUrl = this._emptyPageUrl + entry +
                    '&title=' + encodeURIComponent(title || document.title);
                                if (this._historyFrame.src != newFrameUrl) {
                    this._ignoreIFrame = true;
                    this._historyFrame.src = newFrameUrl;
                }
                this._historyPointIsNew = false;
            }
            this._ignoreTimer = false;
            this._currentEntry = entry;
            var currentHash = this.get_stateString();
            if (currentHash === '{}') {
                currentHash = '';
                this._currentEntry = null;
            }
            if (entry !== currentHash) {
                var encodedEntry = entry ? encodeURIComponent(entry) : '';
                if (Sys.Browser.agent === Sys.Browser.Safari) {
                                                                                                                                            this._history[window.history.length - this._historyInitialLength + 1] = entry;
                    this._historyLength = window.history.length + 1;
                                                            var form = document.createElement('FORM');
                    form.method = 'get';
                    form.action = '#' + encodedEntry;
                    document.appendChild(form);
                    form.submit();
                    document.removeChild(form);
                }
                else {
                    window.location.hash = encodedEntry;
                }
                if ((typeof(title) !== 'undefined') && (title !== null)) {
                    document.title = title;
                }
            }
        }
    }
Sys.Preview._History.prototype = {
    get_stateString: Sys$Preview$_History$get_stateString,
    add_navigate: Sys$Preview$_History$add_navigate,
    remove_navigate: Sys$Preview$_History$remove_navigate,

    addHistoryPoint: Sys$Preview$_History$addHistoryPoint,
    dispose: Sys$Preview$_History$dispose,
    initialize: Sys$Preview$_History$initialize,
    setServerId: Sys$Preview$_History$setServerId,
    setServerState: Sys$Preview$_History$setServerState,
    
    _navigate: Sys$Preview$_History$_navigate,
    _onApplicationLoaded: Sys$Preview$_History$_onApplicationLoaded,
    _onIdle: Sys$Preview$_History$_onIdle,
    _onIFrameLoad: Sys$Preview$_History$_onIFrameLoad,
    _onPageRequestManagerBeginRequest: Sys$Preview$_History$_onPageRequestManagerBeginRequest,
    _onPageRequestManagerEndRequest: Sys$Preview$_History$_onPageRequestManagerEndRequest,
    _raiseNavigate: Sys$Preview$_History$_raiseNavigate,
    _setState: Sys$Preview$_History$_setState
}
Sys.Preview._History.registerClass('Sys.Preview._History', Sys.Component);

Sys._Application.prototype.get_history = function Sys$_Application$get_history() {
    var h = this._history;
    if (!h) {
        h = this._history = new Sys.Preview._History();
        Sys.Application.registerDisposableObject(h);
        h.initialize();
    }
    return h;
}


if(typeof(Sys)!=='undefined')Sys.Application.notifyScriptLoaded();
