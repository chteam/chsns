-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_Remove]
@id bigint,
@userid bigint,
@viewerstatus tinyint=0
AS
BEGIN
	SET NOCOUNT ON;
Delete SuperNote where id=@id and (userid=@userid or @viewerstatus>199)
END


