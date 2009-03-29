namespace CHSNS.Service {
    using Models;
    using CHSNS;
    using System.Configuration;
    public class SQLServerDBManager : IDBManager {


        public string ConnectionString { get; private set; }
        public IContext Context { get; set; }
        public SQLServerDBManager(IContext context) {
            ConnectionString = ConfigurationManager.ConnectionStrings["CHSNSDBLink"].ConnectionString;
            Context = context;
            Init();
        }

        public CHSNSDBDataContext Instance {
            get {
                var db = new CHSNSDBDataContext(ConnectionString);
                db.DeferredLoadingEnabled = false;
                return db;
            }
        }
        #region ²Ù×÷µ¥Àý

        public IAccountService Account { get; private set; }
        public IViewService View { get; private set; }
        public ICommentService Comment { get; private set; }
        public IGatherService Gather { get; private set; }
        public IGroupService Group { get; private set; }
        public IUserService UserInfo { get; private set; }
        public IGolbalService Golbal { get; private set; }
        public IFriendService Friend { get; private set; }
        public IApplicationService Application { get; private set; }
        public IMessageService Message { get; private set; }
        public INoteService Note { get; private set; }
        public IEventService Event { get; private set; }
        public IAlbumService Album { get; private set; }
        public IPhotoService Photo { get; private set; }
        public ISuperNoteService Video { get; private set; }

        #endregion

        public void Init() {
            //_DB = new CHSNSDBDataContext(DataBaseExecutor.DataOpener.Connection);
            Account = new AccountService(this);
            Gather = new GatherService(this);
            View = new ViewService(this);
            Comment = new CommentService(this);
            Group = new GroupService(this);
            UserInfo = new UserService(this);
            Golbal = new GolbalService(this);
            Friend = new FriendService(this);
            Application = new ApplicationService(this);
            Message = new MessageService(this);
            Note = new NoteService(this);
            Event = new EventService(this);
            Video = new VideoService(this);
        }




        //private DataBaseExecutor _dbex;
        //public DataBaseExecutor DataBaseExecutor {
        //    get {
        //        //	return new DataBaseExecutor(new EntityOpener(ConnectionString));
        //        if (_dbex == null)
        //            _dbex = new DataBaseExecutor(new SqlDataOpener(ConnectionString));
        //        return _dbex;
        //    }
        //}



        public void Dispose() {
            //if (_dbex != null)
            //    DataBaseExecutor.Dispose();
        }



    }
}
