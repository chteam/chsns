using System.Transactions;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {

    public partial class NoteController : BaseController
    {
        [Authorize]
        public virtual ActionResult Index(long? userid, int? p)
        {

            if (!userid.HasValue) userid = CHUser.UserId;
            if (!p.HasValue || p == 0) p = 1;
            var user = Services.UserInfo.GetUser(
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

        [HttpPost]
        public virtual ActionResult NoteList(int p, int ep, long userid)
        {
            ViewData.Model = Services.Note.GetNotes(userid, NoteType.Note, p, ep);
            return View();
        }
       
        public virtual ActionResult Details(long id)
        {
            var note = Services.Note.Details(id, NoteType.Note);
            var cl = Services.Comment.CommentList(id, CommentType.Note, 1, WebContext.Site);
            ViewData["commentlist"] = cl;
            Title = note.Title;
            ViewData["NowPage"] = 1;
            ViewData["PageCount"] = note.CommentCount;
            Services.View.Update(VisitLogType.Note, id, CHUser);
            return View(note);
        }
        
        [HttpGet]
        [Authorize]
        public virtual ActionResult Edit(long? id)
        {
            if (id.HasValue)
            {
                Title = "修改日志";
                var n = Services.Note.Details(id.Value, NoteType.Note);
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
            note.UserId = CHUser.UserId;
            if (id.HasValue)
            {
                note.Id = id.Value;
                Services.Note.Edit(note);
            }
            else
            {
                note.Type = (int)NoteType.Note;
                note.Username = CHUser.Name;
                note.ParentId = CHUser.UserId;
                Services.Note.Add(note, CHUser);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize]
        public virtual ActionResult Delete(long id)
        {
            Services.Note.Delete(id, CHUser.UserId, NoteType.Note);
            return Content("");
        }

        /// <summary>
        /// 全局最新的note
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult News()
        {
            Title = "日志首页";
            return View(Services.Note.GetLastNotes(null));
        }
    }
}
