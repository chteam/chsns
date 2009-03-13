namespace CHSNS.Data {
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

        public IAccountMediator Account { get; private set; }
        public IViewMediator View { get; private set; }
        public ICommentMediator Comment { get; private set; }
        public IGatherMediator Gather { get; private set; }
        public IGroupMediator Group { get; private set; }
        public IUserMediator UserInfo { get; private set; }
        public IGolbalMediator Golbal { get; private set; }
        public IFriendMediator Friend { get; private set; }
        public IApplicationMediator Application { get; private set; }
        public IMessageMediator Message { get; private set; }
        public INoteMediator Note { get; private set; }
        public IEventMediator Event { get; private set; }
        public IAlbumMediator Album { get; private set; }
        public IPhotoMediator Photo { get; private set; }
        public ISuperNoteMediator Video { get; private set; }

        #endregion

        public void Init() {
            //_DB = new CHSNSDBDataContext(DataBaseExecutor.DataOpener.Connection);
            Account = new AccountMediator(this);
            Gather = new GatherMediator(this);
            View = new ViewMediator(this);
            Comment = new CommentMediator(this);
            Group = new GroupMediator(this);
            UserInfo = new UserMediator(this);
            Golbal = new GolbalMediator(this);
            Friend = new FriendMediator(this);
            Application = new ApplicationMediator(this);
            Message = new MessageMediator(this);
            Note = new NoteMediator(this);
            Event = new EventMediator(this);
            Video = new VideoMediator(this);
        }




        private DataBaseExecutor _dbex;
        public DataBaseExecutor DataBaseExecutor {
            get {
                //	return new DataBaseExecutor(new EntityOpener(ConnectionString));
                if (_dbex == null)
                    _dbex = new DataBaseExecutor(new SqlDataOpener(ConnectionString));
                return _dbex;
            }
        }



        public void Dispose() {
            if (_dbex != null)
                DataBaseExecutor.Dispose();
        }



    }
}
