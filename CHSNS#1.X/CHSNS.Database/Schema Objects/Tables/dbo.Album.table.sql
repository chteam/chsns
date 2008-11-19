CREATE TABLE [dbo].[Album]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[UserID] [bigint] NOT NULL,
[Name] [nvarchar] (50) NOT NULL,
[ShowLevel] [tinyint] NOT NULL,
[Description] [nvarchar] (150) NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[Order] [int] NOT NULL,
[Location] [nvarchar] (50) NULL,
[FaceUrl] [nvarchar] (250) NULL,
[Count] [int] NOT NULL
) ON [PRIMARY]


