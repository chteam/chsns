-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupListCount]
@userid bigint,
@GroupClass bigint=0,
@type tinyint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @count bigint
if(@type=0 and @GroupClass=0)
 select @count=groupCount from [Profile] where userid=@userid
return @count
END


