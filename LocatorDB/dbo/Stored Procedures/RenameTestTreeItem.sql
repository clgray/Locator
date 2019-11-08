CREATE PROCEDURE [dbo].[RenameTestTreeItem]
    @ItemId int, 
	@TestNewName varchar(150)
AS
BEGIN
	UPDATE CoreTests SET TestName=@TestNewName WHERE TestId=(
	SELECT TestId FROM TestTree WHERE NodeId=@ItemId)
END