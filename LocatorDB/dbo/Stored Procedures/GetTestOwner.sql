CREATE PROCEDURE [dbo].[GetTestOwner]
	@ItemId int
AS
BEGIN
DECLARE @ItemOwner int = NULL;
SELECT @ItemOwner = ItemOwner FROM TestTree WHERE  TestId=@ItemId;
RETURN @ItemOwner;
END