using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {

    public partial class VideoController : BaseController
    {
        [Authorize]
        [HttpGet]
        public virtual ActionResult Edit()
        {
            Title = "提交";
            return View();
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult Edit(SuperNote video)
        {
            Services.Video.Create(CHUser,video);
            Message = "提交成功";
            return RedirectToAction("List");
        }
        /// <summary>
        /// 我的列表
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult List(long? uid, int? p)
        {
            InitPage(ref p);
            ViewData["list"] = Services.Video.List(uid,p.Value, 10,CHUser);
            Title = "视频列表";
            return View();
        }
        public virtual ActionResult Del(long[] uid)
        {
            Services.Video.Remove(CHUser,uid);
            return View();
        }
    }
}
