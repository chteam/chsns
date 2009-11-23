-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReplyUpdateToIsSee]
@id bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
UPDATE    Comment
SET IsSee = 1
WHERE     (id = @id)
END


