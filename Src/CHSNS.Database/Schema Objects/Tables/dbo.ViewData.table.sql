CREATE TABLE [dbo].[ViewData]
(
[Id] [bigint] NOT NULL IdENTITY(1, 1),
[OwnerId] [bigint] NOT NULL,
[ViewerId] [bigint] NOT NULL,
[IPandComputer] [nvarchar] (50) NULL,
[ViewPageUrl] [nvarchar] (255) NULL,
[LastUrl] [nvarchar] (255) NULL,
[ViewTime] [datetime] NOT NULL,
[ViewClass] [tinyint] NOT NULL
) ON [PRIMARY]


