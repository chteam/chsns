
namespace CHSNS.Service
{
    
    using CHSNS.Models;
    using System.Linq;
    /// <summary>
    /// Calling the event
    /// </summary>
    public class EventService : BaseService<EventService>
    {
     
     


        /// <summary>
        /// 50好友事件
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="p"></param>
        /// <param name="ep"></param>
        /// <returns></returns>
        public PagedList<Event> GetFriendEvent(long userid, int page, int pageSize)
        {
            var ids = FriendService.Instance.GetFriendsId(userid);
            using (var db = DBExtInstance)
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
            using (var db = DBExtInstance)
            {
                var e = db.Event.FirstOrDefault(c => c.Id == id && c.OwnerId == ownerId);
                if (e == null) return;
                db.DeleteObject(e);
                db.SaveChanges();
            }
        }
        public void Add(Event e)
        {
            var et = CastTool.Cast<Event>(e);
            using (var db = DBExtInstance)
            {
                db.Event.AddObject(et);
                db.SaveChanges();
            }
        }

        #region IEventService 成员


        public PagedList<Event> GetEvent(long userid, int page, int pageSize)
        {
            using (var db = DBExtInstance)
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
