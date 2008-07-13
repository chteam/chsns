using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHSNS.Models;

namespace CHSNS.Controllers {
	public class AccountController : Controller {
		public ActionResult Index() {
			// Add action logic here

			return View();
		}
		[PostOnlyFilter]
		public ActionResult ProcessLogin(string e,string p,bool a) {
			if (DBExt.Login(e, p.Md5_32(), a)) {
				return View("MyMenu");
			} else {
				return Content("false");
			}
		}
		public ActionResult ProcessLogout() {
			DBExt.Logout();
			return Redirect("/");
		}

		public ActionResult Agreement() {
			ViewData["Title"] = "注册 - 注册协议";
			return View();
		}


		public ActionResult RegPage() {
			ViewData["Title"] = "注册 - 注册账号";
			return View();
		}
		public ActionResult SaveReg() {
			Account a = new Account();
			BindingHelperExtensions.UpdateFrom(a, Request.Form);
			if (DBExt.Register(a)) {
				return View("Reg-Success");
			}
			TempData["errors"] = "Email已经存在";
			return RedirectToAction("RegPage");


		}

	}
}
