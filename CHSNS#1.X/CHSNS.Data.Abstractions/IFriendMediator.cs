using System;
namespace CHSNS.Data {
	public interface IFriendMediator {
		bool Add(long FromID, long ToID);
		bool Agree(long OperaterID, long ToID);
		bool Delete(long FromID, long ToID);
		System.Linq.IQueryable<CHSNS.ModelPas.UserItemPas> GetFriends(long userid);
		System.Linq.IQueryable<long> GetFriendsID(long userid);
		System.Linq.IQueryable<CHSNS.ModelPas.UserItemPas> GetRandoms();
		System.Linq.IQueryable<CHSNS.ModelPas.UserItemPas> GetRequests(long userid);
		bool Ignore(long FromID, long operaterID);
		bool IgnoreAll(long UserID);
		CHSNS.Models.Profile UserFriendInfo(long userid);
	}
}
