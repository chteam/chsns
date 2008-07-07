using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHSNS.Controllers {
	public class AccountController : Controller {
		public ActionResult Index() {
			// Add action logic here
			
			return View();
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

			return View();
		}
	}
}
