

namespace ChAlumna.Controllers {
	using System;
	using System.Linq;
	using Castle.MonoRail.Framework;
	using Chsword;
	using ChAlumna.Models;
    using System.Collections.Generic;
    using System.Collections;
	using ChAlumna.Config;
	using Castle.MonoRail.Framework.Helpers;
	[ControllerDetails(Area = "Admin")]
	public partial class AdminController :BaseAdminController {
		/// <summary>
		/// 管理主页，清理缓存
		/// </summary>
		public void index() {
			//AreaName = null;
			LayoutName = null;
		}
		 
		#region 配置

		public void basic() {
			Chsword.DoDataBase ddb = new Chsword.DoDataBase();
			ViewData.Add("onlinecount", ChAlumna.Online.OnlineList.Count);
			ViewData.Add("cachecount", ChCache.Cache.Count);
			ViewData.Add("regcount", ddb.getTableValue_SqlText("select count(1) from account"));
			ViewData.Add("version", ChAlumnaConfig.Version);
			ViewData["appname"] = ChAlumnaConfig.AppName;
			ViewData["programmer"] = ChAlumnaConfig.Programmer;
			ViewData.Add("serverstart", SiteConfig.SystemUptime);
		}

		/// <summary>
		/// 清理缓存
		/// </summary>
		[AccessibleThrough(Verb.Post)]
		public void clearcache() {
			ChCache.RemoveAll();
			Flash.Now("msg", "缓存更新成功");
			this.RedirectToReferrer();
			//this.RedirectToAction("index");
		}
		/// <summary>
		/// 重启服务器
		/// </summary>
		[AccessibleThrough(Verb.Post)]
		public void restart() {
			//Log.LogEntry("Executing WebApp shutdown", EntryType.General, "SYSTEM");
			System.Web.HttpRuntime.UnloadAppDomain();
			Global g = new Global();
			g.Application_Start(1, EventArgs.Empty);
			Flash.Now("msg", "服务器重启成功");
			this.RedirectToReferrer();
		}
#endregion

		#region 磁盘管理
		public void space() {
			if (IsPost) {
				Flash.Now("ispost", true);
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
									join a in DB.Account on p.UserId equals a.userid
									join s in DB.FieldInformation on p.UserId equals s.userid
									select new
									{
										a.userid,
										a.name,
										s.Field,
										s.MiniField,
										s.Year
									}).ToList();

			//from Profile_AS pas where pas.IsStar = 1 and pas.IsUpdate=0 
			//	Profile_AS.FindByNoStar();
		}
        [AccessibleThrough(Verb.Post)]
        public void SetStar(long userid, bool ispass) {
			
			ChAlumna.Admin admin = new ChAlumna.Admin();
            if (ispass) {
                admin.setStar(userid.ToString(), true);
                Flash["msg"] = userid.ToString() + "设置成功";
            }else {
                admin.setStar(userid.ToString(), false);
                Flash["msg"] = userid.ToString() + "设置成功";
            }
            RedirectToReferrer();
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
			IList i = (from l in this.DB.Note
					   orderby l.AddTime descending
					   select l).ToList();
			ViewData["rows"] =
				PaginationHelper.CreatePagination(this, i, 10);
		}
        #endregion
     


	}
}
