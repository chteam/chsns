using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CHSNS
{
    public class RoleAttribute : ActionFilterAttribute
    {
        List<RoleType> RoleTypes;
        public RoleAttribute(params RoleType[] rts)
        {
            RoleTypes = new List<RoleType>(rts);

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var CHUser = (filterContext.Controller as Controllers.BaseController).CHContext.User;
            if (!CHUser.Status.Contains(RoleTypes))
            {
				filterContext.HttpContext.Response.Redirect("/Admin/Login.html");
                throw new Exception("权限不足");
            }

        }
    }
}
