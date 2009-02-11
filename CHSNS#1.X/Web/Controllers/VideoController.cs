using System;
using System.Web.Mvc;
using CHSNS.Models;

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
        public ActionResult Edit(SuperNote v) {
            DBExt.Video.Create(v);
            Message = "提交成功";
            return RedirectToAction("List");
        }
        /// <summary>
        /// 我的列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List(long? uid, int? p) {
            InitPage(ref p);
            ViewData["list"] = DBExt.Video.List(uid).Pager(p.Value, 10);
            Title = "视频列表";
            return View();
        }
        public ActionResult Del(long[] uid) {
            DBExt.Video.Remove(uid);
            return View();
        }
    }
}
