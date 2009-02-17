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
                if (u == null) return View("join"); //参加应用
                if (u.Character.Count == 0) return View("EditRole");//没创建角色
                if (u.Character1 == null) return View("SetRole", u.Character);//没设置当前角色
                //可以使用了
                return View(u);
            }

        }
        #region Role

        
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
            return RedirectToAction("index");
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
                return View(u.Character.ToList());
            }

        }
        #endregion

        #region task
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddTask() {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTask(Task t)
        {
            using (var w = new WOWDataContext())
            {
                t.AddTime = DateTime.Now;
                t.CreateUserID = CHUser.UserID;
                t.Status = 0;//招中
                w.Task.InsertOnSubmit(t);
                w.SubmitChanges();
                return RedirectToAction("TaskList");
            }
        }
        public ActionResult TaskList(int? p) {
            using (var w = new WOWDataContext())
            {
                return View(w.Task.Where(c => c.CreateUserID == CHUser.UserID).ToList());
            }
        }
        #endregion
        #region work
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddWork(long ? taskid)
        {
            ViewData["t.TaskID"] = taskid;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddWork(Worker t)
        {
            using (var w = new WOWDataContext())
            {
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
        #endregion
    }
}
