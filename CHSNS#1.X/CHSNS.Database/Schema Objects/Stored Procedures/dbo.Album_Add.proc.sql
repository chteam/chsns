-- =============================================
-- Author:		<Author,,Name>
-- Create date: 10 16
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Album_Add]
@userid bigint,
@name nvarchar(50),
@Location nvarchar(50),
@Showlevel tinyint,
@Description nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if exists(select 1 from album where [name]=@name and userid=@userid)
	return 0;
INSERT INTO [dbo].[Album]
           ([userid]
           ,[name]
           ,[Showlevel]
           ,[Description]
           ,[Location])
     VALUES
           (@userid
           ,@name
           ,@Showlevel
           ,@Description
           ,@Location);
if(@Showlevel!=200)
EXECUTE [dbo].[Event_Add] 
   @userid
  ,@userid
  ,3
  ,@name
  ,@@IDENTITY
update [Profile] set AlbumCount=AlbumCount+1 where userid=@userid
return 1;
END


