CREATE TABLE [dbo].[Note]
(
/*基本信息*/
[Id] [bigint] NOT NULL IdENTITY(1000, 1),
[Title] [nvarchar] (255) NOT NULL,
[Summary] [nvarchar] (4000) NULL,
[Body] [ntext] NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[EditTime] [smalldatetime] NOT NULL,
[Type] [tinyint] NOT NULL,
/*外键*/
[PId] [bigint] NOT NULL,
[UserId] [bigint] NOT NULL,

/*权限*/
[IsTellMe] [tinyint] NOT NULL,
[IsAnonymous] [bit] NULL,
[ShowLevel] [tinyint] NOT NULL,
/*统计*/
[ViewCount] [bigint] NOT NULL,
[PushCount] [bigint] NOT NULL,
[TrackBackCount] [bigint] NOT NULL,
[CommentCount] [bigint] NOT NULL,
[LastCommentUserId] [bigint] NOT NULL,
[LastCommentTime] [smalldatetime] NOT NULL,
/*扩展*/
[Ext] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO