
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CHSNS
{
	public class AdminFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (!filterContext.HttpContext.User.IsInRole("admin"))
            {
                filterContext.HttpContext.Response.Redirect("/");
                throw new Exception("È¨ÏÞ²»×ã");
            }

		}
	}
}