// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace CHSNS.Controllers {
    public partial class VideoController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public VideoController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected VideoController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult List() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.List);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Del() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Del);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public VideoController Actions { get { return MVC.Video; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "video";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Edit = ("Edit").ToLowerInvariant();
            public readonly string List = ("List").ToLowerInvariant();
            public readonly string Del = ("Del").ToLowerInvariant();
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Edit = "~/Views/Video/Edit.aspx";
            public readonly string Items = "~/Views/Video/Items.ascx";
            public readonly string List = "~/Views/Video/List.aspx";
            public readonly string Random = "~/Views/Video/Random.aspx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_VideoController: CHSNS.Controllers.VideoController {
        public T4MVC_VideoController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Edit() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(CHSNS.Models.SuperNote v) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("v", v);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult List(long? uid, int? p) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.List);
            callInfo.RouteValueDictionary.Add("uid", uid);
            callInfo.RouteValueDictionary.Add("p", p);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Del(long[] uid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Del);
            callInfo.RouteValueDictionary.Add("uid", uid);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591