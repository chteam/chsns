using System;
using System.Web.Mvc;
using CHSNS.Filter;

namespace CHSNS.Controllers {
	public class IdentityController : BaseController {
		#region 登录注销
		/// <summary>
		/// 注销功能
		/// </summary>
		[LoginedFilter]
		public ActionResult Logout() {
			DBExt.Account.Logout();
			return RedirectToAction("Index","Home");
		}
		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="u">用户名/Id</param>
		/// <param name="p">密码</param>
		/// <param name="a">是否保存密码</param>
		/// <returns>是否登录成功</returns>
		public ActionResult Login(string u, string p, bool a) {
			//throw new Exception(u + p + a.ToString());
			if ((Regular.Macth(u, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") ||
				 Regular.Macth(u, @"\d{5,}")) &&
				Regular.Macth(p, @"[^']{4,}")) {//匹配成功则赋值
				Int16 LoginResult = DBExt.Account.Login(u, p, a, true);
				if (LoginResult == -1) {
					throw new Exception("您的帐号已经被冻结，如有疑问请 <a href=\"/Services.aspx\">联系管理员</a>");
				}
				if (LoginResult == -999)
					return Content("false");
				return Content("true");
			}
			return Content("false");
		}
		#endregion
	}
}
