-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LogSelectByMonth]
@userid bigint,
@year int=0,
@month tinyint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if @year=0 and @month=0
SELECT top 1  @year= year(AddTime)  ,@month=month(AddTime)
  FROM [Log]
 where userid =@userid and Groupid=0
Group by year(AddTime) ,month(AddTime)
order by  year(AddTime) desc ,month(AddTime)  desc

SELECT     [id],dbo.HTMLEncode([title]) as title, [AddTime]
FROM         [Log] 
where year(addtime)=@year and (month(addtime)=@month) and (userid=@userid) and Groupid=0
order by AddTime desc

END


