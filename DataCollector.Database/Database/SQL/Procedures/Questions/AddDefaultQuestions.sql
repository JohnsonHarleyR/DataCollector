CREATE PROCEDURE [dbo].AddDefaultQuestions
AS
	INSERT INTO [dbo].Questions
	(Question, DependentQuestionId, DependentAnswerId)
	VALUES
	('Is it a person?', null, null),
	('Is it a place?', null, null),
	('Is it a thing?', null, null)
GO