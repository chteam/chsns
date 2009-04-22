using CHSNS.Config;
using CHSNS.Abstractions;
using CHSNS.Operator;

namespace CHSNS.Service {
    using System;
    using Model;
    using System.Collections.Generic;
    public class FriendService {
        static readonly FriendService _instance = new FriendService();
        private readonly IFriendOperator Friend;
        private readonly IUserOperator User;
        private readonly IEventOperator Event;
        public FriendService() {
            Friend = new FriendOperator();
            User = new UserOperator();
            Event = new EventOperator();
        }

        public static FriendService GetInstance() {
            return _instance;
        }
        #region 获取
        public IProfile UserFriendInfo(long userid) {
            return Friend.UserFriendInfo(userid);
        }
        public List<long> GetFriendsID(long userid) {
            return Friend.GetFriendsID(userid);
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
        /// <param name="FromID"></param>
        /// <param name="ToID"></param>
        /// <returns>已经是好友则返回False，如果还不是，则返回True，并发送一个好友请求</returns>
        public bool Add(long FromID, long ToID) {
            return Friend.Add(FromID, ToID);
        }

        /// <summary>
        /// Deletes the specified from ID.
        /// </summary>
        /// <param name="FromID">From ID.</param>
        /// <param name="ToID">To ID.</param>
        /// <returns></returns>
        public bool Delete(long FromID, long ToID) {
            return Friend.Delete(FromID, ToID);
        }

        /// <summary>
        /// Agrees the friend request.
        /// </summary>
        /// <param name="OperaterID">The operater ID.</param>
        /// <param name="ToID">To ID.</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Agree(long OperaterID, long ToID, IUser user) {
            var b = Friend.Agree(OperaterID, ToID);
            string name = User.GetUserName(ToID);

            Event.Add(new EventImplement {
                OwnerID = ToID,
                ViewerID = OperaterID,
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
        /// <param name="FromID">From ID.</param>
        /// <param name="operaterID">The operater ID.</param>
        /// <returns></returns>
        public bool Ignore(long FromID, long operaterID) {
            return Friend.Ignore(FromID, operaterID);
        }
        public bool IgnoreAll(long uId) {
            return Friend.IgnoreAll(uId);
        }
    }
}