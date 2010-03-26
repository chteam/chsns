Type.registerNamespace('AjaxControlToolkit');AjaxControlToolkit.HoverMenuBehavior=function(element){AjaxControlToolkit.HoverMenuBehavior.initializeBase(this,[element]);this._hb=null;this._pb=null;this._mEH=null;this._mLH=null;this._uH=null;this._hH=null;this._ih=null;this._oC=null;this._pE=null;this._oSJ=null;this._oHJ=null;this._hCC=null;this._oX=0;this._oY=0;this._pD=100;this._pP=null};AjaxControlToolkit.HoverMenuBehavior.prototype={initialize:function(){AjaxControlToolkit.HoverMenuBehavior.callBaseMethod(this,'initialize');this._hH=Function.createDelegate(this,this._onHover);this._uH=Function.createDelegate(this,this._onUnhover);this._mEH=Function.createDelegate(this,this._onmouseover);this._mLH=Function.createDelegate(this,this._onmouseout);var e=this.get_element();$addHandler(e,"mouseover",this._mEH);$addHandler(e,"mouseout",this._mLH);if(this._pE){this._pb=$create(AjaxControlToolkit.PopupBehavior,{"id":this.get_id()+"_pb"},null,null,this._pE);if(this._pP){this._pb.set_positioningMode(AjaxControlToolkit.HoverMenuPopupPosition.Absolute)}else{this._pb.set_positioningMode(AjaxControlToolkit.HoverMenuPopupPosition.Center)};if(this._oSJ){this._pb.set_onShow(this._oSJ)};if(this._oHJ){this._pb.set_onHide(this._oHJ)};this._hb=$create(AjaxControlToolkit.HoverBehavior,{"id":this.get_id()+"_HoverBehavior","unhoverDelay":this._pD,"hoverElement":this._pE},null,null,e);this._hb.add_hover(this._hH);this._hb.add_unhover(this._uH)}},dispose:function(){this._oSJ=null;this._oHJ=null;if(this._pb){this._pb.dispose();this._pb=null};if(this._pE){this._pE=null};if(this._mEH){$removeHandler(this.get_element(),"mouseover",this._mEH)};if(this._mLH){$removeHandler(this.get_element(),"mouseout",this._mLH)};if(this._hb){if(this._hH){this._hb.remove_hover(this._hH);this._hH=null};if(this._uH){this._hb.remove_hover(this._uH);this._uH=null};this._hb.dispose();this._hb=null};AjaxControlToolkit.HoverMenuBehavior.callBaseMethod(this,'dispose')},_getLeftOffset:function(){var dt=$common.getLocation(this.get_element()).x;var ot=$common.getLocation(this.get_popupElement().offsetParent).x;var da=0;switch(this._pP){case AjaxControlToolkit.HoverMenuPopupPosition.Left:da=(-1*this._pE.offsetWidth);break;case AjaxControlToolkit.HoverMenuPopupPosition.Right:da=this.get_element().offsetWidth;break};return da+dt-ot+this._oX},_getTopOffset:function(){var dt=$common.getLocation(this.get_element()).y;var ot=$common.getLocation(this.get_popupElement().offsetParent).y;var da=0;switch(this._pP){case AjaxControlToolkit.HoverMenuPopupPosition.Top:da=(-1*this._pE.offsetHeight);break;case AjaxControlToolkit.HoverMenuPopupPosition.Bottom:da=this.get_element().offsetHeight;break};return dt-ot+da+this._oY},_onHover:function(){if(this._ih)return;var e=new Sys.CancelEventArgs();this.raiseShowing(e);if(e.get_cancel()){return};this._ih=true;this.populate();this._pb.show();if($common.getCurrentStyle(this._pE,'display')=='none'){this._pE.style.display='block'};this._pb.set_x(this._getLeftOffset());this._pb.set_y(this._getTopOffset());this.raiseShown(Sys.EventArgs.Empty)},_onUnhover:function(){var e=new Sys.CancelEventArgs();this.raiseHiding(e);if(e.get_cancel()){return};this._ih=false;this._resetCssClass();this._pb.hide();this.raiseHidden(Sys.EventArgs.Empty)},_onmouseover:function(){var e=this.get_element();if(this._hCC&&e.className!=this._hCC){this._oC=e.className;e.className=this._hCC}},_onmouseout:function(){this._resetCssClass()},_resetCssClass:function(){var e=this.get_element();if(!this._ih&&this._hCC&&e.className==this._hCC){e.className=this._oC}},get_onShow:function(){return this._pb?this._pb.get_onShow():this._oSJ},set_onShow:function(v){if(this._pb){this._pb.set_onShow(v)}else{this._oSJ=v};this.raisePropertyChanged('onShow')},get_onShowBehavior:function(){return this._pb?this._pb.get_onShowBehavior():null},onShow:function(){if(this._pb){this._pb.onShow()}},get_onHide:function(){return this._pb?this._pb.get_onHide():this._oHJ},set_onHide:function(v){if(this._pb){this._pb.set_onHide(v)}else{this._oHJ=v};this.raisePropertyChanged('onHide')},get_onHideBehavior:function(){return this._pb?this._pb.get_onHideBehavior():null},onHide:function(){if(this._pb){this._pb.onHide()}},get_popupElement:function(){return this._pE},set_popupElement:function(v){if(this._pE!=v){this._pE=v;if(this.get_isInitialized()&&this._hb){this._hb.set_hoverElement(this._pE)};this.raisePropertyChanged('popupElement')}},get_HoverCssClass:function(){return this._hCC},set_HoverCssClass:function(v){if(this._hCC!=v){this._hCC=v;this.raisePropertyChanged('HoverCssClass')}},get_OffsetX:function(){return this._oX},set_OffsetX:function(v){if(this._oX!=v){this._oX=v;this.raisePropertyChanged('OffsetX')}},get_OffsetY:function(){return this._oY},set_OffsetY:function(v){if(this._oY!=v){this._oY=v;this.raisePropertyChanged('OffsetY')}},get_PopupPosition:function(){return this._pP},set_PopupPosition:function(v){if(this._pP!=v){this._pP=v;this.raisePropertyChanged('PopupPosition')}},get_PopDelay:function(){return this._pD},set_PopDelay:function(v){if(this._pD!=v){this._pD=v;this.raisePropertyChanged('PopDelay')}},_ar:function(s,e){var h=this.get_events().getHandler(s);if(h){h(this,e)}},_ah:function(s,h){this.get_events().addHandler(s,h)},_rh:function(s,h){this.get_events().removeHandler(s,h)},add_showing:function(h){this._ah('showing',h)},remove_showing:function(h){this._rh('showing',h)},raiseShowing:function(e){this._ar('showing',e)},add_shown:function(h){this._ah('shown',h)},remove_shown:function(h){this._rh('shown',h)},raiseShown:function(e){this._ar('shown',e)},add_hiding:function(h){this._ah('hiding',h)},remove_hiding:function(h){this._rh('hiding',h)},raiseHiding:function(e){this._ar('hiding',e)},add_hidden:function(h){this._ah('hidden',h)},remove_hidden:function(h){this._rh('hidden',h)},raiseHidden:function(e){this._ar('hidden',e)}};AjaxControlToolkit.HoverMenuBehavior.registerClass('AjaxControlToolkit.HoverMenuBehavior',AjaxControlToolkit.DynamicPopulateBehaviorBase);AjaxControlToolkit.HoverMenuPopupPosition=function(){throw Error.invalidOperation()};AjaxControlToolkit.HoverMenuPopupPosition.prototype={Center:0,Top:1,Left:2,Bottom:3,Right:4};AjaxControlToolkit.HoverMenuPopupPosition.registerEnum('AjaxControlToolkit.HoverMenuPopupPosition');