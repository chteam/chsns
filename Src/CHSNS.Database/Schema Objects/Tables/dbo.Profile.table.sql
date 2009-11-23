CREATE TABLE [dbo].[Profile]
(
[UserId] [bigint] NOT NULL,/*用户唯一标识*/
/*信息*/
[Name] [nvarchar] (50) NOT NULL,
[Face] [nvarchar] (300) Null,
[Status] [int] NOT NULL,
/*分数*/
[Score] [bigint] NOT NULL,
[ShowScore] [bigint] NOT NULL,
[DelScore] [bigint] NOT NULL,
/*权限*/
[ShowLevel] [tinyint] NOT NULL,
/*魔法盒*/
[MagicBox] [nvarchar] (Max) NOT NULL,
[HasMagicBox] [bit] NOT NULL,
/*统计*/
[RegTime] [smalldatetime] NOT NULL,
[LoginTime] [smalldatetime] NOT NULL,
[ViewCount] [bigint] NOT NULL,
[FileSizeAll] [bigint] NOT NULL,
[FileSizeCount] [bigint] NOT NULL,
/*应用*/
[Applications] [ntext] NULL,
[Applicationlist] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]