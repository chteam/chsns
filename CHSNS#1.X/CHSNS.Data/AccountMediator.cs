using System;
using System.Linq;
using System.Web;

namespace CHSNS.Data {
	public class AccountMediator : BaseMediator {
		public AccountMediator(DBExt id) : base(id) { }
		public void Logout() {
			CHCookies.Clear();
			CHUser.Clear();
		}
		public int Login(String Email, String Password, Boolean IsAutoLogin, Boolean IsPasswordMd5){
			if (string.IsNullOrEmpty(Email.Trim()))
				throw new Exception("用户名不能为空");
			var en = new Encrypt();
			var md5pwd = IsPasswordMd5 ? en.MD5Encrypt(Password.Trim(), 32) : Password.Trim();
			long UserID = 0;
			if (!Email.Contains("@"))
				UserID = Convert.ToInt64(Email.Trim());

			var userid = (from a in DBExt.DB.Account
			              where (a.Email == Email || a.UserID == UserID)
			                    && a.Password == md5pwd
			              select a.UserID).FirstOrDefault();
			int retint = -999;

			if (userid != null && userid > 1000){
				var person = (from p in DBExt.DB.Profile
				              where p.UserID == userid
				              select new{
				                        	p.Status,
				                        	p.Name,
				                        	p.LoginTime,
											p.Applications
				                        }).SingleOrDefault();
				retint = person.Status;
			
				if (retint > 0){
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
					CHUser.UserID = userid.Value;
					CHUser.Username = person.Name;
					CHUser.InitStatus(retint);
	
					CHCookies.Apps = person.Applications;
					if (IsAutoLogin){
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
	}
}
