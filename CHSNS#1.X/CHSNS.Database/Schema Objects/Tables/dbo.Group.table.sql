CREATE TABLE [dbo].[Group]
(
--基本信息
[ID] [bigint] NOT NULL IDENTITY(1000, 1),
[Name] [nvarchar] (50) NOT NULL,
[LogoUrl] [nvarchar] (250) NULL,
[AddTime] [smalldatetime] NOT NULL,
[Summmary] [nvarchar] (50) NOT NULL,
[CreaterID] [bigint] NOT NULL,
/*统计*/
[UserCount] [bigint] NOT NULL,
[AdminCount] [tinyint] NOT NULL,
[PostCount] [bigint] NOT NULL,
[ViewCount] [bigint] NOT NULL,
--级别，状态
[JoinLevel] [tinyint] NOT NULL,
[ShowLevel] [tinyint] NOT NULL,
[Status] [tinyint] NOT NULL,
--扩展
[Ext] [ntext] NULL


) ON [PRIMARY]


