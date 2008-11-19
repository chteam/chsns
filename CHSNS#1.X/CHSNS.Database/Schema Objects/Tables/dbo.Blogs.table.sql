CREATE TABLE [dbo].[Blogs]
(
[UserID] [bigint] NOT NULL,
[CreateTime] [smalldatetime] NOT NULL,
[Title] [nvarchar] (50) NOT NULL,
[SubTitle] [nvarchar] (500) NULL,
[Publish] [nvarchar] (max) NULL,
[WriteName] [nvarchar] (50) NOT NULL,
[CommentEmail] [nvarchar] (50) NULL,
[Skin] [nvarchar] (50) NULL,
[Css] [ntext] NULL,
[MetaKey] [nvarchar] (400) NULL,
[IsWebServices] [bit] NOT NULL,
[PostCount] [bigint] NOT NULL,
[CommentCount] [bigint] NOT NULL,
[TrackBackCount] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


