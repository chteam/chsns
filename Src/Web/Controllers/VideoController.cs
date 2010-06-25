using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {

    public partial class VideoController : BaseController
    {
        [LoginedFilter]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Edit()
        {
            Title = "�ύ";
            return View();
        }
        [LoginedFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Edit(SuperNote v)
        {
            DataExt.Video.Create(CHUser,v);
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
            ViewData["list"] = DataExt.Video.List(uid,p.Value, 10,CHUser);
            Title = "��Ƶ�б�";
            return View();
        }
        public virtual ActionResult Del(long[] uid)
        {
            DataExt.Video.Remove(CHUser,uid);
            return View();
        }
    }
}
