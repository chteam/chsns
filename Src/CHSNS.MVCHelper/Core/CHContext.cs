using System;
using System.Web;
using CHSNS.Config;
using CHSNS.LocalImplement;

namespace CHSNS {
    /// <summary>
    /// CHSNS实现，WEB实现
    /// </summary>
    public class CHContext : IContext {
        /// <summary>
        /// 构造函数唯一
        /// </summary>
        /// <param name="context"></param>
        public CHContext(HttpContextBase context,string appRootPath) {
            HttpContext = context;
            AppRootPath = appRootPath;
        }
        public CHContext(HttpContextBase context)
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
                return HttpContext.User.Identity as CHIdentity;
            }
        }
        #endregion

        #region Cookies
        ICookies _cookies;
        public ICookies Cookies {
            get {
                return _cookies ?? (_cookies = new CHCookies(this));
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
                    (_site = new SiteConfig(ConfigSerializer).Current);
            }
            set {
                _site = value;
            }
        }
        #endregion

        #region Online
        IOnline _online;
        public IOnline Online {
            get {
                return _online ?? (_online = new Online(this));
            }
            set {
                _online = value;
            }
        }
        #endregion

        #region Serializer
        ISerializer _serializer;
        public ISerializer ConfigSerializer {
            get {
                return _serializer ?? (_serializer = new ConfigSerializer(AppRootPath ?? HttpContext.Server.MapPath("~/")));
            }
            set {
                _serializer = value;
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
