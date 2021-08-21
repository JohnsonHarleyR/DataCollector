CREATE PROCEDURE [dbo].AddItemAnswer
(@ItemId INT, @QuestionId INT, 
@AnswerId INT)
AS
	INSERT INTO [dbo].ItemAnswers
	(ItemId, QuestionId, AnswerId)
	VALUES
	(@ItemId, @QuestionId, @AnswerId);
GO