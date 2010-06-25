using System.Web.Mvc;


namespace CHSNS.Controllers {
    [LoginedFilter]
    public partial class ProfileController : BaseController
    {
        public void Setting(int? tabs) {
            ViewData.Add("tabs", tabs??0);
        }
        public virtual ActionResult SaveText(string text)
        {
            DataExt.UserInfo.SaveText(CHUser.UserId, text, CHContext);
            return Content("");
        }
    }
}
