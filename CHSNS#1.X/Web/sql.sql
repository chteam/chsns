SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetXueYuan]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070727
-- Description:	由学校名得到院系
-- =============================================
CREATE PROCEDURE [dbo].[GetXueYuan]
@School nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT   id,  XueYuan
FROM         XueYuan
WHERE     School in (select id from school where school=@school  and schoolclass=0)
ORDER BY XueYuan

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_Remove]
@albumid bigint,
@userid bigint,
@FileSizeCount bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if not exists(select 1 from album where userid=@userid and id=@albumid)
	return 0;
update [Profile] set FileSizeCount=@FileSizeCount where userid=@userid
delete dbo.Photos where  userid=@userid and Albumid=@albumid
delete [album] where userid=@userid and id=@albumid
update [Profile] set AlbumCount=AlbumCount-1 where userid=@userid
return 1;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetQinshi]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070727
-- Description:	由学校名得到那个寝室
-- =============================================
CREATE PROCEDURE [dbo].[GetQinshi]
@School nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT   id,  Qinshi
FROM        QinShi
WHERE      School in (select id from school where school=@school and schoolclass=0)
ORDER BY Qinshi

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangeShowLevelSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ChangeShowLevelSelect]
@userid bigint
AS
SELECT
PersonalInfoShowLevel, FaceShowLevel,allshowlevel
FROM [Profile]
WHERE (UserId = @userid)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Note]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Note](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL CONSTRAINT [DF_Log_userid]  DEFAULT ((0)),
	[Title] [nvarchar](255) NOT NULL CONSTRAINT [DF_Log_title]  DEFAULT (''),
	[Summary] [nvarchar](4000) NULL,
	[Body] [ntext] NOT NULL CONSTRAINT [DF_Log_body]  DEFAULT (''),
	[IsPost] [tinyint] NOT NULL CONSTRAINT [DF_Log_isPost]  DEFAULT ((0)),
	[Anonymous] [bit] NULL CONSTRAINT [DF_Log_anonymous]  DEFAULT ((1)),
	[AddTime] [datetime] NOT NULL CONSTRAINT [DF_Log_AddTime]  DEFAULT (getdate()),
	[EditTime] [datetime] NOT NULL CONSTRAINT [DF_Log_EditTime]  DEFAULT (getdate()),
	[ViewCount] [bigint] NOT NULL CONSTRAINT [DF_Log_ViewCount]  DEFAULT ((0)),
	[PushCount] [bigint] NOT NULL CONSTRAINT [DF_Log_PushCount]  DEFAULT ((0)),
	[TrackBackCount] [bigint] NOT NULL CONSTRAINT [DF_Log_TrackBackCount]  DEFAULT ((0)),
	[CommentCount] [bigint] NOT NULL CONSTRAINT [DF_Log_CommentCount]  DEFAULT ((0)),
	[LastCommentUserID] [bigint] NOT NULL CONSTRAINT [DF_Log_LastCommentUserid]  DEFAULT ((0)),
	[LastCommentTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Log_LastCommentTime]  DEFAULT (getdate()),
	[IsTellMe] [tinyint] NOT NULL CONSTRAINT [DF_Log_istellme]  DEFAULT ((1)),
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Log_id] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Note', N'COLUMN',N'IsPost'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'false为草稿true为已经发表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Note', @level2type=N'COLUMN',@level2name=N'IsPost'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_ApplyCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 17
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_ApplyCount]
@groupid bigint,
@type tinyint
AS
BEGIN
	SET NOCOUNT ON;
declare @c bigint
if @type=0--加入的成员
begin 
	select @c=count(istrue) from [groupuser] where groupid=@groupid and istrue=0
end
if @type=1
begin
	select @c=count(istrue) from [groupuser] where groupid=@groupid and [level]=2
end
return @c
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin_Class_Request_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	申请建立班级列表
-- =============================================
CREATE PROCEDURE [dbo].[Admin_Class_Request_list]
AS
BEGIN
SET NOCOUNT ON;

		SELECT 
		 [Group].[id] as groupid,[Group].GroupName,[Group].usercount as [count],
school.school as university,
XueYuan.XueYuan as xueyuan,
[group].Num0 as grade,
[Group].Istrue,
Groupuser.level,Account.name,Account.userid
		FROM [Group] INNER JOIN
		GroupUser ON GroupUser.userid=  [Group].CreateUserid
		INNER JOIN	account on account.userid=GroupUser.userid
		INNER JOIN	school on school.id=[group].Other0
		INNER JOIN	XueYuan on XueYuan.id=[group].Other1
		WHERE
		([Group].GroupClass = 1 and [group].istrue=0)

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReplyUpdateToIsSee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReplyUpdateToIsSee]
@id bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
UPDATE    Comment
SET IsSee = 1
WHERE     (id = @id)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetUserStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 07 27
-- Description:	获得用户的状态即 user.userstatus
-- =============================================
CREATE PROCEDURE [dbo].[GetUserStatus]
@Userid bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [status] from Account where userid=@userid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Push]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Push](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LogID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Push_PushTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Push] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Push] UNIQUE NONCLUSTERED 
(
	[LogID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Group]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Group](
	[ID] [bigint] IDENTITY(1000,1) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL CONSTRAINT [DF_Group_GroupName]  DEFAULT (''),
	[Summmary] [nvarchar](50) NOT NULL CONSTRAINT [DF_Group_summmary]  DEFAULT (''),
	[CreaterID] [bigint] NOT NULL,
	[AdminCount] [tinyint] NOT NULL CONSTRAINT [DF_Group_AdminCount]  DEFAULT ((1)),
	[NoteCount] [bigint] NOT NULL CONSTRAINT [DF_Group_LogCount]  DEFAULT ((0)),
	[ViewCount] [bigint] NOT NULL CONSTRAINT [DF_Group_ViewCount]  DEFAULT ((0)),
	[JoinLevel] [tinyint] NOT NULL CONSTRAINT [DF_Group_JoinLevel]  DEFAULT ((4)),
	[ShowLevel] [tinyint] NOT NULL CONSTRAINT [DF_Group_ShowLevel]  DEFAULT ((4)),
	[UserCount] [bigint] NOT NULL CONSTRAINT [DF_Group_UserCount]  DEFAULT ((1)),
	[MagicBox] [nvarchar](4000) NULL,
	[LogoUrl] [nvarchar](250) NULL,
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Group_addtime]  DEFAULT (getdate()),
	[IsTrue] [bit] NOT NULL CONSTRAINT [DF_Group_IsTrue]  DEFAULT ((1)),
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Group] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Comment](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ShowerID] [bigint] NULL,
	[OwnerID] [bigint] NOT NULL,
	[SenderID] [bigint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_comment_addtime]  DEFAULT (getdate()),
	[Body] [ntext] NOT NULL,
	[IsReply] [bit] NOT NULL CONSTRAINT [DF_Comment_IsReply]  DEFAULT ((0)),
	[IsSee] [bit] NOT NULL CONSTRAINT [DF_Comment_IsSee]  DEFAULT ((0)),
	[IsDel] [bit] NOT NULL CONSTRAINT [DF_Comment_IsDel]  DEFAULT ((0)),
	[Type] [tinyint] NOT NULL CONSTRAINT [DF_Comment_type]  DEFAULT ((0)),
	[IsTellMe] [tinyint] NOT NULL CONSTRAINT [DF_Comment_istellme]  DEFAULT ((0)),
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Comment] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_SelectAllPhoto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_SelectAllPhoto]
@userid bigint,
@id bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

select [Path] from dbo.Photos where userid=@userid and Albumid=@id
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangeShowLevelUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ChangeShowLevelUpdate] 
@PersonalInfoShowLevel tinyint,
@FaceShowLevel tinyint,
@AllShowLevel tinyint,
@userid bigint
AS
	UPDATE [Profile]
	SET 
	PersonalInfoShowLevel = @PersonalInfoShowLevel, 
	FaceShowLevel = @FaceShowLevel,
	AllShowLevel = @AllShowLevel
	WHERE (UserId = @userid)
RETURN 1
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin_Class_Request_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Admin_Class_Request_Remove]
@groupid bigint
AS
BEGIN
	SET NOCOUNT ON;
update [account] set [status]=5 where userid in (select userid from groupuser where groupid =@groupid and istrue=0)
delete groupuser where groupid =@groupid and istrue=0
delete [group] where id=@groupid and istrue=0

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Photo_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Photo_Remove]
@photoid bigint,
@userid bigint,
@FileSize bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @albumid bigint
select @albumid=0;
select @albumid=albumid from dbo.Photos where userid=@userid and id=@photoid
if @albumid=0
	return 0;
update [Profile] set FileSizeCount=FileSizeCount-@FileSize where userid=@userid--减去删除的大小

delete dbo.Photos where  userid=@userid and id=@photoid --删除此照片

update [album] set [Count]=[Count]-1 where id = @albumid and userid=@userid--相册中相处数-1
return 1;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_AddorJoin_Cancle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Class_AddorJoin_Cancle]
@groupid bigint,
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
declare @level tinyint;
select @level=[level] from groupuser where groupid=@groupid and userid=@userid  and istrue=0;
if(@level is null)
return 0;

if(@level=255)
begin
	DELETE FROM GroupUser WHERE     (Groupid = @groupid);--删除群	
	delete from [Group] where id=@groupid;--删除群用户
end
else
	DELETE FROM GroupUser WHERE  userid=@userid and (Groupid = @groupid);
update account set [status]=5 where  userid=@userid
	return 1;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGenInsertSQL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create   proc [dbo].[spGenInsertSQL] (@tablename varchar(256))  
