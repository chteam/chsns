using CHSNS.Config;
using CHSNS.Model;
using CHSNS.Operator;
using System;
 
using System.Collections.Generic;
using CHSNS.Models;
namespace CHSNS.Service
{

    public class FriendService : BaseService<FriendService>
    {
        private readonly FriendOperator _friend;
        private readonly UserOperator _user;
        private readonly EventOperator _event;
        public FriendService()
        {
            _friend = new FriendOperator();
            _user = new UserOperator();
            _event = new EventOperator();
        }

        #region 获取
        public Profile UserFriendInfo(long userid)
        {
            return _friend.UserFriendInfo(userid);
        }
        public List<long> GetFriendsId(long userid)
        {
            return _friend.GetFriendsId(userid);
        }
        public PagedList<UserItemPas> GetFriends(long uid, int p, SiteConfig site)
        {
            return _friend.GetFriends(uid, p, site.EveryPage.Friend);
        }

        public List<UserItemPas> GetRandoms(int n)
        {
            return _friend.GetRandoms(n);
        }

        public PagedList<UserItemPas> GetRequests(long userid, int p, SiteConfig site)
        {
            return _friend.GetRequests(userid, p, site.EveryPage.FriendRequest);
        }

        #endregion
        /// <summary>
        /// 加为好友
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <returns>已经是好友则返回False，如果还不是，则返回True，并发送一个好友请求</returns>
        public bool Add(long fromId, long toId)
        {
            return _friend.Add(fromId, toId);
        }

        /// <summary>
        /// Deletes the specified from ID.
        /// </summary>
        /// <param name="fromId">From ID.</param>
        /// <param name="toId">To ID.</param>
        /// <returns></returns>
        public bool Delete(long fromId, long toId)
        {
            return _friend.Delete(fromId, toId);
        }

        /// <summary>
        /// Agrees the friend request.
        /// </summary>
        /// <param name="operaterId">The operater ID.</param>
        /// <param name="toId">To ID.</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Agree(long operaterId, long toId, IUser user)
        {
            var b = _friend.Agree(operaterId, toId);
            string name = _user.GetUserName(toId);

            _event.Add(new Event
            {
                OwnerId = toId,
                ViewerId = operaterId,
                TemplateName = "MakeFriend",
                AddTime = DateTime.Now,
                ShowLevel = 0,
                Json =
                    Dictionary.CreateFromArgs("ownername", name, "sendername", user.Name).
                    ToJsonString()
            }
                );
            return b;
        }

        /// <summary>
        /// Ignores friend request
        /// </summary>
        /// <param name="fromId">From ID.</param>
        /// <param name="operaterId">The operater ID.</param>
        /// <returns></returns>
        public bool Ignore(long fromId, long operaterId)
        {
            return _friend.Ignore(fromId, operaterId);
        }
        public bool IgnoreAll(long uId)
        {
            return _friend.IgnoreAll(uId);
        }
    }
}