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
            Title = "�ύ";
            return View();
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult Edit(SuperNote video)
        {
            Services.Video.Create(CHUser,video);
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
            ViewData["list"] = Services.Video.List(uid,p.Value, 10,CHUser);
            Title = "��Ƶ�б�";
            return View();
        }
        public virtual ActionResult Del(long[] uid)
        {
            Services.Video.Remove(CHUser,uid);
            return View();
        }
    }
}
