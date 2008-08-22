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

	/// <summary>
	/// Description of EventController.
	/// </summary>
	[LoginedFilter]
	public class EventController: BaseController
	{
		public void index(){
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
			dict.Add("@userid", ChUser.Current.Userid);
			return DataBaseExecutor.GetRows("Reply_New", dict);
		}
		/// <summary>
		/// 我的统计
		/// </summary>
		/// <returns></returns>
		public DataRowCollection Gather() {
			Dictionary dict = new Dictionary();
			dict.Add("@userid", ChUser.Current.Userid);
			return DataBaseExecutor.GetRows("Gather", dict);
		}
		#endregion

	}
}
