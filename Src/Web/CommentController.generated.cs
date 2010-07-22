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
    public partial class CommentController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CommentController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CommentController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Reply() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Reply);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ReplyList() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ReplyList);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult AddReply() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.AddReply);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult DeleteReply() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.DeleteReply);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult List() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.List);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Delete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Add() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Add);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CommentController Actions { get { return MVC.Comment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "comment";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Reply = ("Reply").ToLowerInvariant();
            public readonly string ReplyList = ("ReplyList").ToLowerInvariant();
            public readonly string AddReply = ("AddReply").ToLowerInvariant();
            public readonly string DeleteReply = ("DeleteReply").ToLowerInvariant();
            public readonly string List = ("List").ToLowerInvariant();
            public readonly string Delete = ("Delete").ToLowerInvariant();
            public readonly string Add = ("Add").ToLowerInvariant();
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Reply = "~/Views/Comment/Reply.aspx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_CommentController: CHSNS.Controllers.CommentController {
        public T4MVC_CommentController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Reply(long? userid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Reply);
            callInfo.RouteValueDictionary.Add("userid", userid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ReplyList(long userid, int p) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ReplyList);
            callInfo.RouteValueDictionary.Add("userid", userid);
            callInfo.RouteValueDictionary.Add("p", p);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult AddReply(long replyerId, string body, long userID) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.AddReply);
            callInfo.RouteValueDictionary.Add("replyerId", replyerId);
            callInfo.RouteValueDictionary.Add("body", body);
            callInfo.RouteValueDictionary.Add("userID", userID);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DeleteReply(long id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DeleteReply);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult List(long id, int p, CHSNS.CommentType type) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.List);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("p", p);
            callInfo.RouteValueDictionary.Add("type", type);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(long id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Add(long showerId, long ownerId, string body, CHSNS.CommentType type) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Add);
            callInfo.RouteValueDictionary.Add("showerId", showerId);
            callInfo.RouteValueDictionary.Add("ownerId", ownerId);
            callInfo.RouteValueDictionary.Add("body", body);
            callInfo.RouteValueDictionary.Add("type", type);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
