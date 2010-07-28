namespace CHSNS.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using CHSNS.Model;
    using CHSNS.Models;
    using CHSNS.ViewModel;

    public partial class EntryController : BaseController
    {
        #region 前台部分
        /// <summary>
        /// 显示当前词条
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index(string url)
        {
          //  var model = new EntryIndexViewModel();
            Title = "页面不存在";
            if (string.IsNullOrEmpty(url)) return Wait();
            var t = DataManager.Entry.Get(url);
            ViewModel.Entry = t.Key;
            if (ViewModel.Entry == null) return Wait();
            var version = t.Value;
            if (version == null) return Wait();
            ViewModel.Version = version;
            ViewModel.Ext = JsonAdapter.Deserialize<EntryExt>(version.Ext);
            Title = ViewModel.Entry.Url;
            return View();
        }

        [NonAction]
        public ActionResult Wait() {
            return View(Views.Wait, "site");
        }

        /// <summary>
        /// 历史词条
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult HistoryList(long id)
        {
            ViewModel.Source = DataManager.Entry.Historys(id);
            Title = "版本比较";
            return View();
        }

        public virtual ActionResult History(long versionId)
        {
            var t = DataManager.Entry.GetFromVersion(versionId);
            if (t.Key == null || t.Value == null) return View("wait", "site");
            var entry = t.Key;
            var version = t.Value;
            ViewData["version"] = version;
            ViewData["entry"] = entry;
            ViewData["ext"] = JsonAdapter.Deserialize<EntryExt>(version.Ext);
            Title = entry.Url;
            return View();
        }

        
        #endregion

        #region 管理员后台
        /// <summary>
        /// 编辑与创建词条
        /// </summary>
        /// <param name="title"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AdminFilter]
        public virtual ActionResult Edit(string title, long? id)
        {
            if (!string.IsNullOrEmpty(title)&&title.Contains("%"))
                    title = Server.UrlDecode(title);
    
            if (id != null) {
                //修改
                var d = DataManager.Entry.Get(id.Value);
                var entry = d.Key;
                if ((entry.Status == (int)EntryType.Common || HasManageRight())) {
                    ViewData["exists"] = true;
                    ViewData["entry"] = entry;
                    ViewData["id"] = entry.Id;
                    var entryversion = d.Value;
                    if (entryversion == null) return View("Wait");
                    ViewData["entryversion"] = entryversion;//.Url;
                    var ee = JsonAdapter.Deserialize<EntryExt>(entryversion.Ext)??new EntryExt();
                    ViewData["tags"] = string.Join(",", ee.Tags.ToNotNull().ToArray());
                    Title = "编辑词条:" + entry.Url;
                }
                else 
                    return View(Views.Wait);
            }
            else
            {
                if (!string.IsNullOrEmpty(title))
                    ViewData["entryversion.title"] = title;
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
        [HttpPost]
        [AdminFilter]
        [ValidateInput(false)]
        public virtual ActionResult Edit(long? id, Entry entry, EntryVersion entryversion, string tags)
        {
            var b = DataManager.Entry.AddVersion(id, entry, entryversion, tags, CHUser);
            if (!b) throw new ApplicationException("标题已存在");
            return RedirectToAction("NewList");
        }
        [AdminFilter]
        public virtual ActionResult AdminHistoryList(string url)
        {
            url = url.Trim();
            ViewData["Source"] = DataManager.Entry.Historys(url);
            Title = "历史版本";
            return View();
        }

        /// <summary>
        /// 新建词条列表
        /// </summary>
        /// <returns></returns>
        [AdminFilter]
        public virtual ActionResult NewList()
        {
            var li = DataManager.Entry.List(1, 10);
            Title = "词条列表";
            return View(li);
        }

        /// <summary>
        /// 编辑词条列表
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult EditList()
        {
            return View();
        }
        /// <summary>
        /// 通过审核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AdminFilter]
        public virtual ActionResult Pass(long id)
        {
            /*
             * 1.设置当前版本为最新版本词条
             * 2.将当前版本状态改为常规状态
             */
            DataManager.Entry.PassWaitVersion(id);
            return this.RedirectToReferrer();
        }
        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AdminFilter]
        public virtual ActionResult Lock(long id)
        {
            /*
             * 锁定当前版本
             */
            DataManager.Entry.LockCommonVersion(id);
            return this.RedirectToReferrer();
        }
        /// <summary>
        /// 通过版本id.删除词条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AdminFilter]
        public virtual ActionResult Delete(long id)
        {
            DataManager.Entry.DeleteByVersionId(id, CHUser.UserId);
            return this.RedirectToReferrer();
        }
        [AdminFilter]
        public virtual ActionResult DeleteVersion(long id)
        {
            DataManager.Entry.DeleteVersion(id, CHUser.UserId);
            return this.RedirectToReferrer();
        }
        #endregion
         
        #region Ajax
        public virtual ActionResult Has(string title)
        {
            var exists = DataManager.Entry.HasTitle(title);
            return Json(exists); 
        }

        #endregion
    }
}
