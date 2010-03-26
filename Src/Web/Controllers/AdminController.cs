﻿using System.Web.Mvc;

namespace CHSNS.Controllers {
	[AdminFilter]
	public class AdminController : BaseController {
		public ActionResult Index() {
			Title = "CHSNS#管理平台首页";
			return View();
		}

		public ActionResult About() {
			return View();
		}
	}
}