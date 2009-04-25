using System.Web.Mvc;
using System.Transactions;
using CHSNS.Model;
using CHSNS.Abstractions;

namespace CHSNS.Controllers {

	public class NoteController : BaseController {
        public ActionResult Index(long? userid, int? p)
        {

            if (!userid.HasValue) userid = CHUser.UserID;
            if (!p.HasValue || p == 0) p = 1;
            var user = DbExt.UserInfo.GetUser(
                userid.Value,
                c => new ProfileImplement
                         {
                             UserID=c.UserID,
                             Name = c.Name,
                             //Count = c.NoteCount
                         });
            ViewData["username"] = user.Name;
            ViewData["userid"] = user.UserID;
            ViewData["PageCount"] = 0;// user.Count;
            ViewData["NowPage"] = p.Value;
            Title = user.Name + "的日志";
            var ret = NoteList(p.Value, 10, userid.Value);

            return ret;

        }

	    /// <summary>
		/// Notes the list.
		/// </summary>
		/// <param name="p">The p.</param>
		/// <param name="ep">The ep.</param>
		/// <param name="userid">The userid.</param>
		/// <returns></returns>
		[AcceptVerbs("Post")]
		public ActionResult NoteList(int p, int ep, long userid) {
            var d =
                DbExt.Note.GetNotes(userid, NoteType.Note, p, ep)
                ;
			return View(d);
		}
		public ActionResult Details(long id) {
			var note = DbExt.Note.Details(id, NoteType.Note);
            var cl = DbExt.Comment.CommentList(id, CommentType.Note, 1, CHContext.Site);
			ViewData["commentlist"] = cl;
			Title = note.Note.Title;
			ViewData["NowPage"] = 1;
			ViewData["PageCount"] = note.User.Count;
			return View(note);
		}
		[AcceptVerbs(HttpVerbs.Get)]
		[LoginedFilter]
		public ActionResult Edit(long? id) {
			using (var ts = new TransactionScope()) {
				INote n = null;
				if (id.HasValue) {//编辑
					n = DbExt.Note.Details(id.Value, NoteType.Note).Note;
					Title = "修改日志";
				} else {
					Title = "发新日志";
				}
				ts.Complete();
				return View(n);
			}
		}
		[ValidateInput(false)]
		[AcceptVerbs(HttpVerbs.Post)]
		[LoginedFilter]
		public ActionResult Edit(long? id, [Bind(Prefix="n")]NoteImplement n) {
			using (var ts = new TransactionScope()) {
				if (n.Title.Length < 1 || n.Body.Length < 10) {
					Message = ("请输入正确的日志内容");
					return View(n);
				}
				n.Type = (int)NoteType.Note;
				n.UserID = CHUser.UserID;
				n.PID = CHUser.UserID;
				if (id.HasValue) {
					n.ID = id.Value;
					DbExt.Note.Edit(n);
				}
				else {
					DbExt.Note.Add(n,CHUser);
				}
				ts.Complete();
				return RedirectToAction("Index");
			}
		}

		/// <summary>
		/// Delete the Note
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		[AcceptVerbs("post")]
		[LoginedFilter]
		public ActionResult Delete(long id) {
			using (var ts = new TransactionScope()) {
				DbExt.Note.Delete(id, CHUser.UserID, NoteType.Note);
				ts.Complete();
				return Content("");
			}
		}

		/// <summary>
		/// 全局最新的note
		/// </summary>
		/// <returns></returns>
		public ActionResult News() {
			Title = "日志首页";
			return View(DbExt.Note.GetLastNotes(null));
		}
	}
}