as
begin
declare @SQL varchar(8000)
declare @SQLValues varchar(8000)
set @SQL ='' (''
set @SQLValues = ''values (''''+''
select @SQLValues = @SQLValues + cols + '' + '''','''' + '' ,@SQL = @SQL + ''['' + name + ''],''  
from  
      (select case  
                when xtype in (48,52,56,59,60,62,104,106,108,122,127)                                 
                     then ''case when ''+ name +'' is null then ''''NULL'''' else '' + ''cast(''+ name + '' as varchar)''+'' end''
                when xtype in (58,61)
                     then ''case when ''+ name +'' is null then ''''NULL'''' else ''+'''''''''''''''''' + '' + ''cast(''+ name +'' as varchar)''+ ''+''''''''''''''''''+'' end''
               when xtype in (167)
                     then ''case when ''+ name +'' is null then ''''NULL'''' else ''+'''''''''''''''''' + '' + ''replace(''+ name+'','''''''''''''''','''''''''''''''''''''''')'' + ''+''''''''''''''''''+'' end''
                when xtype in (231)
                     then ''case when ''+ name +'' is null then ''''NULL'''' else ''+''''''N'''''''''''' + '' + ''replace(''+ name+'','''''''''''''''','''''''''''''''''''''''')'' + ''+''''''''''''''''''+'' end''
                when xtype in (175)
                     then ''case when ''+ name +'' is null then ''''NULL'''' else ''+'''''''''''''''''' + '' + ''cast(replace(''+ name+'','''''''''''''''','''''''''''''''''''''''') as Char('' + cast(length as varchar) + ''))+''''''''''''''''''+'' end''
                when xtype in (239)
                     then ''case when ''+ name +'' is null then ''''NULL'''' else ''+''''''N'''''''''''' + '' + ''cast(replace(''+ name+'','''''''''''''''','''''''''''''''''''''''') as Char('' + cast(length as varchar) + ''))+''''''''''''''''''+'' end''
                else ''''''NULL''''''   
              end as Cols,name
         from syscolumns   
        where id = object_id(@tablename)  
      ) T  
set @SQL =''select ''''INSERT INTO [''+ @tablename + '']'' + left(@SQL,len(@SQL)-1)+'') '' + left(@SQLValues,len(@SQLValues)-4) + '')'''' from ''+@tablename
print @SQL exec (@SQL)
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin_Class_Request_Allow]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Admin_Class_Request_Allow]
@groupid bigint,
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
declare @level tinyint
select @level=[level] from groupuser where groupid=@groupid and userid=@userid and istrue=0;
if(@level is null)
return 0;
	update [groupuser] set istrue=1 where groupid=@groupid and userid=@userid
if(@level=255)
begin

	UPDATE [Group]	SET	istrue =  1 WHERE (id = @groupid)
end
else
begin
		UPDATE [Group]	SET	UserCount = UserCount + 1 WHERE (id = @groupid)
end
update account set [status]=8 where  userid=@userid
	return 1;

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Count] [bigint] NOT NULL CONSTRAINT [DF_category_Count]  DEFAULT ((0)),
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_category] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Category', N'COLUMN',N'Type'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 is group ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Type'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Category', N'COLUMN',N'Count'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Count'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[Split](
@s   varchar(8000),  --待分拆的字符串
@split varchar(10)     --数据分隔符
)RETURNS @re TABLE([id] int IDENTITY(1,1),col varchar(100))
AS
BEGIN
	--创建分拆处理的辅助表(用户定义函数中只能操作表变量)
	DECLARE @t TABLE(ID int IDENTITY,b bit)
	INSERT @t(b) SELECT TOP 8000 0 FROM syscolumns a,syscolumns b

	INSERT @re SELECT SUBSTRING(@s,ID,CHARINDEX(@split,@s+@split,ID)-ID)
	FROM @t
	WHERE ID<=LEN(@s+''a'') 
		AND CHARINDEX(@split,@split+@s,ID)=ID
	RETURN
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonalInformation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PersonalInformation](
	[UserID] [bigint] NOT NULL,
	[LoveLike] [nvarchar](255) NULL,
	[LoveBook] [nvarchar](255) NULL,
	[LoveMusic] [nvarchar](255) NULL,
	[LoveMovie] [nvarchar](255) NULL,
	[LoveSports] [nvarchar](255) NULL,
	[LoveGame] [nvarchar](255) NULL,
	[LoveComic] [nvarchar](255) NULL,
	[JoinSociety] [nvarchar](255) NULL,
 CONSTRAINT [PK_PersonalInformation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Relation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	得到浏览者与页面主人的关系
-- =============================================
CREATE PROCEDURE  [dbo].[Relation]
@ownerid bigint,
@viewerid bigint
AS
BEGIN
	declare @ownerStatus tinyint,@viewerStatus tinyint
	select @ownerStatus=[status] from Account where userid=@ownerid
	select @viewerStatus=[status] from Account where userid=@viewerid
if @ownerid=@viewerid-- or (@ownerStatus<@viewerStatus and @viewerStatus>199)
return 200--本人
else if exists(SELECT     id
FROM         Friend
WHERE     (fromid = @ownerid) AND (toid = @viewerid) OR
(fromid = @viewerid) AND (toid = @ownerid)and istrue=1) 
return 150--好友
--else if exists(SELECT     friendid
--FROM         (SELECT     fromid AS friendid
--                       FROM          Friend
--                       WHERE      (toid = @viewerid)
--                       UNION
--                       SELECT     toid AS friendid
--                       FROM         Friend AS Friend_3
--                       WHERE     (fromid = @viewerid)) AS a
--WHERE     (friendid IN
--                          (SELECT     fromid AS friendid
--                            FROM          Friend AS Friend_2
--                            WHERE      (toid = @ownerid)
--                            UNION
--                            SELECT     toid AS friendid
--                            FROM         Friend AS Friend_1
--                            WHERE     (fromid = @ownerid))))
--return 1
else
return 0
--=========返回说明=========
--        ''0任何人
--        ''1好友的好友
--        ''2好友 
--        ''255本人
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Album](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ShowLevel] [tinyint] NOT NULL CONSTRAINT [DF_Album_Showlevel]  DEFAULT ((0)),
	[Description] [nvarchar](150) NOT NULL,
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Album_Addtime]  DEFAULT (getdate()),
	[Order] [int] NOT NULL CONSTRAINT [DF_Album_Order]  DEFAULT ((0)),
	[Location] [nvarchar](50) NULL,
	[FaceUrl] [nvarchar](250) NULL,
	[Count] [int] NOT NULL CONSTRAINT [DF_Album_Count]  DEFAULT ((0)),
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Album] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 08 21
-- Description:	搜索用户
-- =============================================
CREATE PROCEDURE [dbo].[SearchCount]
@page bigint=1,--当前页码
@everyPage bigint=10,

@mode nvarchar(255)=null,
@userid bigint=null,
@Name nvarchar(12)=null,
@University nvarchar(50)=null,
@email nvarchar(50)=null,
@HighSchool  nvarchar(50)=null,
@XueYuan  nvarchar(50)=null,
@Grade smallint=null,
@Province smallint=null,--这个和City比较特殊
@City int=null
--,@birthday nvarchar(100)=null
,@LoveLike nvarchar(50)=null
,@LoveBook nvarchar(50)=null
,@LoveMusic nvarchar(50)=null
,@LoveMovie nvarchar(50)=null
,@LoveSports nvarchar(50)=null
,@LoveGame nvarchar(50)=null
,@LoveComic nvarchar(50)=null
,@JoinSociety nvarchar(50)=null
,@uid bigint=null
,@xid bigint=null
,@qid bigint=null
AS
BEGIN
	SET NOCOUNT ON;
if (@userid=0)
	select @userid=null
	--	declare @uni_id bigint
	--	select @uni_id=id from [school] where school=@University
declare @count bigint
if (@mode=''personal'')
begin
		select @count=count(1)
	from PersonalInformation 
		inner join SchoolInformation on	PersonalInformation.userid=SchoolInformation.userid 
		inner join account on PersonalInformation.userid=account.userid
		LEFT JOIN	XueYuan on SchoolInformation.XueYuan=XueYuan.id
		LEFT JOIN	Qinshi on SchoolInformation.Qinshi=Qinshi.id
		where
		SchoolInformation.University=isnull(@uid,SchoolInformation.University) and
SchoolInformation.xueyuan=isnull(@xid,SchoolInformation.xueyuan) and
		[LoveLike] like ''%''+isnull(@LoveLike,[LoveLike] ) +''%'' and
		[LoveBook] like ''%''+isnull(@LoveBook,[LoveBook] ) +''%'' and
		LoveMusic like ''%''+isnull(@LoveMusic,LoveMusic ) +''%'' and
		LoveMovie like ''%''+isnull(@LoveMovie,LoveMovie ) +''%'' and
		LoveSports like ''%''+isnull(@LoveSports,LoveSports ) +''%'' and
		LoveGame like ''%''+isnull(@LoveGame,LoveGame ) +''%'' and
		LoveComic like ''%''+isnull(@LoveComic,LoveComic ) +''%'' and
		JoinSociety like ''%''+isnull(@JoinSociety,JoinSociety ) +''%'' and account.status>4
end
else
if (@mode=''name'')
begin
	select @count=count(1)
		from account
		where
		[name] like ''%''+isnull(@name,[name])+''%'' and
		account.status>1
end
else
	select @count=count(1)
			from account Left join [profile] on [profile].userid=account.userid
		left join BasicInformation on account.userid=BasicInformation.userid
		left join SchoolInformation on	account.userid=SchoolInformation.userid 
		left JOIN	school on SchoolInformation.University=school.id
		LEFT JOIN	XueYuan on SchoolInformation.XueYuan=XueYuan.id
		LEFT JOIN	Qinshi on SchoolInformation.Qinshi=Qinshi.id
		where
		[profile].userid=isnull(@userid,[profile].userid) and
		[email]=isnull(@email,[email]) and
		[name] like ''%''+isnull(@name,[name])+''%'' and
SchoolInformation.grade=isnull(@grade,SchoolInformation.grade) and
		SchoolInformation.University=isnull(@uid,SchoolInformation.University) and
		SchoolInformation.xueyuan=isnull(@xid,SchoolInformation.xueyuan) and
SchoolInformation.qinshi=isnull(@qid,SchoolInformation.qinshi) and
		Account.status>4


return @count
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Account](
	[UserID] [bigint] IDENTITY(10000,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [char](32) NOT NULL,
	[Code] [bigint] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Search]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 08 21
-- Description:	搜索用户
-- =============================================
CREATE PROCEDURE [dbo].[Search]

@page bigint=1,--当前页码
@everyPage bigint=10,

@mode nvarchar(255)=null,
@userid bigint=null,
@Name nvarchar(12)=null,
@University nvarchar(50)=null,
@email nvarchar(50)=null,
@HighSchool  nvarchar(50)=null,
@XueYuan  nvarchar(50)=null,
@Grade smallint=null,
@Province smallint=null,--这个和City比较特殊
@City int=null
--,@birthday nvarchar(100)=null
,@LoveLike nvarchar(50)=null
,@LoveBook nvarchar(50)=null
,@LoveMusic nvarchar(50)=null
,@LoveMovie nvarchar(50)=null
,@LoveSports nvarchar(50)=null
,@LoveGame nvarchar(50)=null
,@LoveComic nvarchar(50)=null
,@JoinSociety nvarchar(50)=null
,@uid bigint=null
,@xid bigint=null
,@qid bigint=null
AS
BEGIN
	SET NOCOUNT ON;
if (@userid=0)
	select @userid=null
		--declare @uni_id bigint
		--select @uni_id=id from [school] where school=@University
if (@mode=''personal'')
begin

		SELECT TOP (@everyPage) * FROM(
		SELECT  top (@page*@everyPage) 
		account.id,account.UserId,[Name],@University as University,
@uid as Universityid,
	XueYuan.XueYuan AS XueYuan,XueYuan.id AS XUEYUANID,
	Qinshi.Qinshi AS Qinshi,Qinshi.id AS QinshiID
,Grade
		,ROW_NUMBER() OVER (ORDER BY account.id) AS RowNo
		from PersonalInformation 
		inner join SchoolInformation on	PersonalInformation.userid=SchoolInformation.userid 
		inner join account on PersonalInformation.userid=account.userid
		LEFT JOIN	XueYuan on SchoolInformation.XueYuan=XueYuan.id
		LEFT JOIN	Qinshi on SchoolInformation.Qinshi=Qinshi.id
		where
		SchoolInformation.University=isnull(@uid,SchoolInformation.University) and
SchoolInformation.xueyuan=isnull(@xid,SchoolInformation.xueyuan) and
		[LoveLike] like ''%''+isnull(@LoveLike,[LoveLike] ) +''%'' and
		[LoveBook] like ''%''+isnull(@LoveBook,[LoveBook] ) +''%'' and
		LoveMusic like ''%''+isnull(@LoveMusic,LoveMusic ) +''%'' and
		LoveMovie like ''%''+isnull(@LoveMovie,LoveMovie ) +''%'' and
		LoveSports like ''%''+isnull(@LoveSports,LoveSports ) +''%'' and
		LoveGame like ''%''+isnull(@LoveGame,LoveGame ) +''%'' and
		LoveComic like ''%''+isnull(@LoveComic,LoveComic ) +''%'' and
		JoinSociety like ''%''+isnull(@JoinSociety,JoinSociety ) +''%'' and account.status>4
		)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage
end
else
if (@mode=''name'')
begin
	SELECT TOP (@everyPage) * FROM(
		SELECT  top (@page*@everyPage) account.[id], account.UserId,[Name]
		,ROW_NUMBER() OVER (ORDER BY account.id) AS RowNo
		from account
		where
		[name] like ''%''+isnull(@name,[name])+''%'' and
		account.status>1)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage
end
else
	SELECT TOP (@everyPage) * FROM(
		SELECT  top (@page*@everyPage) account.[id], account.UserId,[Name],
	school.school as University,school.id as Universityid,
	XueYuan.XueYuan AS XueYuan,XueYuan.id AS XUEYUANID,
	Qinshi.Qinshi AS Qinshi,Qinshi.id AS QinshiID,
Grade
		,ROW_NUMBER() OVER (ORDER BY [profile].isstar desc) AS RowNo
		from account Left join [profile] on [profile].userid=account.userid
		left join BasicInformation on account.userid=BasicInformation.userid
		left join SchoolInformation on	account.userid=SchoolInformation.userid 
		left JOIN	school on SchoolInformation.University=school.id
		LEFT JOIN	XueYuan on SchoolInformation.XueYuan=XueYuan.id
		LEFT JOIN	Qinshi on SchoolInformation.Qinshi=Qinshi.id
		where
		[profile].userid=isnull(@userid,[profile].userid) and
		[email]=isnull(@email,[email]) and
		[name] like ''%''+isnull(@name,[name])+''%'' and
SchoolInformation.grade=isnull(@grade,SchoolInformation.grade) and
		SchoolInformation.University=isnull(@uid,SchoolInformation.University) and
		SchoolInformation.xueyuan=isnull(@xid,SchoolInformation.xueyuan) and
SchoolInformation.qinshi=isnull(@qid,SchoolInformation.qinshi) and
		Account.status>4)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getFriend_Userid]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[getFriend_Userid]
(	
@userid bigint
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT     Friend.fromid as userid
	FROM         Friend 
	WHERE      (Friend.toid = @userid and IsTrue = 1 )
	union
	SELECT     friend.toid as userid
	FROM         Friend
	WHERE      (Friend.fromid = @userid and IsTrue = 1 )

)
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuperNote_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_Remove]
@id bigint,
@userid bigint,
@viewerstatus tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
Delete SuperNote where id=@id and (userid=@userid or @viewerstatus>199)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuperNote_Count]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_Count]
@userid bigint,
@type tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
select count(1) as [Count] from supernote where userid=@userid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_RandomList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_RandomList]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		SELECT TOP 10  [album].id,[album].[name] as Albumname ,Account.name as Username,[Count] as [Count] ,account.userid as ownerid,[album].[description],[album].addtime,Location,faceurl
		FROM         [album] INNER JOIN
							  Account ON [album].USERID = Account.UserId
		WHERE 	Showlevel<=0 and faceurl is not null
ORDER BY NEWID() 
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GroupUser](
	[UserID] [bigint] NOT NULL,
	[GroupID] [bigint] NOT NULL,
	[Level] [tinyint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Table_1_addtime]  DEFAULT (getdate()),
	[NoteCount] [bigint] NOT NULL CONSTRAINT [DF_GroupUser_LogCount]  DEFAULT ((0)),
	[IsTrue] [bit] NOT NULL CONSTRAINT [DF_GroupUser_IsTrue]  DEFAULT ((0)),
 CONSTRAINT [PK_GroupUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CommentSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 le:10 20 
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CommentSelect]
@logid bigint=null,
@ownerid bigint=null,
@page bigint=1,--当前页码
@everyPage bigint=20,
@type tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
if @logid=0
select @logid = null
if @ownerid=0
select @ownerid = null
if @logid is null and @ownerid is null
return;

if @type!=0
begin
		SELECT TOP (@everyPage) *
		  FROM      (
		SELECT  top (@page*@everyPage)     Comment.[id], Comment.body, Comment.addtime,[Comment].Ownerid,IsDel, issee,
[Account].UserId,[Account].Name,
	ROW_NUMBER() OVER (order by Comment.addtime) AS RowNo 
		FROM         Comment INNER JOIN
		[Account] ON Comment.senderid = [Account].UserId
		WHERE   Comment.Logid = @logid
		and [type]=@type and isdel=0
		)AS A-- 
		WHERE RowNo > (@page-1)*@everyPage

end
else
begin
		SELECT TOP (@everyPage) *
		  FROM      (
		SELECT  top (@page*@everyPage)     Comment.[id], Comment.body, Comment.addtime,[Comment].Ownerid,IsDel, issee,
[Account].UserId,[Account].Name,
	ROW_NUMBER() OVER (order by Comment.addtime desc,Comment.id desc) AS RowNo 
		FROM         Comment INNER JOIN
		[Account] ON Comment.senderid = [Account].UserId
		WHERE  ( Comment.Logid is null or Comment.Logid=0)
		and Comment.ownerid=@ownerid
		and [type]=@type and isdel=0
		)AS A-- 
		WHERE RowNo > (@page-1)*@everyPage
end
END
--0个人留言 userid
--1日志回复 logid
--2相册留言 photoid
--3超级日志 supernoteid
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CommentInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CommentInsert]
@Logid	bigint=null,
@ownerid	bigint,
@senderid	bigint,
@body	ntext,
@isreply bit=0,
@isOnMyPage bit=0,
@type tinyint=0
AS
BEGIN
if(@Logid=0)
	select @logid =null
	SET NOCOUNT ON;
-- 如果在本页回复留言 ，则要给对方留言 还要自己副本
if @isreply=1 and @isOnMyPage=1 and @type=0
begin
	INSERT INTO Comment
	 (Logid, ownerid, senderid, body,isreply)
	VALUES    (@Logid, @senderid, @senderid, @body,@isreply)
end
INSERT INTO Comment
                      (Logid, ownerid, senderid, body,isreply,[type])
VALUES    (@Logid, @ownerid, @senderid, @body,@isreply,@type)


	--返回数据集
	SELECT     Account.UserId,[Name], Comment.addtime, --University,
	Comment.body, Comment.id,Comment.IsDel,Comment.Ownerid
	FROM         Comment INNER JOIN
			Account ON Comment.senderid = Account.UserId
--inner join SchoolInformation on Comment.senderid=SchoolInformation.userid
	WHERE     (Comment.trueid = @@IDENTITY)

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_Option]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 19
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_Option]
@groupid bigint,
@userid bigint,
@executerid bigint,
@type tinyint,
@isAdmin bit=null
AS
BEGIN
	SET NOCOUNT ON;
	declare @Exel tinyint,@bl tinyint,@bistrue bit
	if(@isAdmin=1)
		select @Exel=255
	else
		select @Exel=[level] from [groupuser] where groupid=@groupid and userid=@executerid and istrue=1
	select @bl=[level],@bistrue=istrue from [groupuser] where groupid=@groupid and userid=@userid
	if @Exel is null or @bl is null--不是本群人,白干 
		return 0--成员不在群中
	if @Exel<200 return 0
	if(@type=0 and @bl=1 and @bistrue=0)--同意加为群成员
	begin
		update [groupuser] set istrue=1 where groupid=@groupid and userid=@userid
		UPDATE [Group]	SET		UserCount = UserCount + 1 WHERE (id = @groupid)
		if exists(select 1 from [group] where id=@groupid and groupclass=1)--大学
		begin
			update [account] set [status]=8 where [status]<8 and userid=@userid
		end
		else
		begin
				declare @GroupName nvarchar(50)
				select @GroupName=GroupName from [group] where id=@groupid
				EXECUTE [dbo].[Event_Add] 
				   @userid
				  ,@userid
				  ,6
				  ,@GroupName
				  ,@groupid
		end
	end
	else if @type=1 and @bl=1 and @bistrue=0--不同意加为群成员
	begin
		delete [groupuser] where groupid=@groupid and userid=@userid and istrue=0
		if exists(select 1 from [group] where id=@groupid and groupclass=1)--大学
		begin
			update [account] set [status]=5 where [status]<8 and userid=@userid
		end
	end
	else if @type=2 and @bl=2 and @Exel=255 and @bistrue=1--同意成为管理员
	begin
		update [groupuser] set [level]=200 where groupid=@groupid and userid=@userid and istrue=1
		UPDATE [Group]	SET		AdminCount = AdminCount + 1 WHERE (id = @groupid)
	end
	else if @type=3 and @bl=2 and @Exel=255 and @bistrue=1--不同意加为管理员
	begin
		update [groupuser] set [level]=1 where groupid=@groupid and userid=@userid and istrue=1
	end
	else if @type=4 and @bl=200 and @Exel=255 and @bistrue=1--转让群主
	begin
		update [groupuser] set [level]=255 where groupid=@groupid and userid=@userid and istrue=1
		update [groupuser] set [level]=200 where groupid=@groupid and userid=@executerid and istrue=1
	end
	else if @type=5 and @bl=200 and @Exel=255 and @bistrue=1--降为成员
	begin
		update [groupuser] set [level]=1 where groupid=@groupid and userid=@userid and istrue=1
	end
	else
		return 0
	return 1--成功
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070328 update 2007 8 23
-- Description:	得到我的群的列表
-- =============================================
CREATE PROCEDURE [dbo].[GroupList]
@userid bigint,
@GroupClass bigint=0,
@page bigint=1,--当前页码
--@Count bigint,--总记录数默认每页为10只
@everyPage bigint=10,
@type tinyint=0
AS
BEGIN
	SET NOCOUNT ON;

if @type=0--我的群列表
	SELECT TOP (@everyPage) *
      FROM      (
		SELECT  top (@page*@everyPage)  
		 [Group].[id] as groupid,[Group].GroupName,[Group].usercount as [count],[groupuser].[level]
		,ROW_NUMBER() OVER (ORDER BY [group].id desc) AS RowNo
		FROM GroupUser INNER JOIN
		[Group] ON [Group].id = GroupUser.Groupid
		WHERE
		([Group].GroupClass = @groupclass)
		AND (GroupUser.userid = @userid) and (groupuser.istrue=1)
		)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage
if @type=1--所有群,按groupclass分
	select top (@everyPage) * from(select
		[id] as groupid,GroupName,usercount as [count]
		FROM         [Group] where  GroupCLass=@GroupClass
	)b ORDER BY NEWID() 
if(@type=2)
		SELECT 
		 [Group].[id] as [id],[Group].GroupName,[Group].usercount as [count],
school.school as university,
XueYuan.XueYuan as xueyuan,
[group].Num0 as grade,[Groupuser].Istrue,Groupuser.level
		FROM GroupUser INNER JOIN
		[Group] ON [Group].id = GroupUser.Groupid
		INNER JOIN	school on school.id=[group].Other0
		INNER JOIN	XueYuan on XueYuan.id=[group].Other1
		WHERE
		([Group].GroupClass = @groupclass)
		AND (GroupUser.userid = @userid)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PassSafeSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PassSafeSelect]
@userid bigint
AS
SELECT Question, Answer FROM account where userid=@userid
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070329
-- Description:	加入群
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_Add] 
@userid bigint,
@groupid bigint
AS
BEGIN
	SET NOCOUNT ON;
--判断用户已经存在于此群中
if exists(SELECT id FROM GroupUser WHERE (Groupid = @groupid) AND (userid = @userid))
		return 2--用户已存在或已经提交请求或群主已经发出请求
if exists(SELECT id FROM [Group] WHERE(UserCount >= MaxUserCount) AND (id = @groupid) and istrue=1)
		return 3--群已满
	DECLARE @J bigint,@GROUPCLASS TINYINT,@userstatus int
	
	SELECT	@J= JoinLevel, @GROUPCLASS= GROUPCLASS	FROM	[Group]	WHERE	(id = @groupid)
	SELECT  @userstatus=[status] from Account where userid=@userid
	IF @GROUPCLASS=1
	BEGIN
		if @userstatus<1
			return 4	--用户的非法请求
		if @userstatus<6
			UPDATE    Account SET [Status] = 6	WHERE     (UserId = @userid)
		if exists(select 1 from [group] inner join [groupuser] on [group].id=groupuser.groupid	where groupclass=1 and groupuser.userid=@userid)
			return 25;
		SELECT	@J=4--班级模式时不进行审核
	END
	
		--0 不经审核直接加入 
		--4 需审核
		--8 只能管理员进行邀请
		if @J=0
			begin
				INSERT INTO GroupUser
									  ([Level], Groupid, userid, Class, IsTrue)
				VALUES         (1, @groupid, @userid, 0, 1)
				--将群人数自增
				UPDATE    [Group]
				SET		UserCount = UserCount + 1 WHERE (id = @groupid)
				declare @GroupName nvarchar(50)
				select @GroupName=GroupName from [group] where id=@groupid
				EXECUTE [dbo].[Event_Add] 
				   @userid
				  ,@userid
				  ,6
				  ,@GroupName
				  ,@groupid

				return 9--已经加入群
			end
		--GroupUser.level=1为普通用户

		if @J=4
			INSERT INTO GroupUser
								  ([Level], Groupid, userid,Class, IsTrue)
			VALUES         (1, @groupid, @userid, 4, 0)--需管理员审核
		if @J=8
			INSERT INTO GroupUser
			 ([Level], Groupid, userid,Class, IsTrue)
			VALUES         (1, @groupid, @userid, 8, 0)--需用户同意

return 1

--成功添加
--return 9--已经加入群
--case 2:"已经提交申请,请等待管理员审核.";
--case 3:"群已满,请联系管理员对群进行扩容"
--return 4	--用户的非法请求
--return 25 对不起,您只能加入一个大学班级
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PassSafeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PassSafeUpdate]
@userid bigint,
@o_question nvarchar(50),
@o_answer nvarchar(50),
@question nvarchar(50),
@answer nvarchar(50)
AS
if exists(select [id] from account where userid=@userid and question=@o_question and answer=@o_answer)
	begin
		UPDATE account SET Question = @Question, Answer = @Answer WHERE (UserId = @userid)
		return 1
	end
else
	RETURN -1 --信息不符
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reply]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reply](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[SenderID] [bigint] NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Reply_addtime]  DEFAULT (getdate()),
	[IsSee] [bit] NOT NULL CONSTRAINT [DF_Reply_IsSee]  DEFAULT ((0)),
	[IsDel] [bit] NOT NULL CONSTRAINT [DF_Reply_IsDel]  DEFAULT ((0)),
	[IsTellMe] [tinyint] NOT NULL CONSTRAINT [DF_Reply_istellme]  DEFAULT ((0)),
 CONSTRAINT [PK_Reply_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuperNote_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_Add]
@url nvarchar(500),
@description nvarchar(50),
@userid bigint,
@title nvarchar(50),
@faceurl nvarchar(500),
@showlevel tinyint,
@systemcategory bigint=null,
@category bigint=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO SuperNote
                      (title,faceurl,url, [description], userid,showlevel,systemcategory,category)
VALUES     (@title,@faceurl,@url, @description, @userid,@showlevel,@systemcategory,@category)

			EXECUTE [dbo].[Event_Add] 
			   @userid
			  ,@userid
			  ,5
			  ,@title
			  ,null
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 10 16
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_Add]
@userid bigint,
@name nvarchar(50),
@Location nvarchar(50),
@Showlevel tinyint,
@Description nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if exists(select 1 from album where [name]=@name and userid=@userid)
	return 0;
INSERT INTO [dbo].[Album]
           ([userid]
           ,[name]
           ,[Showlevel]
           ,[Description]
           ,[Location])
     VALUES
           (@userid
           ,@name
           ,@Showlevel
           ,@Description
           ,@Location);
if(@Showlevel!=200)
EXECUTE [dbo].[Event_Add] 
   @userid
  ,@userid
  ,3
  ,@name
  ,@@IDENTITY
update [Profile] set AlbumCount=AlbumCount+1 where userid=@userid
return 1;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupListCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupListCount]
@userid bigint,
@GroupClass bigint=0,
@type tinyint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @count bigint
if(@type=0 and @GroupClass=0)
 select @count=groupCount from [Profile] where userid=@userid
return @count
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RssList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 08 22
-- Description:	我订阅的主题
-- =============================================
CREATE PROCEDURE [dbo].[RssList]
@userid bigint,
@page bigint=1,--当前页码
@everyPage bigint=10,
@groupclass tinyint=0--查询类型
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP (@everyPage) *
      FROM      (
	SELECT  top (@page*@everyPage)    [log].id as logid,[Log].title, [GROUP].groupname,[group].id as groupid, [name],[log].userid,[log].addtime
,ROW_NUMBER() OVER (ORDER BY [log].id desc) AS RowNo
FROM         GroupUser INNER JOIN
                      [Log] ON GroupUser.Groupid = [Log].GroupId INNER JOIN
                      Account ON [Log].userid = Account.UserId INNER JOIN
                      [Group] ON [Log] .groupid = [Group].id
WHERE     (GroupUser.userid = @userid) AND Groupuser.isrss =1 and [group].groupclass=@groupclass and datediff("ww",[log].addtime,getdate())=0
--ORDER BY [log].id desc
)AS T-- 
	WHERE RowNo > (@page-1)*@everyPage
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetScore]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetScore]
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @r bigint
select @r=score from [Profile] where userid=@userid
return @r
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RandomGroup10]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RandomGroup10]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT TOP 10 * FROM [group] where groupclass=0 ORDER BY NEWID() 


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NoteList_Month]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NoteList_Month]
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT count([id]) as counter,
     year(AddTime) as [year] ,month(AddTime)as [month]
  FROM [Log]
 where userid =@userid and Groupid=0
Group by year(AddTime) ,month(AddTime)
order by  year(AddTime) desc ,month(AddTime)  desc
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetUserGroupCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070329
-- Description:	用户群个数
-- =============================================
CREATE PROCEDURE [dbo].[GetUserGroupCount]
@userid bigint,
@groupclass tinyint=0
AS
BEGIN
SET NOCOUNT ON;
SELECT     COUNT(GroupUser.IsTrue) AS C
FROM         GroupUser INNER JOIN
                      [Group] ON GroupUser.groupid = [Group].id
WHERE     (GroupUser.userid = @userid) AND (GroupUser.IsTrue = 1) AND [GROUP] .groupclass = @groupclass

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BasicInformation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BasicInformation](
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Email] [nvarchar](500) NULL,
	[IsEmailTrue] [bit] NOT NULL CONSTRAINT [DF_BasicInformation_IsEmailTrue]  DEFAULT ((0)),
	[Sex] [bit] NULL,
	[Birthday] [smalldatetime] NULL CONSTRAINT [DF_BasicInformation_BirthDay]  DEFAULT ('19850101'),
	[ProvinceID] [int] NOT NULL CONSTRAINT [DF_BasicInformation_Province]  DEFAULT ((0)),
	[CityID] [bigint] NOT NULL CONSTRAINT [DF_BasicInformation_City]  DEFAULT ((0)),
	[ShowLevel] [tinyint] NOT NULL CONSTRAINT [DF_BasicInformation_ShowLevel]  DEFAULT ((0)),
 CONSTRAINT [PK_BasicInformation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchGroup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchGroup]
@GroupName nvarchar(50),
@GroupClass TINYINT=0,
@page bigint=1,--当前页码
--@Count bigint,--总记录数默认每页为10只
@everyPage bigint=10
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP (@everyPage) *
      FROM      (
		SELECT  top (@page*@everyPage)  
		 [Group].[id] as groupid,[Group].GroupName,[Group].usercount as [count]
		,ROW_NUMBER() OVER (ORDER BY [group].id desc) AS RowNo
		FROM [Group] 
		WHERE
		 GroupCLass=@GroupClass AND GROUPNAME like ''%''+@GroupName+''%''
		)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Note_top]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Note_top]
@logid bigint,
@groupid bigint,
@executerid bigint,
@ispost tinyint
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @right tinyint,@mylevelingroup tinyint

if exists(select 1 from groupuser where userid=@executerid and [level]>199) or
exists(select 1 from Account where  userid=@executerid and [status]>199)
 begin
	update [log] set ispost=@ispost where id=@logid and groupid=@groupid
	return 1

end
else
return 0;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchGroupCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchGroupCount]
@GroupName nvarchar(50),
@GroupClass TINYINT=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @c bigint
		SELECT @c=count(1)
		FROM [Group] 
		WHERE
		GroupCLass=@GroupClass AND GROUPNAME like ''%''+@GroupName+''%''
return @c
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CommentDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CommentDelete]
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

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SetStarLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	用户星级的定义处理方案
-- =============================================
CREATE PROCEDURE [dbo].[SetStarLevel]
@userid bigint,
@isstar bit=null,
@isupdate bit=null,
@executerid bigint=null
AS
BEGIN
	SET NOCOUNT ON;
--        ''0 0->1 0
--        ''0 1->上传后 为0 1
--        ''1 1->上传后 为1 0
--        ''1 0->上传后仍为1 0
--即为二值相异不变
--二值相同转化为1 0
	if @isstar is null or @isupdate is null or @executerid is null--系统自动设置
	begin
		if exists(Select 1 from [Profile] where (UserId = @userid) and IsStar=IsUpdate)
			--相同就
			UPDATE    [Profile]
			SET IsUpdate = 0, IsStar = 1, CreateTime = getdate()
			WHERE     (UserId = @userid)
		else
			--相异的处理就是不变不过要处理一下
			UPDATE    [Profile]
			SET CreateTime = getdate()
			WHERE     (UserId = @userid)
	end
	else--管理员操作
	begin
		if exists(select 1 from [account] where userid=@executerid and [status]>200)
		begin
			UPDATE    [Profile]
			SET CreateTime = getdate(),IsUpdate = @isupdate, IsStar = @isstar
			WHERE     (UserId = @userid)
			
		end
	end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyApplication_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MyApplication_Save]
@userid bigint,
@appstr varchar(4000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

update [profile] set Applications=@appstr where userid=@userid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Note_Comment]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 ,2007 9 26
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Note_Comment]
@userid bigint,
@page bigint=1,
@everypage bigint=10,
@type tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
if(@type=0)
SELECT TOP (@everyPage) *
      FROM (SELECT  top (@page*@everyPage)
			Comment.senderid, 
			[Log].id AS Logid, [Log].title, comment.body,
			Comment.id as Commentid,
			Comment.addtime, 
			[name]
			,ROW_NUMBER() OVER (ORDER BY Comment.id desc) AS RowNo
			FROM         Comment INNER JOIN
			 [Log] ON Comment.Logid = [Log].id INNER JOIN
			 Account ON Comment.senderid = Account.UserId
			WHERE     (Comment.ownerid = @userid) and [Log].groupid=0 and (Comment.Logid!=0)
			)AS A-- 发件箱
	WHERE RowNo > (@page-1)*@everyPage
else
begin
	SELECT count(1) as counter
			FROM         Comment INNER JOIN
			 [Log] ON Comment.Logid = [Log].id 
			WHERE     (Comment.ownerid = @userid) and [Log].groupid=0 and (Comment.Logid!=0)
end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tags]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tags](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Count] [bigint] NOT NULL CONSTRAINT [DF_Tags_Count]  DEFAULT ((0)),
	[Type] [tinyint] NOT NULL CONSTRAINT [DF_Tags_type]  DEFAULT ((0)),
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CommentCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070321
-- Description:	得到用户留言数
-- =============================================
CREATE PROCEDURE [dbo].[CommentCount]
@id bigint,
@type tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
declare @rt bigint
if @type=0
	SELECT     @rt=CommentCount
	FROM         [Profile]
	WHERE     (UserId = @id)
if @type=1
	SELECT     @rt=CommentCount
	FROM         [Log]
	WHERE     (Id = @id)
if @type=2
	select @rt=CommentCount from photos where id=@id
return @rt
END
--0个人留言 userid
--1日志回复 logid
--2相册留言 photoid
--3超级日志 supernoteid
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reply_New]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702, update 2007 9 28
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reply_New]
@userid bigint
AS
BEGIN
SET NOCOUNT ON;
	SELECT Top 5 Comment.Logid,Account.UserId, [Name],[log].title,
	 Comment.id,Comment.Isreply, Comment.addtime,[type],[log].groupid
	FROM Comment INNER JOIN
	 Account ON Comment.senderid = Account.UserId left join
	[log] on Comment.Logid=[log].id
	WHERE (Comment.ownerid = @userid) 
	AND (Comment.IsSee = 0) 
	AND (Comment.ownerid!=Comment.senderid) 
	and (Comment.isdel=0)
	and datediff("ww",Comment.addtime,getdate())=0
	order by id desc
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogTag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogTag](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TagID] [bigint] NOT NULL,
	[LogID] [bigint] NOT NULL,
 CONSTRAINT [PK_LogTag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuperNote]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SuperNote](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL CONSTRAINT [DF_SuperNote_title]  DEFAULT (''),
	[Faceurl] [nvarchar](500) NULL,
	[Url] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[UserID] [bigint] NOT NULL,
	[ViewCount] [bigint] NOT NULL CONSTRAINT [DF_SuperNote_CommentCount]  DEFAULT ((0)),
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_SuperNote_AddTime]  DEFAULT (getdate()),
	[ShowLevel] [tinyint] NOT NULL CONSTRAINT [DF_SuperNote_showlevel]  DEFAULT ((0)),
	[SystemCategory] [bigint] NULL,
	[Category] [bigint] NULL,
	[Type] [tinyint] NOT NULL CONSTRAINT [DF_SuperNote_type]  DEFAULT ((0)),
 CONSTRAINT [PK_SuperNote] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_SuperNote] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QinShi]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[QinShi](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[QinShi] [nvarchar](50) NOT NULL,
	[SchoolID] [bigint] NOT NULL,
	[SchoolClass] [int] NOT NULL CONSTRAINT [DF_QinShi_SchoolClass]  DEFAULT ((0)),
 CONSTRAINT [PK_QinShi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_QinShi] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[City]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[City](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[PID] [int] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_City] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MySchoolSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 1 le 10 20 
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MySchoolSelect]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
U.School as University, SchoolInformation.University as University_id,
SchoolInformation.Xueyuan as Xueyuan_id,X.Xueyuan,
Grade,
SchoolInformation.Qinshi as Qinshi_id,Q.Qinshi,
H.School as Highschool,
J.School as Juniorschool,
SchoolInfoShowLevel
	from SchoolInformation
	INNER JOIN [PROFILE] ON [PROFILE].USERID=SchoolInformation.USERID
	left join School as U on U.id=SchoolInformation.University
	left join Xueyuan as X on X.id=SchoolInformation.Xueyuan
	left join Qinshi as Q on q.id=SchoolInformation.Qinshi
	left join School as H on H.id=SchoolInformation.Highschool
	left join School as J on J.id=SchoolInformation.Juniorschool
	where SchoolInformation.userid=@userid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Application]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Application](
	[ID] [bigint] IDENTITY(1000,1) NOT NULL,
	[Controller] [nvarchar](50) NOT NULL CONSTRAINT [DF_Application_Controller]  DEFAULT (''),
	[Action] [nvarchar](50) NOT NULL CONSTRAINT [DF_Application_Action]  DEFAULT (''),
	[ParamStr] [nvarchar](250) NOT NULL CONSTRAINT [DF_Application_ParamStr]  DEFAULT (''),
	[ClassName] [varchar](50) NOT NULL,
	[FullName] [nvarchar](60) NOT NULL CONSTRAINT [DF_Application_fullname]  DEFAULT (''),
	[ShortName] [nvarchar](20) NOT NULL,
	[Vision] [nvarchar](20) NOT NULL,
	[Icon] [nvarchar](250) NULL,
	[Authorid] [bigint] NULL,
	[Addtime] [smalldatetime] NOT NULL CONSTRAINT [DF_Application_Addtime]  DEFAULT (getdate()),
	[Edittime] [smalldatetime] NOT NULL CONSTRAINT [DF_Application_Edittime]  DEFAULT (getdate()),
	[Description] [ntext] NOT NULL CONSTRAINT [DF_Application_Description]  DEFAULT (''),
	[IsSystem] [bit] NOT NULL,
	[IsTrue] [bit] NOT NULL CONSTRAINT [DF_Application_isTrue]  DEFAULT ((0)),
	[DescriptionUrl] [nvarchar](250) NULL,
	[UserCount] [bigint] NOT NULL CONSTRAINT [DF_Application_UserCount]  DEFAULT ((0)),
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Table_shortname] UNIQUE NONCLUSTERED 
(
	[ShortName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuperNote_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_Update]
@id bigint,
@type tinyint
AS
BEGIN
	SET NOCOUNT ON;

update supernote set viewcount = viewcount+1 where id= @id;
if @type=1
begin
			SELECT TOP 10 supernote.id,supernote.title,supernote.faceurl,
				url,[description],viewcount,addtime,account.name,account.userid
			FROM account INNER JOIN
								  supernote ON supernote.userid = account.userid
			WHERE 	Showlevel=0 and title is not null 
					and supernote.userid in(select userid from supernote where id=@id)
			ORDER BY id desc
			return;
end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 070725 le 10 20 
-- Description:	提取用户创建班级的最基本信息
-- =============================================
CREATE PROCEDURE [dbo].[SchoolInfo]
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT   school.school AS   University, Grade,XueYuan.XueYuan
FROM          SchoolInformation
		INNER JOIN	school on SchoolInformation.University=school.id
		INNER JOIN	XueYuan on SchoolInformation.XueYuan=XueYuan.id
WHERE     (UserId = @userid)

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactInformation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContactInformation](
	[UserID] [bigint] NOT NULL,
	[Address] [nvarchar](100) NULL,
	[QQ] [nvarchar](50) NULL,
	[Msn] [nvarchar](50) NULL,
	[WangWang] [nvarchar](50) NULL,
	[NeteasePop] [nvarchar](50) NULL,
	[UC] [nvarchar](50) NULL,
	[Telphone] [nvarchar](50) NULL,
	[Mobiephone] [nvarchar](50) NULL,
	[WebSite] [nvarchar](100) NULL CONSTRAINT [DF_ContactInformation_WebSite]  DEFAULT (''),
	[TellMethod] [tinyint] NOT NULL CONSTRAINT [DF_ContactInformation_TellMethod]  DEFAULT ((1)),
	[ShowLevel] [tinyint] NOT NULL CONSTRAINT [DF_ContactInformation_ShowLevel]  DEFAULT ((200)),
 CONSTRAINT [PK_ContactInformation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserStatus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 9 30
-- Description: 当前用户的级别,或当前用户在群中的级别
-- =============================================
CREATE FUNCTION [dbo].[UserStatus]
(
	@userid bigint,--
	@groupid bigint=null
)
RETURNS tinyint--255为网站创建者
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret tinyint
select @ret=0;

if(@groupid is null or @groupid=0)--查个人的级别
	-- Add the T-SQL statements to compute the return value here
	SELECT @ret = [status] from Account where userid=@userid
else
	SELECT @ret = [level] from [groupuser] where userid=@userid and groupid=@groupid
	-- Return the result of the function
RETURN @ret

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Photos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Photos](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL CONSTRAINT [DF_Photos_name]  DEFAULT (''),
	[AlbumID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Photos_Addtime]  DEFAULT (getdate()),
	[Path] [nvarchar](500) NOT NULL,
	[Order] [bigint] NOT NULL CONSTRAINT [DF_Photos_Order]  DEFAULT ((0)),
	[CommentCount] [bigint] NOT NULL CONSTRAINT [DF_Photos_CommentCount]  DEFAULT ((0)),
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Photos] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProvinceList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ProvinceList]
AS
SELECT [id], [name] FROM [Province]  order by id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Province]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Province](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Province] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Province_name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Services]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Services](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[Answer] [nvarchar](4000) NOT NULL CONSTRAINT [DF_Services_Answer]  DEFAULT (''),
	[Status] [tinyint] NOT NULL CONSTRAINT [DF_Services_status]  DEFAULT ((0)),
	[SendTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Services_sendtime]  DEFAULT (getdate()),
	[AnswerTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Services_Answertime]  DEFAULT (getdate()),
	[UserID] [bigint] NOT NULL CONSTRAINT [DF_Services_userid]  DEFAULT ((0)),
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Event](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](250) NOT NULL,
	[OwnerID] [bigint] NOT NULL,
	[ViewerID] [bigint] NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[ShowLevel] [int] NOT NULL CONSTRAINT [DF_Event_type]  DEFAULT ((0)),
	[Json] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Event] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRandom]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		
-- Create date: 2007 9 14
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetRandom]()
RETURNS bigint
AS
BEGIN
RETURN Datediff("mi",CONVERT(datetime,''2007-9-8''),CONVERT(VARCHAR(30),GETDATE(),9))
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Search_Class]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Search_Class]
@University bigint,
@XueYuan bigint=null,
@Grade bigint=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT     GroupName, summmary, [group].id
FROM         [Group]
WHERE     (Other0 = @University) 
AND (Num0 = isnull(@Grade,Num0)) 
AND (Other1 = isnull(@XueYuan,Other1)) and groupclass=1
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_Takein]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 15
-- Description:	订阅
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_Takein]
@groupid bigint,
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;

update [groupuser] set isrss=1 where groupid=@groupid and userid=@userid and istrue=1
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	退出,解散群
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_Remove]
@userid bigint,
@executerid bigint,
@Groupid bigint
AS
BEGIN
	SET NOCOUNT ON;
declare @l tinyint,@bl tinyint
select @l=[level] from [groupuser] where groupid=@groupid and userid=@executerid and istrue=1
select @bl=[level] from [groupuser] where groupid=@groupid and userid=@userid
if @l is null or @bl is null--不是本群人,白干 
	return 0--成员不在群中
if(((@userid=@executerid or @l>199) and @bl<200)or(@userid=@executerid and @l=255))--执行者为至少为管理员，被执行者不是管理 员
	begin
		if @bl!=255--不是群主
		begin
			delete from [groupuser] where groupid=@groupid and userid=@userid--删除成员
			update [group] set UserCount=UserCount-1 where id=@groupid
				if exists(select 1 from [group] where id=@groupid and groupclass=1)--大学
				begin
					--update [account] set [status]=5 where [status]<8 and userid=@userid
					return 5
				end
			return 1--成功
		end
		else
		begin
			IF EXISTS(SELECT ID FROM [GROUP] WHERE ID=@GROUPID AND UserCount<=1)--可以删除
			begin
				declare @isclass bit
				select @isclass=groupclass from [group] where id=@groupid
				DELETE FROM GroupUser WHERE     (Groupid = @groupid)--删除群
				delete from [Group] where id=@groupid--删除群用户
				if @isclass=1--大学
				begin
					--update [account] set [status]=5 where [status]<8 and userid=@userid
					return 5
				end
				return 1--successful
			end
			else
				return -1--用户多不可删
		end
	end
else
	return -2--不可直接删除管理员
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Profile](
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL CONSTRAINT [DF_Profile_Name]  DEFAULT (''),
	[ShowText] [nvarchar](20) NULL,
	[ShowTextTime] [smalldatetime] NULL,
	[Score] [bigint] NOT NULL CONSTRAINT [DF_User_Score]  DEFAULT ((50)),
	[ShowScore] [bigint] NOT NULL CONSTRAINT [DF_User_ShowScore]  DEFAULT ((50)),
	[DelScore] [bigint] NOT NULL CONSTRAINT [DF_User_DelScore]  DEFAULT ((0)),
	[MagicBox] [ntext] NOT NULL CONSTRAINT [DF_User_MagicBox]  DEFAULT (''),
	[AllShowLevel] [tinyint] NOT NULL CONSTRAINT [DF_User_AllShowLevel]  DEFAULT ((0)),
	[IsMagicBox] [bit] NOT NULL CONSTRAINT [DF_User_IsMusic]  DEFAULT ((1)),
	[ViewCount] [bigint] NOT NULL CONSTRAINT [DF_User_ViewCount]  DEFAULT ((0)),
	[IsStar] [bit] NOT NULL CONSTRAINT [DF_User_IsStart]  DEFAULT ((0)),
	[IsUpdate] [bit] NOT NULL CONSTRAINT [DF_User_IsUpdate]  DEFAULT ((0)),
	[Applications] [varchar](max) NULL,
	[Applicationlist] [varchar](max) NULL,
	[Field] [tinyint] NULL,
	[Status] [int] NOT NULL CONSTRAINT [DF_Profile_Status]  DEFAULT ((0)),
	[RegTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Profile_RegTime]  DEFAULT (getdate()),
	[LoginTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Profile_LoginTime]  DEFAULT (getdate()),
	[AlbumCount] [bigint] NOT NULL CONSTRAINT [DF_User_AlbumCount]  DEFAULT ((0)),
	[UnReadMessageCount] [bigint] NOT NULL CONSTRAINT [DF_Profile_UnReadMessageCount]  DEFAULT ((0)),
	[OutboxCount] [bigint] NOT NULL CONSTRAINT [DF_User_MessageAll]  DEFAULT ((200)),
	[InboxCount] [bigint] NOT NULL CONSTRAINT [DF_User_MessageCount]  DEFAULT ((0)),
	[FileSizeAll] [bigint] NOT NULL CONSTRAINT [DF_User_FileSizeAll]  DEFAULT ((2097152)),
	[FileSizeCount] [bigint] NOT NULL CONSTRAINT [DF_User_FileSizeCount]  DEFAULT ((0)),
	[FriendRequestCount] [bigint] NOT NULL CONSTRAINT [DF_Profile_FriendRequestCount]  DEFAULT ((0)),
	[FriendCount] [bigint] NOT NULL CONSTRAINT [DF_User_FriendCount]  DEFAULT ((0)),
	[NoteCount] [bigint] NOT NULL CONSTRAINT [DF_User_LogCount]  DEFAULT ((0)),
	[ReplyCount] [bigint] NOT NULL CONSTRAINT [DF_User_CommentCount]  DEFAULT ((0)),
	[GroupCount] [int] NOT NULL CONSTRAINT [DF_User_GroupCount]  DEFAULT ((0)),
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Profile', N'COLUMN',N'UserID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户唯一标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Profile', @level2type=N'COLUMN',@level2name=N'UserID'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyMagicBoxUpBack]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MyMagicBoxUpBack]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @MagicBox nvarchar(4000)

SELECT    @MagicBox= MagicBox
FROM         [Profile]
WHERE     (UserId = @userid)

exec MessageInsert
@userid, 
@userid,
''备份'',
@MagicBox

return
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MiniField]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MiniField](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PID] [bigint] NOT NULL,
	[Class] [int] NOT NULL CONSTRAINT [DF_XueYuan_SchoolClass]  DEFAULT ((0)),
 CONSTRAINT [PK_MiniField] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_XueYuan_id] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_XueYuan_school_xueyuan] UNIQUE NONCLUSTERED 
(
	[PID] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CityList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CityList]
@pid tinyint
AS
SELECT [id], [name] FROM [City] WHERE ([pid] = @pid)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupSetting_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 0727改
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupSetting_Select]
@id bigint,
@userid bigint=null
AS
BEGIN
	SET NOCOUNT ON;
		DECLARE @S tinyint,@rt int,@count bigint,@userlevel int,@isrss bit,@groupclass tinyint
		select @rt=-1
if not( @userid is null)
begin
		SELECT     @S=ShowLevel	,@groupclass=groupclass	FROM         [Group] where id=@id
		----------------------------------------------------------
		if (@S=8)--成员才能，看/发
			begin
				if exists(SELECT     IsTrue			FROM         GroupUser
				WHERE     (userid = @userid) AND (Groupid = @id) AND (IsTrue = 1))
					select @rt= 0--本群用户可发帖
				else
					select @rt= 8--非本群用户不能看，立即退出
			end
		-------------------------------------------------------
		else
			begin	
				--exec ViewInsert @userid,@id,1;--插入看的人这个在ViewList里实现了,现删去
				if (@S=0)--公开
					select @rt= 0--可以发帖
				-------------------------------------------------------
				if (@S=4)--公开或可看但不能发贴
					if exists(SELECT     IsTrue		FROM         GroupUser
					WHERE     (userid = @userid) AND (Groupid = @id) AND (IsTrue = 1))
					select @rt= 0--本群用户可发帖
				else
					select @rt= 4--非本群用户只能看
			end
--计算日志总数
--select @count=count(1) from [Log] where groupid=@id
--群暂时没有必要记录查看的次数
end
if(@rt=0)
select @userlevel=[level],@isrss=IsRss from groupuser where  (userid = @userid) AND (Groupid = @id) AND (IsTrue = 1)
else
select @userlevel=0
if(@groupclass!=1)
		SELECT    GroupName,summmary, Publish,GroupClass, JoinLevel, ShowLevel,CreateUserid,AdminCount,
		 @rt AS [Right],ViewCount, UserCount,MaxUserCount, MagicBox, LogoUrl, LogCount,addtime,
isnull(Num0,0) as Num0,isnull(Other0,'''') as Other0,isnull(Other1,'''') as Other1,
isnull(Other2,'''') as Other2,isnull(@userlevel,0) as UserLevel,isnull(@isrss,0) as IsRss
		FROM         [Group]
		WHERE     (id = @id)
else
		SELECT    GroupName,summmary, Publish,GroupClass, JoinLevel, ShowLevel,CreateUserid,AdminCount,
		 @rt AS [Right],ViewCount, UserCount,MaxUserCount, MagicBox, LogoUrl, LogCount,addtime,
isnull(Num0,0) as Num0,school.school as Other0,xueyuan.xueyuan as Other1,
isnull(Other2,'''') as Other2,isnull(@userlevel,0) as UserLevel,isnull(@isrss,0) as IsRss
		FROM         [Group] 
		inner join school on school.id=Other0 
		inner join xueyuan on xueyuan.id=Other1
		WHERE     ([Group].id = @id)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupSetting_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 ,9 17
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupSetting_Update]
@groupid bigint,
@GroupName nvarchar(50),
@userid bigint,
@Publish nvarchar(4000),
@ShowLevel tinyint,
@JoinLevel tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if exists(SELECT     id--当前的执行者是否有权利
FROM         GroupUser
WHERE     (Groupid = @groupid) AND (userid = @userid) AND (IsTrue = 1) AND ([Level] > 199))
	begin
				if exists(select id from [group] where groupclass=1 and id = @groupid)
				select @JoinLevel=4--要批准
				if exists(select id from [group] where groupname=@groupname)
				select @groupname=null
				UPDATE    [Group]
				SET  GroupName=isnull(@GroupName,GroupName), Publish = @Publish, ShowLevel = @ShowLevel, JoinLevel = @JoinLevel
				where id=@groupid
			if (@GroupName is null)
				return -2--已经存在重名群但其它部分已经更新
			else
				return 1
	end
else
	return -1--您不是管理员不能执行此操作
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ViewData](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OwnerID] [bigint] NOT NULL CONSTRAINT [DF_Table_1_userid]  DEFAULT ((0)),
	[ViewerID] [bigint] NOT NULL CONSTRAINT [DF_ViewData_Viewerid]  DEFAULT ((0)),
	[IpandComputer] [nvarchar](50) NULL,
	[ViewPageUrl] [nvarchar](255) NULL,
	[LastUrl] [nvarchar](255) NULL,
	[ViewTime] [datetime] NOT NULL CONSTRAINT [DF_ViewData_ViewTime]  DEFAULT (getdate()),
	[ViewClass] [tinyint] NOT NULL CONSTRAINT [DF_ViewData_ViewClass]  DEFAULT ((0)),
 CONSTRAINT [PK_ViewData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FieldInformation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FieldInformation](
	[UserID] [bigint] NOT NULL,
	[Field] [bigint] NOT NULL,
	[Year] [smallint] NULL CONSTRAINT [DF_SchoolInformation_Grade]  DEFAULT ((0)),
	[MiniField] [bigint] NULL,
	[QinShi] [bigint] NULL,
	[Field1] [bigint] NULL,
	[Field2] [bigint] NULL,
 CONSTRAINT [PK_SchoolInformation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Xueyuan]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Xueyuan]
AS
SELECT     id, trueid, name AS xueyuan, pid AS school, class AS schoolclass
FROM         dbo.MiniField
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Xueyuan', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "MiniField"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 168
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Xueyuan'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Xueyuan', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Xueyuan'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Account_Add]
@name nvarchar(12),
@Email nvarchar(50),
@Password char(32),
@question nvarchar(50)=null,
@answer nvarchar(50)=null
AS
if @email=''''or @password=''''or @question='''' or @answer=''''
return -2
IF EXISTS(SELECT [ID] FROM [Account] WHERE Email=@Email)
return -1---用户已经存在

DECLARE @userid bigint,@code bigint

INSERT INTO [Account]
      ([name],UserId, Email, TrueEmail, [Password], TruePassword)
VALUES (@name,0,@Email,@Email,@Password,@Password)

--生成独立认证码
--生成独立认证码
--select @userid =@@IDENTITY+dbo.GetRandom(),@code=(rand()*@@IDENTITY);

--UPDATE [Account] SET UserId = @userid , Code = @code WHERE id=@@IDENTITY AND email=@email

select userid,code from account where id=@@IDENTITY--@code
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserNameByUserId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserNameByUserId]
@Userid bigint--,
--@RETURN_VALUE nvarchar(50) output
AS
BEGIN

	SET NOCOUNT ON;
select [name] from Account where userid=@userid
return
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comment_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Comment_Update]
@userid bigint,
@id bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
update comment set issee=1 where id=@id and ownerid=@userid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Friend]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Friend](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FromID] [bigint] NOT NULL CONSTRAINT [DF_Table2_send]  DEFAULT ((0)),
	[ToID] [bigint] NOT NULL CONSTRAINT [DF_Friend_toid]  DEFAULT ((0)),
	[IsTrue] [bit] NOT NULL CONSTRAINT [DF_Friend_IsTrue]  DEFAULT ((0)),
	[IsCommon] [bit] NOT NULL CONSTRAINT [DF_Friend_IsCommon]  DEFAULT ((1)),
	[FriendType] [int] NULL,
	[FriendSummary] [int] NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Friend] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Friend__294D0584] UNIQUE NONCLUSTERED 
(
	[FromID] ASC,
	[ToID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702, 9 16
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_Select]
@Groupid bigint,
@page bigint=1,
@everypage bigint=20,
@type tinyint=0
AS
BEGIN

--
	SET NOCOUNT ON;
if @type=0--@type 0成员列表
begin
	SELECT TOP (@everyPage) * FROM (
		SELECT  top (@page*@everyPage) [Name], GroupUser.userid,GroupUser.[LEVEL],
		ROW_NUMBER() OVER (ORDER BY GroupUser.id desc) AS RowNo 
		FROM         GroupUser 
		INNER JOIN Account ON GroupUser.userid = Account.userId 
		WHERE     GroupUser.groupid = @groupid AND GroupUser.istrue = 1 
	)AS A WHERE RowNo > (@page-1)*@everyPage
end
else if @type=1--管理员列表
begin
	SELECT   [name], GroupUser.userid,GroupUser.[LEVEL]
	FROM         GroupUser 
	INNER JOIN Account ON GroupUser.userid = Account.userId 
	WHERE     GroupUser.groupid = @groupid 
	AND GroupUser.istrue = 1 
	AND GroupUser.[LEVEL] > 199 and istrue=1
	order by GroupUser.[LEVEL] desc
	--创建 255
	--管理员 200
end if @type=2--申请者列表
begin
	SELECT    [name], GroupUser.userid,GroupUser.[LEVEL]
	FROM         GroupUser
	 INNER JOIN Account ON GroupUser.userid = Account.userId 
	WHERE     GroupUser.groupid = @groupid 
	AND GroupUser.istrue = 0
	order by GroupUser.[LEVEL] desc

end else if @type=3--申请管理员列表
begin
	SELECT    [name], GroupUser.userid,GroupUser.[LEVEL]
	FROM         GroupUser
	 INNER JOIN Account ON GroupUser.userid = Account.userId 
	WHERE     GroupUser.groupid = @groupid 
	AND GroupUser.istrue = 1 and [level]=2
	order by GroupUser.[LEVEL] desc

end

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comment_Update2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Comment_Update2]
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
update comment set issee=1 where ownerid=@userid and logid is null
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[unSee_Countlist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[unSee_Countlist]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
select count(1) as c from [message] where IsSee=0 and toid=@userid and istodel=0
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangePassword]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ChangePassword]
@Oldpwd Char(32),
@Newpwd char(32),
@Userid bigint
AS
IF EXISTS(SELECT 1 FROM Account WHERE USERID=@USERID AND [PASSWORD]=@OLDPWD)
BEGIN
	UPDATE Account SET [PASSWORD] =@NEWPWD WHERE USERID=@USERID
	RETURN 1
END
ELSE
	RETURN -1
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGroupRight]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070331
-- Description:	得到群的权限信息
-- 0--可以发帖 4可看 8不能看
-- =============================================
CREATE PROCEDURE [dbo].[GetGroupRight]
@userid bigint,
@groupid bigint
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @S tinyint
SELECT     @S=ShowLevel
FROM         [Group] where id=@groupid
----------------------------------------------------------
if (@S=8)--成员才能，看/发
	if exists(SELECT     IsTrue
	FROM         GroupUser
	WHERE     (userid = @userid) AND (Groupid = @groupid) AND (IsTrue = 1))
	begin
		exec ViewInsert @userid,@groupid,1;
		return 0--本群用户可发帖
	end
else
	return 8--非本群用户不能看，立即退出
-------------------------------------------------------
exec ViewInsert @userid,@groupid,1;

if (@S=0)--公开
return 0--可以发帖
-------------------------------------------------------
if (@S=4)--公开或可看但不能发贴
if exists(SELECT     IsTrue
FROM         GroupUser
WHERE     (userid = @userid) AND (Groupid = @groupid) AND (IsTrue = 1))
return 0--本群用户可发帖
else
return 4--非本群用户只能看


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolList_byProvince]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 10 3
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SchoolList_byProvince]
@province nvarchar(50)
,@schoolclass int=0--0 is University
AS
BEGIN
	SET NOCOUNT ON;
if(@province='''')
SELECT [id]
      ,[School]
  FROM [School] where SchoolClass=0
else 
SELECT [id]
      ,[School]
  FROM [School] where SchoolClass=0 and  province in (select id from province where [name]=@province)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admin_School_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 10 6
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Admin_School_Add]
@schoolname nvarchar(50),
@province nvarchar(50),
@SchoolClass int=0--大学为0;
AS
BEGIN
	SET NOCOUNT ON;
if not exists(select id from [school] where school=@schoolname and Province=@province)
begin
	insert [school](school,Province,SchoolClass) values (@schoolname,@province,@SchoolClass)
end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SetPassword]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SetPassword] 
@useremail nvarchar(50),
@password nchar(32),
@code bigint
AS
BEGIN
	SET NOCOUNT ON;

