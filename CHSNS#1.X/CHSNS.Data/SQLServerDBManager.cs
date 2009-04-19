namespace CHSNS.Operator {
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

        public IAccountOperator Account { get; private set; }
        public IViewOperator View { get; private set; }
        public ICommentOperator Comment { get; private set; }
        public IGatherOperator Gather { get; private set; }
        public IGroupOperator Group { get; private set; }
        public IUserOperator UserInfo { get; private set; }
        public IGolbalOperator Golbal { get; private set; }
        public IFriendOperator Friend { get; private set; }
        public IApplicationOperator Application { get; private set; }
        public IMessageOperator Message { get; private set; }
        public INoteOperator Note { get; private set; }
        public IEventOperator Event { get; private set; }
        public IAlbumOperator Album { get; private set; }
        public IPhotoOperator Photo { get; private set; }
        public ISuperNoteOperator Video { get; private set; }

        #endregion

        public void Init() {
            //_DB = new CHSNSDBDataContext(DataBaseExecutor.DataOpener.Connection);
            Account = new AccountOperator(this);
            Gather = new GatherOperator(this);
            View = new ViewOperator(this);
            Comment = new CommentOperator(this);
            Group = new GroupOperator(this);
            UserInfo = new UserOperator(this);
            Golbal = new GolbalOperator(this);
            Friend = new FriendOperator(this);
            Application = new ApplicationOperator(this);
            Message = new MessageOperator(this);
            Note = new NoteOperator(this);
            Event = new EventOperator(this);
            Video = new VideoOperator(this);
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
