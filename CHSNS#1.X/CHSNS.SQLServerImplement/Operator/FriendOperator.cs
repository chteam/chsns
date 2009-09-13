using System.Collections;
using CHSNS.SQLServerImplement;

namespace CHSNS.Operator
{
    using System.Linq;
    using System;
    using Model;
    using System.Collections.Generic;
    public class FriendOperator : BaseOperator, IFriendOperator
    {

        #region ��ȡ
        public IProfile UserFriendInfo(long userId)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from p in db.Profile
                           where p.UserId == userId
                           select new
                           {
                               UserID = userId,
                               //   p.FriendCount,
                               p.Name
                           }).FirstOrDefault();
                return new Profile
                {
                    UserId = ret.UserID,
                    //	FriendCount = ret.FriendCount,
                    Name = ret.Name
                };
            }
        }
        public List<long> GetFriendsId(long userid)
        {
            return QueryToList<long>("FriendsId", userid).ToList();
        }
        public PagedList<UserItemPas> GetFriends(long uid, int page, int pageSize)
        {

            var friends = QueryToList<IProfile>("GetFriendsPaged",
                                                new Hashtable 
                                                    {
                                                        {"Begin", (page - 1)*pageSize + 1},
                                                        {"End", page*pageSize},
                                                        {"UserId", uid}
                                                    });
            var totalCount = Query<int>("GetFriendsCount", uid);
            var ret = new PagedList<UserItemPas>(friends.Select(c => new UserItemPas
                                                                         {
                                                                             Id = c.UserId,
                                                                             Name = c.Name
                                                                         }),
                                                 page,
                                                 pageSize,
                                                 totalCount);
            return ret;
        }

        public List<UserItemPas> GetRandoms(int n)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from p in db.Profile
                           where p.Status.Equals(RoleType.General)
                           orderby db.Newid()
                           select new UserItemPas
                           {
                               Id = p.UserId,
                               Name = p.Name,
                           }).Take(n);
                return ret.ToList();
            }
        }

        public PagedList<UserItemPas> GetRequests(long userid, int page, int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from f1 in db.Friend
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
                return ret.Pager(page,pageSize);//, Site.EveryPage.FriendRequest);
            }
        }
        #endregion
        /// <summary>
        /// ��Ϊ����
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <returns>�Ѿ��Ǻ����򷵻�False����������ǣ��򷵻�True��������һ����������</returns>
        public bool Add(long fromId, long toId)
        {
            using (var db = DBExtInstance)
            {
                var f = db.Friend.FirstOrDefault(
                    c =>
                    (c.ToId == toId && c.FromId == fromId)
                    ||
                    (c.ToId == fromId && c.FromId == toId)
                    );
                if (f == null)
                {
                    db.Friend.InsertOnSubmit(
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
                db.SubmitChanges();
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
            using (var db = DBExtInstance)
            {
                var f = db.Friend.FirstOrDefault(
                    c =>
                    (c.ToId == toId && c.FromId == fromId)
                    ||
                    (c.ToId == fromId && c.FromId == toId)
                    &&
                    c.IsTrue
                    );
                db.Friend.DeleteOnSubmit(f);
                db.SubmitChanges();
            }
            return true;
        }

        /// <summary>
        /// Agrees the friend request.
        /// </summary>
        /// <param name="operaterId">The operater ID.</param>
        /// <param name="toId">To ID.</param>
        /// <returns></returns>
        public bool Agree(long operaterId, long toId)
        {
            //string name;
            using (var db = DBExtInstance)
            {
                var f = db.Friend.FirstOrDefault(
                    c =>
                    (c.ToId == toId && c.FromId == operaterId) ||
                    (c.ToId == operaterId && c.FromId == toId) && !c.IsTrue
                    );
                if (f == null) return false;
                f.IsTrue = true;
                db.SubmitChanges();
            }
            //  name = db.Profile.Where(q => q.UserId == toId).Select(q => q.Title).FirstOrDefault();
            //DBExt.Event.Add(new Event
            //                    {
            //                        OwnerID = toId,
            //                        ViewerID = operaterId,
            //                        TemplateName = "MakeFriend",
            //                        AddTime = DateTime.Now,
            //                        ShowLevel = 0,
            //                        Json =
            //                            Dictionary.CreateFromArgs("ownername", name, "sendername", CHUser.Username).
            //                            ToJsonString()
            //                    }
            //    );
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
            using (var db = DBExtInstance)
            {
                var f = db.Friend.FirstOrDefault(c => c.ToId == operaterId && c.FromId == fromId && !c.IsTrue);
                if (f == null) return false;
                db.Friend.DeleteOnSubmit(f);
                db.SubmitChanges();
                return true;
            }
        }
        public bool IgnoreAll(long userId)
        {
            using (var db = DBExtInstance)
            {
                var f = db.Friend.Where(c => c.ToId == userId && !c.IsTrue);
                db.Friend.DeleteAllOnSubmit(f);
                db.SubmitChanges();
                return true;
            }
        }
    }
}