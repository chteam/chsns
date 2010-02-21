using System.Linq;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service
{
    /// <summary>
    /// Calling the event
    /// </summary>
    public class EventService 
    {
        static readonly EventService _instance = new EventService();
        private readonly IEventOperator Event;
        private readonly IFriendOperator Friend;
        public EventService() {
            Event = new EventOperator();
            Friend = new FriendOperator();
        }

        public static EventService GetInstance() {
            return _instance;
        }

        /// <summary>
        /// 50好友事件
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="p"></param>
        /// <param name="ep"></param>
        /// <returns></returns>
        public PagedList<Event> GetFriendEvent(long userid, int p, int ep)
        {
            var ids = Friend.GetFriendsId(userid);
            return Event.GetUsersEvent(ids.ToArray(), p, ep);
        }

        /// <summary>
        /// Deletes the Event
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="ownerId"></param>
        public void Delete(long id, long ownerId)
        {
            Event.Delete(id, ownerId);
        }
        public void Add(Event e)
        {
            Event.Add(e);
        }

        #region IEventService 成员


        public PagedList<Event> GetEvent(long userid, int p, int ep)
        {
            return Event.GetEvent(userid, p, ep);
        }

        #endregion
    }
}
