
namespace CHSNS.Controllers
{
    using System.Web.Mvc;
    using CHSNS.Models;
    using System.Configuration;
    
    public partial class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            //ViewData["viewlist"] = DBExt.View.ViewList(3, 3, 0, 6);
            Title = "首页";
            return RedirectToAction("index", "Entry", new { title = "index" });
        }
        public void LogOff() {
            ServicesFactory.Account.Logout(CHContext);
            RedirectToAction("index");
        }
        protected override void HandleUnknownAction(string actionName) {
            View(actionName).ExecuteResult(ControllerContext);
        }

    }
}
