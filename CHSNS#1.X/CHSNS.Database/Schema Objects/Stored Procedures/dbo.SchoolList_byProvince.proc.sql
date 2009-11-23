-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 10 3
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SchoolList_byProvince]
@province nvarchar(50)
,@schoolclass int=0--0 is University
AS
BEGIN
	SET NOCOUNT ON;
if(@province='')
SELECT [id]
      ,[School]
  FROM [School] where SchoolClass=0
else 
SELECT [id]
      ,[School]
  FROM [School] where SchoolClass=0 and  province in (select id from province where [name]=@province)
END


