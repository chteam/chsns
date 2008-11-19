ALTER TABLE [dbo].[Profile] ADD CONSTRAINT [DF_Profile_RegTime] DEFAULT (getdate()) FOR [RegTime]


