CREATE PROCEDURE [dbo].GetItemById
(@Id INT)
AS
	SELECT * FROM [dbo].Items
	WHERE Id = @Id;
GO