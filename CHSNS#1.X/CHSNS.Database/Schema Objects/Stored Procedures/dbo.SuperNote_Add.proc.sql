-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SuperNote_Add]
@url nvarchar(500),
@description nvarchar(50),
@userid bigint,
@title nvarchar(50),
@faceurl nvarchar(500),
@showlevel tinyint,
@systemcategory bigint=null,
@category bigint=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO SuperNote
                      (title,faceurl,url, [description], userid,showlevel,systemcategory,category)
VALUES     (@title,@faceurl,@url, @description, @userid,@showlevel,@systemcategory,@category)

			EXECUTE [dbo].[Event_Add] 
			   @userid
			  ,@userid
			  ,5
			  ,@title
			  ,null
END


