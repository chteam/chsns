CREATE TABLE [dbo].[Reply]
(
[Id] [bigint] NOT NULL IdENTITY(1, 1),
[UserId] [bigint] NOT NULL,
[SenderId] [bigint] NOT NULL,
[Body] [nvarchar] (4000) NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[IsSee] [bit] NOT NULL,
[IsDel] [bit] NOT NULL,
[IsTellMe] [tinyint] NOT NULL
) ON [PRIMARY]


