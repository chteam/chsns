-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LogSelectPush5]
AS
BEGIN
	SET NOCOUNT ON;

SELECT   top 5  [Log].id AS Logid, dbo.HTMLEncode([Log].title) as title, Account.UserId, Account.Name, [Log].AddTime
FROM         Push INNER JOIN
                      [Log] ON Push.Logid = [Log].id INNER JOIN
                      Account ON [Log].userid = Account.UserId where Groupid=0
ORDER BY Push.PushTime DESC, Push.id DESC

END


