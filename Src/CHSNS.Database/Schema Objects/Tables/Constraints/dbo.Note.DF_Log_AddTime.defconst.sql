ALTER TABLE [dbo].[Note] ADD CONSTRAINT [DF_Log_AddTime] DEFAULT (getdate()) FOR [AddTime]


