using CHSNS.Config;
using CHSNS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CHSNS.Controllers
{
    using CHSNS.Service;

    public class AccountController : BaseController
    {
        private readonly SiteConfig _siteConfig;

        public AccountController(IOptions<SiteConfig> siteConfig)
        {
            _siteConfig = siteConfig.Value;
        }
        public AccountService Account { get; set; }
        #region 注册

        /// <summary>
        /// 注册页
        /// </summary>
        public virtual ActionResult Register()
        {
            Title = "注册 - 注册账号";
            return View();
        }
        
        [HttpPost]
        public virtual ActionResult Register(RegisterModel account)
        {
            if (!ViewData.ModelState.IsValid)
            {
                ViewData.Model = account;
                return Register();
            }
            var hasSuccess = Account.Create(account, _siteConfig);
            Title = "注册成功";
            if (hasSuccess) return View("Reg-Success");
            return View(account);
        }
        /// <summary>
        /// Username can use.
        /// </summary>
        public virtual ActionResult UsernameCanUse(string username)
        {
            return Json(Account.IsUsernameCanUse(username));
        }
        #endregion

        #region 登录注销

        public virtual ActionResult LogOff()
        {
            Account.Logout(null);
            return Redirect("");
        }

        [HttpGet]
        public virtual ActionResult LogOn(string returnUrl)
        {
            Title = "登录";
            ViewBag.ReturnUrl = returnUrl ?? "";
            return View();
        }

        [HttpPost]
        public virtual ActionResult LogOn(Account account, bool? autoLogOn, string returnUrl)
        {
            if (!ViewData.ModelState.IsValid)
            {
                ViewData.Model = account;
                ViewBag.AutoLogOn = autoLogOn;
                return LogOn(returnUrl);
            }
            //匹配成功则赋值
            var loginResult = Account.Login(account, autoLogOn ?? false, true, null);
            if (loginResult <= 0)
                return View(account);
            var url = string.IsNullOrEmpty(returnUrl) ? HomePage : returnUrl;
            return Redirect(url);
        }
        #endregion

        #region 设置管理员
        public virtual ActionResult InitCreater()
        {
            Account.InitCreater();
            return Content("");
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
