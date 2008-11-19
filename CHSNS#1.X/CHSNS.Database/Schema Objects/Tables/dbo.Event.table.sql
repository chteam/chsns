CREATE TABLE [dbo].[Event]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[TemplateName] [nvarchar] (250) NOT NULL,
[OwnerID] [bigint] NOT NULL,
[ViewerID] [bigint] NULL,
[AddTime] [smalldatetime] NOT NULL,
[ShowLevel] [int] NOT NULL,
[Json] [nvarchar] (max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


