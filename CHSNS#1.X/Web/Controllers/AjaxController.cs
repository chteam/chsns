﻿using System.Web.Mvc;

namespace CHSNS.Controllers
{
	public class AjaxController : BaseController
	{
		[AcceptVerbs("Post")]
		[OutputCache(VaryByParam = "ProvinceID", Duration = int.MaxValue)]
		public ActionResult CityList(int ProvinceID)
		{
			return Json(DbExt.Golbal.GetCitys(CHContext,ProvinceID));
		}
	}
}
