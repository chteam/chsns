
using System.Web.Mvc;
namespace CHSNS.Controllers {
	
	//[Filter(ExecuteEnum.BeforeAction, typeof(AdminFilter))]
	//[Helper(typeof(StringHelper))]
	//[Layout("adminmaster")]
	//[ControllerDetails(Area = "Admin")]
	[AdminFilter]
	abstract public class BaseAdminController : BaseBlockController {
		protected override void OnResultExecuting(ResultExecutingContext filterContext) {
			if (filterContext.Result is ViewResult) {
				ViewResult vr = filterContext.Result as ViewResult;
				if (string.IsNullOrEmpty(vr.MasterName))
					vr.MasterName = "Admin";
			}
		}
	} 

}
