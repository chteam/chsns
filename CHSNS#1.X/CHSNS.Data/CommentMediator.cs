using System.Data;
using System.Linq;
using CHSNS.ModelPas;
using CHSNS.Models;

namespace CHSNS.Data
{
	public class CommentMediator : BaseMediator, ICommentMediator
	{
		public CommentMediator(IDBExt id) : base(id)
		{
		}

		#region reply

		public IQueryable<CommentPas> GetReply(long userid)
		{
			IQueryable<CommentPas> ret = (from r in DBExt.DB.Reply
			                              join p in DBExt.DB.Profile on r.SenderID equals p.UserID
			                              where r.UserID == userid
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
			                                     		Sender = new NameIDPas {ID = p.UserID, Name = p.Name}
			                                     	}
			                             );
			return ret;
		}

		public Reply AddReply(Reply r)
		{
			DataBaseExecutor.Execute(
				@"INSERT INTO [dbo].[Reply]
([UserID],[SenderID],[Body],[AddTime],[IsSee],[IsDel],[IsTellMe])
VALUES(@userid,@senderid,@body,getdate(),0,0,@istellme)",
				"@userid", r.UserID,
				"@senderid", r.SenderID,
				"@body", r.Body,
				"@istellme", r.IsTellMe);
			return r;
		}

		public void DeleteReply(long id, long userid)
		{
			DataBaseExecutor.Execute(@"delete [reply] where id=@id and userid=@userid",
			                         "@id", id,
			                         "@userid", userid);
		}

		#endregion

		#region comment

		/// <summary>
		/// Comments the list.
		/// </summary>
		/// <param name="ShowerID">The shower ID.</param>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public IQueryable<CommentPas> CommentList(long ShowerID, CommentType type)
		{
			var t = (int) type;
			IQueryable<CommentPas> ret = (from c in DBExt.DB.Comment
			                              join p in DBExt.DB.Profile on c.SenderID equals p.UserID
			                              where c.ShowerID == ShowerID && c.Type == t && !c.IsDel

			                              orderby c.ID descending
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
			                                     		Sender = new NameIDPas {ID = p.UserID, Name = p.Name}
			                                     	}
			                             );
			return ret;
		}

		/// <summary>
		/// 删除回复
		/// </summary>
		/// <param name="id"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public bool Delete(long id, CommentType type)
		{
			DataBaseExecutor.Execute(@"update [comment] set isdel=1 where id=@id", "@id", id);
			switch (type)
			{
				case CommentType.Note:
					DataBaseExecutor.Execute(
						@"update [Note] set commentCount=commentCount-1
where id in (select showerid from [comment] where id=@id) and commentcount>0
",
						"@id", id);
					break;
				default:
					break;
			}
			return true;
		}

		public void Add(Comment cmt, CommentType type)
		{
			DataBaseExecutor.Execute(
				@"INSERT INTO [Comment]
           ([ShowerID],[OwnerID],[SenderID],[AddTime],[Body],[Type],[IsTellMe])
VALUES (@ShowerID, @OwnerID,@SenderID, @AddTime,@Body,@Type,@IsTellMe)"
				, "@ShowerID", cmt.ShowerID
				, "@OwnerID", cmt.OwnerID
				, "@SenderID", cmt.SenderID
				, "@AddTime", cmt.AddTime
				, "@Body", cmt.Body
				, "@Type", cmt.Type
				, "@IsTellMe", cmt.IsTellMe
				);
			switch (type)
			{
				case CommentType.Note:
					DataBaseExecutor.Execute(@"update [Note] set commentCount=commentCount+1
where id=@id", "@id", cmt.ShowerID);
					break;
				default:
					break;
			}
		}

		#endregion
	}
}