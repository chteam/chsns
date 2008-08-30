

namespace CHSNS.Controllers {
	using Tools;
	using System.Web.Mvc;
	public class TagsController : BaseController {
		public ActionResult LogTag(string title) {
			ViewData["tags"] = DBExt.GetNotebyTag(title).AsPagination(1, 10);
			//DBExt ms = new DBExt(new Dictionary());
			//ViewData["tags"] =
			//    PaginationHelper.CreatePagination(
			//    this,
			//    DBExt.GetNotebyTag(title),
			//    10);
			ViewData["test"] = DBExt.GetNotebyTag(title);
			//RenderView("logtag");
			return View();
		}
	}
}
