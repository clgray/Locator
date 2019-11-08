CREATE PROCEDURE [dbo].[GetTestItemOwner]
	@ItemId int
AS
BEGIN
DECLARE @ItemOwner int = NULL;
SELECT @ItemOwner = ItemOwner FROM TestTree WHERE NodeId=@ItemId;
RETURN @ItemOwner;
END