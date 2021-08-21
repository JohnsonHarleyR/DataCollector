CREATE PROCEDURE [dbo].GetItemAnswersByAnswer
(@QuestionId INT, @AnswerId INT)
AS
	SELECT * FROM [dbo].ItemAnswers
	WHERE QuestionId = @QuestionId
	AND AnswerId = @AnswerId;
GO