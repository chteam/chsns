﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHSNS.Models;
using System.Drawing;
namespace CHSNS.Controllers {
	[HandleError]
	public class HomeController : Controller {
		/// <summary>
		/// 首页
		/// </summary>
		/// <returns></returns>
		public ActionResult Index() {
			// Add action logic here
			ViewData["Message"] = "123456".Md5_32();
			return View();
		}
		/// <summary>
		/// 关于
		/// </summary>
		/// <returns></returns>
		public ActionResult About() {

			return View();
		}
		/// <summary>
		/// 设置
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[LoginedFilter]
		public ActionResult Setting(string id) {
			if (!UnitySingleton.SytemHas(id)) {
				id = "BaseInfo";
			}
			ViewData["current"] = id.ToLower();
			return View();
		}
	}
}
