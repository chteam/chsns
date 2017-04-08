using Microsoft.AspNetCore.Mvc;

namespace CHSNS
{
	public static class RedirectExtension {
		/// <summary>
		/// 重定向到上一个Action. 即 header 的 "HTTP_REFERER"  (<c>Context.UrlReferrer</c>).
		/// </summary>
		public static RedirectResult RedirectToReferrer(this Controller controller) {
			return new RedirectResult(
				""//controller.Request.ServerVariables["HTTP_REFERER"]
				);
		}
	}
}