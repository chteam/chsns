CREATE TABLE [dbo].[ViewData]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[OwnerID] [bigint] NOT NULL,
[ViewerID] [bigint] NOT NULL,
[IpandComputer] [nvarchar] (50) NULL,
[ViewPageUrl] [nvarchar] (255) NULL,
[LastUrl] [nvarchar] (255) NULL,
[ViewTime] [datetime] NOT NULL,
[ViewClass] [tinyint] NOT NULL
) ON [PRIMARY]


