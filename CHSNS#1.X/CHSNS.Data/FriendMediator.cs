using System.Linq;

namespace CHSNS.Data {
	using System.Linq;
	using Models;
	using System;
	using ModelPas;
	public class FriendMediator : BaseMediator, IFriendMediator {
		public FriendMediator(IDBManager id) : base(id) { }
		#region 获取
		public Profile UserFriendInfo(long userid) {
			var ret = (from p in DBExt.DB.Profile
					   where p.UserID == userid
					   select new {
						   UserID = userid,
						//   p.FriendCount,
						   p.Name
					   }).FirstOrDefault();
			return new Profile {
				UserID = ret.UserID,
			//	FriendCount = ret.FriendCount,
				Name = ret.Name
			};
		}
		public IQueryable<long> GetFriendsID(long userid) {
			return (from f1 in DBExt.DB.Friend
					where f1.FromID == userid && f1.IsTrue
					select f1.ToID)
							   .Union(from f1 in DBExt.DB.Friend
									  where f1.ToID == userid && f1.IsTrue
									  select f1.FromID);
		}
		public IQueryable<UserItemPas> GetFriends(long userid) {
			var ids=GetFriendsID(userid);
			var ret = (from c in DBExt.DB.Profile
					   where ids.Any(q => q == c.UserID)
					   orderby c.UserID
					   select new UserItemPas {
						   ID = c.UserID,
						   Name = c.Name,
						//   ShowText = c.ShowText,
						//   ShowTextTime = c.ShowTextTime
					   });
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
			return ret;
		}

		public IQueryable<UserItemPas> GetRandoms(){
			var ret = (from p in DBExt.DB.Profile
			           where p.Status.Equals(RoleType.General)
			           orderby DBExt.DB.NEWID()
			           select new UserItemPas {
			                                  	ID = p.UserID,
			                                  	Name = p.Name,
			                                  }).Take(10);
			return ret;
		}

		public IQueryable<UserItemPas> GetRequests(long userid) {
			var ret = (from f1 in DBExt.DB.Friend
					   join p1 in DBExt.DB.Profile on f1.FromID equals p1.UserID
					   where f1.ToID == userid && !f1.IsTrue
					   orderby p1.UserID descending
					   select new UserItemPas {
						   ID = p1.UserID,
						   Name = p1.Name,
						   ShowText = "",
						   ShowTextTime = DateTime.Now
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
			if(insret==1)
				DataBaseExecutor.Execute(@"update [profile] set friendrequestcount=friendrequestcount+1 where userid=@toid","@toid", ToID);
			return insret == 1;
		}

		/// <summary>
		/// Deletes the specified from ID.
		/// </summary>
		/// <param name="FromID">From ID.</param>
		/// <param name="ToID">To ID.</param>
		/// <returns></returns>
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

		/// <summary>
		/// Agrees the friend request.
		/// </summary>
		/// <param name="OperaterID">The operater ID.</param>
		/// <param name="ToID">To ID.</param>
		/// <returns></returns>
		public bool Agree(long OperaterID, long ToID){
			var fin =
				DataBaseExecutor.Execute(
					@"update [Friend] set istrue=1 
where istrue=0 and ((fromid=@fromid and toid=@toid) or (toid=@fromid and fromid=@toid))",
					"@fromid", OperaterID, "@toid", ToID);
			if (fin == 1){
				DataBaseExecutor.Execute(
					@"update [Profile] 
set friendcount=friendcount+1
where userid=@fromid or userid =@toid", "@fromid", OperaterID,
					"@toid", ToID);
				DataBaseExecutor.Execute(@"update [profile] set friendrequestcount=friendrequestcount-1 where userid=@userid",
					"@userid", OperaterID);
				var name = DBExt.DB.Profile.Where(q => q.UserID == ToID).Select(q => q.Name).FirstOrDefault();
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
		public bool Ignore(long FromID, long operaterID) {
			int ret =DataBaseExecutor.Execute(@"DELETE FROM Friend
		WHERE toid=@toid and fromid=@fromid and istrue=0", "@toid", operaterID,
									 "@fromid", FromID);
			if(ret==1)
				DataBaseExecutor.Execute(@"update [profile] set friendrequestcount=friendrequestcount-1 where userid=@userid",
	"@userid", operaterID);
			return true;
		}
		public bool IgnoreAll(long UserID) {
			DataBaseExecutor.Execute(@"DELETE FROM Friend
		WHERE toid=@userid and istrue=0", "@userid", UserID);
			DataBaseExecutor.Execute(@"update [profile] set friendrequestcount=0 where userid=@userid",
	"@userid", UserID);
			return true;
		}
	}
}