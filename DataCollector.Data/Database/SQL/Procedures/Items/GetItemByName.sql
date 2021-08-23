CREATE PROCEDURE [dbo].GetItemByName
(@Name VARCHAR(50))
AS
	SELECT * FROM [dbo].Items
	WHERE [Name] = @Name;
GO

DELETE FROM [dbo].Items
WHERE Id = 2