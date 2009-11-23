-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_Count]
@userid bigint,
@type tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
select count(1) as [Count] from supernote where userid=@userid
END


