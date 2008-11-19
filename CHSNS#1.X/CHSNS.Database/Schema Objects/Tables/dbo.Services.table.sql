CREATE TABLE [dbo].[Services]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[Body] [nvarchar] (4000) NOT NULL,
[Answer] [nvarchar] (4000) NOT NULL,
[Status] [tinyint] NOT NULL,
[SendTime] [smalldatetime] NOT NULL,
[AnswerTime] [smalldatetime] NOT NULL,
[UserID] [bigint] NOT NULL,
[Email] [nvarchar] (50) NULL
) ON [PRIMARY]


