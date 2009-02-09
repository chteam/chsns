
using System;
using System.Web.Mvc;

namespace CHSNS
{
	public class AdminFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var CHUser = (filterContext.Controller as Controllers.BaseController).CHContext.User;
			if (!CHUser.IsAdmin) {
				throw new Exception("È¨ÏÞ²»×ã");
			}

		}
	}
}