CREATE TABLE [dbo].[BasicInformation]
(
[UserID] [bigint] NOT NULL,
[Name] [nvarchar] (20) NULL,
[Email] [nvarchar] (500) NULL,
[IsEmailTrue] [bit] NOT NULL,
[Sex] [bit] NULL,
[Birthday] [smalldatetime] NULL,
[ProvinceID] [int] NOT NULL,
[CityID] [bigint] NOT NULL,
[ShowLevel] [tinyint] NOT NULL
) ON [PRIMARY]


