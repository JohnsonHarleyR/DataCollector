CREATE PROCEDURE [dbo].AddItem
(@Name VARCHAR(50))
AS
	INSERT INTO [dbo].Items
	([Name])
	VALUES
	(@Name);
GO