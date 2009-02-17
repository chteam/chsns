USE [Wow]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 02/18/2009 05:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Character](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Race] [nvarchar](50) NOT NULL,
	[RealM] [nvarchar](50) NOT NULL,
	[Level] [int] NOT NULL,
	[BattleGroup] [nvarchar](50) NOT NULL,
	[Class] [nvarchar](50) NOT NULL,
	[Faction] [nvarchar](50) NOT NULL,
	[lastLoginDate] [smalldatetime] NULL,
	[Gend] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrentUser]    Script Date: 02/18/2009 05:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentUser](
	[UID] [bigint] NOT NULL,
	[CurrentCID] [bigint] NULL,
	[Evaluation] [int] NOT NULL,
	[GB] [int] NOT NULL,
	[ConsumerGB] [int] NOT NULL,
	[WorkerGB] [int] NOT NULL,
 CONSTRAINT [PK_CurrentUser] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 02/18/2009 05:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[PersonCount] [int] NOT NULL,
	[BeginTime] [smalldatetime] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[Description] [ntext] NOT NULL,
	[CreateUserID] [bigint] NOT NULL,
	[TaskType] [int] NOT NULL,
	[GB] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 02/18/2009 05:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UID] [bigint] NOT NULL,
	[TaskID] [bigint] NULL,
	[Description] [ntext] NULL,
	[EvaluationWork] [int] NULL,
	[Status] [int] NOT NULL,
	[AddTime] [smalldatetime] NOT NULL,
	[EvaluationTask] [int] NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_CurrentUser_Evaluation]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[CurrentUser] ADD  CONSTRAINT [DF_CurrentUser_Evaluation]  DEFAULT ((0)) FOR [Evaluation]
GO
/****** Object:  Default [DF_CurrentUser_GB]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[CurrentUser] ADD  CONSTRAINT [DF_CurrentUser_GB]  DEFAULT ((0)) FOR [GB]
GO
/****** Object:  Default [DF_CurrentUser_ConsumerGB]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[CurrentUser] ADD  CONSTRAINT [DF_CurrentUser_ConsumerGB]  DEFAULT ((0)) FOR [ConsumerGB]
GO
/****** Object:  Default [DF_CurrentUser_WorkerGB]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[CurrentUser] ADD  CONSTRAINT [DF_CurrentUser_WorkerGB]  DEFAULT ((0)) FOR [WorkerGB]
GO
/****** Object:  Default [DF_Task_AddTime]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
/****** Object:  ForeignKey [FK_Character_CurrentUser]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_CurrentUser] FOREIGN KEY([UID])
REFERENCES [dbo].[CurrentUser] ([UID])
GO
ALTER TABLE [dbo].[Character] CHECK CONSTRAINT [FK_Character_CurrentUser]
GO
/****** Object:  ForeignKey [FK_CurrentUser_Character1]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[CurrentUser]  WITH CHECK ADD  CONSTRAINT [FK_CurrentUser_Character1] FOREIGN KEY([CurrentCID])
REFERENCES [dbo].[Character] ([ID])
GO
ALTER TABLE [dbo].[CurrentUser] CHECK CONSTRAINT [FK_CurrentUser_Character1]
GO
/****** Object:  ForeignKey [FK_Task_CurrentUser]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_CurrentUser] FOREIGN KEY([CreateUserID])
REFERENCES [dbo].[CurrentUser] ([UID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_CurrentUser]
GO
/****** Object:  ForeignKey [FK_Worker_CurrentUser]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_CurrentUser] FOREIGN KEY([UID])
REFERENCES [dbo].[CurrentUser] ([UID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_CurrentUser]
GO
/****** Object:  ForeignKey [FK_Worker_Task]    Script Date: 02/18/2009 05:06:26 ******/
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Task] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Task] ([ID])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Task]
GO
