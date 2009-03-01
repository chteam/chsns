using System;
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
        public ActionResult UsernameCanUse(string username)
        {
            return Json(DBExt.Account.IsUsernameCanUse(username));
        }
        [AcceptVerbs("post")]
        public ActionResult SaveReg(string Username, string Password, string Name)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Name))
                throw new Exception("资料中有空项");
            var a = new AccountPas
            {
                Username = Username,
                Password = Password,
            };
            using (var ts = new TransactionScope())
            {
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

            return RedirectToAction("index", "Entry", new { title = "index" });
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
                var LoginResult = DBExt.Account.Login(u, p, a, true);
                if (LoginResult == -1)
                {
                    throw new Exception("您的帐号已经被冻结，如有疑问请 <a href=\"/Services.aspx\">联系管理员</a>");
                }
                return LoginResult == -999 ? Content("false") : Content("true");
            }
            return Content("false");
        }

        #endregion
        #region 设置管理员
        public ActionResult InitCreater()
        {
            DBExt.Account.InitCreater();
            return View();
        }
        #endregion
        #region 修改密码
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ChangePassword()
        {
            Title = "修改密码";
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangePassword(string oldpassword, string password)
        {
            Message = "您已经成功修改密码";
            return ChangePassword();
        }
        #endregion
    }
}
