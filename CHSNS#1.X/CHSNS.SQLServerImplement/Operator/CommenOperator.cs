using System.Linq;
using CHSNS.Model;
using CHSNS.Abstractions;
using CHSNS.SQLServerImplement;

namespace CHSNS.Operator
{
	public class CommentOperator : BaseOperator, ICommentOperator
	{
		#region reply
   private static IQueryable<CommentPas> GetReplyPrivate(CHSNSDBDataContext db, long uid) {
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
                                              Sender = new NameIDPas { ID = p.UserId, Name = p.Name }
                                          }
                                               );
            return ret;
        }
        public PagedList<CommentPas> GetReply(long uid, int p, int ep)
        {
            using (var db = DBExtInstance)
            {
                return GetReplyPrivate(db, uid).Pager(p, ep);
            }
        }
		public IReply AddReply(IReply r)
		{
            using (var db = DBExtInstance)
            {
                db.Reply.InsertOnSubmit(CastTool.Cast<Reply>(r));
                db.SubmitChanges();
            }
            #region sql
//            DataBaseExecutor.Execute(
//                @"INSERT INTO [dbo].[Reply]
//([UserId],[SenderID],[Body],[AddTime],[IsSee],[IsDel],[IsTellMe])
//VALUES(@userid,@senderid,@body,getdate(),0,0,@istellme)",
//                "@userid", r.UserId,
//                "@senderid", r.SenderID,
//                "@body", r.Body,
//                "@istellme", r.IsTellMe);
            #endregion
			return r;
		}

		public void DeleteReply(long id, long userid)
		{
            using (var db = DBExtInstance)
            {
                db.Reply.DeleteOnSubmit(db.Reply.FirstOrDefault(c => c.Id == id && c.UserId == userid));
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
		/// <param name="showerId">The shower ID.</param>
		/// <param name="type">The type.</param>
		/// <param name="p"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
        public PagedList<CommentPas> CommentList(long showerId, CommentType type, int p,
            int pageSize)
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
                                                            Sender = new NameIDPas { ID = p1.UserId, Name = p1.Name }
                                                        }
                                             );
                return ret.Pager(p, pageSize);//Site.EveryPage.NoteComment
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

        public void Add(IComment cmt, CommentType type)
		{
            using (var db = DBExtInstance)
            {
                db.Comment.InsertOnSubmit(CastTool.Cast<Comment>(cmt));
                switch (type)
                {
                    case CommentType.Note:
                        var n = db.Note.FirstOrDefault(c => c.Id == cmt.ShowerID);
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