-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <17.10.2008>
-- Description:	<GetTestTreeByLevel>
-- =============================================
CREATE PROCEDURE [dbo].[GetTestTreeByLevel]
	@ParentId int,  -- Id родителя, в случае NULL родителем будет корень дерева
	@Level int=NULL, -- Число уровней, с которых берутся потомки
	@GetParents bit, --Выбрать всех родителей данного узла
	@GetOnlyActive bit --Получить только активные тесты
AS
BEGIN

DECLARE  @Id hierarchyid;
IF @ParentId IS NULL
BEGIN
SET @Id = hierarchyid::GetRoot()
END ELSE BEGIN
SELECT @Id=TreeNode FROM TestTree WHERE NodeId=@ParentId
END

IF @GetParents=1
BEGIN
SELECT TestTree.NodeId,TestTree.NodeType,TestTree.TreeNode.ToString() AS 'TreeNode',TestTree.TestId,
CoreTests.TestName, TestTree.ItemOwner, TestTree.IsActive AS 'TestTreeIsActive'
FROM TestTree LEFT JOIN CoreTests ON TestTree.TestId=CoreTests.TestId
WHERE @Id.IsDescendantOf(TreeNode) = 1 AND(
  ((@GetOnlyActive=1) AND (CoreTests.IsActive=1))
  OR
  (@GetOnlyActive=0)
  )
ORDER BY TestTree.TreeNode
END ELSE BEGIN

IF @Level IS NOT NULL
BEGIN
DECLARE @RealLevel int
SET @RealLevel= (@Id.GetLevel()+@Level+1)

SELECT TestTree.NodeId,TestTree.NodeType,TestTree.TreeNode.ToString() AS 'TreeNode',TestTree.TestId,
CoreTests.TestName, TestTree.ItemOwner, TestTree.IsActive AS 'TestTreeIsActive'
FROM TestTree LEFT JOIN CoreTests ON TestTree.TestId=CoreTests.TestId
WHERE TreeNode.IsDescendantOf(@Id) = 1 AND TreeNode.GetLevel()<@RealLevel AND 
TreeNode.GetLevel()>@Id.GetLevel() AND(
  ((@GetOnlyActive=1) AND (CoreTests.IsActive=1))
  OR
  (@GetOnlyActive=0)
  )
ORDER BY TestTree.TreeNode

END ELSE BEGIN

SELECT TestTree.NodeId,TestTree.NodeType,TestTree.TreeNode.ToString() AS 'TreeNode',TestTree.TestId,
CoreTests.TestName, TestTree.ItemOwner, TestTree.IsActive AS 'TestTreeIsActive'
FROM TestTree LEFT JOIN CoreTests ON TestTree.TestId=CoreTests.TestId
WHERE TreeNode.IsDescendantOf(@Id) = 1 AND(
  ((@GetOnlyActive=1) AND (CoreTests.IsActive=1))
  OR
  (@GetOnlyActive=0)
  )
ORDER BY TestTree.TreeNode

END
END
END