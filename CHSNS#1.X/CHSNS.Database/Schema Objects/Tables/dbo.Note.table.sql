CREATE TABLE [dbo].[Note]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[UserID] [bigint] NOT NULL,
[Title] [nvarchar] (255) NOT NULL,
[Summary] [nvarchar] (4000) NULL,
[Body] [ntext] NOT NULL,
[IsPost] [tinyint] NOT NULL,
[Anonymous] [bit] NULL,
[AddTime] [datetime] NOT NULL,
[EditTime] [datetime] NOT NULL,
[ViewCount] [bigint] NOT NULL,
[PushCount] [bigint] NOT NULL,
[TrackBackCount] [bigint] NOT NULL,
[CommentCount] [bigint] NOT NULL,
[LastCommentUserID] [bigint] NOT NULL,
[LastCommentTime] [smalldatetime] NOT NULL,
[IsTellMe] [tinyint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'MS_Description', N'false为草稿true为已经发表', 'SCHEMA', N'dbo', 'TABLE', N'Note', 'COLUMN', N'IsPost'

