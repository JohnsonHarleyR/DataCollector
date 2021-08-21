CREATE PROCEDURE [dbo].DeleteItem
(@Id INT)
AS
	DELETE FROM [dbo].Items
	WHERE Id = @Id;
GO