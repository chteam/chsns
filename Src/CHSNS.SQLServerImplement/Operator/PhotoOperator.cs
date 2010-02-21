using System.Linq;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.SQLServerImplement {
    public class PhotoOperator : BaseOperator, IPhotoOperator {
        #region IPhotoOperator 成员

        public void Add(Photo photo) {
            using (var db = DBExtInstance) {
                db.Photo.AddObject(photo);
              // db.Photo.InsertOnSubmit(CastTool.Cast<Photo>(photo));
                db.SubmitChanges();
            }
        }

        public Photo Get(long id) {
            using (var db = DBExtInstance) {
                var p = db.Photo.Where(c => c.Id == id).FirstOrDefault();
                return p;
            }

        }
        public void Delete(long id) {
            using (var db = DBExtInstance) {
                var p = db.Photo.Where(c => c.Id == id).FirstOrDefault();
                db.DeleteObject(p);
                db.SubmitChanges();
            }

        }
        #endregion
    }
}
