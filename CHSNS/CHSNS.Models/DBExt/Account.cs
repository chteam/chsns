using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CHSNS.Models {
	public partial class DBExt {
		/// <summary>
		/// 注册
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		static public bool Register(Account a) {

			CHSNSDataContext DB = new CHSNSDataContext();
			var ha = (from a1 in DB.Account
					  where a1.Email == a.Email
					  select new { a.ID }).SingleOrDefault();
			if (ha == null)
				return false;

			//a.LoginTime = DateTime.Now;
			//	a.RegTime = DateTime.Now;
			a.Roles = 0;
			a.Password = a.Password.Md5_32();
			//DB.Account.InsertOnSubmit(a);
			//  DB.SubmitChanges();

			return true;
		}

		static Boolean Login(IQueryable<Account> A, bool auto) {
			var exists = (from a in A
						  select new {
							  a.Nickname,
							  a.Password,
							  UserID = a.ID,
							  a.Roles
						  }).SingleOrDefault();
			if (exists == null)
				return false;
			HttpCookie myCookie = new HttpCookie("CHSNS");
			myCookie["nn"] = HttpUtility.UrlEncode(exists.Nickname);
			myCookie["id"] = exists.UserID.ToString();
			myCookie["pwd"] = exists.Password;
			//HttpContext.Current.Response.Cookies["CHSNS"].Domain = "chs";
			HttpContext.Current.Session["roles"] = exists.Roles;
			HttpContext.Current.Response.Cookies.Add(myCookie);
			if (auto) {
				myCookie.Expires = DateTime.Now.AddYears(1);
			}
			return true;
		}
		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="A"></param>
		/// <returns></returns>
		public static Boolean Login(String Email, String Password, bool auto) {
			CHSNSDataContext DB = new CHSNSDataContext();
			return DBExt.Login(
				DB.Account.Where(a => a.Email == Email && a.Password == Password), auto
				);
		}
		public static Boolean Login(Int64 UserID, String Password, bool auto) {
			CHSNSDataContext DB = new CHSNSDataContext();
			return DBExt.Login(
				DB.Account.Where(a => a.ID == UserID && a.Password == Password), auto
				);
		}

		public static void Login() {
			//Debug.Trace(CHUser.UserID.ToString() + HttpContext.Current.Request.Cookies["CHSNS"]["pwd"]);
			DBExt.Login(
				CHUser.UserID,
				HttpContext.Current.Request.Cookies["CHSNS"]["pwd"], true);

		}
		public static void Logout() {
			HttpContext.Current.Response.Cookies["CHSNS"].Expires = DateTime.Now.AddDays(-1);
			HttpContext.Current.Session.Clear();
		}
	}
}
