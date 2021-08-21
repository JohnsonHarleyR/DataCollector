CREATE PROCEDURE [dbo].GetItemAnswerById
(@Id INT)
AS
	SELECT * FROM [dbo].ItemAnswers
	WHERE Id = @Id;
GO