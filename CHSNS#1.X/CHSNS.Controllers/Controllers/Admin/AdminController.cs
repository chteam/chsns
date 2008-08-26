
using System;
using System.Collections;
using System.Linq;
using CHSNS.Config;
using CHSNS.Models;
using System.Web.Mvc;
using CHSNS.Pagination;
using System.Collections.Generic;
	
namespace CHSNS.Controllers {
	
	public partial class AdminController :BaseAdminController {
		/// <summary>
		/// 管理主页，清理缓存
		/// </summary>
		public void index() {
			//AreaName = null;
			//LayoutName = null;
		}
		 
		#region 配置

		public void basic() {
			//Chsword.DoDataBase ddb = new Chsword.DoDataBase();
			ViewData.Add("onlinecount", CHSNS.Online.OnlineList.Count);
			ViewData.Add("cachecount", ChCache.Cache.Count);

			ViewData.Add("regcount", DataBaseExecutor.ExecuteScalar("select count(1) from account"));
			ViewData.Add("version", ChAlumnaConfig.Version);
			ViewData["appname"] = ChAlumnaConfig.AppName;
			ViewData["programmer"] = ChAlumnaConfig.Programmer;
			ViewData.Add("serverstart", SiteConfig.SystemUptime);
			View();
		}

		/// <summary>
		/// 清理缓存
		/// </summary>
		[PostOnlyFilter]
		public void clearcache() {
			ChCache.RemoveAll();
			TempData.Add("msg", "缓存更新成功");
			this.RedirectToReferrer();
			//this.RedirectToAction("index");
		}
		/// <summary>
		/// 重启服务器
		/// </summary>
		[PostOnlyFilter]
		public void restart() {
			//Log.LogEntry("Executing WebApp shutdown", EntryType.General, "SYSTEM");
			System.Web.HttpRuntime.UnloadAppDomain();
			Global g = new Global();
			g.Application_Start(1, EventArgs.Empty);
			TempData.Add("msg", "服务器重启成功");
			this.RedirectToReferrer();
		}
#endregion

		#region 磁盘管理
		public void space() {
			if (IsPost) {
				TempData.Add("ispost", true);
				ViewData.Add("diskall", Regular.BytesToString(Regular.DiskUsage(ChServer.MapPath("~/"))));
				ViewData.Add("viewpage", Regular.BytesToString(Regular.DiskUsage(ChServer.MapPath("~/views/"))));
				ViewData.Add("debuglog", Regular.BytesToString(Regular.DiskUsage(ChServer.MapPath("~/Debug/"))));
				ViewData.Add("userFiles", Regular.BytesToString(Regular.DiskUsage(ChServer.MapPath("~/userFiles/"))));
				ViewData.Add("groupFiles", Regular.BytesToString(Regular.DiskUsage(ChServer.MapPath("~/groupFiles/"))));
			}
		}
		#endregion
		#region 用户管理
		public void user() {
			Chsword.DoDataBase ddb = new Chsword.DoDataBase();
			ViewData.Add("unstarcount", ddb.getTableValue_SqlText("select count(1) from [profile] where [isstar]=1 and isupdate=0"));
			ViewData.Add("today", ddb.getTableValue_SqlText("select count(1) from account where datediff(d,regtime,getdate())<1"));
			ViewData.Add("allcount", ddb.getTableValue_SqlText("select count(1) from account"));
			ViewData.Add("field", ddb.getTableValue_SqlText("select count(1) from account where [status]>7"));
			ViewData.Add("star", ddb.getTableValue_SqlText("select count(1) from [profile] where isstar=1"));
			ViewData.Add("admincount", ddb.getTableValue_SqlText("select count(1) from account where [status]>199"));

			ViewData.Add("newreg", ddb.getTableValue_SqlText("select count(1) from [account] where [status]=1"));
            //ddb.
		}
		/// <summary>
		/// 实名未审用户
		/// </summary>
		public void isstar() {
			ViewData["users"] = (from p in this.DB.Profile
									where p.IsStar == true && p.IsUpdate == false
									join a in DB.Account on p.UserId equals a.UserID
									join s in DB.FieldInformation on p.UserId equals s.UserID
									select new
									{
										userid = a.UserID,
										name = a.Name,
										Field = s.Field,
										s.MiniField,
										s.Year
									}).ToList();

			//from Profile_AS pas where pas.IsStar = 1 and pas.IsUpdate=0 
			//	Profile_AS.FindByNoStar();
		}
        [PostOnlyFilter]
        public ActionResult SetStar(long userid, bool ispass) {

			CHSNS.Admin admin = new CHSNS.Admin();
			if (ispass) {
				admin.setStar(userid.ToString(), true);
				TempData["msg"] = userid.ToString() + "设置成功";
			} else {
				admin.setStar(userid.ToString(), false);
				TempData["msg"] = userid.ToString() + "设置成功";
			}
            return this.RedirectToReferrer();
        }
		#endregion
        #region 群
        public void group() {
            Chsword.DoDataBase ddb = new Chsword.DoDataBase();
            ViewData.Add("classcount", ddb.getTableValue_SqlText("select count(1) from [group] where [istrue]=0 and groupclass=1"));
            ViewData.Add("uninclass", ddb.getTableValue_SqlText("select count(1) from [groupuser] inner join [group] on groupuser.groupid=[group].id where groupuser.[istrue]=0 and [group].groupclass=1"));
            ViewData.Add("groupall", ddb.getTableValue_SqlText("select count(1) from [group] where [istrue]=1 and groupclass=0"));
            ViewData.Add("classall", ddb.getTableValue_SqlText("select count(1) from [group] where [istrue]=1 and groupclass=1"));
         
        }
        public void applyclass() {
            Chsword.DoDataBase ddb = new Chsword.DoDataBase();
            ViewData.Add("groups", ddb.DoDataTable("Admin_Class_Request_list").Rows);
        }
        #endregion
        #region note
        public void note() {
			Chsword.DoDataBase ddb = new Chsword.DoDataBase();
            ViewData.Add("note_today",
				ddb.getTableValue_SqlText(
				"select count(1) from [log] where Datediff(d, addtime, GETDATE()) = 0 and groupid=0"
				));
        }
		public void note_today() {
			IList<Note> i = (from l in this.DB.Note
					   orderby l.AddTime descending
							 select l).ToList < Note>();
			//ViewData["rows"] =
			//    PaginationHelper.CreatePagination(this, i, 10);
			ViewData["rows"] =
		PaginationHelper.AsPagination<Note>(i, 1, 10);
		}
        #endregion
     


	}
}
