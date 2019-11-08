-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <17.10.2008>
-- Description:	<AddTestTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[AddTestTreeItem]
	@ParentId int, -- Id родителя, в случае NULL родителем будет корень дерева
	@NodeType tinyint, -- Тип.
	@TestId int=NULL, --Id теста в таблице CoreTests
	@ItemOwner int = NULL --Пользователь, создавший элемент
AS
BEGIN
DECLARE  @Id hierarchyid;

IF @ParentId IS NULL
BEGIN

SELECT @Id = MAX(TreeNode)
FROM TestTree
WHERE TreeNode.GetAncestor(1) = hierarchyid::GetRoot()
INSERT INTO TestTree (TreeNode, NodeType, TestId, ItemOwner, IsActive)
VALUES (hierarchyid::GetRoot().GetDescendant(@Id,NULL),@NodeType,@TestId,@ItemOwner, 1);

END ELSE BEGIN

DECLARE  @ParentHierId hierarchyid;
SELECT @ParentHierId=TreeNode FROM TestTree WHERE NodeId=@ParentId;

SELECT @Id = MAX(TreeNode)
FROM TestTree
WHERE TreeNode.GetAncestor(1) = @ParentHierId

INSERT INTO TestTree (TreeNode, NodeType, TestId, ItemOwner, IsActive)
VALUES (@ParentHierId.GetDescendant(@Id, NULL),@NodeType,@TestId, @ItemOwner, 1);

END
RETURN @@IDENTITY
END