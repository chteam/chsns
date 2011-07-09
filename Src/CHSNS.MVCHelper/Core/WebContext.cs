namespace CHSNS.Core
{
    using System;
    using System.ComponentModel.Composition;
    using System.Web;
    using CHSNS.Common.LocalImplement;
    using CHSNS.Config;

    /// <summary>
    /// CHSNS实现，WEB实现
    /// </summary>
    [Export]
    public class WebContext : IContext
    {
        /// <summary>
        /// 构造函数唯一
        /// </summary>
        /// <param name="context"></param>
        /// <param name="appRootPath"></param>
        public WebContext(HttpContextBase context, string appRootPath)
        {
            HttpContext = context;
            AppRootPath = appRootPath;
        }

        public WebContext(HttpContextBase context)
        {
            HttpContext = context;
        }
 
        [Import]
        public IPathGenerate Path { get; set; }
 

        #region User

        public IUser User
        {
            get { return HttpContext.User.Identity as WebIdentity; }
        }

        #endregion

        #region Cookies

        private ICookies _cookies;

        public ICookies Cookies
        {
            get { return _cookies ?? (_cookies = new WebCookies(this)); }
            set { _cookies = value; }
        }

        #endregion

        #region Site

        private SiteConfig _site;

        public SiteConfig Site
        {
            get
            {
                return _site ??
                       (_site = ConfigSerializer.Instance.Load<SiteConfig>("Config"));
            }
            set { _site = value; }
        }

        #endregion

        #region Http prop

        public string AppRootPath { get; private set; }

        public HttpContextBase HttpContext { get; set; }

        #endregion
    }
}