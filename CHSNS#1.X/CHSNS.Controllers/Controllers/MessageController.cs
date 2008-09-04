/*
 * ×Þ½¡ 08-1-24
 */


using System.Web.Mvc;

namespace CHSNS.Controllers
{
	using Extension;
	using Filter;
	[LoginedFilter]
	public class MessageController : BaseController {
		public void index1() {
			int tabs;
			switch (this.QueryString("mode")) {
				case "sent":
					tabs = 1;
					break;
				case "compose":
					tabs = 2;
					break;
				case "read":
					tabs = 3;
					break;
				case "inbox":
				default:
					tabs = 0;
					break;
			}
			ViewData.Add("tabs", tabs);
			ViewData.Add("Toid", this.QueryLong("Toid"));
			ViewData.Add("Toname", this.QueryString("Toname"));
		}

		public ActionResult InBox() {
			return View();
		}
		public ActionResult OutBox() {
			return View();
		}
		public ActionResult Details() {
			return View();
		}
		public ActionResult Write() {
			return View();
		}
	}
}
