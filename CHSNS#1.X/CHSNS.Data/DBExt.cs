using System.Data.EntityClient;

namespace CHSNS.Data {
    using System.Data;
    using Models;
    using CHSNS;
    using System.Data.Common;
    public partial class DBExt : IDBExt {
        #region IDataConcreteMediator 成员

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
        public IAlbumMediator Album {  get; private set;}
        public IPhotoMediator Photo { get; private set; }
        public ISuperNoteMediator Video { get; private set; }


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
        #endregion
        #region IDataBase 成员
        public string ConnectionString { get; private set; }
        public DBExt(IContext context) {
            //	ConnectionString = "name=Entities";
            //var conn = new EntityConnection(ConnectionString);
            _DB = new CHSNSDBDataContext();
            _dbex = new DataBaseExecutor(new SqlDataOpener(_DB.Connection));
            Context = context;
            Init(); 
        }
        public IContext Context { get; set; }
        private CHSNSDBDataContext _DB;
        public CHSNSDBDataContext DB {
            get {
                if (_DB == null)
                    _DB = new CHSNSDBDataContext();
                return _DB;
            }
        }

        private DataBaseExecutor _dbex;
        public DataBaseExecutor DataBaseExecutor {
            get {
                //	return new DataBaseExecutor(new EntityOpener(ConnectionString));
                if (_dbex == null)
                    _dbex = new DataBaseExecutor(new EntityOpener(
                                                    ((EntityConnection)DB.Connection).StoreConnection
                                                    )
                        );
                return _dbex;
            }
        }

        #endregion


        #region Transaction
        public IDbTransaction ExeTransaction() {
            var conn = DataBaseExecutor.DataOpener.Connection;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var t = conn.BeginTransaction();
            DataBaseExecutor.DataOpener.Command.Transaction = t as DbTransaction;
            return t;
        }
        public IDbTransaction ContextTransaction() {
            if (DB.Connection.State != ConnectionState.Open)
                DB.Connection.Open();
            return DB.Connection.BeginTransaction();
        }
        #endregion
        #region IDisposable 成员

        public void Dispose() {
            if (_dbex != null)
                DataBaseExecutor.Dispose();
            if (_DB != null) {
                if (DB.Connection != null) {
                    if (DB.Connection.State != ConnectionState.Closed)
                        DB.Connection.Close();
                    DB.Connection.Dispose();
                }
                DB.Dispose();
            }
        }

        #endregion


        }
}
