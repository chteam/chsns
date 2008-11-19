-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[unSee_Countlist]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
select count(1) as c from [message] where IsSee=0 and toid=@userid and istodel=0
END


