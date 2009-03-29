using System;

namespace CHSNS.Service {
	public interface IDBManager : IDisposable {
		string ConnectionString { get; }
        IContext Context { get; set; }
		//DataBaseExecutor DataBaseExecutor { get; }
        Models.CHSNSDBDataContext Instance { get; }
		IAccountService Account { get; }
		IApplicationService Application { get; }
		ICommentService Comment { get; }
		IEventService Event { get; }
		IFriendService Friend { get; }
		IGatherService Gather { get; }
		IGolbalService Golbal { get; }
		IGroupService Group { get; }
		IMessageService Message { get; }
		INoteService Note { get; }
		IUserService UserInfo { get; }
		IViewService View { get; }
		/*相册*/
		IAlbumService Album { get; }
		IPhotoService Photo { get; }
        /*Video*/
        ISuperNoteService Video { get; }

	}
}
