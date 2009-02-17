USE [CHSNS.Database_DB_0d1a7df4-999c-4ef4-8074-83a3fe2a0ffd]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Count] [bigint] NOT NULL,
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
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 is group ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Count'
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ShowerID] [bigint] NULL,
	[OwnerID] [bigint] NOT NULL,
	[SenderID] [bigint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[Body] [ntext] NOT NULL,
	[IsReply] [bit] NOT NULL,
	[IsSee] [bit] NOT NULL,
	[IsDel] [bit] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[IsTellMe] [tinyint] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Comment] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactInformation]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	[WebSite] [nvarchar](100) NULL,
	[TellMethod] [tinyint] NOT NULL,
	[ShowLevel] [tinyint] NOT NULL,
 CONSTRAINT [PK_ContactInformation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry](
	[ID] [bigint] IDENTITY(10000,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[CreaterID] [bigint] NOT NULL,
	[UpdateTime] [smalldatetime] NOT NULL,
	[CurrentID] [bigint] NULL,
	[EditCount] [int] NOT NULL,
	[ViewCount] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
	[Ext] [ntext] NULL,
 CONSTRAINT [PK_Entry] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntryVersion]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntryVersion](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Reason] [ntext] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[Description] [ntext] NOT NULL,
	[Reference] [ntext] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
	[EntryID] [bigint] NULL,
	[ParentText] [nvarchar](50) NULL,
	[Ext] [ntext] NULL,
 CONSTRAINT [PK_EntryVersion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](250) NOT NULL,
	[OwnerID] [bigint] NOT NULL,
	[ViewerID] [bigint] NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[ShowLevel] [int] NOT NULL,
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
GO
/****** Object:  Table [dbo].[FieldInformation]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldInformation](
	[UserID] [bigint] NOT NULL,
	[Field] [bigint] NOT NULL,
	[Year] [smallint] NULL,
	[MiniField] [bigint] NULL,
	[QinShi] [bigint] NULL,
	[Field1] [bigint] NULL,
	[Field2] [bigint] NULL,
 CONSTRAINT [PK_SchoolInformation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friend]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FromID] [bigint] NOT NULL,
	[ToID] [bigint] NOT NULL,
	[IsTrue] [bit] NOT NULL,
	[IsCommon] [bit] NOT NULL,
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
GO
/****** Object:  Table [dbo].[Group]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[ID] [bigint] IDENTITY(1000,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LogoUrl] [nvarchar](250) NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[Summary] [nvarchar](50) NOT NULL,
	[CreaterID] [bigint] NOT NULL,
	[UserCount] [bigint] NOT NULL,
	[AdminCount] [tinyint] NOT NULL,
	[PostCount] [bigint] NOT NULL,
	[ViewCount] [bigint] NOT NULL,
	[JoinLevel] [tinyint] NOT NULL,
	[ShowLevel] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Ext] [ntext] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Group] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupUser]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupUser](
	[UserID] [bigint] NOT NULL,
	[GroupID] [bigint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[PostCount] [bigint] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_GroupUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTag]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTag](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TagID] [bigint] NOT NULL,
	[LogID] [bigint] NOT NULL,
 CONSTRAINT [PK_LogTag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FromID] [bigint] NOT NULL,
	[ToID] [bigint] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[SendTime] [smalldatetime] NOT NULL,
	[IsSee] [bit] NOT NULL,
	[IsFromDel] [bit] NOT NULL,
	[IsToDel] [bit] NOT NULL,
	[IsHtml] [bit] NOT NULL,
 CONSTRAINT [PK_Message_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Message] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[ID] [bigint] IDENTITY(1000,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Summary] [nvarchar](4000) NULL,
	[Body] [ntext] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[EditTime] [smalldatetime] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[PID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[IsTellMe] [tinyint] NOT NULL,
	[IsAnonymous] [bit] NULL,
	[ShowLevel] [tinyint] NOT NULL,
	[ViewCount] [bigint] NOT NULL,
	[PushCount] [bigint] NOT NULL,
	[TrackBackCount] [bigint] NOT NULL,
	[CommentCount] [bigint] NOT NULL,
	[LastCommentUserID] [bigint] NOT NULL,
	[LastCommentTime] [smalldatetime] NOT NULL,
	[Ext] [ntext] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Log_id] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalInformation]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[Photo]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AlbumID] [bigint] NULL,
	[UserID] [bigint] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[Order] [bigint] NOT NULL,
	[Ext] [ntext] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Photo] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Score] [bigint] NOT NULL,
	[ShowScore] [bigint] NOT NULL,
	[DelScore] [bigint] NOT NULL,
	[ShowLevel] [tinyint] NOT NULL,
	[MagicBox] [ntext] NOT NULL,
	[IsMagicBox] [bit] NOT NULL,
	[RegTime] [smalldatetime] NOT NULL,
	[LoginTime] [smalldatetime] NOT NULL,
	[ViewCount] [bigint] NOT NULL,
	[FileSizeAll] [bigint] NOT NULL,
	[FileSizeCount] [bigint] NOT NULL,
	[Applications] [ntext] NULL,
	[Applicationlist] [ntext] NULL,
	[Ext] [ntext] NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户唯一标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Profile', @level2type=N'COLUMN',@level2name=N'UserID'
GO
/****** Object:  Table [dbo].[Push]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Push](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LogID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
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
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[SenderID] [bigint] NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[IsSee] [bit] NOT NULL,
	[IsDel] [bit] NOT NULL,
	[IsTellMe] [tinyint] NOT NULL,
 CONSTRAINT [PK_Reply_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[Answer] [nvarchar](4000) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[SendTime] [smalldatetime] NOT NULL,
	[AnswerTime] [smalldatetime] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuperNote]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperNote](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Faceurl] [nvarchar](500) NULL,
	[Url] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[UserID] [bigint] NOT NULL,
	[ViewCount] [bigint] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[ShowLevel] [tinyint] NOT NULL,
	[SystemCategory] [bigint] NULL,
	[Category] [bigint] NULL,
	[Type] [tinyint] NOT NULL,
 CONSTRAINT [PK_SuperNote] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_SuperNote] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Count] [bigint] NOT NULL,
	[Type] [tinyint] NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViewData]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViewData](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OwnerID] [bigint] NOT NULL,
	[ViewerID] [bigint] NOT NULL,
	[IpandComputer] [nvarchar](50) NULL,
	[ViewPageUrl] [nvarchar](255) NULL,
	[LastUrl] [nvarchar](255) NULL,
	[ViewTime] [datetime] NOT NULL,
	[ViewClass] [tinyint] NOT NULL,
 CONSTRAINT [PK_ViewData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Album]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NULL,
	[Description] [nvarchar](150) NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[FaceUrl] [nvarchar](250) NULL,
	[Count] [int] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Order] [int] NOT NULL,
	[ShowLevel] [tinyint] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Album] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Application](
	[ID] [bigint] IDENTITY(1000,1) NOT NULL,
	[Controller] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[ParamStr] [nvarchar](250) NOT NULL,
	[ClassName] [varchar](50) NOT NULL,
	[FullName] [nvarchar](60) NOT NULL,
	[ShortName] [nvarchar](20) NOT NULL,
	[Vision] [nvarchar](20) NOT NULL,
	[Icon] [nvarchar](250) NULL,
	[Authorid] [bigint] NULL,
	[Addtime] [smalldatetime] NOT NULL,
	[Edittime] [smalldatetime] NOT NULL,
	[Description] [ntext] NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[IsTrue] [bit] NOT NULL,
	[DescriptionUrl] [nvarchar](250) NULL,
	[UserCount] [bigint] NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Table_shortname] UNIQUE NONCLUSTERED 
(
	[ShortName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[BasicInformation]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicInformation](
	[UserID] [bigint] NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Email] [nvarchar](500) NULL,
	[IsEmailTrue] [bit] NOT NULL,
	[Sex] [bit] NULL,
	[Birthday] [smalldatetime] NULL,
	[ProvinceID] [int] NOT NULL,
	[CityID] [bigint] NOT NULL,
	[ShowLevel] [tinyint] NOT NULL,
 CONSTRAINT [PK_BasicInformation] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 02/18/2009 05:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[UserID] [bigint] NOT NULL,
	[CreateTime] [smalldatetime] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[SubTitle] [nvarchar](500) NULL,
	[Publish] [nvarchar](max) NULL,
	[WriteName] [nvarchar](50) NOT NULL,
	[CommentEmail] [nvarchar](50) NULL,
	[Skin] [nvarchar](50) NULL,
	[Css] [ntext] NULL,
	[MetaKey] [nvarchar](400) NULL,
	[IsWebServices] [bit] NOT NULL,
	[PostCount] [bigint] NOT NULL,
	[CommentCount] [bigint] NOT NULL,
	[TrackBackCount] [bigint] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_Album_Addtime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Album] ADD  CONSTRAINT [DF_Album_Addtime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_Album_Count]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Album] ADD  CONSTRAINT [DF_Album_Count]  DEFAULT ((0)) FOR [Count]
GO
/****** Object:  Default [DF_Album_Order]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Album] ADD  CONSTRAINT [DF_Album_Order]  DEFAULT ((0)) FOR [Order]
GO
/****** Object:  Default [DF_Album_Showlevel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Album] ADD  CONSTRAINT [DF_Album_Showlevel]  DEFAULT ((0)) FOR [ShowLevel]
GO
/****** Object:  Default [DF_Application_Controller]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_Controller]  DEFAULT ('') FOR [Controller]
GO
/****** Object:  Default [DF_Application_Action]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_Action]  DEFAULT ('') FOR [Action]
GO
/****** Object:  Default [DF_Application_ParamStr]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_ParamStr]  DEFAULT ('') FOR [ParamStr]
GO
/****** Object:  Default [DF_Application_fullname]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_fullname]  DEFAULT ('') FOR [FullName]
GO
/****** Object:  Default [DF_Application_Addtime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_Addtime]  DEFAULT (getdate()) FOR [Addtime]
GO
/****** Object:  Default [DF_Application_Edittime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_Edittime]  DEFAULT (getdate()) FOR [Edittime]
GO
/****** Object:  Default [DF_Application_Description]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_Description]  DEFAULT ('') FOR [Description]
GO
/****** Object:  Default [DF_Application_isTrue]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_isTrue]  DEFAULT ((0)) FOR [IsTrue]
GO
/****** Object:  Default [DF_Application_UserCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_UserCount]  DEFAULT ((0)) FOR [UserCount]
GO
/****** Object:  Default [DF_BasicInformation_IsEmailTrue]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[BasicInformation] ADD  CONSTRAINT [DF_BasicInformation_IsEmailTrue]  DEFAULT ((0)) FOR [IsEmailTrue]
GO
/****** Object:  Default [DF_BasicInformation_BirthDay]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[BasicInformation] ADD  CONSTRAINT [DF_BasicInformation_BirthDay]  DEFAULT ('19850101') FOR [Birthday]
GO
/****** Object:  Default [DF_BasicInformation_Province]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[BasicInformation] ADD  CONSTRAINT [DF_BasicInformation_Province]  DEFAULT ((0)) FOR [ProvinceID]
GO
/****** Object:  Default [DF_BasicInformation_City]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[BasicInformation] ADD  CONSTRAINT [DF_BasicInformation_City]  DEFAULT ((0)) FOR [CityID]
GO
/****** Object:  Default [DF_BasicInformation_ShowLevel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[BasicInformation] ADD  CONSTRAINT [DF_BasicInformation_ShowLevel]  DEFAULT ((0)) FOR [ShowLevel]
GO
/****** Object:  Default [DF_Blog_CreateTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blog_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_Blog_IsWebServices]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blog_IsWebServices]  DEFAULT ((0)) FOR [IsWebServices]
GO
/****** Object:  Default [DF_Blog_PostCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blog_PostCount]  DEFAULT ((0)) FOR [PostCount]
GO
/****** Object:  Default [DF_Blog_CommentCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blog_CommentCount]  DEFAULT ((0)) FOR [CommentCount]
GO
/****** Object:  Default [DF_Blog_TrackBackCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blog_TrackBackCount]  DEFAULT ((0)) FOR [TrackBackCount]
GO
/****** Object:  Default [DF_category_Count]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_category_Count]  DEFAULT ((0)) FOR [Count]
GO
/****** Object:  Default [DF_comment_addtime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_comment_addtime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_Comment_IsReply]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_IsReply]  DEFAULT ((0)) FOR [IsReply]
GO
/****** Object:  Default [DF_Comment_IsSee]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_IsSee]  DEFAULT ((0)) FOR [IsSee]
GO
/****** Object:  Default [DF_Comment_IsDel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_IsDel]  DEFAULT ((0)) FOR [IsDel]
GO
/****** Object:  Default [DF_Comment_type]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_type]  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF_Comment_istellme]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_istellme]  DEFAULT ((0)) FOR [IsTellMe]
GO
/****** Object:  Default [DF_ContactInformation_WebSite]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[ContactInformation] ADD  CONSTRAINT [DF_ContactInformation_WebSite]  DEFAULT ('') FOR [WebSite]
GO
/****** Object:  Default [DF_ContactInformation_TellMethod]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[ContactInformation] ADD  CONSTRAINT [DF_ContactInformation_TellMethod]  DEFAULT ((1)) FOR [TellMethod]
GO
/****** Object:  Default [DF_ContactInformation_ShowLevel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[ContactInformation] ADD  CONSTRAINT [DF_ContactInformation_ShowLevel]  DEFAULT ((200)) FOR [ShowLevel]
GO
/****** Object:  Default [DF_Entry_UpdateTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Entry] ADD  CONSTRAINT [DF_Entry_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
/****** Object:  Default [DF_EntryVersion_Status]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[EntryVersion] ADD  CONSTRAINT [DF_EntryVersion_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_Event_type]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Event] ADD  CONSTRAINT [DF_Event_type]  DEFAULT ((0)) FOR [ShowLevel]
GO
/****** Object:  Default [DF_SchoolInformation_Grade]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[FieldInformation] ADD  CONSTRAINT [DF_SchoolInformation_Grade]  DEFAULT ((0)) FOR [Year]
GO
/****** Object:  Default [DF_Table2_send]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Friend] ADD  CONSTRAINT [DF_Table2_send]  DEFAULT ((0)) FOR [FromID]
GO
/****** Object:  Default [DF_Friend_toid]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Friend] ADD  CONSTRAINT [DF_Friend_toid]  DEFAULT ((0)) FOR [ToID]
GO
/****** Object:  Default [DF_Friend_IsTrue]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Friend] ADD  CONSTRAINT [DF_Friend_IsTrue]  DEFAULT ((0)) FOR [IsTrue]
GO
/****** Object:  Default [DF_Friend_IsCommon]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Friend] ADD  CONSTRAINT [DF_Friend_IsCommon]  DEFAULT ((1)) FOR [IsCommon]
GO
/****** Object:  Default [DF_Group_GroupName]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_GroupName]  DEFAULT ('') FOR [Name]
GO
/****** Object:  Default [DF_Group_addtime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_addtime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_Group_UserCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_UserCount]  DEFAULT ((1)) FOR [UserCount]
GO
/****** Object:  Default [DF_Group_AdminCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_AdminCount]  DEFAULT ((1)) FOR [AdminCount]
GO
/****** Object:  Default [DF_Group_PostCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_PostCount]  DEFAULT ((0)) FOR [PostCount]
GO
/****** Object:  Default [DF_Group_ViewCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_ViewCount]  DEFAULT ((0)) FOR [ViewCount]
GO
/****** Object:  Default [DF_Group_JoinLevel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_JoinLevel]  DEFAULT ((4)) FOR [JoinLevel]
GO
/****** Object:  Default [DF_Group_ShowLevel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_ShowLevel]  DEFAULT ((4)) FOR [ShowLevel]
GO
/****** Object:  Default [DF_Group_IsTrue]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_IsTrue]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_Table_1_addtime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[GroupUser] ADD  CONSTRAINT [DF_Table_1_addtime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_Letter_FromId]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Letter_FromId]  DEFAULT ((0)) FOR [FromID]
GO
/****** Object:  Default [DF_Letter_ToId]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Letter_ToId]  DEFAULT ((0)) FOR [ToID]
GO
/****** Object:  Default [DF_Letter_SendTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Letter_SendTime]  DEFAULT (getdate()) FOR [SendTime]
GO
/****** Object:  Default [DF_Letter_IsSee]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Letter_IsSee]  DEFAULT ((0)) FOR [IsSee]
GO
/****** Object:  Default [DF_Message_IsFromDel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_IsFromDel]  DEFAULT ((0)) FOR [IsFromDel]
GO
/****** Object:  Default [DF_Message_IsToDel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_IsToDel]  DEFAULT ((0)) FOR [IsToDel]
GO
/****** Object:  Default [DF_Message_IsHtml]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_IsHtml]  DEFAULT ((0)) FOR [IsHtml]
GO
/****** Object:  Default [DF_Log_title]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_title]  DEFAULT ('') FOR [Title]
GO
/****** Object:  Default [DF_Log_body]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_body]  DEFAULT ('') FOR [Body]
GO
/****** Object:  Default [DF_Log_AddTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_Log_EditTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_EditTime]  DEFAULT (getdate()) FOR [EditTime]
GO
/****** Object:  Default [DF_Log_userid]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_userid]  DEFAULT ((0)) FOR [UserID]
GO
/****** Object:  Default [DF_Log_istellme]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_istellme]  DEFAULT ((1)) FOR [IsTellMe]
GO
/****** Object:  Default [DF_Log_ViewCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_ViewCount]  DEFAULT ((0)) FOR [ViewCount]
GO
/****** Object:  Default [DF_Log_PushCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_PushCount]  DEFAULT ((0)) FOR [PushCount]
GO
/****** Object:  Default [DF_Log_TrackBackCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_TrackBackCount]  DEFAULT ((0)) FOR [TrackBackCount]
GO
/****** Object:  Default [DF_Log_CommentCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_CommentCount]  DEFAULT ((0)) FOR [CommentCount]
GO
/****** Object:  Default [DF_Log_LastCommentUserid]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_LastCommentUserid]  DEFAULT ((0)) FOR [LastCommentUserID]
GO
/****** Object:  Default [DF_Log_LastCommentTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Log_LastCommentTime]  DEFAULT (getdate()) FOR [LastCommentTime]
GO
/****** Object:  Default [DF_Profile_Name]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_Name]  DEFAULT ('') FOR [Name]
GO
/****** Object:  Default [DF_Profile_Status]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_User_Score]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_Score]  DEFAULT ((50)) FOR [Score]
GO
/****** Object:  Default [DF_User_ShowScore]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_ShowScore]  DEFAULT ((50)) FOR [ShowScore]
GO
/****** Object:  Default [DF_User_DelScore]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_DelScore]  DEFAULT ((0)) FOR [DelScore]
GO
/****** Object:  Default [DF_User_MagicBox]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_MagicBox]  DEFAULT ('') FOR [MagicBox]
GO
/****** Object:  Default [DF_User_IsMusic]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_IsMusic]  DEFAULT ((1)) FOR [IsMagicBox]
GO
/****** Object:  Default [DF_Profile_RegTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_RegTime]  DEFAULT (getdate()) FOR [RegTime]
GO
/****** Object:  Default [DF_Profile_LoginTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_LoginTime]  DEFAULT (getdate()) FOR [LoginTime]
GO
/****** Object:  Default [DF_User_ViewCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_ViewCount]  DEFAULT ((0)) FOR [ViewCount]
GO
/****** Object:  Default [DF_User_FileSizeAll]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_FileSizeAll]  DEFAULT ((2097152)) FOR [FileSizeAll]
GO
/****** Object:  Default [DF_User_FileSizeCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_User_FileSizeCount]  DEFAULT ((0)) FOR [FileSizeCount]
GO
/****** Object:  Default [DF_Push_PushTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Push] ADD  CONSTRAINT [DF_Push_PushTime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_Reply_addtime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Reply] ADD  CONSTRAINT [DF_Reply_addtime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_Reply_IsSee]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Reply] ADD  CONSTRAINT [DF_Reply_IsSee]  DEFAULT ((0)) FOR [IsSee]
GO
/****** Object:  Default [DF_Reply_IsDel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Reply] ADD  CONSTRAINT [DF_Reply_IsDel]  DEFAULT ((0)) FOR [IsDel]
GO
/****** Object:  Default [DF_Reply_istellme]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Reply] ADD  CONSTRAINT [DF_Reply_istellme]  DEFAULT ((0)) FOR [IsTellMe]
GO
/****** Object:  Default [DF_Services_Answer]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF_Services_Answer]  DEFAULT ('') FOR [Answer]
GO
/****** Object:  Default [DF_Services_status]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF_Services_status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_Services_sendtime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF_Services_sendtime]  DEFAULT (getdate()) FOR [SendTime]
GO
/****** Object:  Default [DF_Services_Answertime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF_Services_Answertime]  DEFAULT (getdate()) FOR [AnswerTime]
GO
/****** Object:  Default [DF_Services_userid]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF_Services_userid]  DEFAULT ((0)) FOR [UserID]
GO
/****** Object:  Default [DF_SuperNote_title]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[SuperNote] ADD  CONSTRAINT [DF_SuperNote_title]  DEFAULT ('') FOR [Title]
GO
/****** Object:  Default [DF_SuperNote_CommentCount]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[SuperNote] ADD  CONSTRAINT [DF_SuperNote_CommentCount]  DEFAULT ((0)) FOR [ViewCount]
GO
/****** Object:  Default [DF_SuperNote_AddTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[SuperNote] ADD  CONSTRAINT [DF_SuperNote_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  Default [DF_SuperNote_showlevel]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[SuperNote] ADD  CONSTRAINT [DF_SuperNote_showlevel]  DEFAULT ((0)) FOR [ShowLevel]
GO
/****** Object:  Default [DF_SuperNote_type]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[SuperNote] ADD  CONSTRAINT [DF_SuperNote_type]  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF_Tags_Count]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Tags] ADD  CONSTRAINT [DF_Tags_Count]  DEFAULT ((0)) FOR [Count]
GO
/****** Object:  Default [DF_Tags_type]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Tags] ADD  CONSTRAINT [DF_Tags_type]  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF_Table_1_userid]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[ViewData] ADD  CONSTRAINT [DF_Table_1_userid]  DEFAULT ((0)) FOR [OwnerID]
GO
/****** Object:  Default [DF_ViewData_Viewerid]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[ViewData] ADD  CONSTRAINT [DF_ViewData_Viewerid]  DEFAULT ((0)) FOR [ViewerID]
GO
/****** Object:  Default [DF_ViewData_ViewTime]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[ViewData] ADD  CONSTRAINT [DF_ViewData_ViewTime]  DEFAULT (getdate()) FOR [ViewTime]
GO
/****** Object:  Default [DF_ViewData_ViewClass]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[ViewData] ADD  CONSTRAINT [DF_ViewData_ViewClass]  DEFAULT ((0)) FOR [ViewClass]
GO
/****** Object:  Check [CK_Friend]    Script Date: 02/18/2009 05:06:12 ******/
ALTER TABLE [dbo].[Friend]  WITH NOCHECK ADD  CONSTRAINT [CK_Friend] CHECK  (([fromid]<>[toid]))
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [CK_Friend]
GO
