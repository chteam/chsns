using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Filter;
using System.Web.Mvc;

namespace CHSNS.Controllers
{
	[AdminFilter]
	public class AdminController : BaseBlockController
	{
		public ActionResult Index() {
			ViewData["Page_Title"] = "CHSNS#管理平台";
			return View();
		}
		public ActionResult About() {
			return View();
		}
	}
}
