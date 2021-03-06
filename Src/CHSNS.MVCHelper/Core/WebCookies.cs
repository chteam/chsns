namespace CHSNS.Core
{
    using System.Linq;
    using System;
    using System.Web;
    using CHSNS.Encrypt;

    /// <summary>
    /// 用户信息 Cookies 类
    /// AU:邹健
    /// EL: 2007 10 25
    /// </summary>
    public class WebCookies : ICookies
    {
        public WebCookies(IContext context)
        {
            Context = context;
        }
        ///<summary>
        ///</summary>
        public Boolean IsExists
        {
            get
            {
                return HttpContext.Current.Request.Cookies[Context.Site.BaseConfig.CookieName] != null;
            }
        }

        #region private Method
        string GetCookieItem(string field)
        {

            if (HttpContext.Current.Request.Cookies[Context.Site.BaseConfig.CookieName] == null)
                return "";
            if (HttpContext.Current.Request.Cookies[Context.Site.BaseConfig.CookieName][field] == null)
                return "";
            return HttpContext.Current.Request.Cookies[Context.Site.BaseConfig.CookieName][field];
        }
        void SetCookieItem(string field, string value)
        {
            HttpContext.Current.Response.Cookies[Context.Site.BaseConfig.CookieName][field] = value;
        }
        #endregion
        ///<summary>清理Cookie
        ///</summary>
        public void Clear()
        {
            //ChCookies.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Remove(Context.Site.BaseConfig.CookieName);
            HttpContext.Current.Response.Cookies.Clear();
            if (HttpContext.Current.Request.Cookies[Context.Site.BaseConfig.CookieName] != null)
            {
                HttpCookie myCookie = new HttpCookie(Context.Site.BaseConfig.CookieName);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
        }
        #region public 属性
        /// <summary>
        /// 获取或设置用户标识
        /// </summary>
        public long UserID
        {
            get
            {
                return Convert.ToInt64(GetCookieItem("userid"));
            }
            set
            {
                SetCookieItem("userid", value.ToString());
            }
        }
        /// <summary>
        /// 获取或设置用户是否自动登录(是否保存Cookie)
        /// </summary>
        public bool IsAutoLogin
        {
            get
            {
                bool b;
                bool.TryParse(GetCookieItem("AutoLogin"), out b);
                return b;
            }
            set
            {
                SetCookieItem("AutoLogin", value.ToString());
            }
        }
        ///<summary>得到应用程序的顺序数组（Long型）
        ///</summary>
        public long[] AppsArray
        {
            get
            {
                if (!string.IsNullOrEmpty(Apps))
                {
                    var x = (from a in Apps.Split(',')
                             select Convert.ToInt64(a)
                            ).ToArray();
                    return x;
                }
                return new long[0];
            }
        }
        const string Cookiedeskey="45;6kjZF";
        ///<summary>获取或设置应用程序顺序
        ///</summary>
        public string Apps
        {
            get
            {
                if (GetCookieItem("apps").Contains("%"))
                    return HttpUtility.UrlDecode(GetCookieItem("userm")).DESDecrypt(Cookiedeskey);
                return GetCookieItem("apps").DESDecrypt(Cookiedeskey);
            }
            set
            {
                SetCookieItem("apps", value.DESEncrypt(Cookiedeskey));
            }
        }
        /// <summary>
        /// 获取或设置密码(已加密)
        /// </summary>
        public string UserPassword
        {
            get
            {
                return GetCookieItem("userm").Contains("%") ? HttpUtility.UrlDecode(GetCookieItem("userm")).DESDecrypt(Cookiedeskey) : GetCookieItem("userm").DESDecrypt(Cookiedeskey);
            }
            set
            {
                SetCookieItem("userm", value.DESEncrypt(Cookiedeskey));
            }
        }
        /// <summary>
        /// 用户Cookie信息过期限 DateTime.Now.AddDays(365);
        /// </summary>
        public DateTime Expires
        {
            set {
                 HttpContext.Current.Response.Cookies[Context.Site.BaseConfig.CookieName].Expires = value;
            }
        }
        #endregion

        public IContext Context { get; set; }

    }
}
