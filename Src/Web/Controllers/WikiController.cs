namespace CHSNS.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Web.Mvc;
    using CHSNS.Common.Serializer;
    using CHSNS.Controllers;
    using CHSNS.Model;
    using CHSNS.Models;
    using CHSNS.Service;

    public class WikiController : BaseController
    {
        [Import]
        public EntryService Entry { get; set; }

        #region 前台部分

        /// <summary>
        /// 显示当前词条
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index(string url)
        {
            Title = "页面不存在";
            if (string.IsNullOrEmpty(url)) return Wait();
            KeyValuePair<Wiki, WikiVersion> t = Entry.Get(url);
            ViewBag.Entry = t.Key;
            if (ViewBag.Entry == null) return Wait();
            WikiVersion version = t.Value;
            if (version == null) return Wait();
            ViewBag.Version = version;
            ViewBag.Ext = JsonAdapter.Deserialize<EntryExt>(version.Ext);
            Title = t.Value.Title;
            return View();
        }

        [NonAction]
        public ActionResult Wait()
        {
            return View(null, "site");
        }

        /// <summary>
        /// 历史词条
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult HistoryList(long id)
        {
            ViewBag.Source = Entry.Historys(id);
            Title = "版本比较";
            return View();
        }

        public virtual ActionResult History(long versionId)
        {
            KeyValuePair<Wiki, WikiVersion> t = Entry.GetFromVersion(versionId);
            if (t.Key == null || t.Value == null) return View("wait", "site");
            Wiki entry = t.Key;
            WikiVersion version = t.Value;
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AdminFilter]
        public virtual ActionResult Edit(long? id)
        {
            if (id != null)
            {
                //修改
                Tuple<Wiki, WikiVersion> d = Entry.Get(id.Value);
                Wiki entry = d.Item1;
                if ((entry.Status == (int) EntryType.Common || HasManageRight() ||
                     new[] {0, WebUser.UserId}.Contains(entry.CreaterId)))
                {
                    ViewData["exists"] = true;
                    ViewData["entry"] = entry;
                    ViewData["id"] = entry.Id;
                    WikiVersion ev = d.Item2;
                    if (ev == null) ev = new WikiVersion();
                    ViewData["entryversion"] = ev; //.Url;
                    EntryExt ee = JsonAdapter.Deserialize<EntryExt>(ev.Ext) ?? new EntryExt();
                    ViewData["tags"] = string.Join(",", ee.Tags.ToNotNull().ToArray());
                    Title = "编辑词条:" + entry.Url;
                }
                else
                    return View("Wait");
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["url"]))
                    ViewData["entry.Url"] = Request.QueryString["url"];
                ViewData["entryversion.reason"] = "创建词条";
                Title = "创建词条";
            }
            return View();
        }

        /// <summary>
        /// 编辑与创建词条
        /// </summary>
        /// <param name="id"></param>
        /// <param name="wiki"></param>
        /// <param name="entryversion"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        [HttpPost]
        [AdminFilter]
        [ValidateInput(false)]
        public virtual ActionResult Edit(long? id, Wiki wiki, WikiVersion entryversion, string tags, bool isNew)
        {
            bool b = Entry.AddVersion(id, wiki, entryversion, tags, WebUser, isNew);
            if (!b) throw new ApplicationException("标题已存在");
            return RedirectToAction("Index", "Entry", new {url = wiki.Url});
        }

        [AdminFilter]
        public virtual ActionResult AdminHistoryList(string url)
        {
            url = url.Trim();
            ViewData["Source"] = Entry.Historys(url);
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
            PagedList<EntryPas> li = Entry.List(1, 10);
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
            Entry.PassWaitVersion(id);
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
            Entry.LockCommonVersion(id);
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
            Entry.DeleteByVersionId(id, WebUser.UserId);
            return this.RedirectToReferrer();
        }

        [AdminFilter]
        public virtual ActionResult DeleteVersion(long id)
        {
            Entry.DeleteVersion(id, WebUser.UserId);
            return this.RedirectToReferrer();
        }

        #endregion

        #region Ajax

        public virtual ActionResult Has(string title)
        {
            bool exists = Entry.HasTitle(title);
            return Json(exists);
        }

        #endregion
    }
}