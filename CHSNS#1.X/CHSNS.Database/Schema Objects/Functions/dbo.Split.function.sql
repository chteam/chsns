-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[Split](
@s   varchar(8000),  --待分拆的字符串
@split varchar(10)     --数据分隔符
)RETURNS @re TABLE([id] int IDENTITY(1,1),col varchar(100))
AS
BEGIN
	--创建分拆处理的辅助表(用户定义函数中只能操作表变量)
	DECLARE @t TABLE(ID int IDENTITY,b bit)
	INSERT @t(b) SELECT TOP 8000 0 FROM syscolumns a,syscolumns b

	INSERT @re SELECT SUBSTRING(@s,ID,CHARINDEX(@split,@s+@split,ID)-ID)
	FROM @t
	WHERE ID<=LEN(@s+'a') 
		AND CHARINDEX(@split,@split+@s,ID)=ID
	RETURN
END


