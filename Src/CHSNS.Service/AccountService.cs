using System;
using CHSNS.Config;
using CHSNS.Operator;
using CHSNS.SQLServerImplement.Operator;
using CHSNS.Models;
using System.Web.Security;
using System.Reflection;
using System.Web;

namespace CHSNS.Service {
    public class AccountService : BaseService<AccountService>
    {
        
        private readonly AccountOperator _account;
        public AccountService() {
            _account = new AccountOperator();
        }

        public static AccountService GetInstance() {
            return Instance;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public void Logout(IContext context)
        {
            context.Cookies.Clear();
            FormsAuthentication.SignOut();
        }
        public int Login(String userName, String password, Boolean isAutoLogin, Boolean isPasswordMd5, IContext context)
        {
            if (string.IsNullOrEmpty(userName.Trim())) throw new Exception("用户名不能为空");
            password = isPasswordMd5 ? password.Trim().ToMd5() : password.Trim();
            var profile = _account.Login(userName, password, context.Site.Score.LogOn);
            if (profile == null) return -1;//无账号
            Logout(context);
            var expires = isAutoLogin
            ? DateTime.Now.AddMinutes(60)
            : DateTime.Now.AddYears(1);
            FormsAuthenticationTicket authTicket = new
       FormsAuthenticationTicket(1, profile.Name, DateTime.Now,
       expires
       , true, JsonAdapter.Serialize(profile));
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie authCookie =
                         new HttpCookie(FormsAuthentication.FormsCookieName,
                                        encryptedTicket);
            authCookie.Expires = expires;
            context.HttpContext.Response.Cookies.Add(authCookie);

            if (!isAutoLogin) return profile.Status;
            return profile.Status;
        }

        public bool Create(Account account, string name,SiteConfig site) {
            var canuse = IsUsernameCanUse(account.UserName);
            return canuse && _account.Create(account, name, site.Score.Init);
        }

        public bool IsUsernameCanUse(string username)
        {
            return username.Trim().Length > 0 && _account.IsUsernameCanUse(username);
        }

        public void InitCreater() {
            _account.InitCreater();
        }
    }
}
