CREATE TABLE [dbo].[Friend]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[FromID] [bigint] NOT NULL,
[ToID] [bigint] NOT NULL,
[IsTrue] [bit] NOT NULL,
[IsCommon] [bit] NOT NULL,
[FriendType] [int] NULL,
[FriendSummary] [int] NULL
) ON [PRIMARY]


