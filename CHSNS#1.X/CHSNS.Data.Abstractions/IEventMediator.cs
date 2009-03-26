namespace CHSNS.Service {
	public interface IEventService {
		void Add(Models.Event e);
		void Delete(long id, long ownerid);
        PagedList<Models.Event> GetEvent(long userid, int p, int ep);
        PagedList<Models.Event> GetFriendEvent(long userid, int p, int ep);
	}
}