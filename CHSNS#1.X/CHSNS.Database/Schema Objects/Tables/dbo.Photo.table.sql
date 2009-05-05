CREATE TABLE [dbo].[Photo](
/*基本信息*/
[Id] [bigint] NOT NULL IdENTITY(1, 1),/*图片ID*/
[Title] [nvarchar] (50) NOT NULL,/*图片名称*/
[Summary] nvarchar (255) NOT NULL,/*图片简介*/
[AlbumId] [bigint] NULL,/*相册Id，留空为头像*/
[UserId] [bigint] NOT NULL,/*用户Id*/
[AddTime] [datetime] NOT NULL,/*提交时间*/
/*图片存储*/
[Domain] [nvarchar] (255) NOT NULL,/*图片放置的域名*/
[URL] [nvarchar] (244) NOT NULL,/*图片URL*/
/*其它*/
[Order] [bigint] NOT NULL,/*顺序*/
[Status] [int] Not Null/*状态*/
) ON [PRIMARY]


