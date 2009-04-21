using System.Linq;
using CHSNS.Models;
using System;
using CHSNS.Model;
using CHSNS.Models.Abstractions;

namespace CHSNS.Operator {
	public class UserOperator : BaseOperator, IUserOperator {

		public UserPas UserInformation(long userid) {
            using (var db = DBExtInstance)
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
            using (var db = DBExtInstance)
            {
                if (OwnerID == ViewerID) return 200;
                var x =
                    (from f in db.Friend
                     where (f.FromID == OwnerID && f.ToID == ViewerID) ||
                           (f.FromID == ViewerID && f.ToID == OwnerID) && f.IsTrue
                     select 1).Count();
                return x > 0 ? 150 : 0;
            }
		}

		#region BasicInfo
		public IBasicInformation GetBaseInfo(long UserID) {
            using (var db = DBExtInstance)
            {
                return db.BasicInformation.Where(c => c.UserID == UserID).FirstOrDefault();
            }
		}
        public void SaveBaseInfo(IBasicInformation b)
        {
          //  if (b.UserID == 0) b.UserID = user.UserID;
            using (var db = DBExtInstance)
            {
                var bi = db.BasicInformation.FirstOrDefault(c => c.UserID == b.UserID);
                if (null == bi) return;
                bi.Name = b.Name;
                bi.Sex = b.Sex;
                bi.Birthday = b.Birthday;
                bi.ProvinceID = b.ProvinceID;
                bi.CityID = b.CityID;
                bi.ShowLevel = b.ShowLevel;
                db.SubmitChanges();
            }

            #region sql

            //            DataBaseExecutor.Execute(
            //                @"UPDATE [BasicInformation]
            //   SET [Name] = @Name
            //      ,[Sex] = @Sex
            //      ,[Birthday] = @Birthday
            //      ,[ProvinceID] = @ProvinceID
            //      ,[CityID] = @CityID
            //      ,[ShowLevel] = @ShowLevel
            // WHERE UserID=@UserID"
            //                , "@Name", b.Name
            //                , "@Sex", b.Sex
            //                , "@Birthday", b.Birthday
            //                , "@ProvinceID", b.ProvinceID
            //                , "@CityID", b.CityID
            //                , "@ShowLevel", b.ShowLevel
            //                , "@UserID", b.UserID);

            #endregion
        }

	    #endregion

		#region Magicbox
		public string GetMagicBox(long UserID) {
            using (var db = DBExtInstance)
            {
                var magicbox = (from p in db.Profile
                                where p.UserID == UserID
                                select p.MagicBox).FirstOrDefault();
                return magicbox;
            }
		}
		public void SaveMagicBox(string magicbox, long uid) {
            using (var db = DBExtInstance)
            {
                var p = db.Profile.FirstOrDefault(c => c.UserID == uid);
                if (null == p) return;
                p.MagicBox = magicbox;
                db.SubmitChanges();
            }
            #region sql
           //            DataBaseExecutor.Execute(@"Update [profile]
//set Magicbox=@magicbox where UserID=@UserID"
//                                     , "@magicbox", magicbox
//                                     , "@UserID", UserID);
            #endregion
		}
		public void MagicBoxBackup() {
		}



		#endregion
		#region face
		public void DeleteFace(long userid) {
			System.IO.Directory.Delete(Path.FaceMapPath(userid), true);
		}
		#endregion

		public IProfile GetUser(long userid) {
			return GetUser(userid, c => new Profile {
				Name = c.Name
			});
		}

		public IProfile GetUser<T>(long userid,System.Linq.Expressions.Expression<Func<IProfile, T>> x) {
            using (var db = DBExtInstance)
            {

                var ret = db.Profile
                    .FirstOrDefault(c => c.UserID == userid);
                  //  .Select(x as Func<Profile, T>).();
                return ret;
            }
		}
		#region profile
        public void SaveText(long uid, string text)
        {
            using (var db = DBExtInstance)
            {
                var p = db.Profile.FirstOrDefault(c => c.UserID == uid);
                if (null == p) return;
  //              p.show = magicbox;
                db.SubmitChanges();
            }
            // TODO:个人签名的表
//            DataBaseExecutor.Execute(@"update [profile]
//set showtext=@text,showtexttime=@now where userid=@uid;"
//                                     , "@text", text
//                                     , "@uid", userid
//                                     , "@now", DateTime.Now
//                );
            //DBExt.Event.Add(new Event
            //                    {
            //                        OwnerID = CHUser.UserID,
            //                        TemplateName = "ProText",
            //                        AddTime = DateTime.Now,
            //                        ShowLevel = 0,
            //                        Json = Dictionary.CreateFromArgs("name", CHUser.Username,
            //                                                         "text", text).ToJsonString()
            //                    });
        }

	    #endregion


		public string GetUserName(long uid) {
            using (var db = DBExtInstance)
            {
                var p = db.Profile.Where(c => c.UserID == uid).FirstOrDefault();
                return p == null ? "undefault" : p.Name;
            }
		}
	}
}
