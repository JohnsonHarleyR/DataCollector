CREATE PROCEDURE [dbo].DeleteQuestion
(@Id INT)
AS
	DELETE FROM [dbo].Questions
	WHERE Id = @Id;
GO