using System;
using System.Web.Mvc;

using CHSNS.Model;
using CHSNS.Abstractions;
using CHSNS.ViewModel;

namespace CHSNS.Controllers
{
    public class EntryController : BaseController
    {
        #region 前台部分
        /// <summary>
        /// 显示当前词条
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string title){
            var model = new EntryIndexViewModel();
            Title = "页面不存在";
            if (string.IsNullOrEmpty(title)) return Wait();
            model.Entry = DbExt.Entry.Get(title);
            if (model.Entry == null || !model.Entry.CurrentId.HasValue) return Wait();
            var version = DbExt.Entry.GetVersion(model.Entry.CurrentId.Value);
            if (version == null) return Wait();
            model.Version = version;
            model.Ext = JsonAdapter.Deserialize<EntryExt>(version.Ext);
            Title = model.Entry.Title;
            return View(model);
           
        }

        [NonAction]
        public ActionResult Wait() {
            return View("wait", "site"); }

        /// <summary>
        /// 历史词条
        /// </summary>
        /// <returns></returns>
		public ActionResult HistoryList(long id)
        {
        	// var arealist = AreaList.Load(AreaType.EntryArea).ToDictionary();
            ViewData["Source"] = DbExt.Entry.Historys(id);
        	Title = "版本比较";
        	return View();
        }

        public ActionResult History(long id)
        {

            var version = DbExt.Entry.GetVersion(id);
            ViewData["version"] = version;
            if (version == null) return View("wait", "site");
            var entry = DbExt.Entry.Get(version.EntryId.Value);
            ViewData["entry"] = entry;

            if (ViewData["entry"] == null || ViewData["version"] == null)
                return View("wait", "site");
            ViewData["ext"] = JsonAdapter.Deserialize<EntryExt>(version.Ext);
            Title = entry.Title;
            return View();

        }

        /// <summary>
        /// 搜索词条
        /// </summary>
        /// <returns></returns>
        //public ActionResult List(string wd) {
        //    if (!string.IsNullOrEmpty(wd))
        //        wd = wd.Trim();
        //    ViewData["wd"] = wd;
        //    Title = "搜索词条 -" + wd;
        //    using (var db = DBExt.Instance) {
        //        var ret = (from e in db.Entry
        //                   join v in db.EntryVersion on e.CurrentID equals v.ID
        //                   where e.Status == (int)EntryType.Common && v.Status == (int)EntryVersionType.Common
        //                   && (string.IsNullOrEmpty(wd) || e.Title.Contains(wd))
        //                   select new EntryPas {
        //                       ID = e.ID,
        //                       AddTime = v.AddTime,
        //                       Reason = v.Description,
        //                       Title = e.Title,
        //                   });

        //        var li = new PagedList<EntryPas>(ret, 1, 10);
        //        return View(li);
        //    }
        //}

        #endregion
        #region 管理员后台
        /// <summary>
        /// 编辑与创建词条
        /// </summary>
        /// <param name="title"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
		[AdminFilter]
        
        public ActionResult Edit(string title, long? id)
        {
            if (!string.IsNullOrEmpty(title))
                if (title.Contains("%"))
                    title = Server.UrlDecode(title);
     
            IEntry data = null;
            if (!string.IsNullOrEmpty(title))
                data = DbExt.Entry.Get(title);
            else if (id.HasValue)
                data = DbExt.Entry.Get(id.Value);


            if (data != null) {
                //修改
                var entry = data;
                if ((entry.Status == (int)EntryType.Common || HasManageRight())) {
                    ViewData["exists"] = true;
                    ViewData["entry.Title"] = entry.Title;
                    ViewData["id"] = entry.Id;

                    var entryversion = DbExt.Entry.GetVersion(entry.CurrentId ?? 0);
                    //db.EntryVersion.Where(c => c.ID == entry.CurrentID).FirstOrDefault();
                    if (entryversion == null) return View("Wait");
                    ViewData["entryversion.description"] = entryversion.Description;
                    var ee = JsonAdapter.Deserialize<EntryExt>(entryversion.Ext);
                    ViewData["tags"] = string.Join(",", ee.Tags.ToArray());
                    ViewData["entryversion.reference"] = entryversion.Reference;

                    Title = "编辑词条:" + entry.Title;
                }
                else {
                    return View("Wait");
                }
            }
            else
            {
//新建
                if (!string.IsNullOrEmpty(title))
                    ViewData["entry.title"] = title;
                ViewData["entryversion.reason"] = "创建词条";
                Title = "创建词条";
            }
            return View();
        }

        /// <summary>
        /// 编辑与创建词条
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entry"></param>
        /// <param name="entryversion"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
		[AdminFilter]
        [ValidateInput(false)]
        public ActionResult Edit(long? id, EntryImplement entry, EntryVersionImplement entryversion, string tags)
        {
            var b = DbExt.Entry.AddVersion(id, entry, entryversion, tags, CHUser);
            if (!b) throw new Exception("标题已存在");
            return RedirectToAction("NewList");
        }
		[AdminFilter]
        public ActionResult AdminHistoryList(string title) {
            title = title.Trim();
		    ViewData["Source"] = DbExt.Entry.Historys(title);
		    Title = "历史版本";
            return View();
        }

        /// <summary>
        /// 新建词条列表
        /// </summary>
        /// <returns></returns>
        [AdminFilter]
        public ActionResult NewList()
        {
            var li = DbExt.Entry.List(1, 10);
            Title = "词条列表";
            return View(li);
        }

        /// <summary>
        /// 编辑词条列表
        /// </summary>
        /// <returns></returns>
        public ActionResult EditList()
        {
            return View();
        }
        /// <summary>
        /// 通过审核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[AdminFilter]
        public ActionResult Pass(long id)
        {
            /*
             * 1.设置当前版本为最新版本词条
             * 2.将当前版本状态改为常规状态
             */
            DbExt.Entry.PassWaitVersion(id);
            return this.RedirectToReferrer();
        }
        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[AdminFilter]
        public ActionResult Lock(long id)
        {
            /*
             * 锁定当前版本
             */
            DbExt.Entry.LockCommonVersion(id);
            return this.RedirectToReferrer();
        }
        /// <summary>
        /// 通过版本id.删除词条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AdminFilter]
        public ActionResult Delete(long id) {
            DbExt.Entry.DeleteByVersionId(id, CHUser.UserID);
            return this.RedirectToReferrer();
        }

        #endregion
         
        #region Ajax
        public ActionResult Has(string title) {
            var exists = DbExt.Entry.HasTitle(title);
            return Json(exists); 
        }

        #endregion

        #region noaction
        public bool HasManageRight()
        {
            return CHUser.Status.Contains(RoleType.Editor, RoleType.Creater);
        }
        #endregion
    }
}
