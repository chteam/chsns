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
    public partial class FriendController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public FriendController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected FriendController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Index() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult RequestHack() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.RequestHack);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult FriendList() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.FriendList);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult RequestList() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.RequestList);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Add() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Add);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Delete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Agree() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Agree);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Ignore() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Ignore);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public FriendController Actions { get { return MVC.Friend; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "friend";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Random = ("Random").ToLowerInvariant();
            public readonly string Index = ("Index").ToLowerInvariant();
            public readonly string RequestHack = ("Request").ToLowerInvariant();
            public readonly string FriendList = ("FriendList").ToLowerInvariant();
            public readonly string RequestList = ("RequestList").ToLowerInvariant();
            public readonly string RandomList = ("RandomList").ToLowerInvariant();
            public readonly string Add = ("Add").ToLowerInvariant();
            public readonly string Delete = ("Delete").ToLowerInvariant();
            public readonly string Agree = ("Agree").ToLowerInvariant();
            public readonly string Ignore = ("Ignore").ToLowerInvariant();
            public readonly string IgnoreAll = ("IgnoreAll").ToLowerInvariant();
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string FriendList = "~/Views/Friend/FriendList.ascx";
            public readonly string Index = "~/Views/Friend/Index.aspx";
            public readonly string Random = "~/Views/Friend/Random.aspx";
            public readonly string RandomList = "~/Views/Friend/RandomList.ascx";
            public readonly string Request = "~/Views/Friend/Request.aspx";
            public readonly string RequestList = "~/Views/Friend/RequestList.ascx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_FriendController: CHSNS.Controllers.FriendController {
        public T4MVC_FriendController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Random() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Random);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Index(int? p, long? userid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            callInfo.RouteValueDictionary.Add("p", p);
            callInfo.RouteValueDictionary.Add("userid", userid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult RequestHack(int? p) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.RequestHack);
            callInfo.RouteValueDictionary.Add("p", p);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult FriendList(int p, long userid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.FriendList);
            callInfo.RouteValueDictionary.Add("p", p);
            callInfo.RouteValueDictionary.Add("userid", userid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult RequestList(int p, long userid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.RequestList);
            callInfo.RouteValueDictionary.Add("p", p);
            callInfo.RouteValueDictionary.Add("userid", userid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult RandomList() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.RandomList);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Add(long toid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Add);
            callInfo.RouteValueDictionary.Add("toid", toid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(long toid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
            callInfo.RouteValueDictionary.Add("toid", toid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Agree(long uid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Agree);
            callInfo.RouteValueDictionary.Add("uid", uid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Ignore(long uid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Ignore);
            callInfo.RouteValueDictionary.Add("uid", uid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult IgnoreAll() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.IgnoreAll);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
