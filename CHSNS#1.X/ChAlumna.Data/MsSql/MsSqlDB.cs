namespace CHSNS.Data
{
	using System.Data;
	using System.Collections;
	using CHSNS.Models;
	using System.Linq;
	using System;
	using LinqToSqlExtensions;
	using CHSNS.Config;
	using CHSNS;
	public partial class DBExt 
	{
		#region IDataBase 成员
		public DBExt(IDictionary session) {
			_session = session;
		}
		public DBExt(ICHSNSDB ichsnsdb) {
			DBE = ichsnsdb.DataBaseExecutor;
		}
		public DBExt(DataBaseExecutor dbe) {
			DBE = dbe;
		}
		DataBaseExecutor DBE { get; set; }
		IDictionary _session;
		ChAlumnaDBDataContext _DB = null;
		public ChAlumnaDBDataContext DB {
			get {
				if (_DB == null)
					_DB = new ChAlumnaDBDataContext(SiteConfig.SiteConnectionString);

				return _DB;
			}
		}

		public IDictionary Session {
			get { return _session; }
			set { _session = value; }
		}

		public DataRowCollection UserListRows(long ownerid, int nowpage, byte type) {
			return DBE.GetRows("UserList",
				"@userid", ownerid,
				"@page", nowpage,
				"@class", type);
		}
		public DataRowCollection MyApplicationRows {
			get {
				return DBE.GetRows("MyApplication",
					"@userid", ChUser.Current.Userid
					);
			}
		}
		public DataRowCollection RssList(int count) {
			return DBE.GetRows("RssList",
				"@userid", ChUser.Current.Userid,
				"@page", 1,
				"@everypage", count,
				"@GroupClass", 0);
		}

		public void Comment_Remove(long id) {
			#region Sql
			/*CREATE PROCEDURE [dbo].[CommentDelete]
@userid bigint,
@commentid bigint,
@logid bigint=null

AS
BEGIN
	SET NOCOUNT ON;
declare @id bigint,@type tinyint
select @id=0
select @id=id,@logid=logid,@type=[type] from comment 
	where id = @Commentid AND (ownerid = @userid or senderid=@userid) and isdel=0
if @id=0--不存在 
return 0
-----------------------------回复数量操作完毕
Update Comment Set IsDel=1 WHERE  (id = @Commentid)
if @type=0
	update [Profile] set CommentCount=CommentCount-1       
	WHERE     (UserId = @userid) and CommentCount>0
if @type=1
	update  [Log] set CommentCount=CommentCount-1      
	WHERE     (Id = @logid) and CommentCount>0
if @type=2
	update  photos set CommentCount=CommentCount-1      
	WHERE     (id = @logid) and CommentCount>0
return 1;
END*/
			#endregion
			ChAlumnaDBDataContext db = new ChAlumnaDBDataContext(SiteConfig.SiteConnectionString);
			var cmt = (from c in db.Comment
					   where c.id == id &&
					   (c.ownerid == ChUser.Current.Userid || c.senderid == ChUser.Current.Userid)
					   && !c.IsDel
					   select new
					   {
						   c.id,
						   c.Logid,
						   c.type,
						   c.IsDel,
						   c.ownerid,
						   c.senderid
					   }).SingleOrDefault();
			if (cmt.id == 0 || !(cmt.senderid == ChUser.Current.Userid || cmt.ownerid == ChUser.Current.Userid || ChUser.Current.isAdmin)) {
				return;
			}
			db.Comment.Delete(c => c.id == id);
			db.SubmitChanges();
			//DataBaseExecutor me = new DataBaseExecutor();
			//me.SqlExecute(
			//    string.Format("update comment set isdel=1 where id={0}", id)
			//    );
			switch (cmt.type) {
				case 0:
					DBE.Execute(
	string.Format(@"update [Profile] set CommentCount=CommentCount-1       
	WHERE     (UserId = {0}) and CommentCount>0", cmt.ownerid)
	);
					//db.Profile.Update(
					//    p => new Profile
					//    {
					//        CommentCount = p.CommentCount - 1
					//    },
					//    p => p.UserId == cmt.ownerid
					//        && p.CommentCount > 0
					//);
					break;
				case 1:
					DBE.Execute(
	string.Format(@"update  [Log] set CommentCount=CommentCount-1      
	WHERE     (Id ={0}) and CommentCount>0", cmt.Logid)
	);
					//db.Note.Update(
					//    n => new Note
					//    {
					//        CommentCount = n.CommentCount - 1
					//    },
					//    n => n.id == cmt.Logid
					//        && n.CommentCount > 0
					//);
					break;
				case 2:
					DBE.Execute(
	string.Format(@"update  photos set CommentCount=CommentCount-1      
	WHERE     (id = {0}) and CommentCount>0", cmt.Logid)
	);
					//db.Photos.Update(
					//    p => new Photos
					//    {
					//        CommentCount = p.CommentCount - 1
					//    },
					//    p => p.id == cmt.Logid
					//        && p.CommentCount > 0
					//);
					break;

				default:
					break;
			}
			
		}
		/// <summary>
		/// 返回用户Status或用户在群中的Level
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="groupid"></param>
		/// <returns></returns>
		public int UserStatus(long userid, long? groupid) {
			#region Sql
			/*
CREATE FUNCTION [dbo].[UserStatus](
@userid bigint,--
@groupid bigint=null)
RETURNS tinyint--255为网站创建者
AS
BEGIN
DECLARE @ret tinyint
select @ret=0;
if(@groupid is null or @groupid=0)--查个人的级别
SELECT @ret = [status] from Account where userid=@userid
else
SELECT @ret = [level] from [groupuser] where userid=@userid and groupid=@groupid
RETURN @ret
END*/
			#endregion
			int r = 0;
			if (groupid == null || groupid == 0) {
				var ret = (from a in DB.Account
						   where a.userid == userid
						   select new
						   {
							   status = a.status
						   }).SingleOrDefault();
				r = ret.status;
			} else {
				var ret = (from g in DB.GroupUser
						   where g.userid == userid && g.Groupid == groupid
						   select new
						   {
							   status = g.Level
						   }
				   ).SingleOrDefault();
				r = ret.status;
			}
			return r;
		}


		#endregion


	}
}
