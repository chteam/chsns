-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_Remove]
@albumid bigint,
@userid bigint,
@FileSizeCount bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if not exists(select 1 from album where userid=@userid and id=@albumid)
	return 0;
update [Profile] set FileSizeCount=@FileSizeCount where userid=@userid
delete dbo.Photos where  userid=@userid and Albumid=@albumid
delete [album] where userid=@userid and id=@albumid
update [Profile] set AlbumCount=AlbumCount-1 where userid=@userid
return 1;
END


