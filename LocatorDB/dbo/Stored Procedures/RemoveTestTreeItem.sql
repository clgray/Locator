-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <17.10.2008>
-- Description:	<RemoveTestTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveTestTreeItem]
	@ItemId int
AS
BEGIN

DECLARE  @TestId int=NULL;

DECLARE  @Id hierarchyid
SELECT @Id=TreeNode,@TestId=TestId FROM TestTree WHERE NodeId=@ItemId

DELETE
FROM TestTree
WHERE TreeNode.IsDescendantOf(@Id) = 1

RETURN @TestId

END