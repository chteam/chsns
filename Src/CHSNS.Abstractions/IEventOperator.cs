//

using CHSNS.Models;
namespace CHSNS.Operator {
	public interface IEventOperator {
		void Add(Event e);
		void Delete(long id, long ownerid);
        PagedList<Event> GetEvent(long userid, int p, int ep);
        PagedList<Event> GetUsersEvent(long[] ids, int page, int pageSize);
	}
}