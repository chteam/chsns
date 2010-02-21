using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Operator
{
    public interface IFriendOperator
    {
        bool Add(long fromId, long toId);
        bool Agree(long operaterId, long toId);
        bool Delete(long fromId, long toId);
        bool Ignore(long fromId, long operaterId);
        bool IgnoreAll(long userId);

        PagedList<UserItemPas> GetFriends(long userId, int page,int pageSize);
        List<long> GetFriendsId(long userId);
        List<UserItemPas> GetRandoms(int n);
        PagedList<UserItemPas> GetRequests(long userId, int page, int pageSize);

        Profile UserFriendInfo(long userId);

	}
}
