
namespace CHSNS.Service
{
    using System;

    using CHSNS.Models;
    using System.Linq;
    using System.ComponentModel.Composition;
    [Export]
    public class VideoService : BaseService<VideoService>
    {
        #region ICURDService<SuperNote> 成员

        public void Create(IUser user, SuperNote content)
        {
            content.UserId = user.UserId;
            content.AddTime = DateTime.Now;
            var m = new Media(content.Url);
            content.Title = content.Title ?? m.Title;
            content.FaceURL = m.Pic;
            content.Type = (byte)SuperNoteType.Video;
            using (var db = DbInstance)
            {
                db.SuperNote.Add(content);
                db.SaveChanges();
            }
        }

        public void Update(SuperNote content)
        {
            throw new NotImplementedException();
        }

        public void Remove(IUser user, params long[] uids)
        {
            using (var db = DbInstance)
            {
                var superNotes = db.SuperNote
                    .Where(c =>
                           c.Type == (byte)SuperNoteType.Video
                               && c.UserId == user.UserId
                           && uids.Contains(c.Id)).ToList();
                db.SuperNote.BulkRemove(superNotes);
                db.SaveChanges();
            }
        }

        public PagedList<SuperNote> List(long? uid, int p, int ep, IUser user)
        {
            uid = uid ?? user.UserId;
            //类型,时间排序,用户
            using (var db = DbInstance)
            {
                return db.SuperNote.Where(c => c.Type == (byte)SuperNoteType.Video
                                               && c.UserId == uid).OrderByDescending(
                    c => c.AddTime).Pager(p, ep);
            }
        }

        #endregion
    }
}
