
using System;
using System.Web.Mvc;

namespace CHSNS
{
	public class AdminFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			if (!CHUser.IsAdmin) {
				throw new Exception("Ȩ�޲���");
			}

		}
	}
}