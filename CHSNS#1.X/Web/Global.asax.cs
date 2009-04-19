/*
 * Created by 邹健
 * Date: 2007-10-19
 * Time: 22:51
 */
using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Routing;
using CHSNS.Mvc;
using CHSNS.Service;

namespace CHSNS
{
    [CompilerGlobalScope]
    public class Global : HttpApplication
    {

        public void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            //Application.Add("Application.IsMustJoinClass", true);
            //网站设置，是否必须加入班级
            //SystemConfig system = SystemConfig.Currect;

            //var path = new ConfigPath();
            RegisterRoutes(RouteTable.Routes);
            DynamicDataInit();
            //ControllerBuilder.Current.SetControllerFactory(typeof(NVelocityEngine.NVelocityControllerFactory));
        }
        public static void DynamicDataInit()
        {
            var model = new MetaModel();
            model.RegisterContext(typeof(Models.CHSNSDBDataContext),
                new ContextConfiguration { ScaffoldAllTables = true });
            ModelBinders.Binders.DefaultBinder = new DynamicDataModelBinder(ModelBinders.Binders.DefaultBinder);
        }
        public void Application_End(object sender, EventArgs e)
        {
        }

        public void Application_Error(object sender, EventArgs e)
        {
        }

        public void Session_OnStart(object sender, EventArgs e){

            IContext context1 = new CHContext(new HttpContextWrapper(Context));
            if (context1.User.IsLogin) return; //当前不处于登录状态
            if (!context1.Cookies.IsAutoLogin) return;
            var pwd = context1.Cookies.UserPassword;
            var idb = new DBManager();
            idb.Account.Login(context1.Cookies.UserID.ToString(),
                              pwd,
                              true,
                              false, context1
                );
        }

        public void Session_OnEnd(object sender, EventArgs e) { }


        public static void RegisterRoutes(RouteCollection routes)
        {

            var ext = "asbx";
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
       "indexf", // Route name
       "", // URL with parameters
       new { controller = "Entry", action = "Index", Title = "Index" }// Parameter defaults
       );
            routes.MapRoute(
                "index", // Route name
                "{Title}." + ext, // URL with parameters
                new { controller = "Entry", action = "Index", Title = "Index" }, // Parameter defaults
                new[] { "CHSNS.Controllers" }
                );
            routes.MapRoute(
                "entry", // Route name
                "w/{title}." + ext, // URL with parameters
                new { controller = "Entry", action = "Index", Title = "Index" }, // Parameter defaults
                new[] { "CHSNS.Controllers" }
                );
            routes.MapRoute(
                "post", // Route name
                "Post/{y}/{m}/{d}/{id}." + ext, // URL with parameters
                new { controller = "Group", action = "Details" } // Parameter defaults
                );
            routes.MapRoute(
                "note", // Route name
                "Note/{y}/{m}/{d}/{id}." + ext, // URL with parameters
                new { controller = "Note", action = "Details" } // Parameter defaults
                );
            routes.MapRoute(
                "url", // Route name
                "{controller}/{action}." + ext, // URL with parameters
                new { controller = "Home", action = "Index" }, // Parameter defaults
                new[] { "CHSNS.Controllers" }
                );

        }
    }
}
