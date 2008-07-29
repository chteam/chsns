using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CHSNS.Models;

namespace CHSNS.Controllers {
	public partial class AjaxController : Controller {
		[PostOnlyFilter]
		[OutputCache(VaryByParam = "ProvinceID")]
		public ActionResult CityList(int ProvinceID) {
			
			return Json(DBExt.GetCitys(ProvinceID));
		}
	}
}
