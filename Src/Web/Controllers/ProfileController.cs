using System.Web.Mvc;

namespace CHSNS.Controllers {
    [Authorize]
    public partial class ProfileController : BaseController
    {
        public void Setting(int? tabs) {
            ViewData.Add("tabs", tabs??0);
        }
        public virtual ActionResult SaveText(string text)
        {
            Services.UserInfo.SaveText(CHUser.UserId, text, WebContext);
            return Content("");
        }
    }
}
