using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service
{
    /// <summary>
    /// Calling the event
    /// </summary>
    public class EventService 
    {
        static readonly EventService Instance = new EventService();
        private readonly IEventOperator _event;
        private readonly IFriendOperator _friend;
        public EventService() {
            _event = new EventOperator();
            _friend = new FriendOperator();
        }

        public static EventService GetInstance() {
            return Instance;
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
            var ids = _friend.GetFriendsId(userid);
            return _event.GetUsersEvent(ids.ToArray(), p, ep);
        }

        /// <summary>
        /// Deletes the Event
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="ownerId"></param>
        public void Delete(long id, long ownerId)
        {
            _event.Delete(id, ownerId);
        }
        public void Add(Event e)
        {
            _event.Add(e);
        }

        #region IEventService 成员


        public PagedList<Event> GetEvent(long userid, int p, int ep)
        {
            return _event.GetEvent(userid, p, ep);
        }

        #endregion
    }
}
