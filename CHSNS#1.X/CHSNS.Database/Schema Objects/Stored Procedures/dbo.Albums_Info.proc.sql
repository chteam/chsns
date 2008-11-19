-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Albums_Info]
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
select [name] ,@rc as Relation,AlbumCount from [Profile]
inner join Account on Account.userid=[Profile].userid
where Account.userid=@ownerid

END


