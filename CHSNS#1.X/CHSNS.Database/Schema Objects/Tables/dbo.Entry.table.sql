CREATE TABLE [dbo].[Entry](
	[ID] [bigint] IDENTITY(10000,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[CreaterID] [bigint] NOT NULL,
	[UpdateTime] [smalldatetime] NOT NULL CONSTRAINT [DF_Entry_UpdateTime]  DEFAULT (getdate()),
	[CurrentID] [bigint] NULL,
	[EditCount] [int] NOT NULL,
	[ViewCount] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
	[Ext] [ntext] NULL,
CONSTRAINT [PK_Entry] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF,
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON
	) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]