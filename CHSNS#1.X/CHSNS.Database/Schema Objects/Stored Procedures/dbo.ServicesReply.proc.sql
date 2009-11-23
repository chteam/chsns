-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ServicesReply]
@id bigint,
@Answer nvarchar(4000)
AS
BEGIN
	SET NOCOUNT ON;
UPDATE    Services
SET              Answer =@Answer, status =2 where id=@id
--登录用户则发一则Message
--非登录用户则发一则email
END


