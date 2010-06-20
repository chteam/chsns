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
using System.Web.Security;
namespace CHSNS.Web
{
    [CompilerGlobalScope]
    public class Global : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            const string ext = "";
            routes.IgnoreRoute("{resource}.{ext}");
            //routes.IgnoreRoute("{resource}.txt");
            routes.IgnoreRoute("{resource}.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("indexf", "", new { controller = "Entry", action = "Index", Url = "Index" });
            routes.MapRoute("index", "{Url}" + ext, new { controller = "Entry", action = "Index", Url = "Index" });
            routes.MapRoute("entry", "w/{Url}" + ext, new { controller = "Entry", action = "Index", Url = "Index" });
            routes.MapRoute("post", "Post/{y}/{m}/{d}/{id}" + ext, new { controller = "Group", action = "Details" });
            routes.MapRoute("note", "Note/{y}/{m}/{d}/{id}" + ext, new { controller = "Note", action = "Details" });
            routes.MapRoute("url", "{controller}/{action}" + ext,
                new { controller = "Home" });
        }
        public void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RegisterRoutes(RouteTable.Routes);
        }
        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (null == authCookie) return;
            FormsAuthenticationTicket authTicket;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception)
            {
                return;
            }
            if (null == authTicket) return;
            string[] userData = authTicket.UserData.Split(new[] { '|' });
            //Context.User = Acl.User.BuildPrincipal(Convert.ToInt32(userData[0]), userData[1], userData[2],
            //                                       userData[3], DateTime.FromBinary(Convert.ToInt64(userData[4])),
            //                                       Acl.GanjiApplications.CRM);

        }
        public void Session_Start(object sender, EventArgs e)
        {

            IContext context1 = new CHContext(new HttpContextWrapper(Context));
            if (context1.User.IsLogin) return; //当前不处于登录状态
            if (!context1.Cookies.IsAutoLogin) return;
            var pwd = context1.Cookies.UserPassword;
            var idb = new DataManager();
            idb.Account.Login(context1.Cookies.UserID.ToString(),
                              pwd,
                              true,
                              false, context1
                );
        }

    }
}
