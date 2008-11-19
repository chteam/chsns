CREATE TABLE [dbo].[Account]
(
[UserID] [bigint] NOT NULL IDENTITY(10000, 1),
[Username] [nvarchar] (50) NOT NULL,
[Password] [char] (32) NOT NULL,
[Code] [bigint] NULL
) ON [PRIMARY]


