-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <21.11.2008>
-- Description:	<ReparentTestTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[ReparentTestTreeItem]
    @ItemId int, 
	@ItemNewParent int
AS
BEGIN
DECLARE @ParentHierId hierarchyid;
DECLARE @Child hierarchyid
DECLARE @Id hierarchyid;

IF @ItemNewParent != 0 BEGIN
SELECT @ParentHierId=TreeNode FROM TestTree WHERE NodeId=@ItemNewParent;
END ELSE BEGIN
SELECT @ParentHierId = hierarchyid::GetRoot() FROM TestTree
END

SELECT @Id = MAX(TreeNode)
FROM TestTree
WHERE TreeNode.GetAncestor(1) = @ParentHierId

SELECT @Child = TreeNode FROM TestTree WHERE NodeId = @ItemId

UPDATE TestTree
SET TreeNode = TreeNode.GetReparentedValue(@Child, @ParentHierId.GetDescendant(@Id, NULL)) 
WHERE 
TreeNode.IsDescendantOf(@Child) = 1
END