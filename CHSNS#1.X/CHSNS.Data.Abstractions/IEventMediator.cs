namespace CHSNS.Data {
	public interface IEventMediator {
		void Add(Models.Event e);
		void Delete(long id, long ownerid);
		System.Linq.IQueryable<Models.Event> GetEvent(long userid);
		System.Linq.IQueryable<Models.Event> GetFriendEvent(long userid);
	}
}
