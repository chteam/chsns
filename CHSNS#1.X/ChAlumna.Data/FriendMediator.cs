using System.Linq;

namespace CHSNS.Data {
	using System.Linq;
	using Models;
	public class FriendMediator : BaseMediator {
		public FriendMediator(DBExt id) : base(id) { }

		public Profile UserFriendInfo(long userid) {
			var ret = (from p in DBExt.DB.Profile
					   where p.UserID == userid
					   select new {
						   UserID = userid,
						   p.FriendCount,
						   p.Name
					   }).SingleOrDefault();
			return new Profile {
				UserID = ret.UserID,
				FriendCount = ret.FriendCount,
				Name = ret.Name
			};
		}

		public IQueryable<UserItemPas> GetFriends(long userid) {
			var ret = (from c in
			           	(from f1 in DBExt.DB.Friend
			           	 join p1 in DBExt.DB.Profile on f1.ToID equals p1.UserID
			           	 where f1.FromID == userid && f1.IsTrue
			           	 select new{
			           	           	p1.UserID,
			           	           	p1.Name,
			           	           	p1.ShowText,
			           	           	p1.ShowTextTime
			           	           })
			           	.Union(from f1 in DBExt.DB.Friend
			           	       join p1 in DBExt.DB.Profile on f1.FromID equals p1.UserID
			           	       where f1.ToID == userid && f1.IsTrue
			           	       select new{
			           	                 	p1.UserID,
			           	                 	p1.Name,
			           	                 	p1.ShowText,
			           	                 	p1.ShowTextTime
			           	                 })
			           orderby c.UserID descending
			           select new UserItemPas{
			                                 	UserID = c.UserID,
			                                 	Name = c.Name,
			                                 	ShowText = c.ShowText,
			                                 	ShowTextTime = c.ShowTextTime
			                                 });
			return ret;
		}

		public IQueryable<UserItemPas> GetRandoms() {
			var ret = (from p in DBExt.DB.Profile
					   where p.IsStar
					   orderby DBExt.DB.NEWID()
					   select new UserItemPas {
						   UserID = p.UserID,
						   Name = p.Name,
						   ShowText = p.ShowText,
						   ShowTextTime = p.ShowTextTime
					   }
					  ).Take(10);
			return ret;
		}

		public IQueryable<UserItemPas> GetRequests(long userid) {
			var ret = (from f1 in DBExt.DB.Friend
					   join p1 in DBExt.DB.Profile on f1.FromID equals p1.UserID
					   where f1.ToID == userid && !f1.IsTrue
					   orderby p1.UserID descending
					   select new UserItemPas {
						   UserID = p1.UserID,
						   Name = p1.Name,
						   ShowText = p1.ShowText,
						   ShowTextTime = p1.ShowTextTime
					   });
			return ret;
		}

	}
}