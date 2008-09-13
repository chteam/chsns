using System;
using System.Data.EntityClient;

namespace CHSNS.Data
{
	using System.Data;
	using System.Collections;
	using Models;
	using System.Linq;
	using LinqToSqlExtensions;
	using Config;
	using CHSNS;
	public partial class DBExt :IDisposable
	{
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

	
//        public void Comment_Remove(long id) {
//            #region Sql
//            /*CREATE PROCEDURE [dbo].[CommentDelete]
//@userid bigint,
//@commentid bigint,
//@logid bigint=null

//AS
//BEGIN
//    SET NOCOUNT ON;
//declare @id bigint,@type tinyint
//select @id=0
//select @id=id,@logid=logid,@type=[type] from comment 
//    where id = @Commentid AND (ownerid = @userid or senderid=@userid) and isdel=0
//if @id=0--不存在 
//return 0
//-----------------------------回复数量操作完毕
//Update Comment Set IsDel=1 WHERE  (id = @Commentid)
//if @type=0
//    update [Profile] set CommentCount=CommentCount-1       
//    WHERE     (UserId = @userid) and CommentCount>0
//if @type=1
//    update  [Log] set CommentCount=CommentCount-1      
//    WHERE     (Id = @logid) and CommentCount>0
//if @type=2
//    update  photos set CommentCount=CommentCount-1      
//    WHERE     (id = @logid) and CommentCount>0
//return 1;
//END*/
//            #endregion
//            //CHSNSDBDataContext db = new CHSNSDBDataContext(SiteConfig.SiteConnectionString);
//            //var cmt = (from c in db.Comment
//            //           where c.ID == id &&
//            //           (c.OwnerID == CHSNSUser.Current.UserID || c.SenderID == CHSNSUser.Current.UserID)
//            //           && !c.IsDel
//            //           select new
//            //           {
//            //               Id = c.ID,
//            //               Logid = c.LogID,
//            //               Type = c.Type,
//            //               c.IsDel,
//            //               Ownerid = c.OwnerID,
//            //               Senderid = c.SenderID
//            //           }).SingleOrDefault();
//            //if (cmt.Id == 0 || !(cmt.Senderid == CHSNSUser.Current.UserID || cmt.Ownerid == CHSNSUser.Current.UserID || CHSNSUser.Current.isAdmin)) {
//            //    return;
//            //}
//            //db.Comment.Delete(c => c.ID == id);
//            //db.SubmitChanges();
//            //DataBaseExecutor me = new DataBaseExecutor();
//            //me.SqlExecute(
//            //    string.Format("update comment set isdel=1 where id={0}", id)
//            //    );
//            switch (cmt.Type) {
//                case 0:
//                    DataBaseExecutor.Execute(
//    string.Format(@"update [Profile] set CommentCount=CommentCount-1       
//	WHERE     (UserId = {0}) and CommentCount>0", cmt.Ownerid)
//    );
//                    //db.Profile.Update(
//                    //    p => new Profile
//                    //    {
//                    //        CommentCount = p.CommentCount - 1
//                    //    },
//                    //    p => p.UserId == cmt.ownerid
//                    //        && p.CommentCount > 0
//                    //);
//                    break;
//                case 1:
//                    DataBaseExecutor.Execute(
//    string.Format(@"update  [Log] set CommentCount=CommentCount-1      
//	WHERE     (Id ={0}) and CommentCount>0", cmt.Logid)
//    );
//                    //db.Note
//                    //.Update(
//                    //    n => new Note
//                    //    {
//                    //        CommentCount = n.CommentCount - 1
//                    //    },
//                    //    n => n.id == cmt.Logid
//                    //        && n.CommentCount > 0
//                    //);
//                    break;
//                case 2:
//                    DataBaseExecutor.Execute(
//    string.Format(@"update  photos set CommentCount=CommentCount-1      
//	WHERE     (id = {0}) and CommentCount>0", cmt.Logid)
//    );
//                    //db.Photos.Update(
//                    //    p => new Photos
//                    //    {
//                    //        CommentCount = p.CommentCount - 1
//                    //    },
//                    //    p => p.id == cmt.Logid
//                    //        && p.CommentCount > 0
//                    //);
//                    break;
//                default:
//                    break;
//            }
			
//        }



		#endregion

		#region IDisposable 成员

		public void Dispose() {
			DB.Connection.Dispose();
		}

		#endregion
	}
}
