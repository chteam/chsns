
using System;
using System.Web.Mvc;
using CHSNS;
namespace CHSNS {
	public class AdminFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			if (!ChSession.isAdmin) {
				throw new Exception("Ȩ�޲���");
			}

		}
	}
}
