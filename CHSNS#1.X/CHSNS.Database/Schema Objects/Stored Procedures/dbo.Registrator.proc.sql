-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Registrator]
@Email nvarchar(50),
@Password char(32),
@name nvarchar(12),
@University nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @RC int
EXECUTE @rc=[Account_Add] 
@Email,@name,@Password,null,null
if @rc=-2 or @rc=-1
return @rc
insert [profile] (userid) values(@rc)
insert BasicInformation (userid) values(@rc)
insert SchoolInformation (userid,University) select @rc,id from school where school=@University
RETURN @rc
END


