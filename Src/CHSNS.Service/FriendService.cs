
using CHSNS.Common.Serializer;

namespace CHSNS.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Config;
    using CHSNS.Model;
    using CHSNS.Models;
    using System.ComponentModel.Composition;
    [Export]
    public class FriendService : BaseService
    {
        #region 获取
        public Profile UserFriendInfo(long userId)
        {
            using (var db = DbInstance)
            {
                var ret = (from p in db.Profile
                           where p.UserId == userId
                           select new
                           {
                               UserId = userId,
                               //   p.FriendCount,
                               p.Name
                           }).FirstOrDefault();
                return new Profile
                {
                    UserId = ret.UserId,
                    //	FriendCount = ret.FriendCount,
                    Name = ret.Name
                };
            }
        }
        public List<long> GetFriendsId(long userid)
        {
            using (var db = DbInstance)
            {
                return (from f1 in db.Friends
                        where f1.FromId == userid && f1.IsTrue
                        select f1.ToId)
                                   .Union(from f1 in db.Friends
                                          where f1.ToId == userid && f1.IsTrue
                                          select f1.FromId).ToList();
            }
        }

        public PagedList<UserItemPas> GetFriends(long uid, int page, SiteConfig site)
        {
            var ids = GetFriendsId(uid);
            using (var db = DbInstance)
            {
                var ret = (from c in db.Profile
                           where ids.Contains(c.UserId)
                           orderby c.UserId
                           select new UserItemPas
                           {
                               Id = c.UserId,
                               Name = c.Name,
                               //   ShowText = c.ShowText,
                               //   ShowTextTime = c.ShowTextTime
                           });

                return ret.Pager(page, site.EveryPage.Friend);// );

            }
        }

        public List<UserItemPas> GetRandoms(int n)
        {
            using (var db = DbInstance)
            {
                var ret = (from p in db.Profile
                           where p.Status.Equals(RoleType.General)
                           //  orderby db.Newid()
                           select new UserItemPas
                           {
                               Id = p.UserId,
                               Name = p.Name,
                           }).Take(n);
                return ret.ToList();
            }
        }

        public PagedList<UserItemPas> GetRequests(long userid, int page, SiteConfig site)
        {
            using (var db = DbInstance)
            {
                var ret = (from f1 in db.Friends
                           join p1 in db.Profile on f1.FromId equals p1.UserId
                           where f1.ToId == userid && !f1.IsTrue
                           orderby p1.UserId descending
                           select new UserItemPas
                           {
                               Id = p1.UserId,
                               Name = p1.Name,
                               ShowText = "",
                               ShowTextTime = DateTime.Now
                           });
                return ret.Pager(page, site.EveryPage.FriendRequest);//, Site.EveryPage.FriendRequest);
            }
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
            using (var db = DbInstance)
            {
                var f = db.Friends.FirstOrDefault(
                    c =>
                    (c.ToId == toId && c.FromId == fromId)
                    ||
                    (c.ToId == fromId && c.FromId == toId)
                    );
                if (f == null)
                {
                    db.Friends.Add(
                        new Friend
                        {
                            FromId = fromId,
                            ToId = toId,
                            IsTrue = false,
                            IsCommon = true
                        });
                }
                else
                {//update
                    if (f.FromId == toId)
                        f.IsTrue = true;
                }
                db.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// Deletes the specified from ID.
        /// </summary>
        /// <param name="fromId">From ID.</param>
        /// <param name="toId">To ID.</param>
        /// <returns></returns>
        public bool Delete(long fromId, long toId)
        {
            using (var db = DbInstance)
            {
                var f = db.Friends.FirstOrDefault(
                    c =>
                    (c.ToId == toId && c.FromId == fromId)
                    ||
                    (c.ToId == fromId && c.FromId == toId)
                    &&
                    c.IsTrue
                    );
                db.Friends.Remove(f);
                db.SaveChanges();
            }
            return true;
        }
        [Import]
        public EventLogService EventLog { get; set; }
        [Import]
        public UserService UserInfo { get; set; }

        /// <summary>
        /// Agrees the friend request.
        /// </summary>
        /// <param name="operaterId">The operater ID.</param>
        /// <param name="toId">To ID.</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Agree(long operaterId, long toId, IUser user)
        {
            var b = Agree(operaterId, toId);
            string name = UserInfo.GetUserName(toId);

EventLog.Add(new EventLog
            {
                OwnerId = toId,
                ViewerId = operaterId,
                TemplateName = "MakeFriend",
                AddTime = DateTime.Now,
                ShowLevel = 0,
                Json =
                    JsonAdapter.Serialize(Dictionary.CreateFromArgs("ownername", name, "sendername", user.Name)
                    )
            }
                );
            return b;
        }
        internal bool Agree(long operaterId, long toId)
        {
            //string name;
            using (var db = DbInstance)
            {
                var f = db.Friends.FirstOrDefault(
                    c =>
                    (c.ToId == toId && c.FromId == operaterId) ||
                    (c.ToId == operaterId && c.FromId == toId) && !c.IsTrue
                    );
                if (f == null) return false;
                f.IsTrue = true;
                db.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// Ignores friend request
        /// </summary>
        /// <param name="fromId">From ID.</param>
        /// <param name="operaterId">The operater ID.</param>
        /// <returns></returns>
        public bool Ignore(long fromId, long operaterId)
        {
            using (var db = DbInstance)
            {
                var f = db.Friends.FirstOrDefault(c => c.ToId == operaterId && c.FromId == fromId && !c.IsTrue);
                if (f == null) return false;
                db.Friends.Remove(f);
                db.SaveChanges();
                return true;
            }
        }
        public bool IgnoreAll(long userId)
        {
            using (var db = DbInstance)
            {
                var f = db.Friends.Where(c => c.ToId == userId && !c.IsTrue);
                db.Friends.BulkRemove(f);
                db.SaveChanges();
                return true;
            }
        }
    }
}