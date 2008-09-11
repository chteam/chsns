using System;
using System.Data;
using CHSNS.Models;

namespace CHSNS.Data {
	public class GatherMediator : BaseMediator {
		public GatherMediator(DBExt id) : base(id) { }
		/// <summary>
		/// 我的统计
		/// </summary>
		/// <returns></returns>
		public EventPagePas EventGather() {
			DataRowCollection drc = DataBaseExecutor.GetRows("Gather", "@userid", CHUser.UserID);
			EventPagePas ep = null;
			if (drc.Count != 0) {
				ep = new EventPagePas();
				DataRow dr = drc[0];
				ep.FriendRequestCount = Convert.ToInt32(dr["FriendRequestCount"]);
				ep.ViewCount = Convert.ToInt32(dr["ViewCount"]);
				ep.CommentCount = Convert.ToInt32(dr["CommentCount"]);
				ep.NewReply = null;// DBExt.Comment.NewFiveReply();
				ep.RssSource = null;// DBExt.Group.TakeIns(10);
			}
			return ep;
		}
	}
}

