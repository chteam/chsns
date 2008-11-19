-- =============================================
-- Author:		邹健
-- Create date: 200702 e:2007 10 3
-- Description:	创建客服消息
-- =============================================
CREATE PROCEDURE [dbo].[Services_Add]
@userid bigint,
@body nvarchar(4000),
@Email nvarchar(50)
AS
BEGIN
SET NOCOUNT ON;
IF @EMAIL	=''
select @email=null;

INSERT INTO Services
			(body,userid,Email)
VALUES     (@body,@userid,@Email)
--else
--INSERT INTO Services
--                      (body,userid)
--VALUES     (@body,@userid)
END


