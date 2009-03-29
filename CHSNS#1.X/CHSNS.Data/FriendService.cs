namespace CHSNS.Service
{
    using System.Linq;
    using Models;
    using System;
    using Model;
    using System.Collections.Generic;
    public class FriendService : BaseService, IFriendService
    {
        public FriendService(IDBManager id) : base(id) { }
        #region 获取
        public Profile UserFriendInfo(long userid)
        {
            using (var db = DBExt.Instance)
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
        public IList<long> GetFriendsID(long userid)
        {
            using (var db = DBExt.Instance)
            {
                return (from f1 in db.Friend
                        where f1.FromID == userid && f1.IsTrue
                        select f1.ToID)
                                   .Union(from f1 in db.Friend
                                          where f1.ToID == userid && f1.IsTrue
                                          select f1.FromID).ToList();
            }
        }
        public PagedList<UserItemPas> GetFriends(long uid, int p)
        {
            var ids = GetFriendsID(uid);
            using (var db = DBExt.Instance)
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
                #region    注

                //var ret = (from c in
                //               (from f1 in DBExt.DB.Friend
                //                join p1 in DBExt.DB.Profile on f1.ToID equals p1.UserID
                //                where f1.FromID == userid && f1.IsTrue
                //                select new {
                //                    p1.UserID,
                //                    p1.Name,
                //                    p1.ShowText,
                //                    p1.ShowTextTime
                //                })
                //               .Union(from f1 in DBExt.DB.Friend
                //                      join p1 in DBExt.DB.Profile on f1.FromID equals p1.UserID
                //                      where f1.ToID == userid && f1.IsTrue
                //                      select new {
                //                          p1.UserID,
                //                          p1.Name,
                //                          p1.ShowText,
                //                          p1.ShowTextTime
                //                      })
                //           orderby c.UserID descending
                //           select new UserItemPas {
                //               ID = c.UserID,
                //               Name = c.Name,
                //               ShowText = c.ShowText,
                //               ShowTextTime = c.ShowTextTime
                //           });
                #endregion
                return ret.Pager(p, Site.EveryPage.Friend);

            }
        }

        public IList<UserItemPas> GetRandoms(int n)
        {
            using (var db = DBExt.Instance)
            {
                var ret = (from p in db.Profile
                           where p.Status.Equals(RoleType.General)
                           orderby db.NEWID()
                           select new UserItemPas
                           {
                               ID = p.UserID,
                               Name = p.Name,
                           }).Take(n);
                return ret.ToList();
            }
        }

        public PagedList<UserItemPas> GetRequests(long userid, int p)
        {
            using (var db = DBExt.Instance)
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
                return ret.Pager(p, Site.EveryPage.FriendRequest);
            }
        }
        #endregion
        /// <summary>
        /// 加为好友
        /// </summary>
        /// <param name="FromID"></param>
        /// <param name="ToID"></param>
        /// <returns>已经是好友则返回False，如果还不是，则返回True，并发送一个好友请求</returns>
        public bool Add(long FromID, long ToID)
        {
            using (var db = DBExt.Instance)
            {
                var f = db.Friend.FirstOrDefault(
                    c =>
                    (c.ToID == ToID && c.FromID == FromID)
                    ||
                    (c.ToID == FromID && c.FromID == ToID)
                    );
                if (f == null)
                {
                    db.Friend.InsertOnSubmit(
                        new Friend
                            {
                                FromID = FromID,
                                ToID = ToID,
                                IsTrue = false,
                                IsCommon = true
                            });
                }
                else
                {//update
                    if (f.FromID == ToID)
                        f.IsTrue = true;
                }
                db.SubmitChanges();
            }
            return true;
        }

        /// <summary>
        /// Deletes the specified from ID.
        /// </summary>
        /// <param name="FromID">From ID.</param>
        /// <param name="ToID">To ID.</param>
        /// <returns></returns>
        public bool Delete(long FromID, long ToID)
        {
            var fin = DataBaseExecutor.Execute(
                @"DELETE FROM Friend
WHERE (fromid=@FromID and toid=@ToID)or (toid=@fromid and fromid=@toid) and istrue=1",
                "@fromid", FromID, "@toid", ToID);
            if (fin == 1)
            {
                DataBaseExecutor.Execute(
                    @"update [Profile] 
set friendcount=friendcount-1
where userid=@fromid or userid =@toid", "@fromid", FromID,
                    "@toid", ToID);
                return true;
            }
            return true;
        }

        /// <summary>
        /// Agrees the friend request.
        /// </summary>
        /// <param name="OperaterID">The operater ID.</param>
        /// <param name="ToID">To ID.</param>
        /// <returns></returns>
        public bool Agree(long OperaterID, long ToID)
        {
            var fin =
                DataBaseExecutor.Execute(
                    @"update [Friend] set istrue=1 
where istrue=0 and ((fromid=@fromid and toid=@toid) or (toid=@fromid and fromid=@toid))",
                    "@fromid", OperaterID, "@toid", ToID);
            if (fin == 1)
            {
                DataBaseExecutor.Execute(
                    @"update [Profile] 
set friendcount=friendcount+1
where userid=@fromid or userid =@toid", "@fromid", OperaterID,
                    "@toid", ToID);
                DataBaseExecutor.Execute(@"update [profile] set friendrequestcount=friendrequestcount-1 where userid=@userid",
                    "@userid", OperaterID);

                string name;
                using (var db = DBExt.Instance)
                {
                    name = db.Profile.Where(q => q.UserID == ToID).Select(q => q.Name).FirstOrDefault();
                }
                DBExt.Event.Add(new Event
                {
                    OwnerID = ToID,
                    ViewerID = OperaterID,
                    TemplateName = "MakeFriend",
                    AddTime = DateTime.Now,
                    ShowLevel = 0,
                    Json = Dictionary.CreateFromArgs("ownername", name, "sendername", CHUser.Username).ToJsonString()
                }
                );
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ignores friend request
        /// </summary>
        /// <param name="FromID">From ID.</param>
        /// <param name="operaterID">The operater ID.</param>
        /// <returns></returns>
        public bool Ignore(long FromID, long operaterID)
        {
            using (var db = DBExt.Instance)
            {
                var f = db.Friend.FirstOrDefault(c => c.ToID == operaterID && c.FromID == FromID && !c.IsTrue);
                if (f == null) return false;
                db.Friend.DeleteOnSubmit(f);
                db.SubmitChanges();
                return true;
            }
        }
        public bool IgnoreAll(long UserID)
        {
            using (var db = DBExt.Instance)
            {
                var f = db.Friend.Where(c => c.ToID == UserID && !c.IsTrue);
                db.Friend.DeleteAllOnSubmit(f);
                db.SubmitChanges();
                return true;
            }
        }
    }
}