-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	管理员查看services
-- =============================================
CREATE PROCEDURE [dbo].[ServicesSelectById]
@id bigint
AS
BEGIN
	SET NOCOUNT ON;
if exists(select id from Services where (id = @id) and  status <1)
UPDATE    Services
SET        status = 1
WHERE     (id = @id)

SELECT     userid, sendtime, body, Email
FROM         Services
WHERE     (id = @id)
END


