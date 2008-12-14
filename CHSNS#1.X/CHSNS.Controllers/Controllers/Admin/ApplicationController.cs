using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CHSNS.Config;

namespace CHSNS.Controllers.Admin {
	public class ApplicationController :BaseController{
		public ActionResult Manage(int? p) {
			InitPage(ref p);
			Title = "应用程序管理";
			var ais = ConfigSerializer.Load<SystemApplicationConfig>("SystemApplication");
			var li = new PagedList<ApplicationItem>(ais.Items, p.Value, 10);
			return View(li);
		}
	}
}
