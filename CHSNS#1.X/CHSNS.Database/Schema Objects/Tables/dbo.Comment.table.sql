CREATE TABLE [dbo].[Comment]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[ShowerID] [bigint] NULL,
[OwnerID] [bigint] NOT NULL,
[SenderID] [bigint] NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[Body] [ntext] NOT NULL,
[IsReply] [bit] NOT NULL,
[IsSee] [bit] NOT NULL,
[IsDel] [bit] NOT NULL,
[Type] [tinyint] NOT NULL,
[IsTellMe] [tinyint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


