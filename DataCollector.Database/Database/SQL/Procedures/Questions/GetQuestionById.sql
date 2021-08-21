CREATE PROCEDURE [dbo].GetQuestionById
(@Id INT)
AS
	SELECT * FROM [dbo].Questions
	WHERE Id = @Id;
GO