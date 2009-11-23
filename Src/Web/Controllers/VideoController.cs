using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Abstractions;

namespace CHSNS.Controllers {

    public class VideoController : BaseController {
        [LoginedFilter]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit() {
            Title = "提交";
            return View();
        }
        [LoginedFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(SuperNoteImplement v) {
            DbExt.Video.Create(CHUser,v);
            Message = "提交成功";
            return RedirectToAction("List");
        }
        /// <summary>
        /// 我的列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List(long? uid, int? p) {
            InitPage(ref p);
            ViewData["list"] = DbExt.Video.List(uid,p.Value, 10,CHUser);
            Title = "视频列表";
            return View();
        }
        public ActionResult Del(long[] uid) {
            DbExt.Video.Remove(CHUser,uid);
            return View();
        }
    }
}
