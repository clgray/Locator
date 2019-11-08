-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <04.11.2008>
-- Description:	<RenameGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[RenameGroupTreeItem]
    @ItemId int, 
	@GroupNewName varchar(150)
AS
BEGIN
	UPDATE GroupTree SET GroupName=@GroupNewName WHERE GroupId=@ItemId
END