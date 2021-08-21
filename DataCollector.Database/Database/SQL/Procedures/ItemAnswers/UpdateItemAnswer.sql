CREATE PROCEDURE [dbo].UpdateItemAnswer
(@ItemId INT, @QuestionId INT, 
@AnswerId INT, @Id INT)
AS
	UPDATE [dbo].ItemAnswers
	SET
	ItemId = @ItemId, 
	QuestionId = @QuestionId,
	AnswerId = @AnswerId
	WHERE
	Id = @Id;
GO