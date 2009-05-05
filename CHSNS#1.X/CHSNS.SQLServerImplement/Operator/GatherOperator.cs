using System.Linq;
using CHSNS.Model;
namespace CHSNS.Operator {
	/// <summary>
	/// 统计的类
	/// </summary>
	public class GatherOperator : BaseOperator, IGatherOperator {
		/// <summary>
		/// 我的统计
		/// </summary>
		/// <returns></returns>
		public EventPagePas EventGather(long userid) {
            EventPagePas ep = null;
            using (var db = DBExtInstance)
            {
                var r = (from p in db.Profile
                         where p.UserId == userid
                         select new
                         {
                             // p.FriendRequestCount,
                             p.ViewCount,
                             // p.ReplyCount
                         }).FirstOrDefault();

                if (r != null)
                {
                    ep = new EventPagePas { NewReply = null, RssSource = null, ViewCount = r.ViewCount };
                    //ep.FriendRequestCount = r.FriendRequestCount;
                    //	ep.ReplyCount = r.ReplyCount;
                }
            }
			return ep;
		}
	}
}

