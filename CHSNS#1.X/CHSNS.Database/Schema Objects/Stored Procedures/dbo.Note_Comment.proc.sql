-- =============================================
-- Author:		邹健
-- Create date: 200702 ,2007 9 26
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Note_Comment]
@userid bigint,
@page bigint=1,
@everypage bigint=10,
@type tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
if(@type=0)
SELECT TOP (@everyPage) *
      FROM (SELECT  top (@page*@everyPage)
			Comment.senderid, 
			[Log].id AS Logid, [Log].title, comment.body,
			Comment.id as Commentid,
			Comment.addtime, 
			[name]
			,ROW_NUMBER() OVER (ORDER BY Comment.id desc) AS RowNo
			FROM         Comment INNER JOIN
			 [Log] ON Comment.Logid = [Log].id INNER JOIN
			 Account ON Comment.senderid = Account.UserId
			WHERE     (Comment.ownerid = @userid) and [Log].groupid=0 and (Comment.Logid!=0)
			)AS A-- 发件箱
	WHERE RowNo > (@page-1)*@everyPage
else
begin
	SELECT count(1) as counter
			FROM         Comment INNER JOIN
			 [Log] ON Comment.Logid = [Log].id 
			WHERE     (Comment.ownerid = @userid) and [Log].groupid=0 and (Comment.Logid!=0)
end
END


