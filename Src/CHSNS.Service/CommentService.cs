namespace CHSNS.Service {
    using System;
    using System.Linq;
    using CHSNS.Config;
    using CHSNS.Model;
    using CHSNS.Models;
    using System.ComponentModel.Composition;
    [Export]
    public class CommentService : BaseService<CommentService>
    {
        #region Reply

        private static IQueryable<CommentPas> GetReplyPrivate(DbEntities db, long uid)
        {
            IQueryable<CommentPas> ret = (from r in db.Reply
                                          join p in db.Profile on r.SenderId equals p.UserId
                                          where r.UserId == uid
                                          orderby r.Id descending
                                          select new CommentPas
                                          {
                                              Comment = new CommentItemPas
                                              {
                                                  ID = r.Id,
                                                  OwnerID = r.UserId,
                                                  Body = r.Body,
                                                  AddTime = r.AddTime,
                                                  IsDel = r.IsDel
                                              },
                                              Sender = new NameIdPas { Id = p.UserId, Name = p.Name }
                                          }
                                               );
            return ret;
        }

        public PagedList<CommentPas> GetReply(long uid, int p, int ep) {
            using (var db = DBExtInstance)
            {
                return GetReplyPrivate(db, uid).Pager(p, ep);
            }
        }
        public Reply AddReply(Reply r) {
            r.AddTime = DateTime.Now;
            using (var db = DBExtInstance)
            {
                db.Reply.Add(r);
                db.SaveChanges();
            }
            return r;
        }

        public void DeleteReply(long id, long userid) {
            using (var db = DBExtInstance)
            {
                var obj = db.Reply.FirstOrDefault(c => c.Id == id && c.UserId == userid);
                db.Reply.Remove(obj);
                db.SaveChanges();
            }
        }

        #endregion

        #region Comment

        /// <summary>
        /// Comments the list.
        /// </summary>
        /// <param name="showerId"></param>
        /// <param name="type">The type.</param>
        /// <param name="p"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public PagedList<CommentPas> CommentList(long showerId, CommentType type, int p
            , SiteConfig site)
        {
            using (var db = DBExtInstance)
            {
                var t = (int)type;
                var ret = (from c in db.Comment
                           join p1 in db.Profile on c.SenderId equals p1.UserId
                           where c.ShowerId == showerId && c.Type == t && !c.IsDel
                           orderby c.Id
                           select new CommentPas
                           {
                               Comment = new CommentItemPas
                               {
                                   ID = c.Id,
                                   OwnerID = c.OwnerId,
                                   Body = c.Body,
                                   AddTime = c.AddTime,
                                   IsDel = c.IsDel
                               },
                               Sender = new NameIdPas { Id = p1.UserId, Name = p1.Name }
                           }
                                             );
                return ret.Pager(p, site.EveryPage.NoteComment);//Site.EveryPage.NoteComment
            }
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Delete(long id, CommentType type) {
            using (var db = DBExtInstance)
            {
                var com = db.Comment.FirstOrDefault(c => c.Id == id);
                if (null == com) return false;
                com.IsDel = true;
                if (type == CommentType.Note)
                {
                    var n = db.Note.FirstOrDefault(c => c.Id == com.ShowerId && c.CommentCount > 0);
                    if (null != n) n.CommentCount--;
                }
                db.SaveChanges();
                return true;
            }
        }


        public void Add(Comment cmt, CommentType type) {
            cmt.AddTime = DateTime.Now;
            using (var db = DBExtInstance)
            {
                db.Comment.Add(cmt);
                switch (type)
                {
                    case CommentType.Note:
                        var n = db.Note.FirstOrDefault(c => c.Id == cmt.ShowerId);
                        n.CommentCount++;
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
            }
        }

        #endregion
    }
}