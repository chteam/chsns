ALTER TABLE [dbo].[Friend] WITH NOCHECK ADD CONSTRAINT [CK_Friend] CHECK (([fromid]<>[toid]))


