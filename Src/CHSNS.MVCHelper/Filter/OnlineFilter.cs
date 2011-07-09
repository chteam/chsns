namespace CHSNS
{
    using System.Web.Mvc;

    public class OnlineFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            OnlineProvider.Instance.Update();
        }
    }
}