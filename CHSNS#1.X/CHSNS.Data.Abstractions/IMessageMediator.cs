using System;
namespace CHSNS.Service {
	public interface IMessageService {
		void Add(CHSNS.Models.Message m);
		void Delete(long id, CHSNS.MessageBoxType t, long userid);
		CHSNS.Model.MessageDetailsPas Details(long id, long userid);
		System.Linq.IQueryable<CHSNS.Model.MessageItemPas> GetInbox(long userid);
		System.Linq.IQueryable<CHSNS.Model.MessageItemPas> GetOutbox(long userid);
		long InboxCount(long userid);
		long OutboxCount(long userid);
	}
}
