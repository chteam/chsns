namespace CHSNS
{
    using System.Configuration;
    using CHSNS.Service;
    public static class DataManager
    {
        #region ²Ù×÷µ¥Àý

        static public AccountService Account { get { return AccountService.Instance; } }
        static public ViewService View { get { return ViewService.Instance; } }
        static public CommentService Comment { get { return CommentService.Instance; } }
        static public GatherService Gather { get { return GatherService.Instance; } }
        static public GroupService Group { get { return GroupService.Instance; } }
        static public UserService UserInfo { get { return UserService.Instance; } }
        //public GolbalService Golbal { get { return GolbalService.Instance; } }
        static public FriendService Friend { get { return FriendService.Instance; } }
        static public ApplicationService Application { get { return ApplicationService.Instance; } }
        static public MessageService Message { get { return MessageService.Instance; } }
        static public NoteService Note { get { return NoteService.Instance; } }
        static public EventService Event { get { return EventService.Instance; } }
        static public AlbumService Album { get { return AlbumService.Instance; } }
        static public PhotoService Photo { get { return PhotoService.Instance; } }
        static public VideoService Video { get { return VideoService.Instance; } }
        static public EntryService Entry { get { return EntryService.Instance; } }

        #endregion
    }
}
