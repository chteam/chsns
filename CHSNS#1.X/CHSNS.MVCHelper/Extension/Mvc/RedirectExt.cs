using System.Web.Mvc;

namespace CHSNS
{
	/// <summary>
	/// 对Controller的Redirect操作的扩展
	/// blog:http://chsword.cnblogs.com/
	/// </summary>
	public static class RedirectExtension {
		/// <summary>
		/// 重定向到上一个Action. 即 header 的 "HTTP_REFERER"  (<c>Context.UrlReferrer</c>).
		/// </summary>
		static public RedirectResult RedirectToReferrer(this Controller controller) {
			return new RedirectResult(
				controller.Request.ServerVariables["HTTP_REFERER"]
				);
		}
		/// <summary> 
		/// Redirect 到站点根目录 (<c>Context.ApplicationPath + "/"</c>).
		/// </summary>
		static public RedirectResult RedirectToSiteRoot(this Controller controller) {
			return new RedirectResult(controller.Request.ApplicationPath + "/");
		}

	}
}