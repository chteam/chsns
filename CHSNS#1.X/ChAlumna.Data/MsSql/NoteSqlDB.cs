namespace CHSNS.Data
{
	using System.Data;
	using System.Collections;
	using ChAlumna.Models;
	using System.Linq;
	using System;
	using LinqToSqlExtensions;
	using ChAlumna.Config;
	using ChAlumna;
	public partial class DBExt 
	{
	
		/// <summary>
		/// log userid, body, title,isPost, AddTime, EditTime,Groupid,LastCommentUserid
		/// </summary>
		/// <param name="l"></param>
		public void Note_Add(Note l) {
			l.AddTime = DateTime.Now;
			l.EditTime = DateTime.Now;
			l.LastCommentTime = DateTime.Now;
			l.userid = ChUser.Current.Userid;
			ChAlumnaDBDataContext db = new ChAlumnaDBDataContext(SiteConfig.SiteConnectionString);
			db.Note.InsertOnSubmit(l);
			db.SubmitChanges();

			if (l.GroupId > 0) {
				//update [Group] set logcount= logcount+1 where id=@groupid
				var group = (from g in db.Group
							 where g.id == l.GroupId
							 select g).Single();
				group.LogCount++;
			} else {
				/*update [profile] set Score=Score+dbo.fun_GetScore(''note_add''),
				ShowScore=ShowScore+dbo.fun_GetScore(''note_add'') where userid=@userid*/
				var profile = (from p in db.Profile
							   where p.UserId == l.userid
							   select p).Single();
				profile.LogCount++;
				profile.ShowScore++;
				profile.Score++;
			}
			if (l.IsPost < 200)//其它人可见
			{
				#region sql

				/*EXECUTE [dbo].[Event_Add] 
	   @userid
	  ,@userid
	  ,2
	  ,@title
	  ,@code
				 @fromid	bigint	,
@toid	bigint	,
@type	int	,
@Application	nvarchar(50)=null	,
@Actionid	bigint=null,
@Strext1 nvarchar(4000)=null,
@Strext2 nvarchar(4000)=null,
@Strext3 nvarchar(4000)=null,
@Numext1 bigint=null,
@Numext2 bigint=null,
@Numext3 bigint=null
				 * 
				 INSERT INTO [Event]
                      (fromid, toid, Addtime, [type], [Application], Actionid)
VALUES     (@fromid, @toid, Getdate(), @type, @Application, @Actionid)
				 
				 */
				#endregion
				Event e = new Event();
				e.fromid = l.userid;
				e.toid = l.userid;
				e.type = 2;
				e.Application = l.title;
				e.Addtime = DateTime.Now;
				e.Actionid = l.id;
				db.Event.InsertOnSubmit(e);
			}
			db.SubmitChanges();
		}

		public void Note_Edit(Note l) {
			#region Sql
			/*
CREATE PROCEDURE [dbo].[Note_Update]
--@title nvarchar(255),
@body	ntext,
@isPost	tinyint,
@id bigint,
@userid bigint,
@groupid bigint=0
AS
Declare @us bigint
select @us=dbo.UserStatus(@userid,@groupid);
--删除记录至新表----
if exists(Select id from [log] where (id = @id) and (userid =@userid) and (groupid =@groupid)) or @us>199
begin
UPDATE [Log]
SET EditTime = { fn NOW() },
      isPost = @isPost,
      body = @body
WHERE ([id]=@id) and groupid=@groupid
RETURN 1
end else
begin
return -1--无权操作
end*/
			#endregion
			int us = UserStatus(ChUser.Current.Userid, l.GroupId);
			//DataBaseExecutor me = new DataBaseExecutor();
			Dictionary dict = new Dictionary();
			dict.Add("@body", l.body);
			DBE.Execute(
				string.Format(@"UPDATE [Log] 
SET EditTime = getdate(),
isPost = {0},
body = @body,
istellme = {1}
WHERE ([id]={2}) 
and groupid={3}
and (userid ={4} or {5}>199)",
l.IsPost,
l.istellme,
l.id,
l.GroupId,
ChUser.Current.Userid,
us), dict);
		}


		public void Note_Remove(long logid, long groupid) {
			Dictionary dict = new Dictionary();
			dict.Add("@id", logid);
			dict.Add("@userid", ChUser.Current.Userid);
			dict.Add("@groupid", groupid);
			//DataBaseExecutor me = new DataBaseExecutor();
			DBE.Execute("Note_Remove", dict);
		}
		public int Note_Push(long logid) {
			Dictionary d = new Dictionary();
			d.Add("@viewerid", ChUser.Current.Userid);
			d.Add("@Logid", logid);
			//DataBaseExecutor me = new DataBaseExecutor();
			return (int)DBE.ExecuteScalar("LogPush", d);
		}
	}
}
