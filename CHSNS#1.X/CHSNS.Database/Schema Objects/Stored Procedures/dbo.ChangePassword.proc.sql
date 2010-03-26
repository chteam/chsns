﻿CREATE PROCEDURE [dbo].[ChangePassword]
@Oldpwd Char(32),
@Newpwd char(32),
@Userid bigint
AS
IF EXISTS(SELECT 1 FROM Account WHERE USERID=@USERID AND [PASSWORD]=@OLDPWD)
BEGIN
	UPDATE Account SET [PASSWORD] =@NEWPWD WHERE USERID=@USERID
	RETURN 1
END
ELSE
	RETURN -1

