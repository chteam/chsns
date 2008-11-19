ALTER TABLE [dbo].[Note] ADD CONSTRAINT [DF_Log_LastCommentTime] DEFAULT (getdate()) FOR [LastCommentTime]


