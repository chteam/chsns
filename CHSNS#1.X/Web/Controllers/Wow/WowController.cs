using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CHSNS.Web;
using System.Net;
using System.Xml;
using System.Xml.Linq;
namespace CHSNS.Controllers
{
    public class WowController : BaseController
    {
        //
        // GET: /Wow/
        int initGB = 1;
        public ActionResult Index()
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == CHUser.UserID).FirstOrDefault();
                if (u == null) return View("join"); //�μ�Ӧ��
                if (u.Character.Count == 0) return View("EditRole");//û������ɫ
                if (u.Character1 == null) return View("SetRole", u.Character);//û���õ�ǰ��ɫ
                //����ʹ����
                Title = "G����ļ";
                return View(u);

            }

        }
        #region Role
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CreateBegin() {
            ViewData["ServerName"]=new List<SelectListItem>();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateBegin(string rolename, string servername, string servernametxt)
        {
            HttpProc proc = new HttpProc(string.Format(
                     "http://cn.wowarmory.com/character-sheet.xml?r={0}&n={1}",
                     Server.UrlEncode(servername ?? servernametxt),
                    Server.UrlEncode(rolename)
                     ));
            proc.encoding = System.Text.Encoding.UTF8;
            string xml = proc.Proc();
            XDocument xdoc = XDocument.Load(new System.IO.StringReader(xml));
            ViewData["c"] = (from c in xdoc.Descendants()
                             where c.Name == "character"
                             select new Character
                             {
                                 Name = c.Attribute("name").Value,
                                 Gend = c.Attribute("gender").Value,
                                 Class = c.Attribute("class").Value,
                                 Faction = c.Attribute("faction").Value,
                                 RealM = c.Attribute("realm").Value,
                                 Level = int.Parse(c.Attribute("level").Value),
                                 BattleGroup =c.Attribute("battleGroup").Value,
                                 Race = c.Attribute("race").Value 
                             }).FirstOrDefault();

            return View("EditRole");
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
                        GB = 1000 * initGB,
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
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditRole(long? ID)
        {
            using (var w = new WOWDataContext())
            {
                if (ID.HasValue)
                {
                    //update
                    ViewData["c"] =
                        w.Character.Where(c1 => c1.ID == ID.Value).FirstOrDefault();
                }
                Title = "�½���Ϸ��ɫ";
            }
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditRole(long? ID, Character c)
        {
            using (var w = new WOWDataContext())
            {
                if (ID.HasValue)
                {
                    //update
                    var cu = w.Character.Where(c1 => c1.ID == ID.Value && c1.UID == CHUser.UserID).FirstOrDefault();
                    cu.RealM = c.RealM;
                    cu.Race = c.Race;
                    cu.Name = c.Name;
                    cu.Level = c.Level;
                    cu.lastLoginDate = c.lastLoginDate;
                    cu.Gend = c.Gend;
                    cu.Faction = c.Faction;
                    cu.BattleGroup = c.BattleGroup;
                }
                else
                { //insert
                    c.UID = CHUser.UserID;
                    w.Character.InsertOnSubmit(c);
                }
                w.SubmitChanges();
            }
            return RedirectToAction("SetRole");
        }
        public ActionResult SetRole(long? id)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == CHUser.UserID).FirstOrDefault();
                if (id.HasValue)
                {
                    u.CurrentCID = id;
                    w.SubmitChanges();
                }
                ViewData["cid"] = u.CurrentCID ?? -1;
                Title = "�����û���ɫ";
                return View(u.Character.ToList());
            }

        }
        #endregion

        #region Question
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddQuestion()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddQuestion(Question t)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.FirstOrDefault(c => c.UID == CHUser.UserID);
//                u.GB -= (initGB + t.GB);
                t.AddTime = DateTime.Now;
                t.UID = CHUser.UserID;
                t.Type = 0;//����
                w.Question.InsertOnSubmit(t);
                w.SubmitChanges();
                Title = "�½��ƻ�";
                return RedirectToAction("QuestionList");
            }
        }
        public ActionResult QuestionList(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Question.Where(c => c.UID == CHUser.UserID).ToList());
            }
        }
        public ActionResult QuestionDetails(Guid id)
        {
            using (var w = new WOWDataContext())
            {
                var t = w.Question.Where(c => c.ID == id).FirstOrDefault();
                ViewData["wid"] = new SelectList(w.Answer.Where(c => c.Status == 0 && c.UID == CHUser.UserID).ToList(),"ID","Description");
                return View(t);
            }
        }
        public ActionResult JoinQuestion(Guid wid, Guid tid)
        {
            using (var w = new WOWDataContext())
            {
                var t = w.Answer.Where(c => c.ID == wid).FirstOrDefault();
                if (t != null) { t.QuestionID = tid;
                t.Status = 1;
                }
                w.SubmitChanges();
                return RedirectToAction("index");
            }
        }
        #endregion
        #region work
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddWork(long? Questionid)
        {
            ViewData["t.QuestionID"] = Questionid;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddWork(Answer t)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == CHUser.UserID).FirstOrDefault();
                u.GB -= initGB;

                t.AddTime = DateTime.Now;
                t.UID = CHUser.UserID;
             //   t.Type = 0;//����



                w.Answer.InsertOnSubmit(t);
                w.SubmitChanges();

                return RedirectToAction("WorkList");
            }
        }
        public ActionResult WorkList(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Answer.Where(c => c.UID == CHUser.UserID).ToList());
            }
        }
        public ActionResult  WorkDetails(Guid id){
            using (var w = new WOWDataContext())
            {
                return View(w.Answer.Where(c => c.ID==id).FirstOrDefault());
            }
        }
        #endregion

        #region ������
        public ActionResult Work(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Answer.Where(c => c.Status == 0));
            }
        }
        public ActionResult Question(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Question.Where(c => c.Type == 0).ToList());
            }
        }

        public ActionResult SetWorkStatus(Guid id, byte s) {
            using (var w = new WOWDataContext())
            {
                var o=w.Answer.Where(c => c.ID == id).FirstOrDefault();
                o.Status = s;
                w.SubmitChanges();
                return this.RedirectToReferrer() ;
            }
        }
        #endregion
#region    pay
        public ActionResult QuestionTask(long id)
        {
            using (var w = new WOWDataContext())
            {
               // var o = w.Question.Where(c => c.ID == id).FirstOrDefault();
               // o.Status = 2;
               // var m = o.GB;
               // var n = o.Worker.Count-initGB;
               // foreach (var w1 in o.Worker)
               // {
               ////     w1.CurrentUser.GB += o.GB / n;
               //   //  w1.CurrentUser.WorkerGB += o.GB / n;
               ////   w1.Status = 2;
               // }
               // w.SubmitChanges();
                return this.RedirectToAction("index");
            }
        }
#endregion
    }
}
