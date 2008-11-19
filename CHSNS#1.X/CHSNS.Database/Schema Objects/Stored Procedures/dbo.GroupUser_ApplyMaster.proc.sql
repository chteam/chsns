-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 17
-- Description:	订阅
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_ApplyMaster]--申请成为管理员
@groupid bigint,
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
if exists(select istrue from [groupuser] where groupid=@groupid and userid=@userid and istrue=1 and [level]=1)
	begin	
		update [groupuser] set [level]=2 where groupid=@groupid and userid=@userid and istrue=1
		return 1--成功
	end
else
	return -1--您已经提交过申请
END


