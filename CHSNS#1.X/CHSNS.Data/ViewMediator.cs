using System.Linq;
using CHSNS.Models;

namespace CHSNS.Data {
	public class ViewMediator : BaseMediator {
		public ViewMediator(DBExt id) : base(id) { }
		public ViewListPas ViewList(byte type, int everyrow, long ownerid, int count) {
			IQueryable<UserItemPas> lu;
			if (type == 2) {
				//最近访问的好友
				lu =
					(from f in DBExt.DB.Friend
					 join p in DBExt.DB.Profile on f.ToID equals p.UserID
					 where f.FromID == ownerid && f.IsTrue
					 orderby p.LoginTime descending
					 select new UserItemPas{
					                       	ID = p.UserID,
					                       	Name = p.Name
					                       }
					).Union(
						from f in DBExt.DB.Friend
						join p in DBExt.DB.Profile on f.FromID equals p.UserID
						where f.ToID == ownerid && f.IsTrue
						orderby p.LoginTime descending
						select new UserItemPas{
						                      	ID = p.UserID,
						                      	Name = p.Name
						                      }
						)
				;
			} else if (type == 1 || type == 0 || type == 5) {
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
				if (type == 5) {

					//UPDATE[Log]
					//SET ViewCount = ViewCount + 1
					//WHERE
					//    id = (select
					//id
					//from[log]
					//where id = @ownerid
					//and
					//not userid = @viewerid)
					//end
				}
			} else if (type == 3) {
				//--3全站人气之星
				lu = (from p in
				      	(from p in DBExt.DB.Profile
				      	 where p.IsStar
				      	 orderby p.UserID descending
				      	 select p
				      	).Take(10)
				      select new UserItemPas{
				                            	Name = p.Name,
				                            	ID = p.UserID
				                            })
					;
				
			} else if (type == 4)
			{//--新人榜
				lu = (from p in
						  (from p in DBExt.DB.Profile
						   where p.IsStar
						   orderby p.RegTime descending
						   select p
						  ).Take(10)
					 
					  select new UserItemPas {
						  Name = p.Name,
						  ID = p.UserID
					  });
			} else {//if (type==6)//--群用户随机
				lu = (from u in DBExt.DB.GroupUser
					  join p in DBExt.DB.Profile on u.UserID equals p.UserID
					  where u.GroupID == ownerid && u.IsTrue
					  orderby p.LoginTime descending
					  select new UserItemPas {
						  Name = p.Name,
						  ID = p.UserID
					  }
					 );
			}
			return new ViewListPas {
				EveryRow = everyrow,
				Rows = lu.Take(count).ToList()
			};
			//            --先调用，再将自己插进去，别的地方就不允许出现这个东西了。。。。注意
			//EXECUTE [ViewInsert] --1 3 5时才执行
			//   @viewerid
			//  ,@ownerid
			//  ,@viewclass
		}
	}
}
