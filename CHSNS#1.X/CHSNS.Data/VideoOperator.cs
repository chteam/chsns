using System;
using System.Linq;
using CHSNS.Models;
using CHSNS.Models.Abstractions;

namespace CHSNS.Operator {
    public class VideoOperator : BaseOperator, ISuperNoteOperator {
      
        #region ICURDOperator<SuperNote> 成员

        public void Create(ISuperNote content) {
            using (var db = DBExtInstance)
            {
                content.AddTime = DateTime.Now;
                var m = new Media(content.Url);
                content.Title = content.Title ?? m.Title;
                content.Faceurl = m.Pic;
               // content.UserID = CHUser.UserID;
                content.Type = (byte) SuperNoteType.Video;
                var inval = content as SuperNote;
                if (inval == null) return;
                db.SuperNote.InsertOnSubmit(inval);
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
                               && c.UserID == uid
                           && uids.Contains(c.ID));
                db.SuperNote.DeleteAllOnSubmit(es);
                db.SubmitChanges();
            }
        }

        public PagedList<ISuperNote> List(long uid, int p, int ep){
            //类型,时间排序,用户
            using (var db = DBExtInstance){
                return db.SuperNote.Where(c => c.Type == (byte) SuperNoteType.Video
                                               && c.UserID == uid).OrderByDescending(
                    c => c.AddTime).Cast<ISuperNote>().Pager(p, ep);
            }
        }

        #endregion
    }
}
