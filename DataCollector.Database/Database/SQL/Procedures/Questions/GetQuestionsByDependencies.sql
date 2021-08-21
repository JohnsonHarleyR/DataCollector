CREATE PROCEDURE [dbo].GetQuestionsByDependencies
(@DependentQuestionId INT, @DependentAnswerId INT)
AS
	SELECT * FROM [dbo].Questions
	WHERE DependentQuestionId = @DependentQuestionId 
	AND DependentAnswerId = @DependentAnswerId;
GO