using System;
using System.Web.Mvc;

namespace CHSNS.Controllers
{
	[LoginedFilter]
	public class VideoController : BaseController
	{
		public ActionResult Edit(){

			return View();
		}

		public ActionResult List() {
			//SuperNoteList snl = new SuperNoteList();
			//snl.Everypage = 10;
			//snl.Nowpage = 1;
			//snl.Template = "supernotepage";
			//snl.Userid = this.QueryLong("userid") == 0
			//    ? CHSNSUser.Current.UserID : this.QueryLong("userid");
			//ViewData["page"] = snl.CreateUserSuperNote().ToString();
			return View();
		}
		public ActionResult Random() {
			//SuperNoteList snl = new SuperNoteList();
			//snl.Everypage = 10;
			//snl.Nowpage = 1;
			//snl.Template = "SuperNoteRandomPage";

			//snl.Type = 1;
			//snl.Userid = CHUser.UserID;

			//ViewData["page"] = snl.CreateUserSuperNote().ToString();
			return View();
		}
	}
}
