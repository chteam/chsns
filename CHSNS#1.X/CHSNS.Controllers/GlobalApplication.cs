/*
 * Created by 邹健
 * Date: 2007-10-19
 * Time: 22:51
 * 
 * 
 */


using System;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Routing;
using CHSNS.Data;
using CHSNS.Mvc;

namespace CHSNS {
	[CompilerGlobalScope]
	public class Global : HttpApplication {

		public void Application_Start(object sender, EventArgs e) {
			// 在应用程序启动时运行的代码
			//Application.Add("Application.IsMustJoinClass", true);
			//网站设置，是否必须加入班级
			//SystemConfig system = SystemConfig.Currect;

			//var path = new ConfigPath();
			RegisterRoutes(RouteTable.Routes);
			DynamicDataInit();
			//ControllerBuilder.Current.SetControllerFactory(typeof(NVelocityEngine.NVelocityControllerFactory));
		}
		public static void DynamicDataInit() {
			var model = new System.Web.DynamicData.MetaModel();
			model.RegisterContext(typeof(Models.CHSNSDBDataContext),
				new ContextConfiguration { ScaffoldAllTables = true });
			ModelBinders.Binders.DefaultBinder = new DynamicDataModelBinder(ModelBinders.Binders.DefaultBinder);
		}
		public void Application_End(object sender, EventArgs e) {
		}

		public void Application_Error(object sender, EventArgs e) {
		}

		public void Session_OnStart(object sender, EventArgs e) {
            IContext Context = new CHContext();
			using (new TransactionScope()) {
                if (!Context.User.IsLogin)
                {
					//当前不处于登录状态
                    if (Context.Cookies.IsAutoLogin)
                    {
                        string pwd = Context.Cookies.UserPassword;
						var idb = new DBExt(Context);
                        idb.Account.Login(Context.Cookies.UserID.ToString(),
										  pwd,
										  true,
										  false
							);
					}
				}
			}
		}

		public void Session_OnEnd(object sender, EventArgs e) { }


		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute("Admin", "Admin/{controller}/{Action}.ashx",
							new { controller = "Admin", Action = "Index" },
							new { controller = "Application" },
							new[] { "CHSNS.Controllers.Admin" }
				);
			routes.MapRoute(
				"index", // Route name
				"{Title}.ashx", // URL with parameters
				new { controller = "Entry", action = "Index", Title = "Index" }, // Parameter defaults
				new[] { "CHSNS.Controllers" }
				);
			routes.MapRoute(
				"entry", // Route name
				"w/{title}.ashx", // URL with parameters
				new { controller = "Entry", action = "Index", Title = "Index" }, // Parameter defaults
				new[] { "CHSNS.Controllers" }
				);
			routes.MapRoute(
		"post", // Route name
		"Post/{y}/{m}/{d}/{id}.ashx", // URL with parameters
		new { controller = "Group", action = "Details" } // Parameter defaults
		);
			routes.MapRoute(
				"note", // Route name
				"Note/{y}/{m}/{d}/{id}.ashx", // URL with parameters
				new { controller = "Note", action = "Details" } // Parameter defaults
				);
			routes.MapRoute(
				"url", // Route name
				"{controller}/{action}.ashx", // URL with parameters
				new { controller = "Home", action = "Index" }, // Parameter defaults
				new[] { "CHSNS.Controllers" }
				);

		}
	}
}
