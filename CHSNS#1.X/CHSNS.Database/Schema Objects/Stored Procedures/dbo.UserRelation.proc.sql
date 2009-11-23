-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserRelation]
@ownerid bigint,
@viewerid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Declare @rc tinyint
EXECUTE @RC = [Relation] 
   @ownerid
  ,@viewerid

select [name] ,@rc as Relation,AllShowLevel from Account
inner join [profile] on [profile].userid=Account.userid
 where Account.userid=@ownerid
END