if exists(select 1 from account where email=@useremail and code= @code)
begin
	update account set [password]=@password where  email=@useremail and code= @code
return 1;
end
else
return 0;	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SetCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetCode]
@email nvarchar(50),
@code bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if exists(select 1 from account where  email=@email)
	update Account set code= @code where email=@email;
else 
	return 0;
return 1
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HTMLEncode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		zsword	
-- Create date: 2007 10 7
-- Description:	HTMLEncode
-- =============================================
CREATE FUNCTION [dbo].[HTMLEncode]
(
@str nvarchar(4000)
)
RETURNS nvarchar(4000)
AS
BEGIN
	-- Declare the return variable here
select @str = replace(@str,''<'',''&lt;'');
select @str = replace(@str,''>'',''&gt;'');
	RETURN @str

END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Message]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Message](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FromID] [bigint] NOT NULL CONSTRAINT [DF_Letter_FromId]  DEFAULT ((0)),
	[ToID] [bigint] NOT NULL CONSTRAINT [DF_Letter_ToId]  DEFAULT ((0)),
	[Title] [nvarchar](200) NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[SendTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Letter_SendTime]  DEFAULT (getdate()),
	[IsSee] [bit] NOT NULL CONSTRAINT [DF_Letter_IsSee]  DEFAULT ((0)),
	[IsFromDel] [bit] NOT NULL CONSTRAINT [DF_Message_IsFromDel]  DEFAULT ((0)),
	[IsToDel] [bit] NOT NULL CONSTRAINT [DF_Message_IsToDel]  DEFAULT ((0)),
	[IsHtml] [bit] NOT NULL CONSTRAINT [DF_Message_IsHtml]  DEFAULT ((0)),
 CONSTRAINT [PK_Message_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Message] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Blogs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Blogs](
	[UserID] [bigint] NOT NULL,
	[CreateTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Blog_CreateTime]  DEFAULT (getdate()),
	[Title] [nvarchar](50) NOT NULL,
	[SubTitle] [nvarchar](500) NULL,
	[Publish] [nvarchar](max) NULL,
	[WriteName] [nvarchar](50) NOT NULL,
	[CommentEmail] [nvarchar](50) NULL,
	[Skin] [nvarchar](50) NULL,
	[Css] [ntext] NULL,
	[MetaKey] [nvarchar](400) NULL,
	[IsWebServices] [bit] NOT NULL CONSTRAINT [DF_Blog_IsWebServices]  DEFAULT ((0)),
	[PostCount] [bigint] NOT NULL CONSTRAINT [DF_Blog_PostCount]  DEFAULT ((0)),
	[CommentCount] [bigint] NOT NULL CONSTRAINT [DF_Blog_CommentCount]  DEFAULT ((0)),
	[TrackBackCount] [bigint] NOT NULL CONSTRAINT [DF_Blog_TrackBackCount]  DEFAULT ((0)),
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Photo_Cover]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 10 22
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Photo_Cover] 
@photoid bigint,
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @path nvarchar(100),@albumid bigint;
select @path=[path],@albumid=albumid from photos where id = @photoid and userid=@userid
if(@path is null or @albumid is null)
return 0;
else
begin
	update album set faceurl=@path where id=@albumid and userid=@userid;
	return 1;
