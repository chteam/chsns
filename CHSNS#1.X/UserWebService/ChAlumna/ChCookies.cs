namespace ChAlumna
{
	using System;
	using System.Web;
	using Chsword;
	using ChAlumna.Models;
	using ChAlumna.Config;
	/// <summary>
	/// �û���Ϣ Cookies ��
	/// AU:�޽�
	/// EL: 2007 10 25
	/// </summary>
	public class ChCookies
	{
		/// <summary>
		/// �洢�û�Cookies
		/// </summary>
		/// <param name="userid">�û���ʶ</param>
		/// <param name="username">�û�����</param>
		/// <param name="md5pwd">�û�����(�Ѽ���)</param>
		/// <param name="status">�û���ǰ״̬</param>
		/// <param name="isAutoLogin">�Ƿ񱣴�Cookie</param>
		public void SaveAll(string userid, string username, string md5pwd,object status, Boolean isAutoLogin)
		{
			HttpContext.Current.Session.Clear();
			ChSession.Userid = long.Parse(userid);
			ChSession.Username= username;
			
			ChSession.InitStatus(status);
			ChCookies.Username =ChSession.Username;
			ChCookies.Userid =ChSession.Userid;
			ChCookies.UserPassword = md5pwd;
			if (isAutoLogin){
				ChCookies.IsAutoLogin = isAutoLogin;
				ChCookies.Expires = DateTime.Now.AddDays(365);
				
			}else
				ChCookies.Expires = DateTime.Now.AddDays(-1);
		}
		static public Boolean IsExists {
			get {
				return HttpContext.Current.Request.Cookies[SiteConfig.Currect.BaseConfig.CookieName] != null
					&& !string.IsNullOrEmpty(ChCookies.Username);
			}
		}

		#region private Method
		static Encrypt en = new Encrypt();
		static string GetCookieItem(string field){
			return HttpContext.Current.Request.Cookies[SiteConfig.Currect.BaseConfig.CookieName][field];
		}
		static void SetCookieItem(string field,string value){
			HttpContext.Current.Response.Cookies[SiteConfig.Currect.BaseConfig.CookieName][field] = value;
		}
		#endregion  
		static public void Clear(){
			//ChCookies.Expires = DateTime.Now.AddDays(-1);
			HttpContext.Current.Response.Cookies.Remove(SiteConfig.Currect.BaseConfig.CookieName);
			HttpContext.Current.Response.Cookies.Clear();
			if (HttpContext.Current.Request.Cookies[SiteConfig.Currect.BaseConfig.CookieName] != null) {
				HttpCookie myCookie = new HttpCookie(SiteConfig.Currect.BaseConfig.CookieName);
				myCookie.Expires = DateTime.Now.AddDays(-1d);
				HttpContext.Current.Response.Cookies.Add(myCookie);
			}
		}
		#region public ����
		/// <summary>
		/// ��ȡ�������û���
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
		/// ��ȡ�������û���ʶ
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
		/// ��ȡ�������û��Ƿ��Զ���¼(�Ƿ񱣴�Cookie)
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
		/// ��ȡ����������(�Ѽ���)
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
		/// �û�Cookie��Ϣ������ DateTime.Now.AddDays(365);
		/// </summary>
		static public DateTime Expires{
			set{
				HttpContext.Current.Response.Cookies[SiteConfig.Currect.BaseConfig.CookieName].Expires = value;
			}
		}
		#endregion
	}
}
