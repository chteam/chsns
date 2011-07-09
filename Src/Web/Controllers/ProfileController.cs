using System.Web.Mvc;

namespace CHSNS.Controllers {
    using System.ComponentModel.Composition;
    using CHSNS.Service;

    [Authorize]
    public partial class ProfileController : BaseController
    {
        [Import]
        public UserService UserInfo { get; set; }
        public void Setting(int? tabs) {
            ViewData.Add("tabs", tabs??0);
        }
        public virtual ActionResult SaveText(string text)
        {
            UserInfo.SaveText(WebUser.UserId, text, WebContext);
            return Content("");
        }
    }
}
