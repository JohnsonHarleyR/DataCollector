CREATE PROCEDURE [dbo].GetItemAnswersByItem
(@ItemId INT)
AS
	SELECT * FROM [dbo].ItemAnswers
	WHERE ItemId = @ItemId;
GO