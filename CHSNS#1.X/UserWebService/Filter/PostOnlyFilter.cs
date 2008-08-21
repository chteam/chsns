namespace System.Web.Mvc
{

	/// <summary>
	/// 标记此Filter则该Action只可以进行Post访问
	/// </summary>
	public class PostOnlyFilter : ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {            
			if (filterContext.HttpContext.Request.RequestType != "POST"){
				throw new Exception(
					string.Format(
					"Action '{0}' 只能通过 Post方法访问.", 
					filterContext.ActionMethod.Name)
					);
				//filterContext.HttpContext.Response.End();
			}
		}

	}
}