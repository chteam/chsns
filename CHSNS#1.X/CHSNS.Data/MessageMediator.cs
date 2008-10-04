using System.Web;

namespace CHSNS.Data {
	using System.Linq;
	using Models;

	public class MessageMediator : BaseMediator {
		public MessageMediator(DBExt id) : base(id) { }
		public IQueryable<MessageItemPas> GetInbox(long userid) {
			var ret = (from m in DBExt.DB.Message
					   join p in DBExt.DB.Profile on m.FromID equals p.UserID
					   where m.ToID == userid && !m.IsToDel
					   orderby m.IsSee, m.ID descending
					   select new MessageItemPas {
						   ID = m.ID,
						   Username = p.Name,
						   UserID = p.UserID,
						   Title = m.Title,
						   SendTime = m.SendTime,
						   IsSee = m.IsSee
					   }
					  );
			return ret;
		}

		public IQueryable<MessageItemPas> GetOutbox(long userid) {
			var ret = (from m in DBExt.DB.Message
					   join p in DBExt.DB.Profile on m.ToID equals p.UserID
					   where m.FromID == userid && !m.IsFromDel
					   orderby m.ID descending
					   select new MessageItemPas {
						   ID = m.ID,
						   Username = p.Name,
						   UserID = p.UserID,
						   Title = m.Title,
						   SendTime = m.SendTime,
						   IsSee = m.IsSee
					   }
					  );
			return ret;
		}
		public long InboxCount(long userid) {
			var ret = (from p in DBExt.DB.Profile
					   where p.UserID == userid
					   select p.InboxCount).FirstOrDefault();
			return ret;
		}
		public long OutboxCount(long userid) {
			var ret = (from p in DBExt.DB.Profile
					   where p.UserID == userid
					   select p.OutboxCount).FirstOrDefault();
			return ret;
		}
		public void Add(Message m){
			DataBaseExecutor.Execute(// 发送站内信
				@"INSERT INTO [Message]
           ([FromID],[ToID],[Title],[Body],[SendTime],[IsSee],[IsFromDel],[IsToDel] ,[IsHtml])
VALUES(@fromid,@toid,@title,@body,getdate(),0,0,0,@ishtml)",
				"@fromid", m.FromID,
				"@toid", m.ToID,
				"@title", HttpUtility.HtmlEncode(m.Title),
				"@body", m.IsHtml ? m.Body : HttpUtility.HtmlEncode(m.Body),
				"@ishtml", m.IsHtml
				);
			DataBaseExecutor.Execute(@"update [profile] set inboxcount=inboxcount+1,unreadMessageCount=unreadMessageCount+1 where userid=@userid",
				"@userid",m.ToID);
			DataBaseExecutor.Execute(@"update [profile] set outboxcount=outboxcount+1 where userid=@userid",
				"@userid", m.FromID);
		}

		public void Delete(long id, MessageBoxType t, long userid) {
			if (t == MessageBoxType.Inbox) {
				DataBaseExecutor.Execute("update [message] set istodel=1 where id=@id", "@id", id);
				DataBaseExecutor.Execute("update [profile] set inboxcount=inboxcount-1 where userid=@id and inboxcount>0", "@id", userid);
			} else {//发件箱
				DataBaseExecutor.Execute("update [message] set isfromdel=1 where id=@id", "@id", id);
				int tr = DataBaseExecutor.Execute(@"update [profile] 
				set unreadMessageCount=unreadMessageCount-1,outboxcount=outboxcount-1
where userid=@uid and unreadMessageCount>0 and outboxcount>0 and 
exists(select 1 from [message] where id=@id and issee=0)", "@uid", userid, "@id", id);
				if (tr != 1)//上条未更新，证明是已经读的
					DataBaseExecutor.Execute("update [profile] set outboxcount=outboxcount-1 where userid=@id and outboxcount>0", "@id", userid);
			}
			// TODO:应该将所有已经双方删除的 彻底更新
		}

		public MessageDetailsPas Details(long id, long userid) {
			var ret = (from m in DBExt.DB.Message
					   where m.ID == id
					   join pout in DBExt.DB.Profile on m.FromID equals pout.UserID
					   join pin in DBExt.DB.Profile on m.ToID equals pin.UserID
					   select new MessageDetailsPas {
						   UserInbox = new UserItemPas { ID = pin.UserID, Name = pin.Name },
						   UserOutbox = new UserItemPas { ID = pout.UserID, Name = pout.Name },
						   Message = m
					   }
					  ).FirstOrDefault();
			if (ret.UserInbox.ID == userid && !ret.Message.IsSee) {//我是收件人,则表示已经看过了,可以更新
				DataBaseExecutor.Execute(@"update [message] set IsSee=1 where id=@id", "@id", ret.Message.ID);
				DataBaseExecutor.Execute(@"update [profile] set unreadMessageCount=unreadMessageCount-1 where userid=@userid and unreadMessageCount>0",
	"@userid", userid);
			}
			return ret;
		}
	}
}

