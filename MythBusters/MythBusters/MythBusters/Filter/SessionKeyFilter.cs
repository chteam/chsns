using System.Web.Mvc;

namespace MythBusters
{
	public class SessionKeyFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var qs = new
			         	{
			         		xn_sig_session_key = filterContext.HttpContext.Request.QueryString["xn_sig_session_key"],
			         		xn_sig_user = filterContext.HttpContext.Request.QueryString["xn_sig_user"]
			         	};
			filterContext.Controller.ViewData["query"] = qs;
		}

	}
}