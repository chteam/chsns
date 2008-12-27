CREATE TABLE [dbo].[Note]
(
[ID] [bigint] NOT NULL IDENTITY(1000, 1),
[UserID] [bigint] NOT NULL,
[Title] [nvarchar] (255) NOT NULL,
[Summary] [nvarchar] (4000) NULL,
[Body] [ntext] NOT NULL,
[ShowLevel] [tinyint] NOT NULL,
[IsAnonymous] [bit] NULL,
[AddTime] [smalldatetime] NOT NULL,
[EditTime] [smalldatetime] NOT NULL,
[ViewCount] [bigint] NOT NULL,
[PushCount] [bigint] NOT NULL,
[TrackBackCount] [bigint] NOT NULL,
[CommentCount] [bigint] NOT NULL,
[LastCommentUserID] [bigint] NOT NULL,
[LastCommentTime] [smalldatetime] NOT NULL,
[IsTellMe] [tinyint] NOT NULL,
[Type] [tinyint] not null
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO