

namespace CHSNS.Controllers {
 
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.Filters;
 
    using Interface;
    using Microsoft.AspNetCore.Http;
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
          
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
     
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //foreach (string key in Request.Params.Keys)
            //    if (!string.IsNullOrEmpty(key) && ViewData.ContainsKey(key))
            //        ViewData[key] = Request.Params[key];
            //foreach (var item in RouteData.Values)
            //    if (ViewData.ContainsKey(item.Key))
            //        ViewData[item.Key] = item.Value;
            if (ViewData.ContainsKey("Page_Title"))
                ViewData["Page_Title"] += " - " + ""; //;WebContext.Site.BaseConfig.Title;

        }




        public string HomePage
        {
            get { return Url.Action("Index", "Entry", new { url = "Index" }); }
        }
        //public ActionResult Empty()
        //{
        //    return new EmptyResult();
        //}
    }
}