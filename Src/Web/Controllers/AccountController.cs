using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Controllers
{
    public partial class AccountController : BaseController
	{
		/// <summary>
		/// 注册协议页
		/// </summary>
		/// <returns></returns>
        public virtual ActionResult Agreement()
		{
			Title = "注册 - 注册协议";
			return View();
		}
		/// <summary>
		/// 注册页
		/// </summary>
        public virtual ActionResult RegPage()
		{
			Title = "注册 - 注册账号";
			return View();
		}
		/// <summary>
		/// Username can use.
		/// </summary>
        public virtual ActionResult UsernameCanUse(string username)
		{
			return Json(DataExt.Account.IsUsernameCanUse(username), JsonRequestBehavior.AllowGet);
		}
		[AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult SaveReg(string userName, string password, string name)
		{
			if (!(userName.Length > 3 && Regex.IsMatch(password, @"[^']{4,}")))
				return this.RedirectToReferrer();

			if (string.IsNullOrEmpty(name))
				throw new Exception("资料中有空项");
			var a = new Account
						{
							UserName = userName,
							Password = password,
						};

			var b = DataExt.Account.Create(a, name, CHContext.Site);

			Title = "注册成功";
            if (b)
                return View(Views.Reg_Success);
			TempData["errors"] = "用户名已经存在";
			return RedirectToAction("RegPage");
		}

		#region 登录注销
		/// <summary>
		/// 注销功能
		/// </summary>
        public virtual ActionResult Logout()
		{
			DataExt.Account.Logout(CHContext);
            return RedirectToAction(MVC.Entry.Index("index"));
		}
		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="u">用户名/Id</param>
		/// <param name="p">密码</param>
		/// <param name="a">是否保存密码</param>
		/// <returns>是否登录成功</returns>
        public virtual ActionResult Login(string u, string p, bool a)
		{
			if (u.Length > 3 && Regex.IsMatch(p, @"[^']{4,}"))
			{
				//匹配成功则赋值
				var loginResult = DataExt.Account.Login(u, p, a, true, CHContext);
				return loginResult <= 0 ? Content("false") : Content("true");
			}
			return Content("false");
		}

		#endregion
		#region 设置管理员
        public virtual ActionResult InitCreater()
		{
			DataExt.Account.InitCreater();
			return View();
		}
		#endregion
		#region 修改密码
		[AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult ChangePassword()
		{
			Title = "修改密码";
			return View();
		}
		[AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult ChangePassword(string oldpassword, string password)
		{
			Message = "您已经成功修改密码";
			return ChangePassword();
		}
		#endregion
	}
}
