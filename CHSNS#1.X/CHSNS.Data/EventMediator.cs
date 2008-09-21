using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Models;

namespace CHSNS.Data
{
	/// <summary>
	/// Calling the event
	/// </summary>
	public class EventMediator : BaseMediator {
		/// <summary>
		/// Initializes a new instance of the <see cref="EventMediator"/> class.
		/// </summary>
		/// <param name="id">The DBExt.</param>
		public EventMediator(DBExt id) : base(id) { }
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

		public void Add(Event e) { 
	/*DataBaseExecutor.Execute(@"	INSERT INTO [Event]([TemplateName] ,[OwnerID],[ViewerID],
[AddTime],[ShowLevel],[Title],[Body]) VALUES
(@templatename,@ownerid,@viewerid,@addtime,@showlevel
,<Title, nvarchar(max),>
,<Body, nvarchar(max),>)"*/
			DBExt.DB.AddToEvent(e);
			DBExt.DB.SaveChanges();
		}
	}
}
