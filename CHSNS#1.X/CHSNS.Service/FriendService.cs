using CHSNS.Config;
using CHSNS.Abstractions;
using CHSNS.Operator;

namespace CHSNS.Service {
    using System;
    using Model;
    using System.Collections.Generic;
    public class FriendService {
        static readonly FriendService Instance = new FriendService();
        private readonly IFriendOperator Friend;
        private readonly IUserOperator User;
        private readonly IEventOperator Event;
        public FriendService() {
            Friend = new FriendOperator();
            User = new UserOperator();
            Event = new EventOperator();
        }

        public static FriendService GetInstance() {
            return Instance;
        }
        #region 获取
        public IProfile UserFriendInfo(long userid) {
            return Friend.UserFriendInfo(userid);
        }
        public List<long> GetFriendsId(long userid) {
            return Friend.GetFriendsId(userid);
        }
        public PagedList<UserItemPas> GetFriends(long uid, int p, SiteConfig site) {
            return Friend.GetFriends(uid, p, site.EveryPage.Friend);
        }

        public List<UserItemPas> GetRandoms(int n) {
            return Friend.GetRandoms(n);
        }

        public PagedList<UserItemPas> GetRequests(long userid, int p, SiteConfig site) {
            return Friend.GetRequests(userid, p, site.EveryPage.FriendRequest);
        }

        #endregion
        /// <summary>
        /// 加为好友
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <returns>已经是好友则返回False，如果还不是，则返回True，并发送一个好友请求</returns>
        public bool Add(long fromId, long toId) {
            return Friend.Add(fromId, toId);
        }

        /// <summary>
        /// Deletes the specified from ID.
        /// </summary>
        /// <param name="fromId">From ID.</param>
        /// <param name="toId">To ID.</param>
        /// <returns></returns>
        public bool Delete(long fromId, long toId) {
            return Friend.Delete(fromId, toId);
        }

        /// <summary>
        /// Agrees the friend request.
        /// </summary>
        /// <param name="operaterId">The operater ID.</param>
        /// <param name="toId">To ID.</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Agree(long operaterId, long toId, IUser user) {
            var b = Friend.Agree(operaterId, toId);
            string name = User.GetUserName(toId);

            Event.Add(new EventImplement {
                OwnerID = toId,
                ViewerID = operaterId,
                TemplateName = "MakeFriend",
                AddTime = DateTime.Now,
                ShowLevel = 0,
                Json =
                    Dictionary.CreateFromArgs("ownername", name, "sendername", user.Username).
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
        public bool Ignore(long fromId, long operaterId) {
            return Friend.Ignore(fromId, operaterId);
        }
        public bool IgnoreAll(long uId) {
            return Friend.IgnoreAll(uId);
        }
    }
}