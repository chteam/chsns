using System;
namespace CHSNS.Data {
	public interface IMessageMediator {
		void Add(CHSNS.Models.Message m);
		void Delete(long id, CHSNS.MessageBoxType t, long userid);
		CHSNS.ModelPas.MessageDetailsPas Details(long id, long userid);
		System.Linq.IQueryable<CHSNS.ModelPas.MessageItemPas> GetInbox(long userid);
		System.Linq.IQueryable<CHSNS.ModelPas.MessageItemPas> GetOutbox(long userid);
		long InboxCount(long userid);
		long OutboxCount(long userid);
	}
}
