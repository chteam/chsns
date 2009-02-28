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
                if (u == null) return View("join"); //参加应用
                if (u.Character.Count == 0) return View("EditRole");//没创建角色
                if (u.Character1 == null) return View("SetRole", u.Character);//没设置当前角色
                //可以使用了
                Title = "G团招募";
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
                    //参加应用
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
                Title = "新建游戏角色";
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
                Title = "设置用户角色";
                return View(u.Character.ToList());
            }

        }
        #endregion

        #region task
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddTask()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTask(Task t)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == CHUser.UserID).FirstOrDefault();
                u.GB -= (initGB + t.GB);
                t.AddTime = DateTime.Now;
                t.CreateUserID = CHUser.UserID;
                t.Status = 0;//招中
                w.Task.InsertOnSubmit(t);
                w.SubmitChanges();
                Title = "新建计划";
                return RedirectToAction("TaskList");
            }
        }
        public ActionResult TaskList(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Task.Where(c => c.CreateUserID == CHUser.UserID).ToList());
            }
        }
        public ActionResult TaskDetails(long id)
        {
            using (var w = new WOWDataContext())
            {
                var t = w.Task.Where(c => c.ID == id).FirstOrDefault();
                ViewData["wid"] = new SelectList(w.Worker.Where(c => c.Status == 0 && c.UID == CHUser.UserID).ToList(),"ID","Description");
                return View(t);
            }
        }
        public ActionResult JoinTask(long wid, long tid)
        {
            using (var w = new WOWDataContext())
            {
                var t = w.Worker.Where(c => c.ID == wid).FirstOrDefault();
                if (t != null) { t.TaskID = tid;
                t.Status = 1;
                }
                w.SubmitChanges();
                return RedirectToAction("index");
            }
        }
        #endregion
        #region work
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddWork(long? taskid)
        {
            ViewData["t.TaskID"] = taskid;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddWork(Worker t)
        {
            using (var w = new WOWDataContext())
            {
                var u = w.CurrentUser.Where(c => c.UID == CHUser.UserID).FirstOrDefault();
                u.GB -= initGB;

                t.AddTime = DateTime.Now;
                t.UID = CHUser.UserID;
                t.Status = 0;//招中



                w.Worker.InsertOnSubmit(t);
                w.SubmitChanges();

                return RedirectToAction("WorkList");
            }
        }
        public ActionResult WorkList(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Worker.Where(c => c.UID == CHUser.UserID).ToList());
            }
        }
        public ActionResult  WorkDetails(long id){
            using (var w = new WOWDataContext())
            {
                return View(w.Worker.Where(c => c.ID==id).FirstOrDefault());
            }
        }
        #endregion

        #region 两大区
        public ActionResult Work(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Worker.Where(c => c.Status == 0));
            }
        }
        public ActionResult Task(int? p)
        {
            using (var w = new WOWDataContext())
            {
                return View(w.Task.Where(c => c.Status == 0).ToList());
            }
        }

        public ActionResult SetWorkStatus(long id, int s) {
            using (var w = new WOWDataContext())
            {
                var o=w.Worker.Where(c => c.ID == id).FirstOrDefault();
                o.Status = s;
                w.SubmitChanges();
                return this.RedirectToReferrer() ;
            }
        }
        #endregion
#region    pay
        public ActionResult PayTask(long id){
            using (var w = new WOWDataContext())
            {
                var o = w.Task.Where(c => c.ID == id).FirstOrDefault();
                o.Status = 2;
                var m = o.GB;
                var n = o.Worker.Count-initGB;
                foreach (var w1 in o.Worker)
                {
                    w1.CurrentUser.GB += o.GB / n;
                    w1.CurrentUser.WorkerGB += o.GB / n;
                    w1.Status = 2;
                }
                w.SubmitChanges();
                return this.RedirectToAction("index");
            }
        }
#endregion
    }
}
