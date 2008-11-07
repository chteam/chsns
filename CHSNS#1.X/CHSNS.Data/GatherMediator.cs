using System.Linq;
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
						 p.FriendRequestCount,
						 p.ViewCount,
						 p.ReplyCount
					 }).FirstOrDefault();
			EventPagePas ep = null;
			if (r!=null) {
				ep = new EventPagePas();

				ep.FriendRequestCount = r.FriendRequestCount;
				ep.ViewCount = r.ViewCount;
				ep.ReplyCount = r.ReplyCount;
				ep.NewReply = null;// DBExt.Comment.NewFiveReply();
				ep.RssSource = null;// DBExt.Group.TakeIns(10);
			}
			return ep;
		}
	}
}

