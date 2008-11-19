CREATE TABLE [dbo].[Group]
(
[ID] [bigint] NOT NULL IDENTITY(1000, 1),
[GroupName] [nvarchar] (50) NOT NULL,
[Summmary] [nvarchar] (50) NOT NULL,
[CreaterID] [bigint] NOT NULL,
[AdminCount] [tinyint] NOT NULL,
[NoteCount] [bigint] NOT NULL,
[ViewCount] [bigint] NOT NULL,
[JoinLevel] [tinyint] NOT NULL,
[ShowLevel] [tinyint] NOT NULL,
[UserCount] [bigint] NOT NULL,
[MagicBox] [nvarchar] (4000) NULL,
[LogoUrl] [nvarchar] (250) NULL,
[AddTime] [smalldatetime] NOT NULL,
[IsTrue] [bit] NOT NULL
) ON [PRIMARY]


