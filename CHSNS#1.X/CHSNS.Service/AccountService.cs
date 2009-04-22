using System;
using CHSNS.Config;
using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service {
    public class AccountService {
        static readonly AccountService Instance = new AccountService();
        private readonly IAccountOperator Account;
        public AccountService() {
            Account = new AccountOperator();
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
            var md5Pwd = isPasswordMd5 ? password.Trim().ToMd5() : password.Trim();
            var profile = Account.Login(userName, password, context.Site.Score.LogOn);
            if (profile == null) return -1;//无账号
            Logout(context);
            context.User.UserID = profile.UserID;
            context.User.Username = profile.Name;
            context.User.InitStatus(profile.Status);
            context.Cookies.Apps = profile.Applications ?? "";
            if (!isAutoLogin) return profile.Status;
            context.Cookies.UserID = context.User.UserID;
            context.Cookies.UserPassword = md5Pwd;
            context.Cookies.IsAutoLogin = true;
            context.Cookies.Expires = DateTime.Now.AddDays(365);
            return profile.Status;
        }

        public bool Create(AccountPas account, string name,SiteConfig site) {
            var canuse = IsUsernameCanUse(account.UserName);
            return canuse && Account.Create(account, name, site.Score.Init);
        }
        public bool IsUsernameCanUse(string username)
        {
            return username.Trim().Length > 0 && Account.IsUsernameCanUse(username);
        }

        public void InitCreater() {
            Account.InitCreater();
        }
    }
}
