ALTER TABLE [dbo].[Blogs] ADD CONSTRAINT [DF_Blog_CreateTime] DEFAULT (getdate()) FOR [CreateTime]


