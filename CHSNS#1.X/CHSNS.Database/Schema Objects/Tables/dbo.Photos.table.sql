CREATE TABLE [dbo].[Photos]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[AlbumID] [bigint] NOT NULL,
[UserID] [bigint] NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[Path] [nvarchar] (500) NOT NULL,
[Order] [bigint] NOT NULL,
[CommentCount] [bigint] NOT NULL
) ON [PRIMARY]


