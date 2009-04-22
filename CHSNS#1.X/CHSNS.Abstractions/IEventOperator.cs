using CHSNS.Models.Abstractions;

namespace CHSNS.Operator {
	public interface IEventOperator {
		void Add(IEvent e);
		void Delete(long id, long ownerid);
        PagedList<IEvent> GetEvent(long userid, int p, int ep);
        PagedList<IEvent> GetUsersEvent(long[] ids, int page, int pageSize);
	}
}