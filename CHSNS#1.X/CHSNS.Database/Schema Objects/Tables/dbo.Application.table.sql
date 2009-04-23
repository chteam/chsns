CREATE TABLE [dbo].[Application]
(
[Id] [bigint] NOT NULL IDENTITY(1000, 1),
[Controller] [nvarchar] (50) NOT NULL,
[Action] [nvarchar] (50) NOT NULL,
[ParamStr] [nvarchar] (250) NOT NULL,
[ClassName] [varchar] (50) NOT NULL,
[FullName] [nvarchar] (60) NOT NULL,
[ShortName] [nvarchar] (20) NOT NULL,
[Vision] [nvarchar] (20) NOT NULL,
[Icon] [nvarchar] (250) NULL,
[Authorid] [bigint] NULL,
[Addtime] [smalldatetime] NOT NULL,
[Edittime] [smalldatetime] NOT NULL,
[Description] [ntext] NOT NULL,
[IsSystem] [bit] NOT NULL,
[IsTrue] [bit] NOT NULL,
[DescriptionUrl] [nvarchar] (250) NULL,
[UserCount] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


