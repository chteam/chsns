using System.Web.Mvc;

namespace CHSNS.Controllers
{
	public class AjaxController : BaseController
	{
		[HttpPost]
        [OutputCache(VaryByParam = "provinceId", Duration = int.MaxValue)]
		public ActionResult CityList(int provinceId)
		{
			return Json(Global.GetCitys(provinceId));
		}
	}
}
