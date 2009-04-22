using System.Linq;
using System;
using CHSNS.Model;

namespace CHSNS.Operator
{
    public class ViewOperator : BaseOperator, IViewOperator
    {
        public ViewListPas ViewList(byte type, int everyrow, long ownerid, int count)
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
                             join p in db.Profile on f.ToID equals p.UserID
                             where f.FromID == ownerid && f.IsTrue
                             orderby p.LoginTime descending
                             select new UserItemPas
                                        {
                                            ID = p.UserID,
                                            Name = p.Name
                                        }
                            ).Union(
                                from f in db.Friend
                                join p in db.Profile on f.FromID equals p.UserID
                                where f.ToID == ownerid && f.IsTrue
                                orderby p.LoginTime descending
                                select new UserItemPas
                                           {
                                               ID = p.UserID,
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
                              join p in db.Profile on v.ViewerID equals p.UserID
                              where v.OwnerID == ownerid && v.ViewClass == type
                              orderby v.ViewTime descending
                              select new UserItemPas
                                         {
                                             Name = p.Name,
                                             ID = p.UserID
                                         }
                             );
                        break;
                    case 3:
                        //--3全站人气之星
                        lu = (from p in
                                  (from p in db.Profile
                                   where !p.Status.Equals(RoleType.Locked)
                                   orderby p.UserID descending
                                   select p
                                  ).Take(10)
                              select new UserItemPas
                                         {
                                             Name = p.Name,
                                             ID = p.UserID
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
                                             ID = p.UserID
                                         });
                        break;
                    default: //if (type==6)//--群用户随机
                        lu = (from u in db.GroupUser
                              join p in db.Profile on u.UserID equals p.UserID
                              where u.GroupID == ownerid && u.Status != (int)GroupUserStatus.Wait
                              orderby p.LoginTime descending
                              select new UserItemPas
                                         {
                                             Name = p.Name,
                                             ID = p.UserID
                                         }
                             );
                        break;
                }
                return new ViewListPas
                           {
                               EveryRow = everyrow,
                               Rows = lu.Take(count).ToList()
                           };
            }
        }

        public void Update(byte type, long ownerid, long myId)
        {
            if (ownerid == myId) return;
            using (var db = DBExtInstance)
            {
                var vd = db.ViewData.FirstOrDefault(c =>
                                                    c.ViewClass == type && c.ViewerID == myId &&
                                                    c.OwnerID == ownerid);
                if (null != vd) return;

                #region sql
//                var x =
//    DataBaseExecutor.Execute(
//        @"UPDATE [ViewData] SET ViewTime = @now
//WHERE (Ownerid = @ownerid) AND (Viewerid = @viewerid) AND (ViewClass = @viewclass)"
//        , "@now", DateTime.Now
//        , "@ownerid", ownerid
//        , "@viewerid", CHUser.UserID
//        , "@viewclass", type
//        );
                #endregion
                switch (type)
                {
                    case 0:
                        var p = db.Profile.FirstOrDefault(c => c.UserID == ownerid);
                        if (p != null) p.ViewCount++;
                        #region sql
//                                                DataBaseExecutor.Execute(
//                            @"UPDATE [profile]
//SET ViewCount = ViewCount + 1 
//WHERE [profile].UserID = @ownerid",
//                            "@ownerid", ownerid);
                        #endregion
                        break;
                    case 1:
                        var g = db.Group.FirstOrDefault(c => c.ID == ownerid);
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
                        var n = db.Note.FirstOrDefault(c => c.ID == ownerid);
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
                var vds = db.ViewData.Where(c => c.OwnerID == ownerid &&
                                                 c.ViewClass == type).OrderByDescending(c => c.ViewTime).Take(50);
                var v = vds.LastOrDefault();
                if(null!=v)
                {
                    v.ViewerID = myId;
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
//                        , "@viewerid", CHUser.UserID
//                        , "@viewclass", type
//                        , "@num", 50
//                        );
                #endregion
                if (vds.Count() <50)
                {
                    db.ViewData.InsertOnSubmit(new ViewData
                                                   {
                                                       ViewerID = myId,
                                                       OwnerID = ownerid,
                                                       ViewClass = type,
                                                       ViewTime = DateTime.Now
                                                   });
                    #region sql
//                                       DataBaseExecutor.Execute(
//                        @"INSERT INTO ViewData(Viewerid, Ownerid, ViewTime,viewclass)
//VALUES(@Viewerid,@ownerid, @now,@viewclass)"
//                        , "@now", DateTime.Now
//                        , "@ownerid", ownerid
//                        , "@viewerid", CHUser.UserID
//                        , "@viewclass", type);
                    #endregion
 
                }
                db.SubmitChanges();
            }
        }
    }
}
