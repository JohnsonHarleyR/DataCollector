CREATE PROCEDURE [dbo].DeleteItemAnswer
(@Id INT)
AS
	DELETE FROM [dbo].ItemAnswers
	WHERE Id = @Id;
GO