CREATE PROCEDURE [dbo].AddQuestion
(@Question VARCHAR(100), @DependentQuestionId INT, 
@DependentAnswerId INT)
AS
	INSERT INTO [dbo].Questions
	(Question, DependentQuestionId, DependentAnswerId)
	VALUES
	(@Question, @DependentQuestionId, @DependentAnswerId);
GO