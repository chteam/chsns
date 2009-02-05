using System.Web.Mvc;


namespace CHSNS.Controllers
{

	
	[LoginedFilter]
	public class ProfileController : BaseController
	{
		public void setting() {
			ViewData.Add("tabs", this.QueryNum("tabs"));
		}
		public ActionResult SaveText(string text) {
			DBExt.UserInfo.SaveText(CHUser.UserID, text);
			return Content("");
		}
	}
}
