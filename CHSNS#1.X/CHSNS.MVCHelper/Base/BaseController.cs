
using System.Web;
using System.Web.Mvc;
using System;
using CHSNS.Service;
using CHSNS.ViewModel;

namespace CHSNS.Controllers {

    //	[Helper(typeof(StringHelper),"String")]
    [OnlineFilter]
    [HandleError]
    abstract public class BaseController : Controller {
        public IContext CHContext { get { return new CHContext(HttpContext); } }
        public ConfigSerializer ConfigSerializer {
            get {
                return CHContext.ConfigSerializer as ConfigSerializer;
            }
        }
        public Boolean IsPost {
            get {
                return Request.Form.Count != 0;
            }
        }
        #region ���ݲ���
        private DBManager _dbext;
        protected DBManager DBExt {
            get {
                if (_dbext == null)
                    _dbext = new DBManager();
                return _dbext;
            }
            set {
                throw new NotImplementedException();
            }
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext) {
            if (_dbext != null)
                DBExt.Dispose();
        }
        #endregion
        public string Title {
            set {
                ViewData["Page_Title"] = value;
            }
        }

        public string Message {
            set {
                TempData["Page_Message"] = value;
            }
        }
        protected static void InitPage(ref int? p) {
            if (!p.HasValue || p == 0) p = 1;
        }
        protected static void InitPage(ref int? p, int def) {
            if (!p.HasValue || p == 0) p = def;
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext) {
            foreach (string key in Request.Params.Keys)
                if (!string.IsNullOrEmpty(key) && ViewData.ContainsKey(key))
                    ViewData[key] = Request.Params[key];
            foreach (var item in RouteData.Values)
                if (ViewData.ContainsKey(item.Key))
                    ViewData[item.Key] = item.Value;
            if (ViewData.ContainsKey("Page_Title"))
                ViewData["Page_Title"] += "-" + CHContext.Site.BaseConfig.Title;
            var m = ViewData.Model as BaseViewModel;
            if (m != null)
                m.Content = CHContext;
        }
        protected static void Validate404(object obj) {
            if (obj == null)
                throw new HttpException(404, "Not Found");
        }
        public IUser CHUser { get { return CHContext.User; } }
    }
}