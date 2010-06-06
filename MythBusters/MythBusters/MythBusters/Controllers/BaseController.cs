using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RenRen;
using MythBusters.Models;
using System.Web.Security;

namespace MythBusters.Controllers
{
    [SessionKeyFilter]
    public class BaseController : Controller, IRenRenHandler
    {

        public RenRenApi GetApi()
        {
            string sessionKey = Request.QueryString["xn_sig_session_key"];
            return Api = new RenRenApi("c7f9c729cd74485897f033609083ba75",
                "26e76666962147549ee365330b692b96",
                         sessionKey, this);
            //http://app.renren.com/apps/tos.do?v=1.0&api_key=c7f9c729cd74485897f033609083ba75
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
            if (!User.Identity.IsAuthenticated) {
                //IPrincipal
                var api = GetApi();
                var userId = api.Users.GetLoggedInUser();
                Profile pro;
                using (var db = new Models.MythBustersEntities1()) {
                    pro = db.Profile.FirstOrDefault(c => c.Id == userId);
                    if (pro == null)
                    {
                        var user = api.Users.GetInfo(userId);
                        db.Profile.AddObject(pro = new Profile
                        {
                            Id = Convert.ToInt32(user.UserId),
                            Name = user.Name,
                            FaceUrl = user.HeadUrl,
                            Money = 0
                        });
                        db.SaveChanges();
                    }
                }
                var ticket = new FormsAuthenticationTicket(string.Join(",", new[] { pro.Id.ToString(), pro.Name, pro.FaceUrl }), true, 3600);
                var authTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, authTicket));

            }
        }

        public RenRenApi Api { get; set; }

        public bool IsDebug { get; set; }

        public string UserID { get; set; }
    }
}
