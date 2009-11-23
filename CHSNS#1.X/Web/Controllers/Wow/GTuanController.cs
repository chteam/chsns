using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CHSNS.Web;

namespace CHSNS.Controllers
{
    public class GTuanController : BaseController
    {
        //
        // GET: /GTuan/
        int initGB = 1;
        /// <summary>
        /// G����ҳ
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            CurrentUser u;
            using (var w = new WOWDataContext())
            {
                u = w.CurrentUser.FirstOrDefault(c => c.UID == CHUser.UserID);
                if (u == null) return View("join"); //�μ�Ӧ��
                if (u.Character.Count == 0) return View("EditRole");//û������ɫ
                if (u.Character1 == null) return View("SetRole", u.Character);//û���õ�ǰ��ɫ
                ViewData["isend"] = w.Question.Where(c => c.UID == CHUser.UserID
                    && c.Type == 0 && c.BeginTime > DateTime.Now).Take(5).ToList();
                ViewData["xfq"] = w.Question.Where(c =>
                    (c.ForType==0 || c.ForType==2)
                && c.Type == 0 && c.BeginTime > DateTime.Now)
                 .OrderByDescending(c => c.BeginTime).Take(5).ToList();
                ViewData["dgq"] = w.Question.Where(c =>
             (c.ForType == 1 || c.ForType == 2)
         && c.Type == 0 && c.BeginTime > DateTime.Now)
         .OrderByDescending(c=>c.BeginTime).Take(15).ToList();
            }
            //����ʹ����
            Title = "G����ļ";
            return View(u);
        }
       /// <summary>
       /// �ύ��ļ����
       /// </summary>
       /// <param name="t"></param>
       /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Submit(Question t)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.FirstOrDefault(c => c.UID == CHUser.UserID);
            //    u.GB -= (initGB + t.GB);

                t.AddTime = DateTime.Now;
                t.UID = CHUser.UserID;
                t.Type = 0;//G��
                t.ID = Guid.NewGuid();
                w.Question.InsertOnSubmit(t);
                w.SubmitChanges();
                Title = "�½��ƻ�";
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// ��ļ����ҳ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(Guid id){
            using (var w = new WOWDataContext())
            {
                var u = w.Question.FirstOrDefault(c => c.ID == id);
                var x = u.CurrentUser.Character1;
                var a = u.Answer.ToList();
                var ac = u.Answer.Select(c => c.CurrentUser).ToList();
                var au = u.Answer.Select(c => c.CurrentUser.Character1).ToList();
                Title = u.Description;
                return View(u);
            }
        }
        public ActionResult SubmitAnswer(Guid qid,byte role){
            using (var w = new WOWDataContext())
            {
                if (w.Answer.Where(c => c.QuestionID == qid && c.UID == CHUser.UserID).Count() == 0)
                {
                    Answer a = new Answer
                    {
                        Status = 0,
                        UID = CHUser.UserID,
                        QuestionID = qid,
                        Role = role,
                        AddTime = DateTime.Now,
                    };
                    w.Answer.InsertOnSubmit(a);
                    w.SubmitChanges();
                }
            }
            return RedirectToAction("Details", new { id = qid });
        }
    }
}
