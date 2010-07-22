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
    public partial class UserController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UserController(Dummy d) { }

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
        public System.Web.Mvc.ActionResult EventDelete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EventDelete);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController Actions { get { return MVC.User; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "user";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = ("Index").ToLowerInvariant();
            public readonly string EventDelete = ("EventDelete").ToLowerInvariant();
            public readonly string BaseInfo = ("BaseInfo").ToLowerInvariant();
            public readonly string School = ("School").ToLowerInvariant();
            public readonly string Contact = ("Contact").ToLowerInvariant();
            public readonly string Personal = ("Personal").ToLowerInvariant();
            public readonly string Upload = ("Upload").ToLowerInvariant();
            public readonly string DeleteFace = ("DeleteFace").ToLowerInvariant();
            public readonly string ManageUser = ("ManageUser").ToLowerInvariant();
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string BaseInfo = "~/Views/User/BaseInfo.aspx";
            public readonly string Contact = "~/Views/User/Contact.ascx";
            public readonly string EmptyMagicBox = "~/Views/User/EmptyMagicBox.ascx";
            public readonly string Index = "~/Views/User/Index.aspx";
            public readonly string MagicBox = "~/Views/User/MagicBox.aspx";
            public readonly string Personal = "~/Views/User/Personal.ascx";
            public readonly string School = "~/Views/User/School.ascx";
            public readonly string Upload = "~/Views/User/Upload.aspx";
            static readonly _Admin s_Admin = new _Admin();
            public _Admin Admin { get { return s_Admin; } }
            public partial class _Admin{
                public readonly string ManageUser = "~/Views/User/Admin/ManageUser.ascx";
            }
            static readonly _IndexChild s_IndexChild = new _IndexChild();
            public _IndexChild IndexChild { get { return s_IndexChild; } }
            public partial class _IndexChild{
                public readonly string Account = "~/Views/User/IndexChild/Account.ascx";
                public readonly string Contact = "~/Views/User/IndexChild/Contact.ascx";
                public readonly string Event = "~/Views/User/IndexChild/Event.ascx";
                public readonly string MyActions = "~/Views/User/IndexChild/MyActions.ascx";
                public readonly string MyStatus = "~/Views/User/IndexChild/MyStatus.ascx";
                public readonly string NoRight = "~/Views/User/IndexChild/NoRight.ascx";
                public readonly string Personal = "~/Views/User/IndexChild/Personal.ascx";
                public readonly string School = "~/Views/User/IndexChild/School.ascx";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_UserController: CHSNS.Controllers.UserController {
        public T4MVC_UserController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index(long? userId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            callInfo.RouteValueDictionary.Add("userId", userId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EventDelete(long id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EventDelete);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult BaseInfo() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.BaseInfo);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult BaseInfo(CHSNS.Models.BasicInformation b) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.BaseInfo);
            callInfo.RouteValueDictionary.Add("b", b);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult School() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.School);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Contact() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Contact);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Personal() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Personal);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Upload() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Upload);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DeleteFace() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DeleteFace);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ManageUser() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ManageUser);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
