-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[getFriend_Userid]
(	
@userid bigint
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT     Friend.fromid as userid
	FROM         Friend 
	WHERE      (Friend.toid = @userid and IsTrue = 1 )
	union
	SELECT     friend.toid as userid
	FROM         Friend
	WHERE      (Friend.fromid = @userid and IsTrue = 1 )

)


