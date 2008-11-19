ALTER TABLE [dbo].[Services] ADD CONSTRAINT [DF_Services_sendtime] DEFAULT (getdate()) FOR [SendTime]


