using System;
using System.Linq;
namespace CHSNS.Data {
	public interface IDBManager : IDisposable {
		string ConnectionString { get; }
        IContext Context { get; set; }
		CHSNS.DataBaseExecutor DataBaseExecutor { get; }
        [Obsolete("过时")]
		CHSNS.Models.CHSNSDBDataContext DB { get; }
        CHSNS.Models.CHSNSDBDataContext Instance { get; }
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
		/*相册*/
		IAlbumMediator Album { get; }
		IPhotoMediator Photo { get; }
        /*Video*/
        ISuperNoteMediator Video { get; }

	}
}
