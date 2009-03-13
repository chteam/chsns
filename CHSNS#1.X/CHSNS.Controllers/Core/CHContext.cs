using CHSNS.Config;
using CHSNS.Data;

namespace CHSNS {
    public class CHContext : IContext {
        #region Cache
        ICache _cahce;
        /// <summary>
        /// 缓存单例
        /// </summary>
        public ICache Cache {
            get {
                return _cahce ?? (_cahce = new CHCache());
            }
            set {
                _cahce = value;
            }
        }
        #endregion
        #region User
        IUser _user;
        public IUser User {
            get {
                return _user ?? (_user = new CHUser());
            }
            set {
                _user = value;
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
                    (_site = (new SiteConfig(new ConfigSerializer(this))).Current);
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
                return _serializer ?? (_serializer = new ConfigSerializer(this));
            }
            set {
                _serializer = value;
            }
        }
        #endregion
        #region DBManager
        IDBManager _dbmanager;
        public IDBManager DBManager {
            get {
                return _dbmanager ?? (_dbmanager = new SQLServerDBManager(this));
            }
            set {
                _dbmanager = value;
            }
        }
        #endregion
    }
}
