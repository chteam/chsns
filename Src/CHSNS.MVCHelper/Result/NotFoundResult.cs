using System.Web.Mvc;

namespace CHSNS
{
    public class NotFoundResult : ViewResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            ViewData = context.Controller.ViewData;
            TempData = context.Controller.TempData;
            ViewName = "NotFound";
            base.ExecuteResult(context);
            context.HttpContext.Response.StatusDescription = "File Not Found";
            context.HttpContext.Response.StatusCode = 404;
        }
    }
}
