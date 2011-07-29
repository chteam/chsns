

namespace CHSNS.Controllers {
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using CHSNS.Core;
    using Interface;

    abstract public class BaseController : Controller
    {
        protected BaseController()
        {
            var catalog = new DirectoryCatalog(HttpRuntime.BinDirectory,"CHSNS.*.dll");
            var container = new CompositionContainer(catalog);
            var batch = new CompositionBatch();
            batch.AddPart(this);
            container.Compose(batch);
        }

        public IContext WebContext { get { return new WebContext(HttpContext); } }
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
                ViewData["Page_Title"] += " - " + WebContext.Site.BaseConfig.Title;

        }

        public WebIdentity WebUser { get { return User.Identity as WebIdentity; } }

        protected bool HasManageRight()
        {
            return WebUser.Status.Equals(RoleType.Editor) || WebUser.Status.Equals(RoleType.Creater);
        }

        public string HomePage
        {
            get { return Url.Action("Index", "Entry", new {url = "Index"}); }
        }
        public ActionResult Empty()
        {
            return new EmptyResult();
        }
    }
}