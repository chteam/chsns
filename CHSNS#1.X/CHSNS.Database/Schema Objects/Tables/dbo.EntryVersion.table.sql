CREATE TABLE [dbo].[EntryVersion](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Reason] [ntext] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[Description] [ntext] NOT NULL,
	[Reference] [ntext] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Status] [int] NOT NULL CONSTRAINT [DF_EntryVersion_Status]  DEFAULT ((0)),
	[EntryID] [bigint] NULL,
	[ParentText] [nvarchar] (50) NULL,
	[Ext] [ntext] NULL,
 CONSTRAINT [PK_EntryVersion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, 
		STATISTICS_NORECOMPUTE  = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS  = ON, 
		ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]