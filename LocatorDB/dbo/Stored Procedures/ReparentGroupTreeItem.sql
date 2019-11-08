-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <21.11.2008>
-- Description:	<ReparentGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[ReparentGroupTreeItem]
    @ItemId int, 
	@ItemNewParent int
AS
BEGIN
DECLARE @ParentHierId hierarchyid;
DECLARE @Child hierarchyid
DECLARE @Id hierarchyid;

IF @ItemNewParent != 0 BEGIN
SELECT @ParentHierId = GroupNode FROM GroupTree WHERE GroupId = @ItemNewParent
END ELSE BEGIN
SELECT @ParentHierId = hierarchyid::GetRoot() FROM GroupTree
END

SELECT @Id = MAX(GroupNode)
FROM GroupTree
WHERE GroupNode.GetAncestor(1) = @ParentHierId

SELECT @Child = GroupNode FROM GroupTree WHERE GroupId = @ItemId

UPDATE GroupTree
SET GroupNode = GroupNode.GetReparentedValue(@Child, @ParentHierId.GetDescendant(@Id, NULL)) 
WHERE 
GroupNode.IsDescendantOf(@Child) = 1
END