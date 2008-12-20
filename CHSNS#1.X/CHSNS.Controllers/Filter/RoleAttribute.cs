using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS.Filter
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

            if (!CHUser.Status.Contains(RoleTypes))
            {
				filterContext.HttpContext.Response.Redirect("/Admin/Login.html");
                throw new Exception("权限不足");
            }

        }
    }
}
