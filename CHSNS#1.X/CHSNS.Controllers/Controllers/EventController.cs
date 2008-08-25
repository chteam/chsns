/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 22:39
 * 
 * 
 */
namespace CHSNS.Controllers
{
	using System;
	using System.Data;
	//using CHSNS.Data;
	
	using CHSNS.Data;
	using CHSNS;
using System.Web.Mvc;
	using System.Collections.Generic;

	/// <summary>
	/// Description of EventController.
	/// </summary>
	[LoginedFilter]
	public class EventController: BaseController
	{
		public void Index(){
			DataRow dr = Gather()[0];
			ViewData.Add("FriendRequestCount",dr["FriendRequestCount"]);
			ViewData.Add("ViewCount",dr["ViewCount"]);
			ViewData.Add("CommentCount",dr["CommentCount"]);
			ViewData.Add("NewReply", NewReplyRows());
			//IDataBase idb = new DBExt(Session);
			ViewData.Add("RssSource", this.DBExt.RssList(10));
		}

		#region DataBase
		/// <summary>
		/// 回复的5人列表
		/// </summary>
		/// <returns></returns>
		public DataRowCollection NewReplyRows() {
			Dictionary dict = new Dictionary();
			dict.Add("@userid", CHSNSUser.Current.UserID);
			return DataBaseExecutor.GetRows("Reply_New", dict);
		}
		/// <summary>
		/// 我的统计
		/// </summary>
		/// <returns></returns>
		public DataRowCollection Gather() {
			Dictionary dict = new Dictionary();
			dict.Add("@userid", CHSNSUser.Current.UserID);
			return DataBaseExecutor.GetRows("Gather", dict);
		}
		#endregion

		#region 组件
		public ActionResult Show(long userid, byte type) {
			ViewData["userid"] = userid;
			//ViewData["type"] = type;
			ViewData["eventrows"] = DataBaseExecutor.GetRows("Event_List"
					, "@userid", userid,
			"@type", type,
			"@page", 1,
			"@everyPage", 10);
			return View();
		}

		#endregion
	}
}
