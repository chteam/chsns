using System;
using System.Linq;
using System.Web;
using CHSNS.Models;
using CHSNS.ModelPas;

namespace CHSNS.Data
{
    public class AccountMediator :BaseMediator ,IAccountMediator
    {
        public AccountMediator(IDBManager id) : base(id) { }
        /// <summary>
        /// 注销
        /// </summary>
        public void Logout()
        {
            DBExt.Context.Cookies.Clear();
            DBExt.Context.User.Clear();
        }
        public int Login(String Username, String Password, Boolean IsAutoLogin, Boolean IsPasswordMd5)
        {
            if (string.IsNullOrEmpty(Username.Trim()))
                throw new Exception("用户名不能为空");
            var en = new Encrypt();
            var md5pwd = IsPasswordMd5 ? en.MD5Encrypt(Password.Trim(), 32) : Password.Trim();
            long UserID = 0;
            long.TryParse(Username.Trim(), out UserID);
            long userid;
            Profile profile;
            int retint = -999;
            using (var db = DBExt.DB)
            {
                userid = (from a in db.Account
                              where (a.Username == Username || a.UserID == UserID)
                                    && a.Password == md5pwd
                              select a.UserID).FirstOrDefault();
                if (userid <= 1000) return retint;
                profile = db.Profile.FirstOrDefault(p => p.UserID == userid);
                retint = profile.Status;
                if (retint <= 0) return -1;
                long score = (profile.LoginTime.Date != DateTime.Now.Date) ? 2 : 0;
                #region    更新

                profile.Score += score;
                profile.ShowScore += score;
                profile.LoginTime = DateTime.Now;
                db.SubmitChanges();
                //                        DataBaseExecutor.Execute(
                //                            @"UPDATE [profile] 
                //SET Score =Score+@s,
                //ShowScore =ShowScore+@s, 
                //LoginTime = getdate() 
                //where userid=@UserID",
                //                            "@UserID", userid, "@s", source);
                #endregion
            }
            HttpContext.Current.Session.Clear();
            CHUser.UserID = userid;
            CHUser.Username = profile.Name;
            CHUser.InitStatus(retint);

            CHCookies.Apps = profile.Applications ?? "";
            if (IsAutoLogin)
            {
                CHCookies.UserID = CHUser.UserID;
                CHCookies.UserPassword = md5pwd;
                CHCookies.IsAutoLogin = IsAutoLogin;
                CHCookies.Expires = DateTime.Now.AddDays(365);
            }
            //else
            //	CHCookies.Expires = DateTime.Now.AddDays(-1);

            return retint;

            //	throw new Exception(retint.ToString());

        }
        public bool Create(AccountPas account, string name)
        {
			var canuse = IsUsernameCanUse(account.Username);
            if (!canuse)
                return false;
        	var ac = new Account {
        	                     	Username = account.Username,
        	                     	Password = account.Password.ToMd5(),
									Code = DateTime.Now.Ticks
        	                     };
        	DBExt.DB.Account.InsertOnSubmit(ac);
        	DBExt.DB.SubmitChanges();
            if (ac.UserID < 999) return false;
            var initscore = 50;
            DBExt.DB.Profile.InsertOnSubmit(new Profile
                {
                    UserID = ac.UserID,
                    Name = name,
                    ShowScore = initscore,
                    Score = initscore,
                    DelScore = 0,
                    Status = (int)RoleType.General,
                    RegTime = DateTime.Now,
                    LoginTime = DateTime.Now,
                    MagicBox = ""
                });
        	DBExt.DB.BasicInformation
        		.InsertOnSubmit(
        		new BasicInformation {
        		                     	UserID = ac.UserID,
        		                     	Name = name
        		                     });
        	DBExt.DB.SubmitChanges();
            return true;
        }
        public bool IsUsernameCanUse(string username)
        {
            if (username.Trim().Length < 4)
                return false;
            return DBExt.DB.Account.Where(c => c.Username == username.Trim()).Count() == 0;
        }


        public void InitCreater()
        {
            var p = DBExt.DB.Profile.FirstOrDefault();
            if (p != null)
            {
                p.Status = (int)RoleType.Creater;

                DBExt.DB.SubmitChanges();
            }
        }
    }
}
