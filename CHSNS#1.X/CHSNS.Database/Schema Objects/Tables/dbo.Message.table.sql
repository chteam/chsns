CREATE TABLE [dbo].[Message]
(
[ID] [bigint] NOT NULL IDENTITY(1, 1),
[FromID] [bigint] NOT NULL,
[ToID] [bigint] NOT NULL,
[Title] [nvarchar] (200) NOT NULL,
[Body] [nvarchar] (4000) NOT NULL,
[SendTime] [smalldatetime] NOT NULL,
[IsSee] [bit] NOT NULL,
[IsFromDel] [bit] NOT NULL,
[IsToDel] [bit] NOT NULL,
[IsHtml] [bit] NOT NULL
) ON [PRIMARY]


