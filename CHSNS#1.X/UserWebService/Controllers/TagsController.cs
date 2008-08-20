
namespace ChAlumna.Controllers
{
	using CHSNS.Data;
	using Castle.MonoRail.Framework.Helpers;
	using CHSNS;
	public class TagsController : BaseController
	{
		public void LogTag(string title) {
			DBExt ms = new DBExt(new Dictionary());
			ViewData["tags"] =
				PaginationHelper.CreatePagination(
				this,
				ms.GetNotebyTag(title),
				10);
			ViewData["test"] = ms.GetNotebyTag(title);
			RenderView("logtag");
		}
	}
}
