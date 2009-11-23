CREATE TABLE [dbo].[Event]
(
[Id] [bigint] NOT NULL IdENTITY(1, 1),
[TemplateName] [nvarchar] (250) NOT NULL,
[OwnerId] [bigint] NOT NULL,
[ViewerId] [bigint] NULL,
[AddTime] [smalldatetime] NOT NULL,
[ShowLevel] [int] NOT NULL,
[Json] [nvarchar] (max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


