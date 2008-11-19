-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fun_GetScore]
(
@type nvarchar(50)
)
RETURNS int
AS
BEGIN
if @type='note_add'
return 5;
if @type='comment_add'
return 1;
return 0;
END


