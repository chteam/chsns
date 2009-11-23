-- =============================================
-- Author:		邹健
-- Create date: 200702, update 2007 9 28
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reply_New]
@userid bigint
AS
BEGIN
SET NOCOUNT ON;
	SELECT Top 5 Comment.Logid,Account.UserId, [Name],[log].title,
	 Comment.id,Comment.Isreply, Comment.addtime,[type],[log].groupid
	FROM Comment INNER JOIN
	 Account ON Comment.senderid = Account.UserId left join
	[log] on Comment.Logid=[log].id
	WHERE (Comment.ownerid = @userid) 
	AND (Comment.IsSee = 0) 
	AND (Comment.ownerid!=Comment.senderid) 
	and (Comment.isdel=0)
	and datediff("ww",Comment.addtime,getdate())=0
	order by id desc
END