end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Photo_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Photo_Add]
@photoname nvarchar(50)='''',
@Albumid bigint,
@userid bigint,
@Path nvarchar(100),
@FileSize bigint
AS
BEGIN
	SET NOCOUNT ON;
if exists(select 1 from [profile] where userid=@userid and filesizeall>=filesizecount+@FileSize)
begin
	if exists(select 1 from album where id=@Albumid and userid=@userid)
			begin
				INSERT INTO Photos
					([name], userid, Albumid, [Path])
				VALUES     (@photoname,@userid,@Albumid,@Path)
			if exists(select 1 from album where  userid=@userid and id=@Albumid and [count]=0)
				update [album] set [Count]=[Count]+1, faceurl=@path where userid=@userid and id=@Albumid
			else
				update [album] set [Count]=[Count]+1 where userid=@userid and id=@Albumid
			update [profile] set FileSizeCount=FileSizeCount+@FileSize where userid=@userid;
		return 1
	end
	else
		return 0
end
else
return -1
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fun_GetScore]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fun_GetScore]
(
@type nvarchar(50)
)
RETURNS int
AS
BEGIN
if @type=''note_add''
return 5;
if @type=''comment_add''
return 1;
return 0;
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_ApplyMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 17
-- Description:	订阅
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_ApplyMaster]--申请成为管理员
@groupid bigint,
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
if exists(select istrue from [groupuser] where groupid=@groupid and userid=@userid and istrue=1 and [level]=1)
	begin	
		update [groupuser] set [level]=2 where groupid=@groupid and userid=@userid and istrue=1
		return 1--成功
	end
else
	return -1--您已经提交过申请
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_Update]
@albumid bigint,
@userid bigint,
@name nvarchar(50),
@Location nvarchar(50),
@Showlevel tinyint,
@Description nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if exists(select 1 from album where [name]=@name and userid=@userid and not id=@albumid)
	return 0;
	UPDATE    Album
	SET              Showlevel =@Showlevel, [name] =@name, [Description] =@Description, Location =@Location
	where userid=@userid and  id=@albumid
return 1;

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Field]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Field](
	[TrueID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID] [bigint] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PID] [bigint] NULL,
	[IsTrue] [bit] NOT NULL CONSTRAINT [DF_School_Ucounter]  DEFAULT ((1)),
	[Class] [int] NOT NULL CONSTRAINT [DF_School_SchoolClass]  DEFAULT ((0)),
 CONSTRAINT [PK_School_trueid] PRIMARY KEY CLUSTERED 
(
	[TrueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_School_id] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_School_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[Class] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[School_Trigger_Insert]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[School_Trigger_Insert]
   ON  [dbo].[Field]
   AFTER Insert
AS 
BEGIN
	SET NOCOUNT ON;
	UPDATE Field
	SET Id = trueid+dbo.GetRandom() WHERE 
	trueid in (select trueid from inserted where id is null or id=0)
END
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser_Takeout]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 9 15
-- Description:	退订
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_Takeout]
@groupid bigint,
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;

update [groupuser] set isrss=0 where groupid=@groupid and userid=@userid and istrue=1
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogPush]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LogPush] 
@Logid bigint ,
@viewerid bigint
AS
BEGIN
	SET NOCOUNT ON;



--/////已经转至COmmentCount
if exists(SELECT 1 FROM [Log] where (id = @Logid) and not ispost=255)--必须是发布的日志,可以发布
	if not exists(SELECT id FROM Push where (Logid = @Logid) and (userid=@viewerid))
	begin
		INSERT INTO Push
							  (Logid, userid)
		VALUES      (@Logid, @viewerid)
		UPDATE    [Log]
		SET              PushCount = PushCount + 1
		WHERE     (id = @Logid)
		return 1--成功
	END
	else return 3--您已经推荐过了
else
	return 2--非发布日志不能推荐
End
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogSelectPush5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LogSelectPush5]
AS
BEGIN
	SET NOCOUNT ON;

SELECT   top 5  [Log].id AS Logid, dbo.HTMLEncode([Log].title) as title, Account.UserId, Account.Name, [Log].AddTime
FROM         Push INNER JOIN
                      [Log] ON Push.Logid = [Log].id INNER JOIN
                      Account ON [Log].userid = Account.UserId where Groupid=0
ORDER BY Push.PushTime DESC, Push.id DESC

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyApplicationlist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		zoujian
-- Create date: 2007 10 10
-- Description:	my Application list
-- =============================================
CREATE PROCEDURE [dbo].[MyApplicationlist]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
declare @apps varchar(4000)
select @apps=isnull(Applicationlist,''App_myfriend,App_mynote,App_mygroup,App_myuniversityclass,App_photos,App_supernote,App_train'') from [profile] where userid=@userid


select [Application].id,fullname,shortname,Folder,icon,issystem from dbo.Split (@apps,'',''  )a
INNER JOIN
	[Application] ON a.col = [Application].id
 order by a.id



END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyPersonalSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 LE:2007 10 20 
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MyPersonalSelect]
@userid bigint
AS
BEGIN
SET NOCOUNT ON;
if exists(select 1 from PersonalInformation where UserId = @userid)
	SELECT     LoveLike, LoveBook, LoveMusic, LoveMovie, LoveSports, LoveGame, LoveComic, JoinSociety
,PersonalInfoShowLevel
	FROM       PersonalInformation inner join [profile] on
PersonalInformation.userid=[profile].userid
	WHERE     (PersonalInformation.USERID = @userid)
ELSE
	SELECT     '''' as  LoveLike,  '''' as LoveBook, '''' as  LoveMusic,  '''' as LoveMovie, 
	 '''' as LoveSports, '''' as  LoveGame, '''' as  LoveComic,  '''' as JoinSociety,200 as PersonalInfoShowLevel
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyPersonalUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- -----------------------------------------------
-- Author:		邹健
-- Create date: 200702 le:2007 10 20 
-- Description:	更改用户
-- -----------------------------------------------
CREATE PROCEDURE [dbo].[MyPersonalUpdate]
@LoveLike	nvarchar(250),
@LoveBook	nvarchar(250),
@LoveMusic	nvarchar(250),
@LoveMovie	nvarchar(250),
@LoveSports	nvarchar(250),
@LoveGame	nvarchar(250),
@LoveComic	nvarchar(250),
@JoinSociety	nvarchar(250),
@userid bigint,
@showlevel tinyint=null
AS
BEGIN
SET NOCOUNT ON;

if( not @showlevel is null )
update [profile] set PersonalInfoShowLevel=@showlevel where userid=@userid and not PersonalInfoShowLevel=@showlevel
	if (@LoveLike is null and @LoveBook is null and @LoveMusic is null and @LoveMovie is null and 
@LoveSports is null and @LoveGame is null and @LoveComic is null and @JoinSociety is null)
	begin
	delete [PersonalInformation] where userid=@userid
	return 1;
	end
if exists(select 1 from PersonalInformation where userid=@userid)
				UPDATE PersonalInformation
				SET LoveLike = isnull(@LoveLike,'',''), LoveBook = isnull(@LoveBook,'',''),
					LoveMusic = isnull(@LoveMusic,'',''), LoveMovie = isnull(@LoveMovie,'',''),
			LoveSports = isnull(@LoveSports,'',''), 
			LoveGame = isnull(@LoveGame,'',''), 
			LoveComic = isnull(@LoveComic,'',''),
			JoinSociety = isnull(@JoinSociety,'','')
				WHERE     (UserId = @userid)
else
			INSERT INTO PersonalInformation
				   ([LoveLike]
				   ,[LoveBook]
				   ,[LoveMusic]
				   ,[LoveMovie]
				   ,[LoveSports]
				   ,[LoveGame]
				   ,[LoveComic]
				   ,[JoinSociety],userid)
			 VALUES
				   (isnull(@LoveLike,'',''),isnull(@LoveBook,'',''),isnull(@LoveMusic,'',''),isnull(@LoveMovie,'',''),isnull(@LoveSports,'',''),isnull(@LoveGame,'',''),isnull(@LoveComic,'',''),isnull(@JoinSociety,'',''),@userid)

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogBookRelation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 2007 08 19
-- Description:	得到日志的相关权限（Relation）及基本信息
-- =============================================
CREATE PROCEDURE [dbo].[LogBookRelation]
@Logid bigint,
@Viewerid bigint,
@Groupid bigint--所在群的ID，如果为个人日志，则为0
AS
BEGIN
	SET NOCOUNT ON;
declare @ownerid bigint,@title nvarchar(255),@rl tinyint
if(@Groupid=0)--为个人日志 ，则与个人的设置有关
begin 
	select @ownerid=userid,@title=title from [log] where id=@logid
	EXECUTE @Rl = [Relation] 
	   @ownerid
	  ,@viewerid
	select @ownerid,@title,@rl 
	return
end


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Albums_Info]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Albums_Info]
@ownerid bigint,
@viewerid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
Declare @rc tinyint
EXECUTE @RC = [Relation] 
   @ownerid
  ,@viewerid
select [name] ,@rc as Relation,AlbumCount from [Profile]
inner join Account on Account.userid=[Profile].userid
where Account.userid=@ownerid

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Info]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_Info]
@albumid bigint,
@ownerid bigint,
@viewerid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
Declare @rc tinyint
EXECUTE @RC = [Relation] 
   @ownerid
  ,@viewerid
select [album].id,[album].[name] as Albumname ,Account.name as Username,@rc as Relation,[Count] as PhotoCount from[album]
inner join Account on  [album].userid=Account.userid
where [album].userid=@ownerid and [album].id=@albumid

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Albums_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 10 14
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Albums_List]
@ownerid bigint,
@viewerid bigint,
@PAGE INT=1,
@EVERYPAGE INT=6
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
DECLARE @RC int
EXECUTE @RC = [dbo].[Relation] 
   @ownerid
  ,@viewerid
--if exists(select id from dbo.Album where userid=@ownerid and Showlevel<=@RC)--有权限看
--	begin
		SELECT TOP (@everyPage) *
		  FROM      (
		SELECT  top (@page*@everyPage)  ALBUM.id,Account.name as Username,ALBUM.[name] as Albumname,
	[Description],ALBUM.Addtime,Location,faceurl,[Count],Showlevel,album.userid as ownerid,
		ROW_NUMBER() OVER (ORDER BY ALBUM.id desc) AS RowNo 
		FROM         ALBUM INNER JOIN
							  Account ON ALBUM.USERID = Account.UserId
		WHERE   ALBUM.USERID = @ownerid )AS A-- 
		WHERE RowNo > (@page-1)*@everyPage
--	end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRelation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserRelation]
@ownerid bigint,
@viewerid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Declare @rc tinyint
EXECUTE @RC = [Relation] 
   @ownerid
  ,@viewerid

select [name] ,@rc as Relation,AllShowLevel from Account
inner join [profile] on [profile].userid=Account.userid
 where Account.userid=@ownerid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuperNote_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_List]
@page bigint=1,
@everyPage bigint=10,
@ownerid bigint,
@viewerid bigint,
@type tinyint=0,
@viewerStatus tinyint=0,
@systemcategory bigint=null
AS
BEGIN
	SET NOCOUNT ON;
if @type=1
begin
		if(@systemcategory is null)
			SELECT TOP 10  supernote.id,supernote.title,supernote.faceurl,
				url,[description],viewcount,addtime,account.name,account.userid,systemcategory
			FROM account
			INNER JOIN  supernote ON supernote.userid = account.userid
			WHERE 	Showlevel=0
			ORDER BY addtime desc
		else
			SELECT TOP 10  supernote.id,supernote.title,supernote.faceurl,
				url,[description],viewcount,addtime,account.name,account.userid,systemcategory
			FROM account
			INNER JOIN  supernote ON supernote.userid = account.userid
			WHERE 	Showlevel=0 and systemcategory=@systemcategory
			ORDER BY addtime desc
		return;
end
if @type=2
begin
			SELECT TOP 10 supernote.id,supernote.title,supernote.faceurl,
				url,[description],viewcount,addtime,account.name,account.userid,systemcategory
			FROM account INNER JOIN
								  supernote ON supernote.userid = account.userid
			WHERE 	Showlevel=0 and datediff(M,addtime,getdate())<1 and title is not null
			ORDER BY id desc
			return;
end
if @type=0
begin
	DECLARE @RC int
	EXECUTE @RC =[dbo].[Relation] 
	   @ownerid
	  ,@viewerid

	SELECT TOP (@everyPage) *
		  FROM      (
				SELECT  top (@page*@everyPage) supernote.id,supernote.title,supernote.faceurl,
				url,[description],viewcount,addtime,account.name,account.userid,systemcategory
			,ROW_NUMBER() OVER (ORDER BY [supernote].id desc) AS RowNo
			FROM account INNER JOIN
								  supernote ON supernote.userid = account.userid
			WHERE account.userid=@ownerid and (Showlevel<=@RC or @viewerStatus>199))AS T-- 
		WHERE RowNo > (@page-1)*@everyPage
end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_List]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_List]
@albumid bigint,
@ownerid bigint,
@viewerid bigint,
@PAGE INT=1,
@EVERYPAGE INT=16
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
DECLARE @RC int,@viewerStatus int
EXECUTE @RC =[dbo].[Relation] 
   @ownerid
  ,@viewerid
select @viewerStatus=dbo.UserStatus(@viewerid,null);
--if exists(select id from dbo.Album where userid=@ownerid and Showlevel<=@RC)--有权限看
--	begin
		SELECT TOP (@everyPage) *
		  FROM      (
		SELECT  top (@page*@everyPage)  photos.id,Account.name as Username,photos.[name] as Photoname,
Photos.Addtime,[Path],
		ROW_NUMBER() OVER (ORDER BY photos.id desc) AS RowNo 
		FROM         photos INNER JOIN
							  Account ON photos.USERID = Account.UserId
inner join [album] on photos.albumid=album.id
		WHERE albumid=@albumid and  photos.USERID = @ownerid and 
				(Showlevel<=@RC or @viewerStatus>199))AS A-- 
		WHERE RowNo > (@page-1)*@everyPage
--	end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyContactSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MyContactSelect]
@UserId bigint
AS
if exists(select 1 from ContactInformation where UserId = @userid)
SELECT isnull(Telphone,'''') as Telphone,
 isnull(QQ,'''') as QQ, isnull(Msn,'''') as Msn,isnull( WangWang,'''') as Wangwang, 
isnull(NeteasePop,'''') as NeteasePop, isnull(UC,'''') as UC
, isnull(Mobiephone,'''') as Mobiephone,isnull( WebSite,'''') as WebSite
,ContactInfoShowLevel
FROM         [ContactInformation] inner join [profile] on
[ContactInformation].userid=[profile].userid
WHERE     ([ContactInformation].UserId = @userid)
else
SELECT '''' as Telphone,
 '''' as QQ, '''' as Msn,'''' as Wangwang, 
'''' as NeteasePop,'''' as UC
, '''' as Mobiephone,'''' as WebSite,200 as ContactInfoShowLevel
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyContactUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MyContactUpdate]
@Telphone nvarchar(15), @QQ nvarchar(11), 
   @Msn nvarchar(50),@WangWang nvarchar(50), @NeteasePop nvarchar(50),@UC nvarchar(11), 
      @Mobiephone nvarchar(14)
,@userid bigint,@WebSite	nvarchar(100),
@showlevel tinyint=null
AS
if( not @showlevel is null )
update [profile] set contactInfoShowLevel=@showlevel where userid=@userid and not contactInfoShowLevel=@showlevel
if exists(select 1 from ContactInformation where UserId = @userid)
UPDATE [ContactInformation]
SET  Telphone = @Telphone, QQ = @QQ,
      Msn = @Msn, WangWang = @WangWang, NeteasePop = @NeteasePop, UC = @UC, 
      Mobiephone = @Mobiephone,WebSite=@WebSite
WHERE (UserId = @userid)
else
begin
	if(@Telphone ='''' and @QQ='''' and @Msn='''' and @WangWang='''' and @NeteasePop='''' and @UC=''''
and @Mobiephone='''' AND @WebSite='''')
	return ;
	else
		INSERT INTO [ContactInformation]
           ([userid]        ,[QQ]           ,[Msn]           ,[WangWang]           ,[NeteasePop]          ,[UC]           ,[Telphone]           ,[Mobiephone]           ,[WebSite])
     VALUES
           (@userid
           ,@QQ
           ,@Msn
           ,@WangWang
           ,@NeteasePop
           ,@UC
           ,@Telphone
           ,@Mobiephone
           ,@WebSite)
end

RETURN
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Services_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 e:2007 10 3
-- Description:	创建客服消息
-- =============================================
CREATE PROCEDURE [dbo].[Services_Add]
@userid bigint,
@body nvarchar(4000),
@Email nvarchar(50)
AS
BEGIN
SET NOCOUNT ON;
IF @EMAIL	=''''
select @email=null;

INSERT INTO Services
			(body,userid,Email)
VALUES     (@body,@userid,@Email)
--else
--INSERT INTO Services
--                      (body,userid)
--VALUES     (@body,@userid)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServicesSelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	管理员查看services
-- =============================================
CREATE PROCEDURE [dbo].[ServicesSelectById]
@id bigint
AS
BEGIN
	SET NOCOUNT ON;
if exists(select id from Services where (id = @id) and  status <1)
UPDATE    Services
SET        status = 1
WHERE     (id = @id)

SELECT     userid, sendtime, body, Email
FROM         Services
WHERE     (id = @id)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Services_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 E:2007 10 1
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Services_Select]
@page bigint=1,--当前页码
--@Count bigint,--总记录数默认每页为10只
@everyPage bigint=10,
@userid bigint=null,
@Email nvarchar(50)=null
AS
BEGIN

	SET NOCOUNT ON;
	if @email=''''
		select @email=null;
	if @userid=0
		select @userid=null;
	SELECT TOP (@everyPage) *
      FROM      (
	SELECT  top (@page*@everyPage)  Services.id, body, Services.answer, Services.[status],
	sendtime,Services.userid,Services.email,[name],answertime,
	ROW_NUMBER() OVER (ORDER BY Services.id desc) AS RowNo 
	FROM Services left JOIN
	Account ON Services.userid = Account.UserId
	WHERE  Services.userid=isnull(@userid,Services.userid) or Services.Email=isnull(@Email,Services.Email)
)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage;

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServicesReply]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ServicesReply]
@id bigint,
@Answer nvarchar(4000)
AS
BEGIN
	SET NOCOUNT ON;
UPDATE    Services
SET              Answer =@Answer, status =2 where id=@id
--登录用户则发一则Message
--非登录用户则发一则email
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Services_Count]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 EDIT 2007 10 1
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Services_Count]
@page bigint=1,--当前页码
--@Count bigint,--总记录数默认每页为10只
@everyPage bigint=10,
@userid bigint=null,
@Email nvarchar(50)=null
AS
BEGIN
	SET NOCOUNT ON;

declare @ret bigint
	SELECT   @ret=count(Services.id)
	FROM Services
	WHERE  Services.userid=isnull(@userid,Services.userid) and Services.Email=isnull(@Email,Services.Email)
return @ret


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Group_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070327, 8 29
-- Description:	创建一个新群
-- =============================================
CREATE PROCEDURE [dbo].[Group_Add]
@GroupName nvarchar(50),		--群名
@CreateUserid bigint,			--创建用户
@GroupClass tinyint=0,			--groupClass=0 is normal ,1 is class
@Score bigint=50,				--创建群用的积分
@Num0 bigint=null,				--字段扩展1
@Other0 bigint=null,			--字段扩展2
@Other1 bigint=null,			--字段扩展3
@Other2 bigint=null,			--字段扩展4
@userstatus bigint=null,
@categroy bigint=null
AS
BEGIN
SET NOCOUNT ON;
--已存在返回0
if @groupclass=1--大学班级
begin
	if exists(select 1 from [group] inner join [groupuser] 
				on [group].id=groupuser.groupid
				where groupclass=1 and groupuser.userid=@CreateUserid)
	return -9----大学班级只能加入一个
	select @Num0=grade ,@Other0=university,@Other1=xueyuan from SchoolInformation where userid=@CreateUserid;
end
if exists(SELECT id FROM[Group] WHERE(GroupName = @groupname) and Num0=@Num0 and Other0=@Other0 and Other1=@Other1 and Other2=@Other2 and istrue=1)
	return 0;---已经存在
else
begin
--如果用户分数不够返回-1
-- 
if @userstatus<200 and exists(SELECT 1 FROM [profile] WHERE Score < @Score AND userid =@CreateUserid)
	return -1;
	
declare @joinlevel int,@istrue bit;
if @groupclass=1
	select @joinlevel=8,@istrue=0;
else
	select @joinlevel=4,@istrue=1;

		if(@categroy=0) select @categroy=null

--添加一个群
		INSERT INTO [Group]
							  (id,GroupName, CreateUserid,GroupClass, Num0, Other0, Other1, Other2,joinlevel,istrue,categoryid)
		VALUES     (0,@GroupName,@CreateUserid,@GroupClass,@Num0,@Other0, @Other1, @Other2,@joinlevel,@istrue,@categroy);
--添加管理员
		DECLARE @id bigint;
		select @id=@@IDENTITY+dbo.GetRandom();

		update [Group] set id=@id where trueid=@@IDENTITY;

		INSERT INTO GroupUser
							  (userid, Groupid, [Level], AddTime,IsTrue)
		VALUES     (@CreateUserid, @id, 255, getdate(),@istrue);
--校友录状态下,进行升级 并进行创建群的减分
	if  @GroupClass=1
	begin
			update Account set [status]=6 where userid =@CreateUserid AND ([Status] < 8) AND ([Status] > 0);
	end
	else
	begin
			EXECUTE [dbo].[Event_Add] 
			   @CreateUserid
			  ,@CreateUserid
			  ,4
			  ,@GroupName
			  ,@id
	end
	if @userstatus<200
		UPDATE [profile] SET Score = Score - @Score WHERE     userid =@CreateUserid;
		
return @id

end

END


--成功1
--已存在0
--分数不够2
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SchoolInformation]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[SchoolInformation]
AS
SELECT     userid, Field AS University, Year AS Grade, MiniField AS Xueyuan, QinShi, Field1 AS HighSchool, Field2 AS JuniorSchool
FROM         dbo.FieldInformation
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'SchoolInformation', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "FieldInformation"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 216
               Right = 397
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SchoolInformation'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'SchoolInformation', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SchoolInformation'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogSelectByMonth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LogSelectByMonth]
@userid bigint,
@year int=0,
@month tinyint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if @year=0 and @month=0
SELECT top 1  @year= year(AddTime)  ,@month=month(AddTime)
  FROM [Log]
 where userid =@userid and Groupid=0
Group by year(AddTime) ,month(AddTime)
order by  year(AddTime) desc ,month(AddTime)  desc

SELECT     [id],dbo.HTMLEncode([title]) as title, [AddTime]
FROM         [Log] 
where year(addtime)=@year and (month(addtime)=@month) and (userid=@userid) and Groupid=0
order by AddTime desc

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Group_NoteList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702 El:10 11将群的帖子阅读权限更改为<10
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Group_NoteList]
@Groupid bigint,
@page bigint=1,--当前页码
@everyPage bigint=10
AS
BEGIN
	SET NOCOUNT ON;


	SELECT TOP (@everyPage) *
	FROM      (
		SELECT  top (@page*@everyPage) [Log].[id],dbo.HTMLEncode(Substring([Log].[title],0,40)) as title, 
		[Log].ViewCount,[Log].CommentCount,LastCommentTime as Addtime,ispost,
		Account.[Name] as sendername, Account.UserId as senderid,--最后回复
		 Account_1.Userid, Account_1.Name AS [Name],--发帖人
		ROW_NUMBER() OVER (ORDER BY ispost desc, LastCommentTime desc,[log].id desc) AS RowNo 
		FROM         [Log] INNER JOIN
		Account ON [Log].LastCommentUserid = Account.UserId INNER JOIN
		Account AS Account_1 ON [Log].userid = Account_1.UserId
		WHERE    ispost<10 and  ( [Log].GroupId = @groupid) 
	)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NoteSummary_Month]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	获取GETLOG页面的LOG信息
--即LOG可show的所有字段
-- =============================================
CREATE PROCEDURE [dbo].[NoteSummary_Month]
@userid bigint,
@year int=0,
@month tinyint=0
AS
BEGIN
SET NOCOUNT ON;
if @year=0 and @month=0
SELECT top 1  @year= year(AddTime)  ,@month=month(AddTime)
  FROM [Log]
 where userid =@userid and Groupid=0
Group by year(AddTime) ,month(AddTime)
order by  year(AddTime) desc ,month(AddTime)  desc

SELECT     id, dbo.HTMLEncode(title) as title, AddTime, Substring([Log].body,0,250) as body, PushCount, ViewCount, CommentCount, isPost
FROM         [Log]
WHERE     (YEAR(AddTime) = @year) AND (MONTH(AddTime) = @month) AND (userid = @userid)and Groupid=0
ORDER BY AddTime DESC

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[School]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[School]
AS
SELECT     trueid, id, name AS school, pid AS province, istrue AS ispudate, class AS schoolclass
FROM         dbo.Field
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'School', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Field"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 198
               Right = 310
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'School'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'School', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'School'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInformation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UserInformation]
@ownerid bigint
,@viewerid bigint
AS
Declare @rc tinyint,@class_id bigint,@class nvarchar(50)
EXECUTE @RC = [Relation] 
   @ownerid
  ,@viewerid
--页面最终显示结果
--if exists(select 1 from [account] where userid=@userid and [status]<8
--	select @rc as [Relation] 

select @class_id=[group].id,@class =GroupName from groupuser inner join [group] on groupuser.groupid=[group].id
where [group].istrue=1 and groupuser.istrue=1 and groupuser.userid=@ownerid and 
GroupClass=1

SELECT  @rc as [Relation] ,
Account.Userid,Account.[Name],
[Profile].ShowText,[Profile].ShowTextTime,
MagicBox, 

PersonalInfoShowLevel, FaceShowLevel,SchoolInfoShowLevel,
BasicInfoShowLevel,ContactInfoShowLevel,

Account.Status as Userstatus, RegTime,LoginTime, WebSite, 
isstar,

school.id as University_id,
school.school as University,'''' as  HighSchool,'''' as JuniorSchool,Xueyuan as Xueyuan_id,
@class as UniClass,@class_id as UniClass_id,
Mobiephone, UC, 
NeteasePop, Msn, WangWang, QQ, Telphone, 
[Address], 
City.name AS cityname, Telphone,
Province.name AS Provincename, 
BirthDay, Sex, 
Score,ShowScore,
ViewCount,AllShowLevel,grade,IsMagicBox

,LoveLike, LoveBook, LoveMusic,
LoveMovie, LoveSports, LoveGame, LoveComic,
PersonalInformation.JoinSociety
FROM         Account 
inner JOIN [Profile] ON   Account.userid = [Profile].userid
inner join BasicInformation on BasicInformation.userid=  Account.userid
left join SchoolInformation on SchoolInformation.userid=Account.Userid
left join ContactInformation on ContactInformation.userid=Account.Userid
left join PersonalInformation on PersonalInformation.userid=Account.Userid
inner JOIN Province ON BasicInformation.Provinceid = Province.id 
inner JOIN City ON BasicInformation.Cityid = City.id
left JOIN school on SchoolInformation.University=school.id
WHERE     (Account.UserId = @ownerid)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MySchoolUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 07904 le:1020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MySchoolUpdate]
@userid bigint,
@Xueyuan nvarchar(50),
@Grade smallint,
@Qinshi bigint,
@Highschool nvarchar(50)=null,
@Juniorschool nvarchar(50)=null,
@showlevel tinyint=null
AS
BEGIN
SET NOCOUNT ON;
declare @Xueyuan_id bigint,@Qinshi_id bigint,@Highschool_id bigint,@Juniorschool_id bigint,@Uni_id bigint
select @Xueyuan_id=null,@Qinshi_id=null,@Highschool_id=null,@Juniorschool_id=null

if (@Qinshi<1)
 select @Qinshi=null
--select @Uni_id=University from [SchoolInformation] where userid=@userid
--
--select @Xueyuan_id=id from XueYuan where XueYuan=@Xueyuan and school=@Uni_id
--if(@Xueyuan_id is null and not @Xueyuan is null)
--begin
--	INSERT INTO XueYuan
--                      (XueYuan, School, SchoolClass)
--	VALUES     (@Xueyuan,@Uni_id,0)
--	select @Xueyuan_id=@@IDENTITY
--end

--select @Qinshi_id=id from Qinshi where Qinshi=@Qinshi
--if(@Qinshi_id is null and not @Qinshi is null)
--begin
--	INSERT INTO Qinshi
--                      (Qinshi, School, SchoolClass)
--	VALUES     (@Qinshi,@Uni_id,0)
--	select @Qinshi_id=@@IDENTITY
--end
if not @showlevel is null
update [profile] set SchoolInfoShowLevel=@showlevel where userid=@userid and not SchoolInfoShowLevel=@showlevel
UPDATE   SchoolInformation
SET Grade = @Grade, QinShi = @QinShi--XueYuan = @XueYuan_id, ,JuniorSchool = @JuniorSchool_id, HighSchool = @HighSchool_id, 
WHERE     (UserId = @userid)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Field_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Field_Add]
@University nvarchar(50),
@Xueyuan nvarchar(50),
@userid bigint,
@field tinyint
AS
BEGIN
	SET NOCOUNT ON;
if exists(select 1 from [profile] where userid=@userid)
return 0;
	insert [profile] (userid,field) values(@userid,@field)
	insert BasicInformation (userid) values(@userid)
	if(@field=1)
	begin
			declare @Xueyuan_id bigint,@Uni_id bigint
			select @Uni_id=id from School where SchoolClass=0 and School=@University
			select @Xueyuan_id=id from XueYuan where XueYuan=@Xueyuan and school=@Uni_id
			if(@Xueyuan_id is null and not @Xueyuan is null)
			begin
				INSERT INTO XueYuan
								  (XueYuan, School, SchoolClass)
				VALUES     (@Xueyuan,@Uni_id,0)
				select @Xueyuan_id=@@IDENTITY
			end
			
			insert SchoolInformation (userid,University,XUEYUAN) 
			values (@userid,@Uni_id,@Xueyuan_id)
			update [account] set [status]=2 where userid=@userid
	end
return 1;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registrator]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Registrator]
@Email nvarchar(50),
@Password char(32),
@name nvarchar(12),
@University nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @RC int
EXECUTE @rc=[Account_Add] 
@Email,@name,@Password,null,null
if @rc=-2 or @rc=-1
return @rc
insert [profile] (userid) values(@rc)
insert BasicInformation (userid) values(@rc)
insert SchoolInformation (userid,University) select @rc,id from school where school=@University
RETURN @rc
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRelationClass]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		邹健
-- Create date: 20070726
-- Description:	获得相关班级
-- =============================================
CREATE PROCEDURE [dbo].[GetRelationClass]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @GRADE INT , @UNIVERSITY NVARCHAR(50),@XUEYUAN NVARCHAR(50)
SELECT @GRADE=GRADE,@UNIVERSITY =UNIVERSITY ,@XUEYUAN=XUEYUAN from SchoolInformation
where userid=@userid


SELECT     GroupName, summmary, [group].id,@GRADE as grade ,xueyuan.xueyuan as xueyuan,[group].istrue,[groupuser].[level]
FROM         [Group]
left JOIN groupuser ON  GroupUser.Groupid=[Group].id and groupuser.userid=@userid
inner join xueyuan on xueyuan.id=@XueYuan

WHERE     (Other0 = @University) AND (Num0 = @Grade) AND (Other1 = @XueYuan) 


END
' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Friend]') AND parent_object_id = OBJECT_ID(N'[dbo].[Friend]'))
ALTER TABLE [dbo].[Friend]  WITH NOCHECK ADD  CONSTRAINT [CK_Friend] CHECK  (([fromid]<>[toid]))
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [CK_Friend]
