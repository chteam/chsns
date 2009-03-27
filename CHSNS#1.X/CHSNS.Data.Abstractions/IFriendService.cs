using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Service
{
    public interface IFriendService
    {
        bool Add(long FromID, long ToID);
        bool Agree(long OperaterID, long ToID);
        bool Delete(long FromID, long ToID);
        bool Ignore(long FromID, long operaterID);
        bool IgnoreAll(long UserID);

        PagedList<UserItemPas> GetFriends(long uid, int p);
        IList<long> GetFriendsID(long userid);
        IList<UserItemPas> GetRandoms(int n);
        PagedList<UserItemPas> GetRequests(long userid,int p);

        Profile UserFriendInfo(long userid);

	}
}
