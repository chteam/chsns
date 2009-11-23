-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NoteList_Month]
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT count([id]) as counter,
     year(AddTime) as [year] ,month(AddTime)as [month]
  FROM [Log]
 where userid =@userid and Groupid=0
Group by year(AddTime) ,month(AddTime)
order by  year(AddTime) desc ,month(AddTime)  desc
END


