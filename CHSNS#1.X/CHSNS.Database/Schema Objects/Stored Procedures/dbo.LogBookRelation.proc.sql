-- =============================================
-- Author:		邹健
-- Create date: 2007 08 19
-- Description:	得到日志的相关权限（Relation）及基本信息
-- =============================================
CREATE PROCEDURE [dbo].[LogBookRelation]
@Logid bigint,
@Viewerid bigint,
@Groupid bigint--所在群的ID，如果为个人日志，则为0
AS
BEGIN
	SET NOCOUNT ON;
declare @ownerid bigint,@title nvarchar(255),@rl tinyint
if(@Groupid=0)--为个人日志 ，则与个人的设置有关
begin 
	select @ownerid=userid,@title=title from [log] where id=@logid
	EXECUTE @Rl = [Relation] 
	   @ownerid
	  ,@viewerid
	select @ownerid,@title,@rl 
	return
end


END


