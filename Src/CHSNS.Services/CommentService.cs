namespace CHSNS.Service
{
    using System;
    
    using System.Linq;
    using CHSNS.Config;
    using CHSNS.DataContext;
    using CHSNS.Model;
    using CHSNS.Models;

   
    public class CommentService : BaseService
    {
        #region Reply

        private static IQueryable<CommentPas> GetReplyPrivate(IDbEntities sqlServer, long uid)
        {
            IQueryable<CommentPas> ret = (from r in sqlServer.Reply
                                          join p in sqlServer.Profile on r.SenderId equals p.UserId
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
                                                         Sender = new NameIdPas {Id = p.UserId, Name = p.Name}
                                                     }
                                         );
            return ret;
        }

        public PagedList<CommentPas> GetReply(long uid, int p, int ep)
        {
            using (IDbEntities db = DbInstance)
            {
                return GetReplyPrivate(db, uid).Pager(p, ep);
            }
        }

        public Reply AddReply(Reply r)
        {
            r.AddTime = DateTime.Now;
            using (IDbEntities db = DbInstance)
            {
                db.Reply.Add(r);
                db.SaveChanges();
            }
            return r;
        }

        public void DeleteReply(long id, long userid)
        {
            using (IDbEntities db = DbInstance)
            {
                Reply obj = db.Reply.FirstOrDefault(c => c.Id == id && c.UserId == userid);
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
            using (IDbEntities db = DbInstance)
            {
                var t = (int) type;
                IQueryable<CommentPas> ret = (from c in db.Comment
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
                                                             Sender = new NameIdPas {Id = p1.UserId, Name = p1.Name}
                                                         }
                                             );
                return ret.Pager(p, site.EveryPage.NoteComment); //Site.EveryPage.NoteComment
            }
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Delete(long id, CommentType type)
        {
            using (IDbEntities db = DbInstance)
            {
                Comment com = db.Comment.FirstOrDefault(c => c.Id == id);
                if (null == com) return false;
                com.IsDel = true;
                if (type == CommentType.Note)
                {
                    Note n = db.Note.FirstOrDefault(c => c.Id == com.ShowerId && c.CommentCount > 0);
                    if (null != n) n.CommentCount--;
                }
                db.SaveChanges();
                return true;
            }
        }


        public void Add(Comment cmt, CommentType type)
        {
            cmt.AddTime = DateTime.Now;
            using (IDbEntities db = DbInstance)
            {
                db.Comment.Add(cmt);
                switch (type)
                {
                    case CommentType.Note:
                        Note n = db.Note.FirstOrDefault(c => c.Id == cmt.ShowerId);
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