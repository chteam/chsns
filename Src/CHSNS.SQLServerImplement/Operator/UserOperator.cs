using System.Linq;
using System;
using CHSNS.Model;

using CHSNS.SQLServerImplement;
using CHSNS.Models;

namespace CHSNS.Operator {
    public class UserOperator : BaseOperator {

        public UserPas UserInformation(long userid) {
            using (var db = DBExtInstance) {
                var ret = (from p in db.Profile
                           join b in db.BasicInformation on p.UserId equals b.UserId
                           where p.UserId == userid
                           select new UserPas { Profile = p, Basic = b }
                          ).FirstOrDefault();
                return ret;
            }
        }

        public int Relation(long ownerId, long viewerId) {
            using (var db = DBExtInstance) {
                if (ownerId == viewerId) return 200;
                var x =
                    (from f in db.Friend
                     where (f.FromId == ownerId && f.ToId == viewerId) ||
                           (f.FromId == viewerId && f.ToId == ownerId) && f.IsTrue
                     select 1).Count();
                return x > 0 ? 150 : 0;
            }
        }

        #region BasicInfo
        public BasicInformation GetBaseInfo(long userId) {
            using (var db = DBExtInstance) {
                return db.BasicInformation.Where(c => c.UserId == userId).FirstOrDefault();
            }
        }
        public void SaveBaseInfo(BasicInformation b) {
            //  if (b.UserId == 0) b.UserId = user.UserId;
            using (var db = DBExtInstance) {
                var bi = db.BasicInformation.FirstOrDefault(c => c.UserId == b.UserId);
                if (null == bi) return;
                bi.Name = b.Name;
                bi.Sex = b.Sex;
                bi.Birthday = b.Birthday;
                bi.ProvinceId = b.ProvinceId;
                bi.CityId = b.CityId;
                bi.ShowLevel = b.ShowLevel;
                db.SubmitChanges();
            }

            #region sql

            //            DataBaseExecutor.Execute(
            //                @"UPDATE [BasicInformation]
            //   SET [Title] = @Title
            //      ,[Sex] = @Sex
            //      ,[Birthday] = @Birthday
            //      ,[ProvinceID] = @ProvinceID
            //      ,[CityID] = @CityID
            //      ,[ShowLevel] = @ShowLevel
            // WHERE UserId=@UserId"
            //                , "@Title", b.Title
            //                , "@Sex", b.Sex
            //                , "@Birthday", b.Birthday
            //                , "@ProvinceID", b.ProvinceID
            //                , "@CityID", b.CityID
            //                , "@ShowLevel", b.ShowLevel
            //                , "@UserId", b.UserId);

            #endregion
        }

        #endregion

        #region Magicbox
        //public string GetMagicBox(long userId) {
        //    using (var db = DBExtInstance) {
        //        var magicbox = (from p in db.Profile
        //                        where p.UserId == userId
        //                        select p.MagicBox).FirstOrDefault();
        //        return magicbox;
        //    }
        //}
        //public void SaveMagicBox(string magicbox, long uid) {
        //    using (var db = DBExtInstance) {
        //        var p = db.Profile.FirstOrDefault(c => c.UserId == uid);
        //        if (null == p) return;
        //        p.MagicBox = magicbox;
        //        db.SubmitChanges();
        //    }
        //    #region sql
        //    //            DataBaseExecutor.Execute(@"Update [profile]
        //    //set Magicbox=@magicbox where UserId=@UserId"
        //    //                                     , "@magicbox", magicbox
        //    //                                     , "@UserId", UserId);
        //    #endregion
        //}
        //public void MagicBoxBackup() {
        //}



        #endregion
        #region face
        public void DeleteFace(long userid) {
            //IOFactory.Folder.Delete(Path.FaceMapPath(userid), true);
        }
        #endregion

        public Profile GetUser(long userid) {
            return GetUser(userid, c => new Profile {
                Name = c.Name
            });
        }

        public Profile GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<Profile, T>> x) {
            using (var db = DBExtInstance) {

                var ret = db.Profile
                    .FirstOrDefault(c => c.UserId == userid);
                //  .Select(x as Func<Profile, T>).();
                return ret;
            }
        }
        #region profile
        public void SaveText(long uid, string text) {
            using (var db = DBExtInstance) {
                var p = db.Profile.FirstOrDefault(c => c.UserId == uid);
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
            //                        OwnerID = CHUser.UserId,
            //                        TemplateName = "ProText",
            //                        AddTime = DateTime.Now,
            //                        ShowLevel = 0,
            //                        Json = Dictionary.CreateFromArgs("name", CHUser.Username,
            //                                                         "text", text).ToJsonString()
            //                    });
        }

        #endregion


        public string GetUserName(long uid) {
            using (var db = DBExtInstance) {
                var p = db.Profile.FirstOrDefault(c => c.UserId == uid);
                return p == null ? "undefault" : p.Name;
            }
        }

        public void ChangeFace(long userId, string url)
        {
            using (var db = DBExtInstance)
            {
                var p = db.Profile.Where(c => c.UserId == userId).FirstOrDefault();
                p.Face = url;
                db.SubmitChanges();
            }
        }
    }
}
