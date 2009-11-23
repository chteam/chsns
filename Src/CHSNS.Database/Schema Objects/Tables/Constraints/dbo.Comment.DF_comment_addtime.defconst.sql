ALTER TABLE [dbo].[Comment] ADD CONSTRAINT [DF_comment_addtime] DEFAULT (getdate()) FOR [AddTime]


