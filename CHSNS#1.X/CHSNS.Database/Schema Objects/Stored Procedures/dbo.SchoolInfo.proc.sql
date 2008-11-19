-- =============================================
-- Author:		邹健
-- Create date: 070725 le 10 20 
-- Description:	提取用户创建班级的最基本信息
-- =============================================
CREATE PROCEDURE [dbo].[SchoolInfo]
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT   school.school AS   University, Grade,XueYuan.XueYuan
FROM          SchoolInformation
		INNER JOIN	school on SchoolInformation.University=school.id
		INNER JOIN	XueYuan on SchoolInformation.XueYuan=XueYuan.id
WHERE     (UserId = @userid)

END


