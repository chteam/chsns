namespace CHSNS.Core {
    using System;
    using System.Web;
    using CHSNS.Config;
    using CHSNS.LocalImplement;
    using System.ComponentModel.Composition;

    /// <summary>
    /// CHSNS实现，WEB实现
    /// </summary>
    [Export]
    public class WebContext : IContext {
        /// <summary>
        /// 构造函数唯一
        /// </summary>
        /// <param name="context"></param>
        /// <param name="appRootPath"></param>
        public WebContext(HttpContextBase context,string appRootPath) {
            HttpContext = context;
            AppRootPath = appRootPath;
        }
        public WebContext(HttpContextBase context)
        {
            HttpContext = context;
        }
        public IPathGenerate Path {
            get {
                return LocalPathGenerate.Intance;
            }
            set { throw new NotImplementedException(); }
        }

        #region User
        public IUser User {
            get {
                return HttpContext.User.Identity as WebIdentity;
            }
        }
        #endregion

        #region Cookies
        ICookies _cookies;
        public ICookies Cookies {
            get {
                return _cookies ?? (_cookies = new WebCookies(this));
            }
            set {
                _cookies = value;
            }
        }
        #endregion

        #region Site
        SiteConfig _site;
        public SiteConfig Site {
            get {
                return _site ??
                    (_site = ConfigSerializer.Instance.Load<SiteConfig>("Config"));
            }
            set {
                _site = value;
            }
        }
        #endregion


        #region Http prop

        public string AppRootPath { get; private set; }

        public HttpContextBase HttpContext {
            get;
            set;
        }

        #endregion
    }
}
