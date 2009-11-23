-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Photo_Remove]
@photoid bigint,
@userid bigint,
@FileSize bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @albumid bigint
select @albumid=0;
select @albumid=albumid from dbo.Photos where userid=@userid and id=@photoid
if @albumid=0
	return 0;
update [Profile] set FileSizeCount=FileSizeCount-@FileSize where userid=@userid--减去删除的大小

delete dbo.Photos where  userid=@userid and id=@photoid --删除此照片

update [album] set [Count]=[Count]-1 where id = @albumid and userid=@userid--相册中相处数-1
return 1;
END


