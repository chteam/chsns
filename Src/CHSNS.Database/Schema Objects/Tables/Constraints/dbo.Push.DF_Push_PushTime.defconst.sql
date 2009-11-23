ALTER TABLE [dbo].[Push] ADD CONSTRAINT [DF_Push_PushTime] DEFAULT (getdate()) FOR [AddTime]


