CREATE PROCEDURE [dbo].GetPossibleAnswerById
(@Id INT)
AS
	SELECT * FROM [dbo].PossibleAnswers
	WHERE Id = @Id;
GO