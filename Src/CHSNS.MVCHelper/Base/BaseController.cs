

namespace CHSNS.Controllers {
    using System.Web.Mvc;
    using CHSNS.Service;

    abstract public class BaseController : Controller {

        public IContext CHContext { get { return new CHContext(HttpContext); } }
        public ISerializer ConfigSerializer
        {
            get
            {
                return CHSNS.ConfigSerializer.Instance;
            }
        }
        public bool IsPost { get { return Request.Form.Count != 0; } }

        public string Title { set { ViewData["Page_Title"] = value; } }

        public string Message { set { TempData["Page_Message"] = value; } }

        protected static void InitPage(ref int? p)
        {
            if (!p.HasValue || p == 0) p = 1;
        }
        protected static void InitPage(ref int? p, int def)
        {
            if (!p.HasValue || p == 0) p = def;
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            foreach (string key in Request.Params.Keys)
                if (!string.IsNullOrEmpty(key) && ViewData.ContainsKey(key))
                    ViewData[key] = Request.Params[key];
            foreach (var item in RouteData.Values)
                if (ViewData.ContainsKey(item.Key))
                    ViewData[item.Key] = item.Value;
            if (ViewData.ContainsKey("Page_Title"))
                ViewData["Page_Title"] += " - " + CHContext.Site.BaseConfig.Title;

        }

        public CHIdentity CHUser { get { return User.Identity as CHIdentity; } }

        protected bool HasManageRight()
        {
            return CHUser.Status.Equals(RoleType.Editor) || CHUser.Status.Equals(RoleType.Creater);
        }

    }
}