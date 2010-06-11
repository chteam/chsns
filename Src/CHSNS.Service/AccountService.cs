using System;
using CHSNS.Config;
using CHSNS.Operator;
using CHSNS.SQLServerImplement.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
    public class AccountService {
        static readonly AccountService Instance = new AccountService();
        private readonly IAccountOperator _account;
        public AccountService() {
            _account = new AccountOperator();
        }

        public static AccountService GetInstance() {
            return Instance;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public void Logout(IContext context) {
            context.Cookies.Clear();
            context.User.Clear();
        }
        public int Login(String userName, String password, Boolean isAutoLogin, Boolean isPasswordMd5, IContext context) {
            if (string.IsNullOrEmpty(userName.Trim())) throw new Exception("用户名不能为空");
            password = isPasswordMd5 ? password.Trim().ToMd5() : password.Trim();
            var profile = _account.Login(userName, password, context.Site.Score.LogOn);
            if (profile == null) return -1;//无账号
            Logout(context);
            context.User.UserId = profile.UserId;
            context.User.NickName = profile.Name;
            context.User.InitStatus(profile.Status);
            context.Cookies.Apps = profile.Applications ?? "";
            if (!isAutoLogin) return profile.Status;
            context.Cookies.UserID = context.User.UserId;
            context.Cookies.UserPassword = password;
            context.Cookies.IsAutoLogin = true;
            context.Cookies.Expires = DateTime.Now.AddDays(365);
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
