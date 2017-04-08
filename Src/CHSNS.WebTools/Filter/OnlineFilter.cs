using Microsoft.AspNetCore.Mvc.Filters;

namespace CHSNS
{
    using Microsoft.AspNetCore.Mvc;

    public class OnlineFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            OnlineProvider.Instance.Update();
        }
    }
}