using System.Web.Mvc;


namespace CHSNS.Controllers {
    [LoginedFilter]
    public class ProfileController : BaseController {
        public void Setting(int? tabs) {
            ViewData.Add("tabs", tabs??0);
        }
        public ActionResult SaveText(string text) {
            DbExt.UserInfo.SaveText(CHUser.UserId, text, CHContext);
            return Content("");
        }
    }
}
