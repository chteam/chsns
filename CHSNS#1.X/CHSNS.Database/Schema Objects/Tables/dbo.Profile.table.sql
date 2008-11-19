CREATE TABLE [dbo].[Profile]
(
[UserID] [bigint] NOT NULL,
[Name] [nvarchar] (50) NOT NULL,
[ShowText] [nvarchar] (20) NULL,
[ShowTextTime] [smalldatetime] NULL,
[Score] [bigint] NOT NULL,
[ShowScore] [bigint] NOT NULL,
[DelScore] [bigint] NOT NULL,
[MagicBox] [ntext] NOT NULL,
[AllShowLevel] [tinyint] NOT NULL,
[IsMagicBox] [bit] NOT NULL,
[ViewCount] [bigint] NOT NULL,
[IsStar] [bit] NOT NULL,
[IsUpdate] [bit] NOT NULL,
[Applications] [varchar] (max) NULL,
[Applicationlist] [varchar] (max) NULL,
[Field] [tinyint] NULL,
[Status] [int] NOT NULL,
[RegTime] [smalldatetime] NOT NULL,
[LoginTime] [smalldatetime] NOT NULL,
[AlbumCount] [bigint] NOT NULL,
[UnReadMessageCount] [bigint] NOT NULL,
[OutboxCount] [bigint] NOT NULL,
[InboxCount] [bigint] NOT NULL,
[FileSizeAll] [bigint] NOT NULL,
[FileSizeCount] [bigint] NOT NULL,
[FriendRequestCount] [bigint] NOT NULL,
[FriendCount] [bigint] NOT NULL,
[NoteCount] [bigint] NOT NULL,
[ReplyCount] [bigint] NOT NULL,
[GroupCount] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'MS_Description', N'用户唯一标识', 'SCHEMA', N'dbo', 'TABLE', N'Profile', 'COLUMN', N'UserID'

