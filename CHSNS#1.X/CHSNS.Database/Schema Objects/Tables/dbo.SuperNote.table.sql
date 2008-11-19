CREATE TABLE [dbo].[SuperNote]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (50) NULL,
[Faceurl] [nvarchar] (500) NULL,
[Url] [nvarchar] (500) NOT NULL,
[Description] [nvarchar] (50) NULL,
[UserID] [bigint] NOT NULL,
[ViewCount] [bigint] NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[ShowLevel] [tinyint] NOT NULL,
[SystemCategory] [bigint] NULL,
[Category] [bigint] NULL,
[Type] [tinyint] NOT NULL
) ON [PRIMARY]


