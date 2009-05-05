using CHSNS.Abstractions;

namespace CHSNS.Operator
{
    using System.Linq;
    using System;
    using Model;
    using System.Collections.Generic;
    public class FriendOperator : BaseOperator, IFriendOperator
    {

        #region ��ȡ
        public IProfile UserFriendInfo(long userid)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from p in db.Profile
                           where p.UserID == userid
                           select new
                           {
                               UserID = userid,
                               //   p.FriendCount,
                               p.Name
                           }).FirstOrDefault();
                return new Profile
                {
                    UserID = ret.UserID,
                    //	FriendCount = ret.FriendCount,
                    Name = ret.Name
                };
            }
        }
        public List<long> GetFriendsId(long userid)
        {
            using (var db = DBExtInstance)
            {
                return (from f1 in db.Friend
                        where f1.FromID == userid && f1.IsTrue
                        select f1.ToID)
                                   .Union(from f1 in db.Friend
                                          where f1.ToID == userid && f1.IsTrue
                                          select f1.FromID).ToList();
            }
        }
        public PagedList<UserItemPas> GetFriends(long uid, int page,int pageSize)
        {
            var ids = GetFriendsId(uid);
            using (var db = DBExtInstance)
            {
                var ret = (from c in db.Profile
                           where ids.Contains(c.UserID)
                           orderby c.UserID
                           select new UserItemPas
                           {
                               ID = c.UserID,
                               Name = c.Name,
                               //   ShowText = c.ShowText,
                               //   ShowTextTime = c.ShowTextTime
                           });
                #region    ע

                //var ret = (from c in
                //               (from f1 in DBExt.DB.Friend
                //                join p1 in DBExt.DB.Profile on f1.ToID equals p1.UserId
                //                where f1.FromID == userid && f1.IsTrue
                //                select new {
                //                    p1.UserId,
                //                    p1.Title,
                //                    p1.ShowText,
                //                    p1.ShowTextTime
                //                })
                //               .Union(from f1 in DBExt.DB.Friend
                //                      join p1 in DBExt.DB.Profile on f1.FromID equals p1.UserId
                //                      where f1.ToID == userid && f1.IsTrue
                //                      select new {
                //                          p1.UserId,
                //                          p1.Title,
                //                          p1.ShowText,
                //                          p1.ShowTextTime
                //                      })
                //           orderby c.UserId descending
                //           select new UserItemPas {
                //               ID = c.UserId,
                //               Title = c.Title,
                //               ShowText = c.ShowText,
                //               ShowTextTime = c.ShowTextTime
                //           });
                #endregion
                return ret.Pager(page,pageSize);// Site.EveryPage.Friend);

            }
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
                               ID = p.UserID,
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
                           join p1 in db.Profile on f1.FromID equals p1.UserID
                           where f1.ToID == userid && !f1.IsTrue
                           orderby p1.UserID descending
                           select new UserItemPas
                           {
                               ID = p1.UserID,
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
                    (c.ToID == toId && c.FromID == fromId)
                    ||
                    (c.ToID == fromId && c.FromID == toId)
                    );
                if (f == null)
                {
                    db.Friend.InsertOnSubmit(
                        new Friend
                            {
                                FromID = fromId,
                                ToID = toId,
                                IsTrue = false,
                                IsCommon = true
                            });
                }
                else
                {//update
                    if (f.FromID == toId)
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
                    (c.ToID == toId && c.FromID == fromId)
                    ||
                    (c.ToID == fromId && c.FromID == toId)
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
                    (c.ToID == toId && c.FromID == operaterId) ||
                    (c.ToID == operaterId && c.FromID == toId) && !c.IsTrue
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
                var f = db.Friend.FirstOrDefault(c => c.ToID == operaterId && c.FromID == fromId && !c.IsTrue);
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
                var f = db.Friend.Where(c => c.ToID == userId && !c.IsTrue);
                db.Friend.DeleteAllOnSubmit(f);
                db.SubmitChanges();
                return true;
            }
        }
    }
}