ALTER TABLE [dbo].[Photos] ADD CONSTRAINT [DF_Photos_Addtime] DEFAULT (getdate()) FOR [AddTime]


