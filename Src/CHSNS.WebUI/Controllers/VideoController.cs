using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {
    using System.ComponentModel.Composition;
    using CHSNS.Service;

    public partial class VideoController : BaseController
    {
        [Import]
        public VideoService Video { get; set; }
        [Authorize]
        [HttpGet]
        public virtual ActionResult Edit()
        {
            Title = "�ύ";
            return View();
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult Edit(SuperNote video)
        {
            Video.Create(WebUser,video);
            Message = "�ύ�ɹ�";
            return RedirectToAction("List");
        }
        /// <summary>
        /// �ҵ��б�
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult List(long? uid, int? p)
        {
            InitPage(ref p);
            ViewData["list"] = Video.List(uid,p.Value, 10,WebUser);
            Title = "��Ƶ�б�";
            return View();
        }
        public virtual ActionResult Del(long[] uid)
        {
            Video.Remove(WebUser,uid);
            return View();
        }
    }
}
