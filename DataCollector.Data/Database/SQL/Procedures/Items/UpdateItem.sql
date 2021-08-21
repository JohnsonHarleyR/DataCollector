CREATE PROCEDURE [dbo].UpdateItem
(@Id INT, @Name VARCHAR(50))
AS
	UPDATE [dbo].Items
	SET
	[Name] = @Name
	WHERE
	Id = @Id;
GO