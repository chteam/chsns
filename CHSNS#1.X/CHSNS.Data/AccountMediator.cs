using System;
using System.Linq;
using System.Web;
using CHSNS.Models;
using CHSNS.ModelPas;

namespace CHSNS.Data
{
    public class AccountMediator :BaseMediator ,IAccountMediator
    {
        public AccountMediator(IDBExt id) : base(id) { }
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

            var userid = (from a in DBExt.DB.Account
                          where (a.Username == Username || a.UserID == UserID)
                                && a.Password == md5pwd
                          select a.UserID).FirstOrDefault();
            int retint = -999;

            if (userid > 1000)
            {
                var person = (from p in DBExt.DB.Profile
                              where p.UserID == userid
                              select new
                              {
                                  p.Status,
                                  p.Name,
                                  p.LoginTime,
                                  p.Applications
                              }).FirstOrDefault();
                retint = person.Status;

                if (retint > 0)
                {
                    int source = 0;
                    if (person.LoginTime.Date != DateTime.Now.Date)
                        source = 2;
                    DataBaseExecutor.Execute(
                        @"UPDATE [profile] 
SET Score =Score+@s,
ShowScore =ShowScore+@s, 
LoginTime = getdate() 
where userid=@UserID",
                        "@UserID", userid, "@s", source);
                    HttpContext.Current.Session.Clear();
                    CHUser.UserID = userid;
                    CHUser.Username = person.Name;
                    CHUser.InitStatus(retint);

					CHCookies.Apps = person.Applications ?? "";
                    if (IsAutoLogin)
                    {
                        CHCookies.UserID = CHUser.UserID;
                        CHCookies.UserPassword = md5pwd;
                        CHCookies.IsAutoLogin = IsAutoLogin;
                        CHCookies.Expires = DateTime.Now.AddDays(365);
                    }
                    //else
                    //	CHCookies.Expires = DateTime.Now.AddDays(-1);
                }
                else
                    return -1;
            }
            //	throw new Exception(retint.ToString());
            return retint;
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
		public bool IsUsernameCanUse(string username) {
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
            }
        }
    }
}
