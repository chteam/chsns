using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Models;
using CHSNS.Operator;

namespace CHSNS.SQLServerImplement {
    public class PhotoOperator:BaseOperator,IPhotoOperator  {
        #region IPhotoOperator 成员

        public void Add(Photo photo){
            using (var db = DBExtInstance){
                db.Photo.InsertOnSubmit(photo);
                db.SubmitChanges();
            }
        }

        public Photo Get(long id){
            using (var db = DBExtInstance) {
                var p = db.Photo.Where(c => c.ID == id).FirstOrDefault();
                return p;
            }
          
        }

        public void Delete(long id){
            using (var db = DBExtInstance) {
                var p = db.Photo.Where(c => c.ID == id).FirstOrDefault();
                db.Photo.DeleteOnSubmit(p);
                db.SubmitChanges();
            }
          
        }

        #endregion
    }
}
