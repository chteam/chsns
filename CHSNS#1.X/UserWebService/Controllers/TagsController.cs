
namespace ChAlumna.Controllers
{
	using ChAlumna.Data;
	using Castle.MonoRail.Framework.Helpers;
	public class TagsController : BaseController
	{
		public void LogTag(string title) {
			MsSqlDB ms = new MsSqlDB(new Dictionary());
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
