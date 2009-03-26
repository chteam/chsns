﻿using System.Data;
using System.Linq;
using CHSNS.Models;
using System;
using CHSNS.ModelPas;
namespace CHSNS.Data {
	public class UserService : BaseService, IUserService {
		public UserService(IDBManager id) : base(id) { }
		public UserPas UserInformation(long userid) {
            using (var db = DBExt.Instance)
            {
                var ret = (from p in db.Profile
                           join b in db.BasicInformation on p.UserID equals b.UserID
                           where p.UserID == userid
                           select new UserPas {Profile = p, Basic = b}
                          ).FirstOrDefault();
                return ret;
            }
		}

		public int Relation(long OwnerID, long ViewerID) {
            using (var db = DBExt.Instance)
            {
                if (OwnerID == ViewerID) return 200;
                var x =
                    (from f in db.Friend
                     where (f.FromID == OwnerID && f.ToID == ViewerID) ||
                           (f.FromID == ViewerID && f.ToID == OwnerID) && f.IsTrue
                     select 1).Count();
                if (x > 0) return 150;
                return 0;
            }
		}

		#region BasicInfo
		public BasicInformation GetBaseInfo(long UserID) {
            using (var db = DBExt.Instance)
            {
                return db.BasicInformation.Where(c => c.UserID == UserID).FirstOrDefault();
            }
		}
		public void SaveBaseInfo(BasicInformation b) {
			if (b.UserID == 0) b.UserID = CHUser.UserID;
			DataBaseExecutor.Execute(
				@"UPDATE [BasicInformation]
   SET [Name] = @Name
      ,[Sex] = @Sex
      ,[Birthday] = @Birthday
      ,[ProvinceID] = @ProvinceID
      ,[CityID] = @CityID
      ,[ShowLevel] = @ShowLevel
 WHERE UserID=@UserID"
				, "@Name", b.Name
				, "@Sex", b.Sex
				, "@Birthday", b.Birthday
				, "@ProvinceID", b.ProvinceID
				, "@CityID", b.CityID
				, "@ShowLevel", b.ShowLevel
				, "@UserID", b.UserID);
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
            using (var db = DBExt.Instance)
            {
                var magicbox = (from p in db.Profile
                                where p.UserID == UserID
                                select p.MagicBox).FirstOrDefault();
                return magicbox;
            }
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

		public T GetUser<T>(long userid,System.Linq.Expressions.Expression<Func<Profile, T>> x) {

            using (var db = DBExt.Instance)
            {
                var ret = db.Profile
                    .Where(c => c.UserID == userid)
                    .Select(x).FirstOrDefault();
                return ret;
            }
		}
		#region profile
		public void SaveText(long userid,string text) {
			DataBaseExecutor.Execute(@"update [profile]
set showtext=@text,showtexttime=@now where userid=@uid;"
			, "@text", text
			, "@uid", userid
			, "@now", DateTime.Now
			);
			DBExt.Event.Add(new Event {
				OwnerID = CHUser.UserID,
				TemplateName = "ProText",
				AddTime = DateTime.Now,
				ShowLevel = 0,
				Json = Dictionary.CreateFromArgs("name", CHUser.Username,
				"text", text).ToJsonString()
			});
		}
		#endregion


		public string GetUserName(long uid) {
            using (var db = DBExt.Instance)
            {
                var p = db.Profile.Where(c => c.UserID == uid).FirstOrDefault();
                return p == null ? "undefault" : p.Name;
            }
		}
	}
}
