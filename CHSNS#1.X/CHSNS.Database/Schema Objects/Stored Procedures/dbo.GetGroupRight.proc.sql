-- =============================================
-- Author:		邹健
-- Create date: 20070331
-- Description:	得到群的权限信息
-- 0--可以发帖 4可看 8不能看
-- =============================================
CREATE PROCEDURE [dbo].[GetGroupRight]
@userid bigint,
@groupid bigint
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @S tinyint
SELECT     @S=ShowLevel
FROM         [Group] where id=@groupid
----------------------------------------------------------
if (@S=8)--成员才能，看/发
	if exists(SELECT     IsTrue
	FROM         GroupUser
	WHERE     (userid = @userid) AND (Groupid = @groupid) AND (IsTrue = 1))
	begin
		exec ViewInsert @userid,@groupid,1;
		return 0--本群用户可发帖
	end
else
	return 8--非本群用户不能看，立即退出
-------------------------------------------------------
exec ViewInsert @userid,@groupid,1;

if (@S=0)--公开
return 0--可以发帖
-------------------------------------------------------
if (@S=4)--公开或可看但不能发贴
if exists(SELECT     IsTrue
FROM         GroupUser
WHERE     (userid = @userid) AND (Groupid = @groupid) AND (IsTrue = 1))
return 0--本群用户可发帖
else
return 4--非本群用户只能看


END


