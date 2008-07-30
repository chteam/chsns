using CHSNS;
namespace System.Web.Mvc {
	/// <summary>
	/// 登录访问权限
	/// </summary>
	public class LoginedFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			if (!CHUser.IsLogin) {
				throw new Exception(
					string.Format(
					"Action '{0}' 只能登录访问.",
					filterContext.ActionMethod.Name
					)
					);
			}
		}

	}
}