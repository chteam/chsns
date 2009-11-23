CREATE TABLE [dbo].[Account]
(
[UserId] [bigint] NOT NULL IDENTITY(10000, 1),
[UserName] [nvarchar] (50) NOT NULL,
[Password] [char] (32) NOT NULL,
[Code] [bigint] NULL
) ON [PRIMARY]


