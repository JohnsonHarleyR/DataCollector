CREATE PROCEDURE [dbo].UpdateQuestion
(@Question VARCHAR(100), @DependentQuestionId INT, 
@DependentAnswerId INT, @Id INT)
AS
	UPDATE [dbo].Questions
	SET
	Question = @Question, 
	DependentQuestionId = @DependentQuestionId,
	DependentAnswerId = @DependentAnswerId
	WHERE
	Id = @Id;
GO