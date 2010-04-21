using System.Web.Mvc;

namespace CHSNS.Controllers
{
	public class AjaxController : BaseController
	{
		[HttpPost]
		[OutputCache(VaryByParam = "ProvinceID", Duration = int.MaxValue)]
		public ActionResult CityList(int provinceID)
		{
			return Json(DbExt.Golbal.GetCitys(CHContext,provinceID));
		}
	}
}
