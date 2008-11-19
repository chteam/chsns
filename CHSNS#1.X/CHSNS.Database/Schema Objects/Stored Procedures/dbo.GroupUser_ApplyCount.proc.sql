-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 17
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GroupUser_ApplyCount]
@groupid bigint,
@type tinyint
AS
BEGIN
	SET NOCOUNT ON;
declare @c bigint
if @type=0--加入的成员
begin 
	select @c=count(istrue) from [groupuser] where groupid=@groupid and istrue=0
end
if @type=1
begin
	select @c=count(istrue) from [groupuser] where groupid=@groupid and [level]=2
end
return @c
END


