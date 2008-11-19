-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	获取GETLOG页面的LOG信息
--即LOG可show的所有字段
-- =============================================
CREATE PROCEDURE [dbo].[NoteSummary_Month]
@userid bigint,
@year int=0,
@month tinyint=0
AS
BEGIN
SET NOCOUNT ON;
if @year=0 and @month=0
SELECT top 1  @year= year(AddTime)  ,@month=month(AddTime)
  FROM [Log]
 where userid =@userid and Groupid=0
Group by year(AddTime) ,month(AddTime)
order by  year(AddTime) desc ,month(AddTime)  desc

SELECT     id, dbo.HTMLEncode(title) as title, AddTime, Substring([Log].body,0,250) as body, PushCount, ViewCount, CommentCount, isPost
FROM         [Log]
WHERE     (YEAR(AddTime) = @year) AND (MONTH(AddTime) = @month) AND (userid = @userid)and Groupid=0
ORDER BY AddTime DESC

END


