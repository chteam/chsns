-- =============================================
-- Author:		邹健
-- Create date: 200702 El:10 11将群的帖子阅读权限更改为<10
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Group_NoteList]
@Groupid bigint,
@page bigint=1,--当前页码
@everyPage bigint=10
AS
BEGIN
	SET NOCOUNT ON;


	SELECT TOP (@everyPage) *
	FROM      (
		SELECT  top (@page*@everyPage) [Log].[id],dbo.HTMLEncode(Substring([Log].[title],0,40)) as title, 
		[Log].ViewCount,[Log].CommentCount,LastCommentTime as Addtime,ispost,
		Account.[Name] as sendername, Account.UserId as senderid,--最后回复
		 Account_1.Userid, Account_1.Name AS [Name],--发帖人
		ROW_NUMBER() OVER (ORDER BY ispost desc, LastCommentTime desc,[log].id desc) AS RowNo 
		FROM         [Log] INNER JOIN
		Account ON [Log].LastCommentUserid = Account.UserId INNER JOIN
		Account AS Account_1 ON [Log].userid = Account_1.UserId
		WHERE    ispost<10 and  ( [Log].GroupId = @groupid) 
	)AS A-- 
	WHERE RowNo > (@page-1)*@everyPage
END


