using System.Collections.Generic;
using System.Linq;
using CHSNS.ModelPas;
using CHSNS.Models;

namespace CHSNS.Data
{
    public interface IFriendMediator
    {
        bool Add(long FromID, long ToID);
        bool Agree(long OperaterID, long ToID);
        bool Delete(long FromID, long ToID);
        PagedList<UserItemPas> GetFriends(long uid, int p, int ep);
        List<long> GetFriendsID(long userid);
        IQueryable<UserItemPas> GetRandoms();
        IQueryable<UserItemPas> GetRequests(long userid);
        bool Ignore(long FromID, long operaterID);
        bool IgnoreAll(long UserID);
        Profile UserFriendInfo(long userid);
	}
}
