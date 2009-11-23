ALTER TABLE [dbo].[Profile] ADD CONSTRAINT [DF_Profile_LoginTime] DEFAULT (getdate()) FOR [LoginTime]


