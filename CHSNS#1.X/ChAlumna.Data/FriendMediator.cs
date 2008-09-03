using System.Linq;

namespace CHSNS.Data {
	using System.Linq;
	using Models;
	public class FriendMediator : BaseMediator {
		public FriendMediator(DBExt id) : base(id) { }
		#region 获取
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
							select new {
								p1.UserID,
								p1.Name,
								p1.ShowText,
								p1.ShowTextTime
							})
						   .Union(from f1 in DBExt.DB.Friend
								  join p1 in DBExt.DB.Profile on f1.FromID equals p1.UserID
								  where f1.ToID == userid && f1.IsTrue
								  select new {
									  p1.UserID,
									  p1.Name,
									  p1.ShowText,
									  p1.ShowTextTime
								  })
					   orderby c.UserID descending
					   select new UserItemPas {
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
		#endregion
		/// <summary>
		/// 加为好友
		/// </summary>
		/// <param name="FromID"></param>
		/// <param name="ToID"></param>
		/// <returns>已经是好友则返回False，如果还不是，则返回True，并发送一个好友请求</returns>
		public bool Add(long FromID, long ToID) {
			int insret = DataBaseExecutor.Execute(
				@"INSERT INTO Friend (fromid, toid, IsTrue, IsCommon)
select  @fromid, @toid,0, 1 where not exists (select 1 from Friend 
where (fromid=@fromid and toid=@toid) or (toid=@fromid and fromid=@toid))",
				"@fromid", FromID, "@toid", ToID);
			return insret == 1;
		}
		public bool Delete(long FromID,long ToID){
			var fin = DataBaseExecutor.Execute(
				@"DELETE FROM Friend
WHERE (fromid=@FromID and toid=@ToID)or (toid=@fromid and fromid=@toid) and istrue=1",
				"@fromid", FromID, "@toid", ToID);
			if (fin == 1) {
				DataBaseExecutor.Execute(
					@"update [Profile] 
set friendcount=friendcount-1
where userid=@fromid or userid =@toid", "@fromid", FromID,
					"@toid", ToID);
				return true;
			}
			return true;
		}
		public bool Agree(long FromID, long ToID){
			var fin =
				DataBaseExecutor.Execute(
					@"update [Friend] set istrue=1 
where istrue=0 and ((fromid=@fromid and toid=@toid) or (toid=@fromid and fromid=@toid))",
					"@fromid", FromID, "@toid", ToID);
			if (fin == 1){
				DataBaseExecutor.Execute(
					@"update [Profile] 
set friendcount=friendcount+1
where userid=@fromid or userid =@toid", "@fromid", FromID,
					"@toid", ToID);
				return true;
			}
			return false;
		}

		public bool Ignore(long FromID, long ToID) {
			DataBaseExecutor.Execute(@"DELETE FROM Friend
		WHERE toid=@toid and fromid=@fromid and istrue=0", "@toid", ToID,
									 "@fromid", FromID);
			return true;
		}
		public bool IgnoreAll(long UserID) {
			DataBaseExecutor.Execute(@"DELETE FROM Friend
		WHERE toid=@userid and istrue=0", "@userid", UserID);
			return true;
		}
	}
}