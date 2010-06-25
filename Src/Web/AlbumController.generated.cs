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
    public partial class AlbumController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AlbumController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AlbumController(Dummy d) { }

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
        public System.Web.Mvc.ActionResult Edit() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Details() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Upload() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Upload);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult UploadPhoto() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.UploadPhoto);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult PhotoDel() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.PhotoDel);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult SetFace() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.SetFace);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AlbumController Actions { get { return MVC.Album; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "album";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = ("Index").ToLowerInvariant();
            public readonly string Edit = ("Edit").ToLowerInvariant();
            public readonly string Details = ("Details").ToLowerInvariant();
            public readonly string Upload = ("Upload").ToLowerInvariant();
            public readonly string UploadPhoto = ("UploadPhoto").ToLowerInvariant();
            public readonly string PhotoDel = ("PhotoDel").ToLowerInvariant();
            public readonly string SetFace = ("SetFace").ToLowerInvariant();
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Details = "~/Views/Album/Details.aspx";
            public readonly string Edit = "~/Views/Album/Edit.aspx";
            public readonly string Index = "~/Views/Album/Index.aspx";
            public readonly string List = "~/Views/Album/List.aspx";
            public readonly string Upload = "~/Views/Album/Upload.aspx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_AlbumController: CHSNS.Controllers.AlbumController {
        public T4MVC_AlbumController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index(int? p, long? uid) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            callInfo.RouteValueDictionary.Add("p", p);
            callInfo.RouteValueDictionary.Add("uid", uid);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(long? id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(long? id, CHSNS.Models.Album a) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("a", a);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Details(long id, int? p) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Details);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("p", p);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Upload(long? id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Upload);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult UploadPhoto(string name, long id, System.Web.HttpPostedFileBase file) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.UploadPhoto);
            callInfo.RouteValueDictionary.Add("name", name);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("file", file);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult PhotoDel(long id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.PhotoDel);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SetFace(long id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SetFace);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
