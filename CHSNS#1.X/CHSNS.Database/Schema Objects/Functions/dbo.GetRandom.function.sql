-- =============================================
-- Author:		
-- Create date: 2007 9 14
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetRandom]()
RETURNS bigint
AS
BEGIN
RETURN Datediff("mi",CONVERT(datetime,'2007-9-8'),CONVERT(VARCHAR(30),GETDATE(),9))
END


