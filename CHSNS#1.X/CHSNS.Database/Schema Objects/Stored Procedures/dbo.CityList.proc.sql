CREATE PROCEDURE [dbo].[CityList]
@pid tinyint
AS
SELECT [id], [name] FROM [City] WHERE ([pid] = @pid)


