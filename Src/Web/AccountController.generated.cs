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
    public partial class AccountController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AccountController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult UsernameCanUse() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.UsernameCanUse);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult SaveReg() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.SaveReg);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Login() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Login);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController Actions { get { return MVC.Account; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "account";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Agreement = ("Agreement").ToLowerInvariant();
            public readonly string RegPage = ("RegPage").ToLowerInvariant();
            public readonly string UsernameCanUse = ("UsernameCanUse").ToLowerInvariant();
            public readonly string SaveReg = ("SaveReg").ToLowerInvariant();
            public readonly string Logout = ("Logout").ToLowerInvariant();
            public readonly string Login = ("Login").ToLowerInvariant();
            public readonly string InitCreater = ("InitCreater").ToLowerInvariant();
            public readonly string ChangePassword = ("ChangePassword").ToLowerInvariant();
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Agreement = "~/Views/Account/Agreement.aspx";
            public readonly string ChangePassword = "~/Views/Account/ChangePassword.aspx";
            public readonly string Reg_Success = "~/Views/Account/Reg-Success.aspx";
            public readonly string RegPage = "~/Views/Account/RegPage.aspx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_AccountController: CHSNS.Controllers.AccountController {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Agreement() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Agreement);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult RegPage() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.RegPage);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult UsernameCanUse(string username) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.UsernameCanUse);
            callInfo.RouteValueDictionary.Add("username", username);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SaveReg(string userName, string password, string name) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SaveReg);
            callInfo.RouteValueDictionary.Add("userName", userName);
            callInfo.RouteValueDictionary.Add("password", password);
            callInfo.RouteValueDictionary.Add("name", name);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Logout() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Logout);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Login(string u, string p, bool a) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Login);
            callInfo.RouteValueDictionary.Add("u", u);
            callInfo.RouteValueDictionary.Add("p", p);
            callInfo.RouteValueDictionary.Add("a", a);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult InitCreater() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.InitCreater);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ChangePassword() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ChangePassword);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ChangePassword(string oldpassword, string password) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ChangePassword);
            callInfo.RouteValueDictionary.Add("oldpassword", oldpassword);
            callInfo.RouteValueDictionary.Add("password", password);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591