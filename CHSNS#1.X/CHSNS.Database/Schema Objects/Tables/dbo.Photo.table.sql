CREATE TABLE [dbo].[Photo]
(
/*基本信息*/
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[AlbumID] [bigint] NULL,
[UserID] [bigint] NOT NULL,
[AddTime] [datetime] NOT NULL,
/*其它*/
[Order] [bigint] NOT NULL,
[Ext] [ntext] Null,
[Status] [int] Not Null
) ON [PRIMARY]


