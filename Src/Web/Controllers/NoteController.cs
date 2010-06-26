using System.Web.Mvc;
using System.Transactions;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {

    public partial class NoteController : BaseController
    {
        public virtual ActionResult Index(long? userid, int? p)
        {

            if (!userid.HasValue) userid = CHUser.UserId;
            if (!p.HasValue || p == 0) p = 1;
            var user = DataExt.UserInfo.GetUser(
                userid.Value,
                c => new Profile
                         {
                             UserId=c.UserId,
                             Name = c.Name,
                             //Count = c.NoteCount
                         });
            ViewData["username"] = user.Name;
            ViewData["userid"] = user.UserId;
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
		[HttpPost]
        public virtual ActionResult NoteList(int p, int ep, long userid)
        {
            var d =
                DataExt.Note.GetNotes(userid, NoteType.Note, p, ep)
                ;
			return View(d);
		}
        public virtual ActionResult Details(long id)
        {
			var note = DataExt.Note.Details(id, NoteType.Note);
            var cl = DataExt.Comment.CommentList(id, CommentType.Note, 1, CHContext.Site);
			ViewData["commentlist"] = cl;
			Title = note.Note.Title;
			ViewData["NowPage"] = 1;
			ViewData["PageCount"] = note.User.Count;
			return View(note);
		}
		[HttpGet]
		[Authorize]
        public virtual ActionResult Edit(long? id)
        {
			using (var ts = new TransactionScope()) {
				Note n = null;
				if (id.HasValue) {//编辑
					n = DataExt.Note.Details(id.Value, NoteType.Note).Note;
					Title = "修改日志";
				} else {
					Title = "发新日志";
				}
				ts.Complete();
				return View(n);
			}
		}
		[ValidateInput(false)]
		[HttpPost]
		[Authorize]
        public virtual ActionResult Edit(long? id,Note n)
        {
			using (var ts = new TransactionScope()) {
				if (n.Title.Length < 1 || n.Body.Length < 10) {
					Message = ("请输入正确的日志内容");
					return View(n);
				}
				n.Type = (int)NoteType.Note;
				n.UserId = CHUser.UserId;
				n.ParentId = CHUser.UserId;
				if (id.HasValue) {
					n.Id = id.Value;
					DataExt.Note.Edit(n);
				}
				else {
					DataExt.Note.Add(n,CHUser);
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
		[HttpPost]
		[Authorize]
        public virtual ActionResult Delete(long id)
        {
			using (var ts = new TransactionScope()) {
				DataExt.Note.Delete(id, CHUser.UserId, NoteType.Note);
				ts.Complete();
				return Content("");
			}
		}

		/// <summary>
		/// 全局最新的note
		/// </summary>
		/// <returns></returns>
        public virtual ActionResult News()
        {
			Title = "日志首页";
			return View(DataExt.Note.GetLastNotes(null));
		}
	}
}
