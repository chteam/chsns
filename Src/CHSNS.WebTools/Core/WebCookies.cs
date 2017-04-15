namespace CHSNS.Core
{
    using System.Linq;
    using System;
    using CHSNS.Encrypt;

    /// <summary>
    /// �û���Ϣ Cookies ��
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
        ///<summary>����Cookie
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
        #region public ����
        /// <summary>
        /// ��ȡ�������û���ʶ
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
        /// ��ȡ�������û��Ƿ��Զ���¼(�Ƿ񱣴�Cookie)
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
        ///<summary>�õ�Ӧ�ó����˳�����飨Long�ͣ�
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
        ///<summary>��ȡ������Ӧ�ó���˳��
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
        /// ��ȡ����������(�Ѽ���)
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
        /// �û�Cookie��Ϣ������ DateTime.Now.AddDays(365);
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