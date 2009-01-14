﻿using System.Linq;
using CHSNS.ModelPas;
namespace CHSNS.Data {
	/// <summary>
	/// 统计的类
	/// </summary>
	public class GatherMediator : BaseMediator, IGatherMediator {
		public GatherMediator(IDBExt id) : base(id) { }
		/// <summary>
		/// 我的统计
		/// </summary>
		/// <returns></returns>
		public EventPagePas EventGather(long userid) {
			var r = (from p in DBExt.DB.Profile
					 where p.UserID == userid
					 select new
					 {
						// p.FriendRequestCount,
						 p.ViewCount,
						// p.ReplyCount
					 }).FirstOrDefault();
			EventPagePas ep = null;
			if (r!=null) {
				ep = new EventPagePas {NewReply = null, RssSource = null, ViewCount = r.ViewCount};
				//ep.FriendRequestCount = r.FriendRequestCount;
				//	ep.ReplyCount = r.ReplyCount;
			}
			return ep;
		}
	}
}

