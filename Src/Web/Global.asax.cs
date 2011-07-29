﻿namespace CHSNS.Web
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;
    using CHSNS.Common.LocalImplement;
    using CHSNS.Common.Serializer;
    using CHSNS.DataContext;
    using CHSNS.Validator;

    [CompilerGlobalScope]
    public class Global : HttpApplication
    {
        public Global()
        {
            BeginRequest+=Global_BeginRequest;
            EndRequest+=GlobalEndRequest;
        }

        private void GlobalEndRequest(object sender, EventArgs e)
        {
            if(Context.Request.IsLocal)
            {
                MvcMiniProfiler.MiniProfiler.Start();
            }
        }

        private void Global_BeginRequest(object sender, EventArgs e)
        {
            
            MvcMiniProfiler.MiniProfiler.Start();
        }

        #region Register Routes and GlobalFilters

        public static void RegisterRoutes(RouteCollection routes)
        {
            const string ext = "";
            routes.IgnoreRoute("{resource}.{ext}");
            //routes.IgnoreRoute("{resource}.txt");
            routes.IgnoreRoute("{resource}.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("indexf", "", new {controller = "Entry", action = "Index", Url = "Index"});
            routes.MapRoute("index", "{Url}" + ext, new {controller = "Entry", action = "Index", Url = "Index"});
            routes.MapRoute("entry", "w/{Url}" + ext, new {controller = "Entry", action = "Index", Url = "Index"});
            routes.MapRoute("post", "Post/{y}/{m}/{d}/{id}" + ext, new {controller = "Group", action = "Details"});
            routes.MapRoute("note", "Note/{y}/{m}/{d}/{id}" + ext, new {controller = "Note", action = "Details"});
            routes.MapRoute("url", "{controller}/{action}" + ext,
                            new {controller = "Home"});
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new OnlineFilter());
        }

        #endregion

        public void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ValidatorRegister.RegisterAdapter();
            CacheProvider.Register(new HttpCache());
            string rootPath = Server.MapPath("~/");
            IOFactory.Register(new LocalStoreFile(rootPath), new LocalFolder(rootPath));
            ConfigSerializer.Register(new ConfigSerializer(rootPath));
            OnlineProvider.Register(new Online());
            
            using (var db = new SqlServerEntities())
            {
                db.Database.CreateIfNotExists();
            }
        }

        #region Authenticate

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
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
            var profile = JsonAdapter.Deserialize<WebIdentity>(authTicket.UserData);
            Context.User = new WebPrincipal
                               {
                                   Identity = profile
                               };
        }

        #endregion
        
    }
}