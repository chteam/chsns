ALTER TABLE [dbo].[Note] ADD CONSTRAINT [DF_Log_EditTime] DEFAULT (getdate()) FOR [EditTime]


