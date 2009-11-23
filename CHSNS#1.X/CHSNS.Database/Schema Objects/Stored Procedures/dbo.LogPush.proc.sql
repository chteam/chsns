-- =============================================
-- Author:		邹健
-- Create date: 200702
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LogPush] 
@Logid bigint ,
@viewerid bigint
AS
BEGIN
	SET NOCOUNT ON;



--/////已经转至COmmentCount
if exists(SELECT 1 FROM [Log] where (id = @Logid) and not ispost=255)--必须是发布的日志,可以发布
	if not exists(SELECT id FROM Push where (Logid = @Logid) and (userid=@viewerid))
	begin
		INSERT INTO Push
							  (Logid, userid)
		VALUES      (@Logid, @viewerid)
		UPDATE    [Log]
		SET              PushCount = PushCount + 1
		WHERE     (id = @Logid)
		return 1--成功
	END
	else return 3--您已经推荐过了
else
	return 2--非发布日志不能推荐
End


