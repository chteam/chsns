using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using CHSNS.ModelPas;
using CHSNS.Models;
using Newtonsoft.Json;
using CHSNS;
namespace CHSNS.Controllers
{
    public class EntryController : BaseController
    {
        #region 前台部分
        /// <summary>
        /// 显示当前词条
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string title)
        {
            if (string.IsNullOrEmpty(title))
                return View("wait", "site");
            var entry = DBExt.DB.Entry.Where(c => c.Title == title).FirstOrDefault();
			if (entry != null) {
				ViewData["entry"] = entry;
				var version = DBExt.DB.EntryVersion.Where(c => c.ID == entry.CurrentID).FirstOrDefault();
				Title = entry.Title;
				if (version != null) {
					ViewData["version"] = version;
					if (ViewData["entry"] == null || ViewData["version"] == null)
						return View("wait", "site");
					ViewData["ext"] = JavaScriptConvert.DeserializeObject<EntryExt>(version.Ext);
				}
			} else {
				Title = "当前词条不存在";
			}
        	return View();
        }
        /// <summary>
        /// 历史词条
        /// </summary>
        /// <returns></returns>
		public ActionResult HistoryList(long id)
        {
        	// var arealist = AreaList.Load(AreaType.EntryArea).ToDictionary();
        	var ret = (DBExt.DB.EntryVersion.Join(DBExt.DB.Entry, v => v.EntryID, e => e.ID, (v, e) => new {v, e}).Join(
        		DBExt.DB.Profile, @t => @t.v.UserID, p => p.UserID, (@t, p) => new {@t, p}).Where(@t => @t.@t.e.ID == id)
        		.OrderByDescending(@t => @t.@t.v.ID).Select(@t => new EntryPas
        		                                                  	{
        		                                                  		ID = @t.@t.v.ID,
        		                                                  		AddTime = @t.@t.v.AddTime,

        		                                                  		Reason = @t.@t.v.Reason,
        		                                                  		Title = @t.@t.e.Title,
        		                                                  		EditCount = @t.@t.e.EditCount,
        		                                                  		User =
        		                                                  			new NameIDPas {Name = @t.p.Name, ID = @t.p.UserID},
        		                                                  	}));

        	ViewData["Source"] = ret;
        	Title = "版本比较";
        	return View();
        }

