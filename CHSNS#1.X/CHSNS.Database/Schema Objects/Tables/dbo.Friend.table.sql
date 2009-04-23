CREATE TABLE [dbo].[Friend]
(
[Id] [bigint] NOT NULL IdENTITY(1, 1),
[FromId] [bigint] NOT NULL,
[ToId] [bigint] NOT NULL,
[IsTrue] [bit] NOT NULL,
[IsCommon] [bit] NOT NULL,
[FriendType] [int] NULL,
[FriendSummary] [int] NULL
) ON [PRIMARY]


