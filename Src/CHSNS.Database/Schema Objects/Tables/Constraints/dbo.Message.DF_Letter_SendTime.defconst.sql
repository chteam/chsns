ALTER TABLE [dbo].[Message] ADD CONSTRAINT [DF_Letter_SendTime] DEFAULT (getdate()) FOR [SendTime]


