CREATE TRIGGER [dbo].[School_Trigger_Insert]
   ON  [dbo].[Field]
   AFTER Insert
AS 
BEGIN
	SET NOCOUNT ON;
	UPDATE Field
	SET Id = trueid+dbo.GetRandom() WHERE 
	trueid in (select trueid from inserted where id is null or id=0)
END


