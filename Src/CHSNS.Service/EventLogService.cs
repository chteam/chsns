
namespace CHSNS.Service
{
    using System.ComponentModel.Composition;
    using CHSNS.Models;
    using System.Linq;
    /// <summary>
    /// Calling the event
    /// </summary>    

    [Export]
    public class EventLogService : BaseService
    {
        [Import]
        public FriendService Friend { get; set; }
        /// <summary>
        /// 50好友事件
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<EventLog> GetFriendEvent(long userid, int page, int pageSize)
        {
            var ids = Friend.GetFriendsId(userid);
            using (var db = DbInstance)
            {
                var ret = (from e in db.Event
                           where ids.Contains(e.OwnerId)
                           orderby e.Id descending
                           select e);
                return ret.Pager(page, pageSize);
            }
            
        }

        /// <summary>
        /// Deletes the Event
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="ownerId"></param>
        public void Delete(long id, long ownerId)
        {
            using (var db = DbInstance)
            {
                var e = db.Event.FirstOrDefault(c => c.Id == id && c.OwnerId == ownerId);
                if (e == null) return;
                db.Event.Remove(e);
                db.SaveChanges();
            }
        }
        public void Add(EventLog e)
        {
            var et = CastTool.Cast<EventLog>(e);
            using (var db = DbInstance)
            {
                db.Event.Add(et);
                db.SaveChanges();
            }
        }

        #region IEventService 成员


        public PagedList<EventLog> GetEvent(long userid, int page, int pageSize)
        {
            using (var db = DbInstance)
            {
                var ret = (from e in db.Event
                           where e.OwnerId == userid
                           orderby e.Id descending
                           select e);
                return ret.Pager(page, pageSize);
            }
        }

        #endregion
    }
}
