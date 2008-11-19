CREATE TABLE [dbo].[Tags]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (50) NOT NULL,
[Count] [bigint] NOT NULL,
[Type] [tinyint] NOT NULL
) ON [PRIMARY]


