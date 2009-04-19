using System;
using System.Linq;

namespace CHSNS.Operator {
    public class VideoOperator : BaseOperator, ISuperNoteOperator {
        public VideoOperator(IDBManager id) : base(id) { }
        #region ICURDOperator<SuperNote> 成员

        public void Create(Models.SuperNote content) {
            using (var db = DBExtInstance)
            {
                content.AddTime = DateTime.Now;
                var m = new Media(content.Url);
                content.Title = content.Title ?? m.Title;
                content.Faceurl = m.Pic;
                content.UserID = CHUser.UserID;
                content.Type = (byte) SuperNoteType.Video;
                db.SuperNote.InsertOnSubmit(content);
                db.SubmitChanges();
            }
        }

        public void Update(Models.SuperNote content) {
            throw new NotImplementedException();
        }

        public void Remove(params long[] uid) {
            using (var db = DBExtInstance)
            {
                var es = db.SuperNote
                    .Where(c =>
                           c.Type == (byte) SuperNoteType.Video
                           && c.UserID == CHUser.UserID
                           && uid.Contains(c.ID));
                db.SuperNote.DeleteAllOnSubmit(es);
                db.SubmitChanges();
            }
        }

        public PagedList<Models.SuperNote> List(long? uid,int p,int ep) {
            //类型,时间排序,用户
            using (var db = DBExtInstance)
            {
                return db.SuperNote.Where(c => c.Type == (byte)SuperNoteType.Video
                                                     && c.UserID == (uid ?? CHUser.UserID)).OrderByDescending(
                    c => c.AddTime).Pager(p, ep);
            }
        }

        #endregion
    }
}
