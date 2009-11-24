
using System;
using System.Web.Mvc;

namespace CHSNS
{
	public class AdminFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var CHUser = (filterContext.Controller as Controllers.BaseController).CHContext.User;
			if (!CHUser.IsAdmin) {
                filterContext.Controller.ControllerContext.HttpContext.Response.Redirect("/");
				throw new Exception("È¨ÏÞ²»×ã");
			}

		}
	}
}