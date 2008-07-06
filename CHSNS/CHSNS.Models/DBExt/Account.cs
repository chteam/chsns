using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CHSNS.Models {
	public class DBExt {
		static Boolean Login(IQueryable<Account> A){
			var exists = (from a in A
						  select new {
							  a.NickName,
							  a.PasswordMd5,
							  UserID = a.ID,
							  a.RoleID
						  }).SingleOrDefault();
			if (exists == null)
				return false;
			HttpContext.Current.Response.Cookies["CHSNS"]["nn"] = HttpUtility.UrlEncode(exists.NickName);
			HttpContext.Current.Response.Cookies["CHSNS"]["id"] = exists.UserID.ToString();
			HttpContext.Current.Response.Cookies["CHSNS"]["pwd"] = exists.PasswordMd5;
			HttpContext.Current.Response.Cookies["CHSNS"].Domain = "chs";
			HttpContext.Current.Session["role"] = exists.RoleID;
			HttpContext.Current.Response.Cookies["CHSNS"].Expires = DateTime.Now.Add(new TimeSpan(365, 0, 0, 0, 0));
			return true;
		}

		public static Boolean Login(String Email,String Password) {
			CHSNSDataContext DB = new CHSNSDataContext();
			return DBExt.Login(
				DB.Account.Where(a => a.Email == Email && a.PasswordMd5 == Password.Md5_32())
				);
		}
		public static Boolean Login(Int64 UserID, String Password) {
			CHSNSDataContext DB = new CHSNSDataContext();
			return DBExt.Login(
				DB.Account.Where(a => a.ID == UserID && a.PasswordMd5 == Password.Md5_32())
				);
		}
	}
}
