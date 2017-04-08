using System.Web.Mvc;
using CHSNS.Models;


namespace CHSNS.Controllers {
    using System.ComponentModel.Composition;
    using CHSNS.Service;

    public partial class NoteController : BaseController
    {[Import]
        public UserService UserInfo { get; set; }
        [Authorize]
        public virtual ActionResult Index(long? userid, int? p)
        {

            if (!userid.HasValue) userid = WebUser.UserId;
            if (!p.HasValue || p == 0) p = 1;
            var user = UserInfo.GetUser(
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
        [Import]
        public NoteService Note { get; set; }
        [HttpPost]
        public virtual ActionResult NoteList(int p, int ep, long userid)
        {
            ViewData.Model = Note.GetNotes(userid, NoteType.Note, p, ep);
            return View();
        }
        [Import]
        public CommentService Comment { get; set; }
        [Import]
        public ViewLogService ViewLogLog { get; set; }
        public virtual ActionResult Details(long id)
        {
            var note = Note.Details(id, NoteType.Note);
            var cl = Comment.CommentList(id, CommentType.Note, 1, WebContext.Site);
            ViewData["commentlist"] = cl;
            Title = note.Title;
            ViewData["NowPage"] = 1;
            ViewData["PageCount"] = note.CommentCount;
            ViewLogLog.Update(VisitLogType.Note, id, WebUser);
            return View(note);
        }
        
        [HttpGet]
        [Authorize]
        public virtual ActionResult Edit(long? id)
        {
            if (id.HasValue)
            {
                Title = "修改日志";
                var n = Note.Details(id.Value, NoteType.Note);
                return View(n);
            }
            else
            {
                Title = "发新日志";
                return View();
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        [Authorize]
        public virtual ActionResult Edit(long? id, Note note)
        {
            if (note.Title.Length < 1 || note.Body.Length < 10)
            {
                Message = ("请输入正确的日志内容");
                return View(note);
            }
            note.UserId = WebUser.UserId;
            if (id.HasValue)
            {
                note.Id = id.Value;
                Note.Edit(note);
            }
            else
            {
                note.Type = (int)NoteType.Note;
                note.Username = WebUser.Name;
                note.ParentId = WebUser.UserId;
                Note.Add(note, WebUser);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize]
        public virtual ActionResult Delete(long id)
        {
            Note.Delete(id, WebUser.UserId, NoteType.Note);
            return Content("");
        }

        /// <summary>
        /// 全局最新的note
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult News()
        {
            Title = "日志首页";
            return View(Note.GetLastNotes(null));
        }
    }
}
