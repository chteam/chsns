using System.Web.Mvc;
using CHSNS.Service;

namespace CHSNS.Controllers
{
    public partial class AjaxController : BaseController
    {
        [HttpPost]
        [OutputCache(VaryByParam = "provinceId", Duration = int.MaxValue)]
        public virtual ActionResult CityList(int provinceId)
        {
            return Json(GolbalService.GetCitys(provinceId));
        }
    }
}
