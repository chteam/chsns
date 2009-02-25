using System.Linq;
using CHSNS.Models;

namespace CHSNS.Data
{
	/// <summary>
	/// Calling the event
	/// </summary>
	public class EventMediator : BaseMediator, IEventMediator {
		/// <summary>
		/// Initializes a new instance of the <see cref="EventMediator"/> class.
		/// </summary>
		/// <param name="id">The DBExt.</param>
		public EventMediator(IDBManager id) : base(id) { }
		/// <summary>
		/// Gets the event./获取某人的Event
		/// </summary>
		/// <param name="userid">The userid.</param>
		/// <returns></returns>
		public IQueryable<Event> GetEvent(long userid) {
			var ret = (from e in DBExt.DB.Event
					   where e.OwnerID == userid
					   orderby e.ID descending
					   select e);
			return ret;
		}

		/// <summary>
		/// 50好友事件
		/// </summary>
		/// <param name="userid">The userid.</param>
		/// <returns></returns>
		public IQueryable<Event> GetFriendEvent(long userid) {
			var ids=DBExt.Friend.GetFriendsID(userid);
			var ret = (from e in DBExt.DB.Event
					   where ids.Any(c => c == e.OwnerID)
					   orderby e.ID descending
					   select e).Take(50);
			return ret;
		}

		/// <summary>
		/// Deletes the Event
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="ownerid">The ownerid.</param>
		public void Delete(long id, long ownerid) {
			DataBaseExecutor.Execute(@"delete [event] where id=@id and ownerid=@oid", "@id", id, "@oid", ownerid);
		}
		public void Add(Event e) {
			DataBaseExecutor.Execute(@"INSERT INTO [Event]
([TemplateName],[OwnerID],[ViewerID],[AddTime],[ShowLevel],[Json])
VALUES(@tname,@ownerid,@viewerid,@now,@showlevel,@json)"
				, "@tname", e.TemplateName
				, "@ownerid", e.OwnerID
				, "@viewerid", e.ViewerID.Get()
				, "@now", e.AddTime
				, "@showlevel", e.ShowLevel
				, "@json", e.Json
				);
		}
	}
}
