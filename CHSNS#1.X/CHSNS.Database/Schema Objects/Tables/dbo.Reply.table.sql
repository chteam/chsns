CREATE TABLE [dbo].[Reply]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[UserID] [bigint] NOT NULL,
[SenderID] [bigint] NOT NULL,
[Body] [nvarchar] (4000) NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[IsSee] [bit] NOT NULL,
[IsDel] [bit] NOT NULL,
[IsTellMe] [tinyint] NOT NULL
) ON [PRIMARY]


