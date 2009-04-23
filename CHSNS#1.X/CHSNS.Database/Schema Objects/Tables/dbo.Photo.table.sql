CREATE TABLE [dbo].[Photo]
(
/*基本信息*/
[Id] [bigint] NOT NULL IdENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[AlbumId] [bigint] NULL,
[UserId] [bigint] NOT NULL,
[AddTime] [datetime] NOT NULL,
/*其它*/
[Order] [bigint] NOT NULL,
[Ext] [ntext] Null,
[Status] [int] Not Null
) ON [PRIMARY]


