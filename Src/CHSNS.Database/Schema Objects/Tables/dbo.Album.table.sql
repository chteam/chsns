CREATE TABLE [dbo].[Album]
(
/*基本信息*/
[Id] [bigint] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[Location] [nvarchar] (50) NULL,
[Description] [nvarchar] (150) NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[FaceUrl] [nvarchar] (250) NULL,

[Count] [int] NOT NULL,
[UserId] [bigint] NOT NULL,

[Order] [int] NOT NULL,
[ShowLevel] [tinyint] NOT NULL
) ON [PRIMARY]


