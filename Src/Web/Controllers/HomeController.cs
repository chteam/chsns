
namespace CHSNS.Controllers
{
    using System.ComponentModel.Composition;
    using System.Web.Mvc;
    using CHSNS.Service;

    public partial class HomeController : BaseController
    {
        [Import]
        public AccountService Account { get; set; }
        public virtual ActionResult Index()
        {
            //ViewData["viewlist"] = DBExt.View.ViewList(3, 3, 0, 6);
            Title = "首页";
            return RedirectToAction("index", "Entry", new { title = "index" });
        }
        public void LogOff() {
            Account.Logout(WebContext);
            RedirectToAction("index");
        }
        protected override void HandleUnknownAction(string actionName) {
            View(actionName).ExecuteResult(ControllerContext);
        }

    }
}
