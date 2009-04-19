using System.Linq;
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Service
{
	public class CommentService : BaseService, ICommentService
	{
		public CommentService(IDBManager id) : base(id)
		{
		}
     
		#region reply
   private static IQueryable<CommentPas> GetReplyPrivate(CHSNSDBDataContext db, long uid) {
            IQueryable<CommentPas> ret = (from r in db.Reply
                                          join p in db.Profile on r.SenderID equals p.UserID
                                          where r.UserID == uid
                                          orderby r.ID descending
                                          select new CommentPas
                                          {
                                              Comment = new CommentItemPas
                                              {
                                                  ID = r.ID,
                                                  OwnerID = r.UserID,
                                                  Body = r.Body,
                                                  AddTime = r.AddTime,
                                                  IsDel = r.IsDel
                                              },
                                              Sender = new NameIDPas { ID = p.UserID, Name = p.Name }
                                          }
                                               );
            return ret;
        }
        public PagedList<CommentPas> GetReply(long uid, int p, int ep)
        {
            using (var db = DBExt.Instance)
            {
                return GetReplyPrivate(db, uid).Pager(p, ep);
            }
        }
		public Reply AddReply(Reply r)
		{
            using (var db = DBExt.Instance)
            {
                db.Reply.InsertOnSubmit(new Reply
                                            {
                                                UserID = r.UserID,
                                                SenderID = r.SenderID,
                                                Body = r.Body,
                                                IsTellMe = r.IsTellMe,
                                                AddTime = System.DateTime.Now
                                            });
                db.SubmitChanges();
            }
            #region sql
//            DataBaseExecutor.Execute(
//                @"INSERT INTO [dbo].[Reply]
//([UserID],[SenderID],[Body],[AddTime],[IsSee],[IsDel],[IsTellMe])
//VALUES(@userid,@senderid,@body,getdate(),0,0,@istellme)",
//                "@userid", r.UserID,
//                "@senderid", r.SenderID,
//                "@body", r.Body,
//                "@istellme", r.IsTellMe);
            #endregion
			return r;
		}

		public void DeleteReply(long id, long userid)
		{
            using (var db = DBExt.Instance)
            {
                db.Reply.DeleteOnSubmit(db.Reply.FirstOrDefault(c => c.ID == id && c.UserID == userid));
                db.SubmitChanges();
            }
            //DataBaseExecutor.Execute(@"delete [reply] where id=@id and userid=@userid",
            //                         "@id", id,
            //                         "@userid", userid);
		}

		#endregion

		#region comment

		/// <summary>
		/// Comments the list.
		/// </summary>
		/// <param name="ShowerID">The shower ID.</param>
		/// <param name="type">The type.</param>
		/// <param name="p"></param>
		/// <returns></returns>
        public PagedList<CommentPas> CommentList(long ShowerID, CommentType type,int p)
        {
            using (var db = DBExt.Instance)
            {
                var t = (int)type;
                IQueryable<CommentPas> ret = (from c in db.Comment
                                              join p1 in db.Profile on c.SenderID equals p1.UserID
                                              where c.ShowerID == ShowerID && c.Type == t && !c.IsDel
                                              orderby c.ID
                                              select new CommentPas
                                                        {
                                                            Comment = new CommentItemPas
                                                                        {
                                                                            ID = c.ID,
                                                                            OwnerID = c.OwnerID,
                                                                            Body = c.Body,
                                                                            AddTime = c.AddTime,
                                                                            IsDel = c.IsDel
                                                                        },
                                                            Sender = new NameIDPas { ID = p1.UserID, Name = p1.Name }
                                                        }
                                             );
                return ret.Pager(p, Site.EveryPage.NoteComment);
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
            using (var db = DBExt.Instance)
            {
                var com = db.Comment.FirstOrDefault(c => c.ID == id);
                if (null == com) return false;
                com.IsDel = true;
                if (type == CommentType.Note)
                {
                    var n = db.Note.FirstOrDefault(c => c.ID == com.ShowerID && c.CommentCount > 0);
                    if (null != n) n.CommentCount--;
                }
                db.SubmitChanges();
                return true;
            }
		    #region sql

		    //DataBaseExecutor.Execute(@"update [comment] set isdel=1 where id=@id", "@id", id);
		    //            switch (type)
		    //            {
		    //                case CommentType.No te:
		    //                    DataBaseExecutor.Execute(
		    //                        @"update [No te] set commentCount=commentCount-1
		    //where id in (select showerid from [comment] where id=@id) and commentcount>0
		    //",
		    //                        "@id", id);
		    //                    break;
		    //                default:
		    //                    break;
		    //            }

		    #endregion
		}

	    public void Add(Comment cmt, CommentType type)
		{
            using (var db = DBExt.Instance)
            {
                db.Comment.InsertOnSubmit(new Comment
                                              {
                                                  ShowerID = cmt.ShowerID,
                                                  OwnerID = cmt.OwnerID,
                                                  SenderID = cmt.SenderID,
                                                  AddTime = System.DateTime.Now,
                                                  Body = cmt.Body,
                                                  Type = cmt.Type,
                                                  IsTellMe = cmt.IsTellMe
                                              });
                switch (type)
                {
                    case CommentType.Note:
                        var n = db.Note.FirstOrDefault(c => c.ID == cmt.ShowerID);
                        n.CommentCount++;
                        break;
                    default:
                        break;
                }
                db.SubmitChanges();
            }
		}

		#endregion
    }
}