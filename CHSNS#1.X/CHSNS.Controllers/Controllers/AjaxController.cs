using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS.Controllers
{
	public class AjaxController : BaseController
	{
		[AcceptVerbs("Post")]
		[OutputCache(VaryByParam = "ProvinceID", Duration = int.MaxValue)]
		public ActionResult CityList(int ProvinceID)
		{
			return Json(DBExt.Golbal.GetCitys(ProvinceID));
		}
	}
}
