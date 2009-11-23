-- =============================================
-- Author:		邹健
-- Create date: 20070727
-- Description:	由学校名得到院系
-- =============================================
CREATE PROCEDURE [dbo].[GetXueYuan]
@School nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT   id,  XueYuan
FROM         XueYuan
WHERE     School in (select id from school where school=@school  and schoolclass=0)
ORDER BY XueYuan

END


