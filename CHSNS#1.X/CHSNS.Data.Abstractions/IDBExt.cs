using System;
namespace CHSNS.Data {
	public interface IDBExt : IDisposable {
		string ConnectionString { get; }
		
		CHSNS.DataBaseExecutor DataBaseExecutor { get; }
		CHSNS.Models.CHSNSDBDataContext DB { get; }

		System.Data.IDbTransaction ContextTransaction();
		System.Data.IDbTransaction ExeTransaction();

		IAccountMediator Account { get; }
		IApplicationMediator Application { get; }
		ICommentMediator Comment { get; }
		IEventMediator Event { get; }
		IFriendMediator Friend { get; }
		IGatherMediator Gather { get; }
		IGolbalMediator Golbal { get; }
		IGroupMediator Group { get; }
		IMessageMediator Message { get; }
		INoteMediator Note { get; }
		IUserMediator UserInfo { get; }
		IViewMediator View { get; }
	}
}
