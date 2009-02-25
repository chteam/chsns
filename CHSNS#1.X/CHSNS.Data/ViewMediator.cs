using System.Linq;
using System;
using CHSNS.ModelPas;

namespace CHSNS.Data {
	public class ViewMediator : BaseMediator, IViewMediator {
		public ViewMediator(IDBManager id) : base(id) { }
		public ViewListPas ViewList(byte type, int everyrow, long ownerid, int count) {
			IQueryable<UserItemPas> lu;
			switch (type) {
				case 2:
					//最近登录的好友
					lu =
						(from f in DBExt.DB.Friend
						 join p in DBExt.DB.Profile on f.ToID equals p.UserID
						 where f.FromID == ownerid && f.IsTrue
						 orderby p.LoginTime descending
						 select new UserItemPas {
							 ID = p.UserID,
							 Name = p.Name
						 }
						).Union(
							from f in DBExt.DB.Friend
							join p in DBExt.DB.Profile on f.FromID equals p.UserID
							where f.ToID == ownerid && f.IsTrue
							orderby p.LoginTime descending
							select new UserItemPas {
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

					lu = (from v in DBExt.DB.ViewData
						  join p in DBExt.DB.Profile on v.ViewerID equals p.UserID
						  where v.OwnerID == ownerid && v.ViewClass == type
						  orderby v.ViewTime descending
						  select new UserItemPas {
							  Name = p.Name,
							  ID = p.UserID
						  }
								 );
					break;
				case 3:
					//--3全站人气之星
					lu = (from p in
							  (from p in DBExt.DB.Profile
							   where !p.Status.Equals(RoleType.Locked)
							   orderby p.UserID descending
							   select p
							  ).Take(10)
						  select new UserItemPas {
							  Name = p.Name,
							  ID = p.UserID
						  })
						;
					break;
				case 4:
					//--新人榜
					lu = (from p in
							  (from p in DBExt.DB.Profile
							   where !p.Status.Equals(RoleType.Locked)
							   orderby p.RegTime descending
							   select p
							  ).Take(10)

						  select new UserItemPas {
							  Name = p.Name,
							  ID = p.UserID
						  });
					break;
				default://if (type==6)//--群用户随机
					lu = (from u in DBExt.DB.GroupUser
						  join p in DBExt.DB.Profile on u.UserID equals p.UserID
						  where u.GroupID == ownerid && u.Status!=(int)GroupUserStatus.Lock
						  orderby p.LoginTime descending
						  select new UserItemPas {
							  Name = p.Name,
							  ID = p.UserID
						  }
						 );
					break;
			}
			return new ViewListPas {
				EveryRow = everyrow,
				Rows = lu.Take(count).ToList()
			};
		}

		public void ViewCreate(byte type, int everyrow, long ownerid) {
			if (ownerid == CHUser.UserID) return;


			var x = DataBaseExecutor.Execute(@"UPDATE [ViewData] SET ViewTime = @now
WHERE (Ownerid = @ownerid) AND (Viewerid = @viewerid) AND (ViewClass = @viewclass)"
					, "@now", DateTime.Now
					, "@ownerid", ownerid
					, "@viewerid", CHUser.UserID
					, "@viewclass", type
					);

			if (x == 0) {
				switch (type) {
					case 0:
						DataBaseExecutor.Execute(@"UPDATE [profile]
SET ViewCount = ViewCount + 1 
WHERE [profile].UserID = @ownerid", "@ownerid", ownerid);
						break;
					case 1:
						DataBaseExecutor.Execute(@"UPDATE    [group]
			SET              ViewCount = ViewCount + 1 
			WHERE     ([group].Id = @ownerid)", "@ownerid", ownerid);
						break;
					case 5:
						DataBaseExecutor.Execute(@"UPDATE    [Note]
			SET              ViewCount = ViewCount + 1 
			WHERE     ([Note].Id = @ownerid)", "@ownerid", ownerid);
						break;
					default:
						break;
				}
				//更新相关数据完毕
				var num = DataBaseExecutor.Execute(@"UPDATE [ViewData]
SET ViewTime = @now,Viewerid = @viewerid
WHERE ID IN	(SELECT top (1) [id] FROM ViewData WHERE  Ownerid = @ownerid AND ViewClass = @viewclass
order by ViewTime) and @num < All(SELECT count(1) FROM ViewData WHERE  Ownerid = @ownerid and viewclass=@viewclass)"
					, "@now", DateTime.Now
					, "@ownerid", ownerid
					, "@viewerid", CHUser.UserID
					, "@viewclass", type
					, "@num", 50
					);
				if (num == 0) {
					DataBaseExecutor.Execute(@"INSERT INTO ViewData(Viewerid, Ownerid, ViewTime,viewclass)
VALUES(@Viewerid,@ownerid, @now,@viewclass)"
						, "@now", DateTime.Now
					, "@ownerid", ownerid
					, "@viewerid", CHUser.UserID
					, "@viewclass", type);
				}
			}
		}
	}
}
