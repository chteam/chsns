CREATE TABLE [dbo].[Category]
(
[Id] [bigint] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[Type] [tinyint] NOT NULL,
[Count] [bigint] NOT NULL,
[UserId] [bigint] NULL
) ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'MS_Description', N'0 is group ', 'SCHEMA', N'dbo', 'TABLE', N'Category', 'COLUMN', N'Type'
GO
EXEC sp_addextendedproperty N'MS_Description', N'0', 'SCHEMA', N'dbo', 'TABLE', N'Category', 'COLUMN', N'Count'

