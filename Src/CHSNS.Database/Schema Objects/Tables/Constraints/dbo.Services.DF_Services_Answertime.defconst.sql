ALTER TABLE [dbo].[Services] ADD CONSTRAINT [DF_Services_Answertime] DEFAULT (getdate()) FOR [AnswerTime]


