/*
 * Created by 邹健
 * Date: 2007-10-19
 * Time: 22:51
 */
using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CHSNS.Service;

namespace CHSNS.Web
{
    [CompilerGlobalScope]
    public class Global : HttpApplication
    {

        public void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RegisterRoutes(RouteTable.Routes);
        }

        public void SessionOnStart(object sender, EventArgs e)
        {

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
        public static void RegisterRoutes(RouteCollection routes)
        {

            const string ext = "";
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("indexf", "", new { controller = "Entry", action = "Index", Title = "Index" });
            routes.MapRoute("index", "{Title}" + ext, new { controller = "Entry", action = "Index", Title = "Index" }, new[] { "CHSNS.Controllers" });
            routes.MapRoute("entry", "w/{title}" + ext, new { controller = "Entry", action = "Index", Title = "Index" }, new[] { "CHSNS.Controllers" });
            routes.MapRoute("post", "Post/{y}/{m}/{d}/{id}" + ext, new { controller = "Group", action = "Details" });
            routes.MapRoute("note", "Note/{y}/{m}/{d}/{id}" + ext, new { controller = "Note", action = "Details" });
            routes.MapRoute("url", "{controller}/{action}" + ext,
                new { controller = "Home", action = "Index" }, new[] { "CHSNS.Controllers" });

        }
    }
}