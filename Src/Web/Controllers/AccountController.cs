using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;
using CHSNS.Web;

namespace CHSNS.Controllers
{
    public partial class AccountController : BaseController
    {
        #region 注册

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
            return Json(DataManager.Account.IsUsernameCanUse(username), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public virtual ActionResult SaveReg(string userName, string password, string name)
        {
            if (!(userName.Length > 3 && Regex.IsMatch(password, @"[^']{4,}")))
                return this.RedirectToReferrer();

            if (string.IsNullOrEmpty(name))
                throw new ApplicationException("资料中有空项");
            var account = new Account
                        {
                            UserName = userName,
                            Password = password,
                        };

            var hasSuccess = DataManager.Account.Create(account, name, CHContext.Site);

            Title = "注册成功";
            if (hasSuccess)
                return View(Views.Reg_Success);
            TempData["errors"] = "用户名已经存在";
            return RedirectToAction(Actions.RegPage());
        }
        #endregion

        #region 登录注销
        /// <summary>
        /// 注销功能
        /// </summary>
        public virtual ActionResult LogOff()
        {
            DataManager.Account.Logout(CHContext);
            return RedirectToAction(MVC.Entry.Index("index"));
        }
        [HttpGet]
        public virtual ActionResult LogOn()
        {
            Title = "登录";
            return View();
        }
        [HttpPost]
        public virtual ActionResult LogOn(Account account, bool? autoLogOn)
        {
            if (!ViewData.ModelState.IsValid)
            {
                return View(account);
            }
            //匹配成功则赋值
            var loginResult = DataManager.Account.Login(
                account.UserName, account.Password,
                autoLogOn ?? false, true, CHContext);
            if (loginResult <= 0)
                return View(account);
            else
                return RedirectToAction(MVC.Entry.Index("index"));
        }
        #endregion

        #region 设置管理员
        public virtual ActionResult InitCreater()
        {
            DataManager.Account.InitCreater();
            return View();
        }
        #endregion

        #region 修改密码
        [HttpGet]
        public virtual ActionResult ChangePassword()
        {
            Title = "修改密码";
            return View();
        }
        [HttpPost]
        public virtual ActionResult ChangePassword(string oldpassword, string password)
        {
            Message = "您已经成功修改密码";
            return ChangePassword();
        }
        #endregion
    }
}
