CREATE TABLE [dbo].[GroupUser]
(
[UserID] [bigint] NOT NULL,
[GroupID] [bigint] NOT NULL,
[Level] [tinyint] NOT NULL,
[AddTime] [smalldatetime] NOT NULL,
[NoteCount] [bigint] NOT NULL,
[IsTrue] [bit] NOT NULL
) ON [PRIMARY]


