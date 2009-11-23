-- =============================================
-- Author:		邹健
-- Create date: 200702 EDIT 2007 10 1
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Services_Count]
@page bigint=1,--当前页码
--@Count bigint,--总记录数默认每页为10只
@everyPage bigint=10,
@userid bigint=null,
@Email nvarchar(50)=null
AS
BEGIN
	SET NOCOUNT ON;

declare @ret bigint
	SELECT   @ret=count(Services.id)
	FROM Services
	WHERE  Services.userid=isnull(@userid,Services.userid) and Services.Email=isnull(@Email,Services.Email)
return @ret


END


