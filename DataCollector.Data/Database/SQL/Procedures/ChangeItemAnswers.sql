SELECT * FROM [dbo].[ItemAnswers]
SELECT * FROM [dbo].[PossibleAnswers]
SELECT * FROM [dbo].[Items]
SELECT * FROM [dbo].[Questions]

DELETE FROM [dbo].[ItemAnswers]
WHERE ItemId = 19
DELETE FROM [dbo].[Items]
WHERE Id = 19

SELECT * FROM [dbo].[ItemAnswers]
WHERE ItemId = 22 AND QuestionId = 7

UPDATE [dbo].[ItemAnswers]
SET AnswerId = 3
WHERE ItemId = 22 AND QuestionId = 7