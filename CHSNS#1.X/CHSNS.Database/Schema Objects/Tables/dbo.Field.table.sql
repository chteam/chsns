CREATE TABLE [dbo].[Field]
(
[TrueID] [bigint] NOT NULL IDENTITY(1, 1),
[ID] [bigint] NULL,
[Name] [nvarchar] (50) NOT NULL,
[PID] [bigint] NULL,
[IsTrue] [bit] NOT NULL,
[Class] [int] NOT NULL
) ON [PRIMARY]


