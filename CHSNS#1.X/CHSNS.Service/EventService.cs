using System.Linq;
using CHSNS.Abstractions;
using CHSNS.Operator;

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
        public PagedList<IEvent> GetFriendEvent(long userid, int p, int ep)
        {
            var ids = Friend.GetFriendsID(userid);
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
        public void Add(IEvent e)
        {
            Event.Add(e);
        }

        #region IEventService 成员


        public PagedList<IEvent> GetEvent(long userid, int p, int ep)
        {
            return Event.GetEvent(userid, p, ep);
        }

        #endregion
    }
}
