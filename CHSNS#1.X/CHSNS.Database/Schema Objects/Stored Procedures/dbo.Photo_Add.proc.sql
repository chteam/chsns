-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Photo_Add]
@photoname nvarchar(50)='',
@Albumid bigint,
@userid bigint,
@Path nvarchar(100),
@FileSize bigint
AS
BEGIN
	SET NOCOUNT ON;
if exists(select 1 from [profile] where userid=@userid and filesizeall>=filesizecount+@FileSize)
begin
	if exists(select 1 from album where id=@Albumid and userid=@userid)
			begin
				INSERT INTO Photos
					([name], userid, Albumid, [Path])
				VALUES     (@photoname,@userid,@Albumid,@Path)
			if exists(select 1 from album where  userid=@userid and id=@Albumid and [count]=0)
				update [album] set [Count]=[Count]+1, faceurl=@path where userid=@userid and id=@Albumid
			else
				update [album] set [Count]=[Count]+1 where userid=@userid and id=@Albumid
			update [profile] set FileSizeCount=FileSizeCount+@FileSize where userid=@userid;
		return 1
	end
	else
		return 0
end
else
return -1
END


