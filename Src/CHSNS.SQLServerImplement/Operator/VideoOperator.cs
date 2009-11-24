using System;
using System.Linq;
using CHSNS.Abstractions;
using CHSNS.SQLServerImplement;

namespace CHSNS.Operator {
    public class VideoOperator : BaseOperator, ISuperNoteOperator {
      
        #region ICURDOperator<SuperNote> 成员

        public void Create(ISuperNote content) {
            using (var db = DBExtInstance)
            {
                var inval = CastTool.Cast<SuperNote>(content);
                if (inval == null) return;
                db.AddToSuperNote(inval);
                db.SubmitChanges();
            }
        }

        public void Update(ISuperNote content) {
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

        public PagedList<ISuperNote> List(long uid, int p, int ep){
            //类型,时间排序,用户
            using (var db = DBExtInstance){
                return db.SuperNote.Where(c => c.Type == (byte) SuperNoteType.Video
                                               && c.UserId == uid).OrderByDescending(
                    c => c.AddTime).Cast<ISuperNote>().Pager(p, ep);
            }
        }

        #endregion
    }
}
