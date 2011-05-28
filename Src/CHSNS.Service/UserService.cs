
namespace CHSNS.Service {
    using System;
    using CHSNS.Model;

    using CHSNS.Models;
    using System.Linq;
    using System.ComponentModel.Composition;
    [Export]
    public class UserService : BaseService<UserService>
    {
        public UserPas UserInformation(long userid) {
            using (var db = DbInstance)
            {
                var ret = (from p in db.Profile
                           join b in db.BasicInformation on p.UserId equals b.UserId
                           where p.UserId == userid
                           select new UserPas { Profile = p, Basic = b }
                          ).FirstOrDefault();
                return ret;
            }
        }

        public int Relation(long ownerId, long viewerId) {
            using (var db = DbInstance)
            {
                if (ownerId == viewerId) return 200;
                var x =
                    (from f in db.Friends
                     where (f.FromId == ownerId && f.ToId == viewerId) ||
                           (f.FromId == viewerId && f.ToId == ownerId) && f.IsTrue
                     select 1).Count();
                return x > 0 ? 150 : 0;
            }
        }

        #region BasicInfo
        public BasicInformation GetBaseInfo(long userId) {
            using (var db = DbInstance)
            {
                return db.BasicInformation.Where(c => c.UserId == userId).FirstOrDefault();
            }
        }
        public void SaveBaseInfo(BasicInformation b, IContext context) {
            if (b.UserId == 0) b.UserId = context.User.UserId;
            using (var db = DbInstance)
            {
                var bi = db.BasicInformation.FirstOrDefault(c => c.UserId == b.UserId);
                if (null == bi) return;
                bi.Name = b.Name;
                bi.Sex = b.Sex;
                bi.Birthday = b.Birthday;
                bi.ProvinceId = b.ProvinceId;
                bi.CityId = b.CityId;
                bi.ShowLevel = b.ShowLevel;
                db.SaveChanges();
            }
        }

        #endregion

        #region Magicbox
        //public string GetMagicBox(long userId) {
        //    return _user.GetMagicBox(userId);
        //}
        //public void SaveMagicBox(string magicbox, long uid) {
        //    _user.SaveMagicBox(magicbox, uid);
        //}
        //public void MagicBoxBackup() {
        //    _user.MagicBoxBackup();
        //}



        #endregion
        #region face
        public void DeleteFace(long userid, string path) {
            //IOFactory.Folder.Delete(Path.FaceMapPath(userid), true);
        }
        #endregion

        public Profile GetUser(long userid) {
            return GetUser(userid, c => new Profile{
                Name = c.Name
            });
        }

        public Profile GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<Profile, T>> x) {
            using (var db = DbInstance)
            {
                var ret = db.Profile
                    .FirstOrDefault(c => c.UserId == userid);
                //  .Select(x as Func<Profile, T>).();
                return ret;
            }
        }

 
        #region profile
        public void SaveText(long uid, string text, IContext context) {
            using (var db = DbInstance)
            {
                var p = db.Profile.FirstOrDefault(c => c.UserId == uid);
                if (null == p) return;
                //              p.show = magicbox;
                db.SaveChanges();
            }
            EventService.Instance.Add(new Event
            {
                OwnerId = context.User.UserId,
                TemplateName = "ProText",
                AddTime = DateTime.Now,
                ShowLevel = 0,
                Json = Dictionary.CreateFromArgs("name", context.User.Name,
                                                 "text", text).ToJsonString()
            });
        }

        #endregion


        public string GetUserName(long uid) {
            using (var db = DbInstance)
            {
                var p = db.Profile.FirstOrDefault(c => c.UserId == uid);
                return p == null ? "undefault" : p.Name;
            }
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="url">头像地址，（全）</param>
        public void ChangeFace(long userId, string url) {
            using (var db = DbInstance)
            {
                var p = db.Profile.Where(c => c.UserId == userId).FirstOrDefault();
                p.Face = url;
                db.SaveChanges();
            }
        }
    }
}
