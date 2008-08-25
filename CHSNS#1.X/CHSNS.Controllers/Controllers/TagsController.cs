
namespace CHSNS.Controllers
{
	using CHSNS.Data;
	
	using CHSNS;
	using CHSNS.Pagination;
	using CHSNS.Models;
	using System.Web.Mvc;
	public class TagsController : BaseController
	{
		public ActionResult LogTag(string title) {
			ViewData["tags"] = PaginationHelper.AsPagination<NotePas>(DBExt.GetNotebyTag(title), 1, 10);
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
