-- =============================================
-- Author:		zsword	
-- Create date: 2007 10 7
-- Description:	HTMLEncode
-- =============================================
CREATE FUNCTION [dbo].[HTMLEncode]
(
@str nvarchar(4000)
)
RETURNS nvarchar(4000)
AS
BEGIN
	-- Declare the return variable here
select @str = replace(@str,'<','&lt;');
select @str = replace(@str,'>','&gt;');
	RETURN @str

END


