CREATE TABLE [dbo].[Group]
(
--基本信息
[Id] [bigint] NOT NULL IdENTITY(1000, 1),
[Name] [nvarchar] (50) NOT NULL,
[LogoUrl] [nvarchar] (250) NULL,
[AddTime] [smalldatetime] NOT NULL,
[Summary] [nvarchar] (50) NOT NULL,
[CreaterId] [bigint] NOT NULL,
/*统计*/
[UserCount] [bigint] NOT NULL,
[AdminCount] [tinyint] NOT NULL,
[PostCount] [bigint] NOT NULL,
[ViewCount] [bigint] NOT NULL,
--级别，状态
[JoinLevel] [tinyint] NOT NULL,
[ShowLevel] [tinyint] NOT NULL,
[Status] [tinyint] NOT NULL,
[Type] tinyint not Null,
--扩展
[Ext] [ntext] NULL


) ON [PRIMARY]


