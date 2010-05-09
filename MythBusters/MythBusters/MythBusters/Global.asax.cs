using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using RenRen;

namespace MythBusters
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
		}
        protected void Application_AuthorizeRequest(object sender, System.EventArgs e)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            var authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (null == authCookie) return;
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (null == authTicket) return;
            string[] fields = authTicket.Name.Split(new char[] { ',' });
            var pri = new RenRenPrincipal(Convert.ToInt64(fields[0]), fields[1], fields[2]);
            Context.User = pri; 
        }
	}
}