using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {

    public class VideoController : BaseController {
        [LoginedFilter]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit() {
            Title = "�ύ";
            return View();
        }
        [LoginedFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(SuperNote v) {
            DataExt.Video.Create(CHUser,v);
            Message = "�ύ�ɹ�";
            return RedirectToAction("List");
        }
        /// <summary>
        /// �ҵ��б�
        /// </summary>
        /// <returns></returns>
        public ActionResult List(long? uid, int? p) {
            InitPage(ref p);
            ViewData["list"] = DataExt.Video.List(uid,p.Value, 10,CHUser);
            Title = "��Ƶ�б�";
            return View();
        }
        public ActionResult Del(long[] uid) {
            DataExt.Video.Remove(CHUser,uid);
            return View();
        }
    }
}