    	public ActionResult History(long id )
        {
            var version = DBExt.DB.EntryVersion.Where(c => c.ID == id).FirstOrDefault();
            ViewData["version"] = version;

            var entry = DBExt.DB.Entry.Where(c => c.ID == version.EntryID).FirstOrDefault();
            ViewData["entry"] = entry;
        
            if (ViewData["entry"] == null || ViewData["version"] == null)
                return View("wait", "site");
            ViewData["ext"] = JavaScriptConvert.DeserializeObject<EntryExt>(version.Ext);
            Title = entry.Title;
            return View();
        }
        /// <summary>
        /// 搜索词条
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string wd)
        {
            if (!string.IsNullOrEmpty(wd))
            wd = wd.Trim();
            ViewData["wd"] = wd;

            var ret = (from e in DBExt.DB.Entry
                       join v in DBExt.DB.EntryVersion on e.CurrentID equals v.ID
                       where e.Status == (int) EntryType.Common && v.Status == (int) EntryVersionType.Common
                       && (string.IsNullOrEmpty(wd) || e.Title.Contains(wd))
                       select new EntryPas
                                  {
                                      ID=e.ID,
                                      AddTime = v.AddTime,
                                      Reason = v.Description,
                                      Title = e.Title,
                                  });
            Title = "景点搜索 -" + wd;
            var li = new PagedList<EntryPas>(ret, 1, 10);
            return View(li);
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
            if (!string.IsNullOrEmpty(title))
                if (title.Contains("%"))
                    title = Server.UrlDecode(title);
          
            bool exists;
            IQueryable<Entry> data = null;
            if (!string.IsNullOrEmpty(title))
            {
                data = DBExt.DB.Entry.Where(c => c.Title == title);
                exists = data.Count() != 0;
            }
            else
            {
                if (id.HasValue)
                {
                    data = DBExt.DB.Entry.Where(c => c.ID == id.Value);
                    exists = data.Count() != 0;
                }
                else
                {
                    exists = false;
                }
            }

            if (exists)
            {
//修改
                var entry = data.FirstOrDefault();
				if ((entry.Status == (int)EntryType.Common || HasManageRight()))
				{
					ViewData["exists"] = exists;
					ViewData["entry.Title"] = entry.Title;
					ViewData["id"] = entry.ID;
					var entryversion =
						DBExt.DB.EntryVersion.Where(c => c.ID == entry.CurrentID).FirstOrDefault();
					if (entryversion == null) return View("Wait");
					ViewData["entryversion.description"] = entryversion.Description;
					var ee = JavaScriptConvert.DeserializeObject<EntryExt>(entryversion.Ext);
					ViewData["tags"] = string.Join(",", ee.Tags.ToArray());
					ViewData["entryversion.reference"] = entryversion.Reference;
					Title = "编辑词条:" + entry.Title;

				}
				else {
					return View("Wait");
				}
            }
            else
            {//新建
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
        public ActionResult Edit(long? id,Entry entry,EntryVersion entryversion,string  tags)
        {
            var dt = DateTime.Now;
            if (id.HasValue)
            {
                entry = DBExt.DB.Entry.Where(c => c.ID == id.Value).FirstOrDefault();
                entry.UpdateTime = dt;
                entry.EditCount += 1;
                
            }else
            {
                var old = DBExt.DB.Entry.Where(c => c.Title == entry.Title.Trim()).Count();
                if (old > 0) throw new Exception("标题已存在");
                entry.Status = (int) EntryType.Common;
                entry.CreaterID = CHUser.UserID;
                entry.UpdateTime = dt;
                entry.EditCount = 1;

                DBExt.DB.AddToEntry(entry);
                DBExt.DB.SaveChanges();
            }
            entryversion.UserID = CHUser.UserID;
            entryversion.Status = (int)(CHUser.IsAdmin ? EntryType.Common : EntryType.Wait);
            entryversion.EntryID = entry.ID;
            entryversion.AddTime = dt;
            entryversion.Reference += "";
            entryversion.Ext = JavaScriptConvert.SerializeObject(new EntryExt { Tags = tags.Split(',').ToList() });
            
            DBExt.DB.AddToEntryVersion(entryversion);
            DBExt.DB.SaveChanges();
            entry.CurrentID = entryversion.ID;
            DBExt.DB.SaveChanges();
            return RedirectToAction("NewList");
        }
		[AdminFilter]
        public ActionResult AdminHistoryList(string title) {
            title = title.Trim();
           
            var ret = (DBExt.DB.EntryVersion.Join(DBExt.DB.Entry, v => v.EntryID, e => e.ID, (v, e) => new { v, e }).Join(
                DBExt.DB.Profile, @t => @t.v.UserID, p => p.UserID, (@t, p) => new { @t, p }).Where(@t => @t.@t.e.Title == title)
                .OrderByDescending(@t => @t.@t.v.ID).Select(@t => new EntryPas
                {
                    ID = @t.@t.v.ID,
                    AddTime = @t.@t.v.AddTime,
                    Reason = @t.@t.v.Reason,
                    Title = @t.@t.e.Title,
                    EditCount = @t.@t.e.EditCount,
                    User =
                        new NameIDPas { Name = @t.p.Name, ID = @t.p.UserID },
                    Status = (@t.t.v.Status)
                }));

            ViewData["Source"] = ret;
            Title = "历史版本";
            return View();
        }

        /// <summary>
        /// 新建景点列表
        /// </summary>
        /// <returns></returns>
		[AdminFilter]
        public ActionResult NewList()
        {       
            var newlist = (from e in DBExt.DB.EntryVersion
                           join v in DBExt.DB.Entry on e.EntryID equals v.ID
                           join p in DBExt.DB.Profile on e.UserID equals p.UserID
                           orderby e.ID descending 
                           select new EntryPas
                                      {
                                          ID = e.ID,
                                          AddTime = e.AddTime,
                                          EditCount = v.EditCount,
                                          Reason = e.Reason,
                                          Title = v.Title,
                                          User = new NameIDPas {Name = p.Name, ID = p.UserID},
                                          ViewCount = v.ViewCount,
                                          Status = e.Status
                                      });
            IQueryable<EntryPas> li1 = newlist;
            // li1 = li1.Where(c => c.User.ID == CHUser.UserID);
            //AreaList.Load(AreaType.EntryArea).Where(
//   c => c.ID == e.AreaID).FirstOrDefault().Name
			Title = "词条列表";
            var li = new PagedList<EntryPas>(li1, 1, 10);
            return View(li);
        }
        /// <summary>
        /// 编辑景点列表
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
            var ev = DBExt.DB.EntryVersion.Where(c => c.ID == id).FirstOrDefault();
            ev.Status = (int)EntryVersionType.Common;
            var e = DBExt.DB.Entry.Where(c => c.ID == ev.EntryID).SingleOrDefault();
            e.CurrentID = ev.ID;
			DBExt.DB.SaveChanges();
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
            var ev = DBExt.DB.EntryVersion.Where(c => c.ID == id).FirstOrDefault();
            ev.Status = (int)EntryVersionType.Lock;
			DBExt.DB.SaveChanges();
            return this.RedirectToReferrer();
        }
        /// <summary>
        /// 通过版本id.删除词条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AdminFilter]
        public ActionResult Delete(long id)
        {
            var v = DBExt.DB.EntryVersion.Where(c => c.ID == id).FirstOrDefault();
            Validate404(v);
            var e = DBExt.DB.Entry.Where(c => c.ID == v.EntryID).FirstOrDefault();
            Validate404(e);
            var vs = DBExt.DB.EntryVersion.Where(c => c.EntryID == e.ID);
			if (e.CreaterID != CHUser.UserID) Validate404(null);

            DBExt.DB.EntryVersion.DeleteAllOnSubmit(vs);
            DBExt.DB.Entry.DeleteOnSubmit(e);
            DBExt.DB.SaveChanges();
            return this.RedirectToReferrer();
        }

        #endregion

        #region Ajax
        public ActionResult Has(string title)
        {
            var exists = DBExt.DB.Entry.Where(c => c.Title == title).Count() != 0;
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
