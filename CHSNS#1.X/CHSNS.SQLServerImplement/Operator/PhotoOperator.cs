using System.Linq;
using CHSNS.Abstractions;
using CHSNS.Operator;

namespace CHSNS.SQLServerImplement {
    public class PhotoOperator:BaseOperator,IPhotoOperator  {
        #region IPhotoOperator 成员

        public void Add(IPhoto photo){
            using (var db = DBExtInstance){
                db.Photo.InsertOnSubmit(CastTool.Cast<Photo>( photo));
                db.SubmitChanges();
            }
        }

        public IPhoto Get(long id) {
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
