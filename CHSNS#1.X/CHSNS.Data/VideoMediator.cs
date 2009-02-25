using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Data {
    public class VideoMediator : BaseMediator, ISuperNoteMediator {
        public VideoMediator(IDBManager id) : base(id) { }
        #region ICURDMediator<SuperNote> 成员

        public void Create(CHSNS.Models.SuperNote content) {
            content.AddTime = DateTime.Now;
            var m = new Media(content.Url);
            content.Title = content.Title ?? m.Title;
            content.Faceurl = m.Pic;
            content.UserID = CHUser.UserID;
            content.Type = (byte)SuperNoteType.Video;
            DBExt.DB.SuperNote.InsertOnSubmit(content);
            DBExt.DB.SubmitChanges();
        }

        public void Update(CHSNS.Models.SuperNote content) {
            throw new NotImplementedException();
        }

        public void Remove(params long[] uid) {
            var es = DBExt.DB.SuperNote
                .Where(c =>
                    c.Type == (byte)SuperNoteType.Video
                    && c.UserID == CHUser.UserID
                    && uid.Contains(c.ID));
            DBExt.DB.SuperNote.DeleteAllOnSubmit(es);
            DBExt.DB.SubmitChanges();
        }

        public IQueryable<CHSNS.Models.SuperNote> List(long? uid) {
            //类型,时间排序,用户
            return DBExt.DB.SuperNote.Where(c => c.Type == (byte)SuperNoteType.Video
                && c.UserID == (uid ?? CHUser.UserID)).OrderByDescending(c => c.AddTime);
        }

        #endregion
    }
}
