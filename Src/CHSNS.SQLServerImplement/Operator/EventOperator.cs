using System.Linq;

using CHSNS.SQLServerImplement;
using CHSNS.Models;

namespace CHSNS.Operator
{
    /// <summary>
    /// Calling the event
    /// </summary>
    public class EventOperator : BaseOperator
    {
/// <summary>
/// 
/// </summary>
/// <param name="ids"></param>
/// <param name="page"></param>
/// <param name="pageSize"></param>
/// <returns></returns>
        public PagedList<Event> GetUsersEvent(long[] ids, int page, int pageSize)
        {
           // var ids = DBExt.Friend.GetFriendsId(userid);
          //  throw new System.Exception(ids.Count.ToString());
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
        /// <param name="ownerid">The ownerid.</param>
        public void Delete(long id, long ownerid)
        {
            using (var db = DBExtInstance)
            {
                var e = db.Event.FirstOrDefault(c => c.Id == id && c.OwnerId == ownerid);
                if (e == null) return;
                db.DeleteObject(e);
                db.SubmitChanges();
            }
        }
        public void Add(Event e)
        {
            var et = CastTool.Cast<Event>(e);
            using (var db = DBExtInstance)
            {
                db.Event.AddObject(et);
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
            using (var db = DBExtInstance)
            {
                var ret = (from e in db.Event
                           where e.OwnerId == userid
                           orderby e.Id descending
                           select e);
                return ret.Pager(p, ep);
            }
        }

        #endregion
    }
}
