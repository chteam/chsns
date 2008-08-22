namespace CHSNS
{
	using System;
	using System.Web;
	using Chsword;
	using CHSNS.Models;
	using CHSNS.Config;
	/// <summary>
	/// 用户信息 Cookies 类
	/// AU:邹健
	/// EL: 2007 10 25
	/// </summary>
	public class ChCookies
	{
		/// <summary>
		/// 存储用户Cookies
		/// </summary>
		/// <param name="userid">用户标识</param>
		/// <param name="username">用户姓名</param>
		/// <param name="md5pwd">用户密码(已加密)</param>
		/// <param name="status">用户当前状态</param>
		/// <param name="isAutoLogin">是否保存Cookie</param>
		public void SaveAll(string userid, string username, string md5pwd,object status, Boolean isAutoLogin)
		{
			HttpContext.Current.Session.Clear();
			CHUser.UserID = long.Parse(userid);
			CHUser.Username= username;
			
			CHUser.InitStatus(status);
			ChCookies.Username =CHUser.Username;
			ChCookies.Userid =CHUser.UserID;
			ChCookies.UserPassword = md5pwd;
			if (isAutoLogin){
				ChCookies.IsAutoLogin = isAutoLogin;
				ChCookies.Expires = DateTime.Now.AddDays(365);
				
			}else
				ChCookies.Expires = DateTime.Now.AddDays(-1);
		}
		static public Boolean IsExists {
			get {
				return HttpContext.Current.Request.Cookies[SiteConfig.Current.BaseConfig.CookieName] != null
					&& !string.IsNullOrEmpty(ChCookies.Username);
			}
		}

		#region private Method
		static Encrypt en = new Encrypt();
		static string GetCookieItem(string field){
			return HttpContext.Current.Request.Cookies[SiteConfig.Current.BaseConfig.CookieName][field];
		}
		static void SetCookieItem(string field,string value){
			HttpContext.Current.Response.Cookies[SiteConfig.Current.BaseConfig.CookieName][field] = value;
		}
		#endregion  
		static public void Clear(){
			//ChCookies.Expires = DateTime.Now.AddDays(-1);
			HttpContext.Current.Response.Cookies.Remove(SiteConfig.Current.BaseConfig.CookieName);
			HttpContext.Current.Response.Cookies.Clear();
			if (HttpContext.Current.Request.Cookies[SiteConfig.Current.BaseConfig.CookieName] != null) {
				HttpCookie myCookie = new HttpCookie(SiteConfig.Current.BaseConfig.CookieName);
				myCookie.Expires = DateTime.Now.AddDays(-1d);
				HttpContext.Current.Response.Cookies.Add(myCookie);
			}
		}
		#region public 属性
		/// <summary>
		/// 获取或设置用户名
		/// </summary>
		static public string Username{
			get{
				return ChServer.UrlDecode(GetCookieItem("username"));
			}
			set{
				SetCookieItem("username",ChServer.UrlEncode(value));
			}
		}
		static public int Status {
			get {
				return Convert.ToInt32(GetCookieItem("userstatus"));
			}
			set {
				SetCookieItem("userstatus", value.ToString());
			}
		}
		/// <summary>
		/// 获取或设置用户标识
		/// </summary>
		static public long Userid{
			get{
				return Convert.ToInt64(GetCookieItem("userid"));
			}
			set{
				SetCookieItem("userid",value.ToString());
			}
		}
		/// <summary>
		/// 获取或设置用户是否自动登录(是否保存Cookie)
		/// </summary>
		static public bool IsAutoLogin{
			get{
				return Convert.ToBoolean(GetCookieItem("AutoLogin"));
			}
			set{
				SetCookieItem("AutoLogin",value.ToString());
			}
		}
		/// <summary>
		/// 获取或设置密码(已加密)
		/// </summary>
		static public string UserPassword{
			get{
				if(GetCookieItem("userm").Contains("%"))
					return en.DESDecrypt(ChServer.UrlDecode(GetCookieItem("userm")), "77298666") ;
				else
					return en.DESDecrypt(GetCookieItem("userm"), "77298666") ;
			}
			set{
				SetCookieItem("userm",en.DESEncrypt(value, "77298666"));
			}
		}
		/// <summary>
		/// 用户Cookie信息过期限 DateTime.Now.AddDays(365);
		/// </summary>
		static public DateTime Expires{
			set{
				HttpContext.Current.Response.Cookies[SiteConfig.Current.BaseConfig.CookieName].Expires = value;
			}
		}
		#endregion
	}
}
