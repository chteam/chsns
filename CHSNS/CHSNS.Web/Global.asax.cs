using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CHSNS.Models;

namespace CHSNS.Web {
	public class GlobalApplication : System.Web.HttpApplication {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",                                              // Route name
				"{controller}/{action}/{id}",                           // URL with parameters
				new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);

		}

		protected void Application_Start() {
			RegisterRoutes(RouteTable.Routes);
		}
		public void Session_OnStart(object sender, EventArgs e) {
			if (!CHUser.IsLogin && HttpContext.Current.Request.Cookies.AllKeys.Contains("CHSNS")) {	//当前不处于登录状态
				DBExt.Login();
			}
		}
	}
}