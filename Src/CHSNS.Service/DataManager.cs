namespace CHSNS.Service
{
    using System.Configuration;
    public class DataManager
    {
        //public string ConnectionString { get; set; }
        public DataManager()
        {
           // ConnectionString = ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString;
           // Init();
        }
        #region ²Ù×÷µ¥Àý

        public AccountService Account { get { return AccountService.Instance; } }
        public ViewService View { get { return ViewService.Instance; } }
        public CommentService Comment { get { return CommentService.Instance; } }
        public GatherService Gather { get { return GatherService.Instance; } }
        public GroupService Group { get { return GroupService.Instance; } }
        public UserService UserInfo { get { return UserService.Instance; } }
        //public GolbalService Golbal { get { return GolbalService.Instance; } }
        public FriendService Friend { get { return FriendService.Instance; } }
        public ApplicationService Application { get { return ApplicationService.Instance; } }
        public MessageService Message { get { return MessageService.Instance; } }
        public NoteService Note { get { return NoteService.Instance; } }
        public EventService Event { get { return EventService.Instance; } }
        public AlbumService Album { get { return AlbumService.Instance; } }
        public PhotoService Photo { get { return PhotoService.Instance; } }
        public VideoService Video { get { return VideoService.Instance; } }
        public EntryService Entry { get { return EntryService.Instance; } }

        #endregion
    }
}
