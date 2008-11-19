-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_Update]
@albumid bigint,
@userid bigint,
@name nvarchar(50),
@Location nvarchar(50),
@Showlevel tinyint,
@Description nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if exists(select 1 from album where [name]=@name and userid=@userid and not id=@albumid)
	return 0;
	UPDATE    Album
	SET              Showlevel =@Showlevel, [name] =@name, [Description] =@Description, Location =@Location
	where userid=@userid and  id=@albumid
return 1;

END


