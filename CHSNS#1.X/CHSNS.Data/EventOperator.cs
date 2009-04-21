using System.Linq;
using CHSNS.Models;
using CHSNS.Models.Abstractions;

namespace CHSNS.Operator
{
    /// <summary>
    /// Calling the event
    /// </summary>
    public class EventOperator : BaseOperator, IEventOperator
    {
/// <summary>
/// 
/// </summary>
/// <param name="ids"></param>
/// <param name="page"></param>
/// <param name="pageSize"></param>
/// <returns></returns>
        public PagedList<IEvent> GetUsersEvent(long[] ids, int page, int pageSize)
        {
           // var ids = DBExt.Friend.GetFriendsID(userid);
          //  throw new System.Exception(ids.Count.ToString());
            using (var db = DBExtInstance)
            {
                var ret = (from e in db.Event
                           where ids.Contains(e.OwnerID)
                           orderby e.ID descending
                           select e).Cast<IEvent>();
                return ret.Pager(page, pageSize);
            }
        }

        /// <summary>
        /// Deletes the Event
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="ownerid">The ownerid.</param>
        public void Delete(long id, long ownerid)
        {
            using (var db = DBExtInstance)
            {
                var e = db.Event.FirstOrDefault(c => c.ID == id && c.OwnerID == ownerid);
                if (e == null) return;
                db.Event.DeleteOnSubmit(e);
                db.SubmitChanges();
            }
        }
        public void Add(IEvent e)
        {
            using (var db = DBExtInstance)
            {
                db.Event.InsertOnSubmit(e as Event);
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


        public PagedList<IEvent> GetEvent(long userid, int p, int ep)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from e in db.Event
                           where e.OwnerID == userid
                           orderby e.ID descending
                           select e).Cast<IEvent>();
                return ret.Pager(p, ep);
            }
        }

        #endregion
    }
}
