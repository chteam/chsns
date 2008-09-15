using System;
using System.Linq;
using System.Web;
using CHSNS.Models;

namespace CHSNS.Data
{
    public class AccountMediator : BaseMediator
    {
        public AccountMediator(DBExt id) : base(id) { }
        public void Logout()
        {
            CHCookies.Clear();
            CHUser.Clear();
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
        public bool Create(Account account, string name)
        {
            var exists = DBExt.DB.Account.Where(c => c.Username == account.Username).Select(c => 1).Count();
            if (exists != 0)
                return false;
            var pas = account.Password.ToMd5();
			DataBaseExecutor.Execute(@"INSERT INTO [Account]
([Username],[Password],[Question],[Answer],[Code])VALUES
(@email,@pas,@question,@answer,@code)",
												  "@email", account.Username, "@pas", pas, "@question", account.Question ?? "",
												  "@answer", account.Answer ?? "", "@code", DateTime.Now.Ticks);
            var x = DBExt.DB.Account.Where(c => c.Username == account.Username).Select(c => c.UserID).FirstOrDefault();
            if (x < 999) return false;
            var initscore = 50;
            DataBaseExecutor.Execute(@"INSERT INTO [Profile]
([UserID],[Name],[Score],[ShowScore],[Status],[RegTime],[LoginTime])values
(@userid,@name,@initscore,@initscore,1,@time,@time)", "@userid", x, "@name", name, "@initscore", initscore,
                                                    "@time", DateTime.Now);
            DataBaseExecutor.Execute(@"INSERT INTO [BasicInformation]
([UserID],[Name]) values(@userid,@name)", "@userid", x, "@name", name);
            return true;
        }
    }
}
