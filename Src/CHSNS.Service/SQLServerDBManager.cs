namespace CHSNS.Service {
    using System.Configuration;
    public class DBManager {


        public string ConnectionString { get; set; }
        public DBManager() {
            ConnectionString = ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString;
            Init();
        }
        #region ²Ù×÷µ¥Àý

        public AccountService Account {
            get { return AccountService.GetInstance(); }
        }
        public ViewService View { get { return ViewService.GetInstance(); } }
        public CommentService Comment { get { return CommentService.GetInstance(); } }
        public GatherService Gather { get { return GatherService.GetInstance(); } }
        public GroupService Group { get { return GroupService.GetInstance(); } }
        public UserService UserInfo { get { return UserService.GetInstance(); } }
        public GolbalService Golbal { get { return GolbalService.GetInstance(); } }
        public FriendService Friend { get { return FriendService.GetInstance(); } }
        public ApplicationService Application { get { return ApplicationService.GetInstance(); } }
        public MessageService Message { get { return MessageService.GetInstance(); } }
        public NoteService Note { get { return NoteService.GetInstance(); } }
        public EventService Event { get { return EventService.GetInstance(); } }
        public AlbumService Album { get { return AlbumService.GetInstance(); } }
        public PhotoService Photo { get { return PhotoService.GetInstance(); } }
        public VideoService Video { get { return VideoService.GetInstance(); } }
        public EntryService Entry { get { return EntryService.GetInstance(); } }

        #endregion

        public void Init() {
        }
        public void Dispose() {
        }



    }
}
