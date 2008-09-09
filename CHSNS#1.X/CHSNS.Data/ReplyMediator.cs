using System.Data;
using System.Linq;
using CHSNS.Models;

namespace CHSNS.Data {
	public class ReplyMediator : BaseMediator {
		public ReplyMediator(DBExt id) : base(id) { }
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
	}
}
