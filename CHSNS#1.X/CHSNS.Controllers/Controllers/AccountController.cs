﻿using System;
using System.Web.Mvc;
using System.Transactions;
using CHSNS.ModelPas;

namespace CHSNS.Controllers
{
	public class AccountController : BaseController
	{
		/// <summary>
		/// 注册协议页
		/// </summary>
		/// <returns></returns>
		public ActionResult Agreement()
		{
			Title = "注册 - 注册协议";
			return View();
		}
		/// <summary>
		/// 注册页
		/// </summary>
		public ActionResult RegPage()
		{
			Title = "注册 - 注册账号";
			return View();
		}
		/// <summary>
		/// Username can use.
		/// </summary>
		public ActionResult UsernameCanUse(string username) {
			return Json(DBExt.Account.IsUsernameCanUse(username));
		}
		[AcceptVerbs("post")]
		public ActionResult SaveReg(string Username, string Password, string Name) {
			if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Name))
				throw new Exception("资料中有空项");
			var a = new AccountPas {
				Username = Username,
				Password = Password,
			};
			using (var ts = new TransactionScope()) {
				var b = DBExt.Account.Create(a, Name);
				ts.Complete();
				Title = "注册成功";
				if (b)
					return View("Reg-Success");
			}
			TempData["errors"] = "用户名已经存在";
			return RedirectToAction("RegPage");
		}
		#region 登录注销
		/// <summary>
		/// 注销功能
		/// </summary>
		public ActionResult Logout()
		{
			DBExt.Account.Logout();
		
			return RedirectToAction("Index", "Home");
		}
		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="u">用户名/Id</param>
		/// <param name="p">密码</param>
		/// <param name="a">是否保存密码</param>
		/// <returns>是否登录成功</returns>
		public ActionResult Login(string u, string p, bool a)
		{
			//throw new Exception(u + p + a.ToString());
			if (u.Length > 3 &&
				Regular.Macth(p, @"[^']{4,}"))
			{//匹配成功则赋值
				int LoginResult = DBExt.Account.Login(u, p, a, true);
				if (LoginResult == -1)
				{
					throw new Exception("您的帐号已经被冻结，如有疑问请 <a href=\"/Services.aspx\">联系管理员</a>");
				}
				if (LoginResult == -999)
				{
					return Content("false");
				}
				return Content("true");
			}
			return Content("false");
		}
		#endregion
	}
}
