ALTER TABLE [dbo].[Album] ADD CONSTRAINT [DF_Album_Addtime] DEFAULT (getdate()) FOR [AddTime]


