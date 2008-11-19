-- =============================================
-- Author:		邹健
-- Create date: 2007 08 22
-- Description:	我订阅的主题
-- =============================================
CREATE PROCEDURE [dbo].[RssList]
@userid bigint,
@page bigint=1,--当前页码
@everyPage bigint=10,
@groupclass tinyint=0--查询类型
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP (@everyPage) *
      FROM      (
	SELECT  top (@page*@everyPage)    [log].id as logid,[Log].title, [GROUP].groupname,[group].id as groupid, [name],[log].userid,[log].addtime
,ROW_NUMBER() OVER (ORDER BY [log].id desc) AS RowNo
FROM         GroupUser INNER JOIN
                      [Log] ON GroupUser.Groupid = [Log].GroupId INNER JOIN
                      Account ON [Log].userid = Account.UserId INNER JOIN
                      [Group] ON [Log] .groupid = [Group].id
WHERE     (GroupUser.userid = @userid) AND Groupuser.isrss =1 and [group].groupclass=@groupclass and datediff("ww",[log].addtime,getdate())=0
--ORDER BY [log].id desc
)AS T-- 
	WHERE RowNo > (@page-1)*@everyPage
END


