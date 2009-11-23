-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MyMagicBoxUpBack]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @MagicBox nvarchar(4000)

SELECT    @MagicBox= MagicBox
FROM         [Profile]
WHERE     (UserId = @userid)

exec MessageInsert
@userid, 
@userid,
'备份',
@MagicBox

return
END


