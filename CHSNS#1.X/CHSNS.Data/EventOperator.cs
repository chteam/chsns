using System.Linq;
using CHSNS.Models;

namespace CHSNS.Operator
{
    /// <summary>
    /// Calling the event
    /// </summary>
    public class EventOperator : BaseOperator, IEventOperator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventOperator"/> class.
        /// </summary>
        /// <param name="id">The DBExt.</param>
        public EventOperator(IDBManager id) : base(id) { }


        /// <summary>
        /// 50好友事件
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="p"></param>
        /// <param name="ep"></param>
        /// <returns></returns>
        public PagedList<Event> GetFriendEvent(long userid, int p, int ep)
        {
            var ids = DBExt.Friend.GetFriendsID(userid);
          //  throw new System.Exception(ids.Count.ToString());
            using (var db = DBExt.Instance)
            {
                var ret = (from e in db.Event
                           where ids.Contains(e.OwnerID)
                           orderby e.ID descending
                           select e);
                return ret.Pager(p, ep);
            }
        }

        /// <summary>
        /// Deletes the Event
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="ownerid">The ownerid.</param>
        public void Delete(long id, long ownerid)
        {
            using (var db = DBExt.Instance)
            {
                var e = db.Event.FirstOrDefault(c => c.ID == id && c.OwnerID == ownerid);
                if (e == null) return;
                db.Event.DeleteOnSubmit(e);
                db.SubmitChanges();
            }
        }
        public void Add(Event e)
        {
            using (var db = DBExt.Instance)
            {
                db.Event.InsertOnSubmit(e);
                db.SubmitChanges();
            }
            #region sql
//           DataBaseExecutor.Execute(@"INSERT INTO [Event]
//([TemplateName],[OwnerID],[ViewerID],[AddTime],[ShowLevel],[Json])
//VALUES(@tname,@ownerid,@viewerid,@now,@showlevel,@json)"
//                , "@tname", e.TemplateName
//                , "@ownerid", e.OwnerID
//                , "@viewerid", e.ViewerID.Get()
//                , "@now", e.AddTime
//                , "@showlevel", e.ShowLevel
//                , "@json", e.Json
//                );
            #endregion
 
        }

        #region IEventOperator 成员


        public PagedList<Event> GetEvent(long userid, int p, int ep)
        {
            using (var db = DBExt.Instance)
            {
                var ret = (from e in db.Event
                           where e.OwnerID == userid
                           orderby e.ID descending
                           select e);
                return ret.Pager(p, ep);
            }
        }

        #endregion
    }
}
