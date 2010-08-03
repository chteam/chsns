using System.Linq;
using CHSNS.Model;
using System;
using CHSNS.Models;
namespace CHSNS.Service
{
    public class ViewService : BaseService<ViewService>
    {
        public ViewListPas ViewList(byte type, int everyRow, long ownerId, int count)
        {
            using (var db = DBExtInstance)
            {
                IQueryable<UserItemPas> lu;
                switch (type)
                {
                    case 2:
                        //最近登录的好友
                        lu =
                            (from f in db.Friend
                             join p in db.Profile on f.ToId equals p.UserId
                             where f.FromId == ownerId && f.IsTrue
                             orderby p.LoginTime descending
                             select new UserItemPas
                             {
                                 Id = p.UserId,
                                 Name = p.Name
                             }
                            ).Union(
                                from f in db.Friend
                                join p in db.Profile on f.FromId equals p.UserId
                                where f.ToId == ownerId && f.IsTrue
                                orderby p.LoginTime descending
                                select new UserItemPas
                                {
                                    Id = p.UserId,
                                    Name = p.Name
                                }
                                )
                            ;
                        break;
                    case 1:
                    case 0:
                    case 5:
                        //--viewclass=0页面 1群 若是群那个Userid即为Groupid
                        //		为5时为日志浏览ownerid 为logid

                        lu = (from v in db.ViewData
                              join p in db.Profile on v.ViewerId equals p.UserId
                              where v.OwnerId == ownerId && v.ViewClass == type
                              orderby v.ViewTime descending
                              select new UserItemPas
                              {
                                  Name = p.Name,
                                  Id = p.UserId
                              }
                             );

                        break;

                    case 3:
                        //--3全站人气之星
                        lu = (from p in
                                  (from p in db.Profile
                                   where !p.Status.Equals(RoleType.Locked)
                                   orderby p.UserId descending
                                   select p
                                  ).Take(10)
                              select new UserItemPas
                              {
                                  Name = p.Name,
                                  Id = p.UserId
                              })
                            ;
                        break;
                    case 4:
                        //--新人榜
                        lu = (from p in
                                  (from p in db.Profile
                                   where !p.Status.Equals(RoleType.Locked)
                                   orderby p.RegTime descending
                                   select p
                                  ).Take(10)

                              select new UserItemPas
                              {
                                  Name = p.Name,
                                  Id = p.UserId
                              });
                        break;
                    default: //if (type==6)//--群用户随机
                        lu = (from u in db.GroupUser
                              join p in db.Profile on u.UserId equals p.UserId
                              where u.GroupId == ownerId && u.Status != (int)GroupUserStatus.Wait
                              orderby p.LoginTime descending
                              select new UserItemPas
                              {
                                  Name = p.Name,
                                  Id = p.UserId
                              }
                             );
                        break;
                }
                return new ViewListPas
                {
                    EveryRow = everyRow,
                    Rows = lu.Take(count).ToList()
                };
            }
        }

        public void Update(byte type, long ownerid, IUser user)
        {
            var myId = user.UserId;
            if (ownerid == myId) return;
            using (var db = DBExtInstance)
            {
                var vd = db.ViewData.FirstOrDefault(c =>
                                                    c.ViewClass == type && c.ViewerId == myId &&
                                                    c.OwnerId == ownerid);
                if (null != vd) return;

                #region sql
                //                var x =
                //    DataBaseExecutor.Execute(
                //        @"UPDATE [ViewData] SET ViewTime = @now
                //WHERE (Ownerid = @ownerid) AND (Viewerid = @viewerid) AND (ViewClass = @viewclass)"
                //        , "@now", DateTime.Now
                //        , "@ownerid", ownerid
                //        , "@viewerid", CHUser.UserId
                //        , "@viewclass", type
                //        );
                #endregion
                switch (type)
                {
                    case 0:
                        var p = db.Profile.FirstOrDefault(c => c.UserId == ownerid);
                        if (p != null) p.ViewCount++;
                        #region sql
                        //                                                DataBaseExecutor.Execute(
                        //                            @"UPDATE [profile]
                        //SET ViewCount = ViewCount + 1 
                        //WHERE [profile].UserId = @ownerid",
                        //                            "@ownerid", ownerid);
                        #endregion
                        break;
                    case 1:
                        var g = db.Group.FirstOrDefault(c => c.Id == ownerid);
                        if (g != null) g.ViewCount++;
                        #region sql
                        //                        DataBaseExecutor.Execute(
                        //                            @"UPDATE    [group]
                        //			SET              ViewCount = ViewCount + 1 
                        //			WHERE     ([group].Id = @ownerid)",
                        //                            "@ownerid", ownerid);

                        #endregion
                        break;
                    case 5:
                        var n = db.Note.FirstOrDefault(c => c.Id == ownerid);
                        if (n != null) n.ViewCount++;
                        #region sql
                        //                        DataBaseExecutor.Execute(
                        //                            @"UPDATE    [N ote]
                        //			SET              ViewCount = ViewCount + 1 
                        //			WHERE     ([No te].Id = @ownerid)",
                        //                            "@ownerid", ownerid);
                        #endregion

                        break;
                    default:
                        break;
                }
                //更新相关数据完毕
                var vds = db.ViewData.Where(c => c.OwnerId == ownerid &&
                                                 c.ViewClass == type).OrderByDescending(c => c.ViewTime).Take(50);
                var v = vds.LastOrDefault();
                if (null != v)
                {
                    v.ViewerId = myId;
                    v.ViewTime = DateTime.Now;
                }
                #region sql

                //                var num =
                //                    DataBaseExecutor.Execute(
                //                        @"UPDATE [ViewData]
                //SET ViewTime = @now,Viewerid = @viewerid
                //WHERE ID IN	(SELECT top (1) [id] FROM ViewData
                //WHERE  Ownerid = @ownerid AND ViewClass = @viewclass
                //order by ViewTime) 
                //and 
                //@num < All(SELECT count(1) FROM ViewData WHERE 
                //Ownerid = @ownerid and viewclass=@viewclass)"
                //                        , "@now", DateTime.Now
                //                        , "@ownerid", ownerid
                //                        , "@viewerid", CHUser.UserId
                //                        , "@viewclass", type
                //                        , "@num", 50
                //                        );
                #endregion
                if (vds.Count() < 50)
                {
                    db.ViewData.AddObject(new ViewData
                    {
                        ViewerId = myId,
                        OwnerId = ownerid,
                        ViewClass = type,
                        ViewTime = DateTime.Now
                    });
                    #region sql
                    //                                       DataBaseExecutor.Execute(
                    //                        @"INSERT INTO ViewData(Viewerid, Ownerid, ViewTime,viewclass)
                    //VALUES(@Viewerid,@ownerid, @now,@viewclass)"
                    //                        , "@now", DateTime.Now
                    //                        , "@ownerid", ownerid
                    //                        , "@viewerid", CHUser.UserId
                    //                        , "@viewclass", type);
                    #endregion

                }
                db.SaveChanges();
            }
        }
    }
}
