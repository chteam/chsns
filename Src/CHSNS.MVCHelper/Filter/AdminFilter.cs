
using System;
using System.Web.Mvc;

namespace CHSNS
{
	public class AdminFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (!filterContext.HttpContext.User.IsInRole("admin"))
            {
                filterContext.Controller.ControllerContext.HttpContext.Response.Redirect("/");
                throw new Exception("È¨ÏÞ²»×ã");
            }

		}
	}
}