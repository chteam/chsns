using System.Data;
using System.Linq;
using CHSNS.Models;

namespace CHSNS.Data {
	public class CommentMediator : BaseMediator {
		public CommentMediator(DBExt id) : base(id) { }
		public DataRowCollection NewFiveReply() {
			return DataBaseExecutor.GetRows("Reply_New", "@userid", CHUser.UserID);
		}
		public IQueryable<ReplyPas> GetReply(long userid) {
			var ret = (from r in DBExt.DB.Reply
					   join p in DBExt.DB.Profile on r.SenderID equals p.UserID
					   where r.UserID == userid
					   orderby r.ID descending
					   select new ReplyPas {
						   Reply = r,
						   Sender = new NameIDPas {
							   ID = p.UserID,
							   Name = p.Name
						   }
					   }
					  );
			return ret;
		}
		public Reply AddReply(Reply r){
			DataBaseExecutor.Execute(
				@"INSERT INTO [sq_menglei].[dbo].[Reply]
([UserID],[SenderID],[Body],[AddTime],[IsSee],[IsDel],[IsTellMe])
VALUES(@userid,@senderid,@body,getdate(),0,0,@istellme)",
				"@userid", r.UserID,
				"@senderid", r.SenderID,
				"@body", r.Body,
				"@istellme", r.IsTellMe);
			DataBaseExecutor.Execute("update [profile] set replycount=replycount+1 where userid=@userid",
			                         "@userid", r.UserID);
			return r;
		}
		public void DeleteReply(long id, long userid) {
			DataBaseExecutor.Execute(@"delete [reply] where id=@id and userid=@userid",
				"@id", id,
				"@userid", userid);
			DataBaseExecutor.Execute(@"update [profile] set ReplyCount=ReplyCount-1
where userid=@userid",
				"@userid", userid);
		}
	}
}
