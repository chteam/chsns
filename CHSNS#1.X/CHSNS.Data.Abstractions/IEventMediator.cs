using System;
namespace CHSNS.Data {
	public interface IEventMediator {
		void Add(CHSNS.Models.Event e);
		void Delete(long id, long ownerid);
		System.Linq.IQueryable<CHSNS.Models.Event> GetEvent(long userid);
		System.Linq.IQueryable<CHSNS.Models.Event> GetFriendEvent(long userid);
	}
}
