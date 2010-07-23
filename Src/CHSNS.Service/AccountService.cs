
namespace CHSNS.Service
{

    using System;
    using CHSNS.Config;
    using CHSNS.Models;
    using System.Web.Security;
    using System.Web;
    using System.Linq;

    public class AccountService : BaseService<AccountService>
    {
        #region LogOut

        /// <summary>
        /// 注销
        /// </summary>
        public void Logout(IContext context)
        {
            context.Cookies.Clear();
            FormsAuthentication.SignOut();
        }
        #endregion

        #region LogOn

        public int Login(String userName, String password, Boolean isAutoLogin, Boolean isPasswordMd5, IContext context)
        {
            if (string.IsNullOrEmpty(userName.Trim())) throw new Exception("用户名不能为空");
            password = isPasswordMd5 ? password.Trim().ToMd5() : password.Trim();
            var identity = GeneralIdentity(userName, password, context.Site.Score.LogOn);
            if (identity == null) return -1;//无账号
            Logout(context);
            var expires = isAutoLogin
            ? DateTime.Now.AddMinutes(60)
            : DateTime.Now.AddYears(1);
            FormsAuthenticationTicket authTicket = new
       FormsAuthenticationTicket(1, identity.Name, DateTime.Now,
       expires
       , true, JsonAdapter.Serialize(identity));
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie authCookie =
                         new HttpCookie(FormsAuthentication.FormsCookieName,
                                        encryptedTicket);
            authCookie.Expires = expires;
            context.HttpContext.Response.Cookies.Add(authCookie);

            if (!isAutoLogin) return identity.Status;
            return identity.Status;
        }

        internal CHIdentity GeneralIdentity(String userName, String password, int logOnScore)
        {
            using (var db = DBExtInstance)
            {
                long userId;
                long.TryParse(userName.Trim(), out userId);
                var userid = (from a in db.Account
                              where (a.UserName == userName || a.UserId == userId)
                                    && a.Password == password
                              select a.UserId).FirstOrDefault();
                if (userid <= 1000) return null;
                var profile = db.Profile.FirstOrDefault(p => p.UserId == userid);
                var roles = (from ur in db.UserRole
                             join ro in db.Roles on ur.RoleId equals ro.Id
                             where ur.UserId == profile.UserId
                             select ro.RoleName).ToList();
                //var retint = profile.Status;
                // if (retint <= 0) return null;
                if (profile.LoginTime.Date != DateTime.Now.Date)
                {
                    profile.Score += logOnScore;
                    profile.ShowScore += logOnScore;
                    profile.LoginTime = DateTime.Now;
                    db.SaveChanges();
                }
                return new CHIdentity
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

        }

        #endregion

        #region Create

        public bool Create(Account account, string name, SiteConfig site)
        {
            var canuse = IsUsernameCanUse(account.UserName);
            return canuse && Create(account, name, site.Score.Init);
        }
        internal bool Create(Account account, string name, int initScore)
        {
            account.Password = account.Password.ToMd5();
            account.Code = DateTime.Now.Ticks;
            using (var db = DBExtInstance)
            {
                db.Account.AddObject(account);
                db.SaveChanges();
                if (account.UserId < 999) return false;
                db.Profile.AddObject(new Profile
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
                db.BasicInformation.AddObject(
                    new BasicInformation
                    {
                        UserId = account.UserId,
                        Name = name
                    });
                db.SaveChanges();
                return true;
            }
        }


        #endregion

        #region Username is Used
        public bool IsUsernameCanUse(string username)
        {
            bool isNotExists;
            using (var db = DBExtInstance)
            {
                isNotExists = db.Account.Where(c => c.UserName == username.Trim()).Count() == 0;
            }
            return username.Trim().Length > 0 && isNotExists;
        }
        #endregion

        #region Init
        public void InitCreater()
        {
            using (var db = DBExtInstance)
            {
                var p = db.Profile.FirstOrDefault();
                if (p == null) return;

                var userrole = new UserRole()
                {
                    RoleId = 1,
                    UserId = p.UserId
                };
                db.UserRole.AddObject(userrole);
                db.SaveChanges();
            }
        }
        #endregion

    }
}