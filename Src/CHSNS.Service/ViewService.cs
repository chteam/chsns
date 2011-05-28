
namespace CHSNS.Service
{
    using System.Linq;
    using CHSNS.Model;
    using System;
    using CHSNS.Models;
    using System.Threading.Tasks;
    using System.ComponentModel.Composition;
    [Export]
    public class ViewService : BaseService<ViewService>
    {
        public ViewListPas ViewList(byte type, int everyRow, long ownerId, int count)
        {
            using (var db = DbInstance)
            {
                IQueryable<UserItemPas> lu;
                switch (type)
                {
                    case 2:
                        //最近登录的好友
                        lu =
                            (from f in db.Friends
                             join p in db.Profile on f.ToId equals p.UserId
                             where f.FromId == ownerId && f.IsTrue
                             orderby p.LoginTime descending
                             select new UserItemPas
                             {
                                 Id = p.UserId,
                                 Name = p.Name
                             }
                            ).Union(
                                from f in db.Friends
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
        public void Update(VisitLogType type, long ownerId, IUser user)
        {
            Parallel.Invoke(() =>
            {
                UpdateMethod(type, ownerId, user);
            });
        }
        
        private void UpdateMethod(VisitLogType type, long ownerId, IUser user)
        {            
            if (ownerId == user.UserId) return;
            var intType = (byte)type;
            using (var db = DbInstance)
            {
                #region old
                
                //var vd = db.ViewData.FirstOrDefault(c =>
                //                                    c.ViewClass == intType
                //                                    && c.ViewerId == myId
                //                                    && c.OwnerId == ownerid
                //                                    );
                //if (null != vd) return;
                #endregion
                var x = db.Database.ExecuteSqlCommand(
@"UPDATE [ViewData] SET ViewTime=getdate() WHERE Ownerid=@p0 AND Viewerid=@p1 AND ViewClass=@p2"
        , ownerId, user.UserId, intType);

                if (x == 0) {
                    db.Database.ExecuteSqlCommand(
@"INSERT INTO ViewData(Viewerid, Ownerid, ViewTime,viewclass)VALUES(@p0,@p1, getdate(),@p2)"
, user.UserId, ownerId, intType);
                }
                #region UPDATE Details
                
                switch (type)
                {
                    case VisitLogType.Profile:
                        db.Database.ExecuteSqlCommand(
    @"UPDATE [profile] SET ViewCount+=1 WHERE [profile].UserId=@p0", ownerId);
                        break;
                    case VisitLogType.Group:
                        db.Database.ExecuteSqlCommand(
                            @"UPDATE [group] SET ViewCount+=1 WHERE Id=@p0", ownerId);
                        break;
                    case VisitLogType.Note:
                        db.Database.ExecuteSqlCommand(
                            @"UPDATE [Note] SET ViewCount+=1 WHERE Id=@p0", ownerId);
                        break;
                    default:
                        break;
                }
                //更新相关数据完毕
                #endregion
                #region old

                //var vds = db.ViewData.Where(c => c.OwnerId == ownerid &&
                //                                 c.ViewClass == intType)
                //                                 .OrderByDescending(c => c.ViewTime)
                //                                 .Take(50);
                //var v = vds.LastOrDefault();
                //if (null != v)
                //{
                //    v.ViewerId = myId;
                //    v.ViewTime = DateTime.Now;
                //}
                //#region sql

                ////                var num =
                ////                    DataBaseExecutor.Execute(
                ////                        @"UPDATE [ViewData]
                ////SET ViewTime = @now,Viewerid = @viewerid
                ////WHERE ID IN	(SELECT top (1) [id] FROM ViewData
                ////WHERE  Ownerid = @ownerid AND ViewClass = @viewclass
                ////order by ViewTime) 
                ////and 
                ////@num < All(SELECT count(1) FROM ViewData WHERE 
                ////Ownerid = @ownerid and viewclass=@viewclass)"
                ////                        , "@now", DateTime.Now
                ////                        , "@ownerid", ownerid
                ////                        , "@viewerid", CHUser.UserId
                ////                        , "@viewclass", type
                ////                        , "@num", 50
                ////                        );
                //#endregion
                //db.SaveChanges();

                #endregion
            }
        }
    }
}
