CREATE TABLE [dbo].[BasicInformation]
(
[UserId] [bigint] NOT NULL,
[Name] [nvarchar] (20) NULL,
[Email] [nvarchar] (500) NULL,
[IsEmailTrue] [bit] NOT NULL,
[Sex] [bit] NULL,
[Birthday] [smalldatetime] NULL,
[ProvinceId] [int] NOT NULL,
[CityId] [bigint] NOT NULL,
[ShowLevel] [tinyint] NOT NULL
) ON [PRIMARY]