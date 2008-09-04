using System.Linq;

namespace CHSNS
{
	using System;
	using System.Web;
	using Config;
	/// <summary>
	/// �û���Ϣ Cookies ��
	/// AU:�޽�
	/// EL: 2007 10 25
	/// </summary>
	public class CHCookies
	{
		///<summary>
		///</summary>
		static public Boolean IsExists {
			get {
				return HttpContext.Current.Request.Cookies[SiteConfig.Current.BaseConfig.CookieName] != null;
			}
		}

		#region private Method
		static Encrypt en = new Encrypt();
		static string GetCookieItem(string field){
			if (HttpContext.Current.Request.Cookies[SiteConfig.Current.BaseConfig.CookieName] == null)
				return "";
			if (HttpContext.Current.Request.Cookies[SiteConfig.Current.BaseConfig.CookieName][field]==null)
				return "";
			return HttpContext.Current.Request.Cookies[SiteConfig.Current.BaseConfig.CookieName][field];
		}
		static void SetCookieItem(string field,string value){
			HttpContext.Current.Response.Cookies[SiteConfig.Current.BaseConfig.CookieName][field] = value;
		}
		#endregion  
		///<summary>����Cookie
		///</summary>
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
		#region public ����
		/// <summary>
		/// ��ȡ�������û���ʶ
		/// </summary>
		static public long UserID{
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
				bool b;
				bool.TryParse(GetCookieItem("AutoLogin"), out b);
				return b;
			}
			set{
				SetCookieItem("AutoLogin",value.ToString());
			}
		}
		///<summary>�õ�Ӧ�ó����˳�����飨Long�ͣ�
		///</summary>
		static public long[] AppsArray{
			get{
				if(!string.IsNullOrEmpty(Apps)){
					var x = (from a in Apps.Split(',')
					         select Convert.ToInt64(a)
					        ).ToArray();
					return x;
				}
				return new long[0];
			}
		}
		///<summary>��ȡ������Ӧ�ó���˳��
		///</summary>
		static public string Apps {
			get{
				if (GetCookieItem("apps").Contains("%"))
					return en.DESDecrypt(CHServer.UrlDecode(GetCookieItem("userm")), "77298666");
				return en.DESDecrypt(GetCookieItem("apps"), "77298666");
			}
			set{
				SetCookieItem("apps", en.DESEncrypt(value, "77298666"));
			}
		}
		/// <summary>
		/// ��ȡ����������(�Ѽ���)
		/// </summary>
		static public string UserPassword{
			get{
				if(GetCookieItem("userm").Contains("%"))
					return en.DESDecrypt(CHServer.UrlDecode(GetCookieItem("userm")), "77298666") ;
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
				HttpContext.Current.Response.Cookies[SiteConfig.Current.BaseConfig.CookieName].Expires = value;
			}
		}
		#endregion
	}
}
