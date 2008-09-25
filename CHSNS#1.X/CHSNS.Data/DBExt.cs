using System;
using System.Data.EntityClient;

namespace CHSNS.Data {
	using System.Data;
	using System.Collections;
	using Models;
	using System.Linq;
	using LinqToSqlExtensions;
	using Config;
	using CHSNS;
	using System.Data.Common;
	public partial class DBExt : IDisposable {
		#region IDataConcreteMediator 成员

		public AccountMediator Account { get; private set; }
		public ViewMediator View { get; private set; }
		public CommentMediator Comment { get; private set; }
		public GatherMediator Gather { get; private set; }
		public GroupMediator Group { get; private set; }
		public UserInfoMediator UserInfo { get; private set; }
		public GolbalMediator Golbal { get; private set; }
		public FriendMediator Friend { get; private set; }
		public ApplicationMediator Application { get; private set; }
		public MessageMediator Message { get; private set; }
		public NoteMediator Note { get; private set; }
		public EventMediator Event { get; private set; }
		public void Init() {
			//_DB = new CHSNSDBDataContext(DataBaseExecutor.DataOpener.Connection);
			Account = new AccountMediator(this);
			Gather = new GatherMediator(this);
			View = new ViewMediator(this);
			Comment = new CommentMediator(this);
			Group = new GroupMediator(this);
			UserInfo = new UserInfoMediator(this);
			Golbal = new GolbalMediator(this);
			Friend = new FriendMediator(this);
			Application = new ApplicationMediator(this);
			Message = new MessageMediator(this);
			Note = new NoteMediator(this);
			Event = new EventMediator(this);
		}
		#endregion
		#region IDataBase 成员
		public string ConnectionString { get; private set; }
		public DBExt() {
			ConnectionString = "name=CHSNSDBEntities";
			var conn = new EntityConnection(ConnectionString);

			_DB = new CHSNSDBDataContext(conn);
			_dbex = new DataBaseExecutor(new SqlDataOpener(conn.StoreConnection));
			//	DataBaseExecutor = ichsnsdb.DataBaseExecutor;
			Init();
		}

		private CHSNSDBDataContext _DB;
		public CHSNSDBDataContext DB {
			get {
				if (_DB == null)
					_DB = new CHSNSDBDataContext(ConnectionString);
				return _DB;
			}
		}

		private DataBaseExecutor _dbex;
		public DataBaseExecutor DataBaseExecutor {
			get {
				//	return new DataBaseExecutor(new EntityOpener(ConnectionString));
				if (_dbex == null)
					_dbex = new DataBaseExecutor(new EntityOpener(
													(DB.Connection as EntityConnection).StoreConnection
													)
						);
				return _dbex;
			}
		}
		public DataRowCollection UserListRows(long ownerid, int nowpage, byte type) {
			return DataBaseExecutor.GetRows("UserList",
				"@userid", ownerid,
				"@page", nowpage,
				"@class", type);
		}

		#endregion


		#region Transaction

		public DbTransaction CreateTransaction() {
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
