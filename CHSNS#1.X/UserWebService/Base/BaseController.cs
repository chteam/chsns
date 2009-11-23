
using System.Web.Mvc;
using System;
namespace CHSNS.Controllers {
	
//	[Helper(typeof(StringHelper),"String")]
	[OnlineFilter]
	abstract public class BaseController : BaseBlockController  {

		protected override void OnResultExecuting(ResultExecutingContext filterContext) {
			
		
			if (filterContext.Result is ViewResult) {
			//	ViewResult vr = filterContext.Result as ViewResult;
				ViewResult vr = filterContext.Result as ViewResult;
				
				if (string.IsNullOrEmpty(vr.MasterName))
					vr.MasterName = "Site";
			}
		}
	}
}