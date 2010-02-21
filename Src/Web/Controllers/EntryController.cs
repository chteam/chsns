using System;
using System.Web.Mvc;

using CHSNS.Model;

using CHSNS.ViewModel;
using CHSNS.Operator;
using CHSNS.SQLServerImplement;
using CHSNS.Models;

namespace CHSNS.Controllers
{
    public class EntryController : NewBaseController
    {
        private readonly EntryOperator EntryDb = new EntryOperator();
        #region 前台部分
        /// <summary>
        /// 显示当前词条
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string url)
        {
            var model = new EntryIndexViewModel();
            Title = "页面不存在";
            if (string.IsNullOrEmpty(url)) return Wait();
            var t = EntryDb.Get(url);
            model.Entry = t.Key;
            if (model.Entry == null) return Wait();
            var version = t.Value;
            if (version == null) return Wait();
            model.Version = version;
            model.Ext = JsonAdapter.Deserialize<EntryExt>(version.Ext);
            Title = model.Entry.Url;
            return View(model);
        }

        [NonAction]
        public ActionResult Wait() {
            return View("wait", "site"); 
        }

        /// <summary>
        /// 历史词条
        /// </summary>
        /// <returns></returns>
		public ActionResult HistoryList(long id)
        {
        	// var arealist = AreaList.Load(AreaType.EntryArea).ToDictionary();
            ViewData["Source"] = EntryDb.Historys(id);
        	Title = "版本比较";
        	return View();
        }

        public ActionResult History(long versionId)
        {
            var t = EntryDb.GetFromVersion(versionId);
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
        [AcceptVerbs(HttpVerbs.Get)]
		[AdminFilter]
        
        public ActionResult Edit(string title, long? id)
        {
            if (!string.IsNullOrEmpty(title)&&title.Contains("%"))
                    title = Server.UrlDecode(title);
    
            if (id != null) {
                //修改
                var d = EntryDb.Get(id.Value);
                var entry = d.Key;
                if ((entry.Status == (int)EntryType.Common || HasManageRight())) {
                    ViewData["exists"] = true;
                    ViewData["entry"] = entry;
                    ViewData["id"] = entry.Id;
                    var entryversion = d.Value;
                    if (entryversion == null) return View("Wait");
                    ViewData["entryversion"] = entryversion;//.Url;
                    var ee = JsonAdapter.Deserialize<EntryExt>(entryversion.Ext);
                    ViewData["tags"] = string.Join(",", ee.Tags.ToArray());
                    Title = "编辑词条:" + entry.Url;
                }
                else 
                    return View("Wait");
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
        [AcceptVerbs(HttpVerbs.Post)]
		[AdminFilter]
        [ValidateInput(false)]
        public ActionResult Edit(long? id, Entry entry, EntryVersion entryversion, string tags)
        {
            var b = EntryDb.AddVersion(id, entry, entryversion, tags, CHUser);
            if (!b) throw new Exception("标题已存在");
            return RedirectToAction("NewList");
        }
		[AdminFilter]
        public ActionResult AdminHistoryList(string url) {
            url = url.Trim();
		    ViewData["Source"] = EntryDb.Historys(url);
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
            var li = EntryDb.List(1, 10);
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
            EntryDb.PassWaitVersion(id);
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
            EntryDb.LockCommonVersion(id);
            return this.RedirectToReferrer();
        }
        /// <summary>
        /// 通过版本id.删除词条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AdminFilter]
        public ActionResult Delete(long id) {
            EntryDb.DeleteByVersionId(id, CHUser.UserId);
            return this.RedirectToReferrer();
        }

        #endregion
         
        #region Ajax
        public ActionResult Has(string title) {
            var exists = EntryDb.HasTitle(title);
            return Json(exists); 
        }

        #endregion
    }
}
