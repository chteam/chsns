CREATE TABLE [dbo].[Comment]
(
[Id] [bigint] NOT NULL IDENTITY(1, 1),
[ShowerId] [bigint] NULL,
[OwnerId] [bigint] NOT NULL,
[SenderId] [bigint] NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[Body] [ntext] NOT NULL,
[IsReply] [bit] NOT NULL,
[IsSee] [bit] NOT NULL,
[IsDel] [bit] NOT NULL,
[Type] [tinyint] NOT NULL,
[IsTellMe] [tinyint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


