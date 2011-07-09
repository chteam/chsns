
namespace CHSNS.Service
{
    using CHSNS.Model;
    using System.Linq;
    using System.ComponentModel.Composition;

    /// <summary>
    /// 统计的类
    /// </summary>
    [Export]
    public class GatherService : BaseService
    {
        /// <summary>
        /// 我的统计
        /// </summary>
        /// <returns></returns>
        public EventPagePas EventGather(long userId)
        {
            EventPagePas ep = null;
            using (var db = DbInstance)
            {
                var r = (from p in db.Profile
                         where p.UserId == userId
                         select new
                         {
                             // p.FriendRequestCount,
                             p.ViewCount,
                             // p.ReplyCount
                         }).FirstOrDefault();

                if (r != null)
                {
                    ep = new EventPagePas { ViewCount = r.ViewCount };
                    //ep.FriendRequestCount = r.FriendRequestCount;
                    //	ep.ReplyCount = r.ReplyCount;
                }
            }
            return ep;
        }
    }
}

