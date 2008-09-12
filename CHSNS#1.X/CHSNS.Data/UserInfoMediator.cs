﻿using System.Data;
using System.Linq;
using CHSNS.Models;
using CHSNS;
namespace CHSNS.Data {
	public class UserInfoMediator : BaseMediator {
		public UserInfoMediator(DBExt id) : base(id) { }
		public UserPas UserInformation(long userid) {
			var ret = (from p in DBExt.DB.Profile
					   join b in DBExt.DB.BasicInformation on p.UserID equals b.UserID
					   where p.UserID == userid
					   select new UserPas { Profile = p, Basic = b }
						 ).FirstOrDefault();			
			return ret;
		}

		public int Relation(long OwnerID, long ViewerID) {
			if (OwnerID == ViewerID) return 200;
			var x =
				(from f in DBExt.DB.Friend
				 where (f.FromID == OwnerID && f.ToID == ViewerID) ||
(f.FromID == ViewerID && f.ToID == OwnerID) && f.IsTrue
				 select 1).Count();
			if (x > 0) return 150;
			return 0;
		}
		#region BasicInfo
		public BasicInformation GetBaseInfo(long UserID) {
			return DBExt.DB.BasicInformation.Where(c => c.UserID == UserID).FirstOrDefault();
		}
		public void SaveBaseInfo(BasicInformation bi) {
			DataBaseExecutor.Execute(
				@"UPDATE [BasicInformation]
   SET [Name] = @Name
      ,[Sex] = @Sex
      ,[Birthday] = @Birthday
      ,[ProvinceID] = @ProvinceID
      ,[CityID] = @CityID
      ,[ShowLevel] = @ShowLevel
 WHERE UserID=@UserID"
				, "@Name", bi.Name
				, "@Sex", bi.Sex
				, "@Birthday", bi.Birthday
				, "@ProvinceID", bi.ProvinceID
				, "@CityID", bi.CityID
				, "@ShowLevel", bi.ShowLevel
				, "@UserID", bi.UserID);
		}
		#endregion
		#region other info
		public DataRowCollection GetSchoolInfo(long UserID) {
			return DataBaseExecutor.GetRows("MySchoolSelect", "@userid", UserID);
		}
		public DataRowCollection GetContactInfo(long UserID) {
			return DataBaseExecutor.GetRows("MyContactSelect", "@userid", UserID);
		}
		public DataRowCollection GetPersonalInfo(long UserID) {
			return DataBaseExecutor.GetRows("MyPersonalSelect", "@userid", UserID);
		}
		#endregion
		#region Magicbox
		public string GetMagicBox(long UserID) {
			var magicbox = (from p in DBExt.DB.Profile
							where p.UserID == UserID
							select p.MagicBox).Single();
			return magicbox;
		}
		public void SaveMagicBox(string magicbox, long UserID) {
			DataBaseExecutor.Execute(@"Update [profile]
set Magicbox=@magicbox where UserID=@UserID"
									 , "@magicbox", magicbox
									 , "@UserID", UserID);
		}
		public void MagicBoxBackup() {
		}



		#endregion
		#region face
		public void DeleteFace(long userid) {
			System.IO.Directory.Delete(Path.FaceMapPath(userid), true);
		}
		#endregion
		public Profile GetUser(long userid) {
			return GetUser(userid, c => new Profile {
				Name = c.Name
			});
		}

		public T GetUser<T>(long userid,
			System.Linq.Expressions.Expression<System.Func<Profile, T>> x) {
			var ret = DBExt.DB.Profile
				.Where(c => c.UserID == userid)
				.Select(x).FirstOrDefault();
			return ret;
		}
	}
}
