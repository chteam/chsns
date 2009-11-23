-- =============================================
-- Author:		<Author,,Name>
-- Create date: 10 22
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Photo_Cover] 
@photoid bigint,
@userid bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @path nvarchar(100),@albumid bigint;
select @path=[path],@albumid=albumid from photos where id = @photoid and userid=@userid
if(@path is null or @albumid is null)
return 0;
else
begin
	update album set faceurl=@path where id=@albumid and userid=@userid;
	return 1;
end
END


