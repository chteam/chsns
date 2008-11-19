-- =============================================
-- Author:		邹健
-- Create date: 2007 10 6
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Admin_School_Add]
@schoolname nvarchar(50),
@province nvarchar(50),
@SchoolClass int=0--大学为0;
AS
BEGIN
	SET NOCOUNT ON;
if not exists(select id from [school] where school=@schoolname and Province=@province)
begin
	insert [school](school,Province,SchoolClass) values (@schoolname,@province,@SchoolClass)
end
END


