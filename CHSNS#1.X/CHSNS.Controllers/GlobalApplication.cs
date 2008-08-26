/*
 * Created by 邹健
 * Date: 2007-10-19
 * Time: 22:51
 * 
 * 
 */


using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CHSNS.Config;
using CHSNS.Data;
namespace CHSNS {
	[CompilerGlobalScope]
	public class Global : HttpApplication {
		private bool __initialized;

		public Global() {
			if (!__initialized) {
				__initialized = true;
			}
		}
		public void Application_Start(object sender, EventArgs e) {
			// 在应用程序启动时运行的代码
			//Application.Add("Application.IsMustJoinClass", true);
			//网站设置，是否必须加入班级
			SystemConfig system = SystemConfig.Currect;

			ConfigPath path = new ConfigPath();
			RegisterRoutes(RouteTable.Routes);
			//ControllerBuilder.Current.SetControllerFactory(typeof(NVelocityEngine.NVelocityControllerFactory));
		}

		public void Application_End(object sender, EventArgs e) {
		}

		public void Application_Error(object sender, EventArgs e) {
		}

		public void Session_OnStart(object sender, EventArgs e) {
			if (!CHUser.IsLogin) {	//当前不处于登录状态
				if (ChCookies.IsExists && ChCookies.IsAutoLogin) {
					try {
						string pwd = ChCookies.UserPassword;
						DBExt idb = new DBExt(new DataBaseExecutor(new SqlDataOpener(
						SiteConfig.SiteConnectionString)));
						idb.Account.Login(ChCookies.Userid.ToString(),
							pwd,
							true,
							false
							);
					} catch { }
				} 
			}
		}

		public void Session_OnEnd(object sender, EventArgs e) { }


		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				"url",                                              // Route name
				"{controller}/{action}.ashx",                           // URL with parameters
				new { controller = "Home", action = "Index" }  // Parameter defaults
			);

		}
	}
}
