CREATE TABLE [dbo].[Tags]
(
[Id] [bigint] NOT NULL IdENTITY(1, 1),
[Title] [nvarchar] (50) NOT NULL,
[Count] [bigint] NOT NULL,
[Type] [tinyint] NOT NULL
) ON [PRIMARY]


