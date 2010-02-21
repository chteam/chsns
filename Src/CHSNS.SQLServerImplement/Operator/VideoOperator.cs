using System;
using System.Linq;

using CHSNS.SQLServerImplement;
using CHSNS.Models;

namespace CHSNS.Operator {
    public class VideoOperator : BaseOperator, ISuperNoteOperator {
      
        #region ICURDOperator<SuperNote> 成员

        public void Create(SuperNote content) {
            using (var db = DBExtInstance)
            {
				db.SuperNote.AddObject(content);
                db.SubmitChanges();
            }
        }

        public void Update(SuperNote content) {
            throw new NotImplementedException();
        }

        public void Remove(long uid,params long[] uids) {
            using (var db = DBExtInstance)
            {
                var es = db.SuperNote
                    .Where(c =>
                           c.Type == (byte) SuperNoteType.Video
                               && c.UserId == uid
                           && uids.Contains(c.Id));
                db.DeleteObject(es);
                db.SubmitChanges();
            }
        }

        public PagedList<SuperNote> List(long uid, int p, int ep){
            //类型,时间排序,用户
            using (var db = DBExtInstance){
                return db.SuperNote.Where(c => c.Type == (byte) SuperNoteType.Video
                                               && c.UserId == uid).OrderByDescending(
                    c => c.AddTime).Pager(p, ep);
            }
        }

        #endregion
    }
}
