using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CHSNS.Web;

namespace CHSNS.Controllers
{
    public class WowController :BaseController
    {
        //
        // GET: /Wow/
        
        public ActionResult Index()
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == CHUser.UserID).FirstOrDefault();
                if (u == null)
                {
                    //�μ�Ӧ��
                    return View("join");
                }
                if (u.Character.Count == 0)
                {
                    //û������ɫ
                    return View("CreateRole");
                }
                if (u.Character1 == null)
                {
                    //û���õ�ǰ��ɫ
                }
                //����ʹ����

            }
            return View();
        }
        public ActionResult Join()
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == CHUser.UserID).FirstOrDefault();
                if (u == null)
                {
                    u = new CurrentUser()
                    {
                        ConsumerGB = 0,
                        Evaluation = 0,
                        GB = 100,
                        UID = CHUser.UserID,
                        WorkerGB = 0
                    };
                    w.CurrentUser.InsertOnSubmit(u);
                    w.SubmitChanges();
                    //�μ�Ӧ��
                }
            }
            return RedirectToAction("Index");
        }


    }
}
