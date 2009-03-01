using System;
using System.Collections.Generic;
namespace CHSNS.Data {
	public interface IFriendMediator {
		bool Add(long FromID, long ToID);
		bool Agree(long OperaterID, long ToID);
		bool Delete(long FromID, long ToID);
		PagedList<CHSNS.ModelPas.UserItemPas> GetFriends(long uid,int p,int ep);
		List<long> GetFriendsID(long userid);
		System.Linq.IQueryable<CHSNS.ModelPas.UserItemPas> GetRandoms();
		System.Linq.IQueryable<CHSNS.ModelPas.UserItemPas> GetRequests(long userid);
		bool Ignore(long FromID, long operaterID);
		bool IgnoreAll(long UserID);
		CHSNS.Models.Profile UserFriendInfo(long userid);
	}
}
