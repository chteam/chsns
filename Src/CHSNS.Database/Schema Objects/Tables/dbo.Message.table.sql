CREATE TABLE [dbo].[Message]
(
[Id] [bigint] NOT NULL IdENTITY(1, 1),
[FromId] [bigint] NOT NULL,
[ToId] [bigint] NOT NULL,
[Title] [nvarchar] (200) NOT NULL,
[Body] [nvarchar] (4000) NOT NULL,
[SendTime] [smalldatetime] NOT NULL,
[IsSee] [bit] NOT NULL,
[IsFromDel] [bit] NOT NULL,
[IsToDel] [bit] NOT NULL,
[IsHtml] [bit] NOT NULL
) ON [PRIMARY]


