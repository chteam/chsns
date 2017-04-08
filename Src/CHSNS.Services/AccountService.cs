using CHSNS.Config;
using CHSNS.DataContext;
using System;
using System.Collections.Generic;

using CHSNS.Models;
using System.Linq;
using Microsoft.Extensions.Options;

namespace CHSNS.Service
{
    public class AccountService
    {
        private readonly SqlServerEntities _db;
        private readonly SiteConfig _siteConfig;

        public AccountService(SqlServerEntities db,
            IOptions<SiteConfig> siteConfig)
        {
            _db = db;
            _siteConfig = siteConfig.Value;
        }


        /// <summary>
        /// 注销
        /// </summary>
        public void Logout(IContext context)
        {
            context.Cookies.Clear();
        }



        public int Login(Account account, Boolean isAutoLogin, Boolean isPasswordMd5)
        {
            string userName = account.UserName;
            string password = account.Password;
            if (string.IsNullOrEmpty(userName.Trim())) throw new Exception("用户名不能为空");
            password = isPasswordMd5 ? password.Trim().ToMd5() : password.Trim();
            WebIdentity identity = GeneralIdentity(userName, password, _siteConfig.Score.LogOn);
            if (identity == null) return -1; //无账号
            Logout(null);
            DateTime expires = isAutoLogin ? DateTime.Now.AddMinutes(60) : DateTime.Now.AddYears(1);
            //var authTicket = new FormsAuthenticationTicket(1, identity.Name, DateTime.Now, expires, true,
            //                                               JsonConvert.SerializeObject(identity));
            //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            //var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) {Expires = expires};
            //context.HttpContext.Response.Cookies.Add(authCookie);

            //if (!isAutoLogin) return identity.Status;
            return identity.Status;
        }

        internal WebIdentity GeneralIdentity(String userName, String password, int logOnScore)
        {

            long userId;
            long.TryParse(userName.Trim(), out userId);
            long userid = (from a in _db.Account
                           where (a.UserName == userName || a.UserId == userId)
                                 && a.Password == password
                           select a.UserId).FirstOrDefault();
            if (userid <= 1000) return null;
            Profile profile = _db.Profile.FirstOrDefault(p => p.UserId == userid);
            List<string> roles = (from ur in _db.UserRole
                                  join ro in _db.Roles on ur.RoleId equals ro.Id
                                  where ur.UserId == profile.UserId
                                  select ro.RoleName).ToList();
            //var retint = profile.Status;
            // if (retint <= 0) return null;
            if (profile.LoginTime.Date != DateTime.Now.Date)
            {
                profile.Score += logOnScore;
                profile.ShowScore += logOnScore;
                profile.LoginTime = DateTime.Now;
                _db.SaveChanges();
            }
            return new WebIdentity
            {
                Name = profile.Name,
                UserId = profile.UserId,
                // Email= profile.
                Roles = roles,
                Status = profile.Status
                //                    AuthenticationType = AccountType.Default.ToString()

                //Status = retint,
                //Applications = profile.Applications
            };

        }



        public bool Create(RegisterModel account)
        {
            bool canuse = IsUsernameCanUse(account.UserName);
            if (!canuse) return false;
            return Create(account.ToAccount(), account.Nickname, _siteConfig.Score.Init);
        }

        internal bool Create(Account account, string name, int initScore)
        {
            account.Password = account.Password.ToMd5();
            account.Code = DateTime.Now.Ticks;

            _db.Account.Add(account);
            _db.SaveChanges();
            if (account.UserId < 999) return false;
            _db.Profile.Add(new Profile
            {
                UserId = account.UserId,
                Name = name,
                ShowScore = initScore,
                Score = initScore,
                DelScore = 0,
                Status = (int)RoleType.General,
                RegTime = DateTime.Now,
                LoginTime = DateTime.Now,
                // MagicBox = ""
            });
            _db.BasicInformation.Add(
                new BasicInformation
                {
                    UserId = account.UserId,
                    Name = name
                });
            _db.SaveChanges();
            return true;

        }


        public bool IsUsernameCanUse(string username)
        {
            bool isNotExists;

            isNotExists = _db.Account.Where(c => c.UserName == username.Trim()).Count() == 0;

            return username.Trim().Length > 0 && isNotExists;
        }

        public void InitCreater()
        {

            Profile p = _db.Profile.FirstOrDefault();
            if (p == null) return;

            var userrole = new UserRole
            {
                RoleId = 1,
                UserId = p.UserId
            };
            _db.UserRole.Add(userrole);
            _db.SaveChanges();

        }
    }
}