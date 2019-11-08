-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <4.11.2008>
-- Description:	<AddGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[AddGroupTreeItem]
	@ParentId int, -- Id родителя, в случае NULL родителем будет корень дерева
	@GroupName varchar(250)=NULL, -- Имя группы
	@GroupCode varchar(50)=NULL -- Код группы
AS
BEGIN
DECLARE  @Id hierarchyid;

IF @ParentId IS NULL
BEGIN

SELECT @Id = MAX(GroupNode)
FROM GroupTree
WHERE GroupNode.GetAncestor(1) = hierarchyid::GetRoot()
INSERT INTO GroupTree (GroupNode, GroupName, GroupCode)
VALUES (hierarchyid::GetRoot().GetDescendant(@Id,NULL),@GroupName,@GroupCode);

END ELSE BEGIN

DECLARE  @ParentHierId hierarchyid;
SELECT @ParentHierId=GroupNode FROM GroupTree WHERE GroupId=@ParentId;

SELECT @Id = MAX(GroupNode)
FROM GroupTree
WHERE GroupNode.GetAncestor(1) = @ParentHierId

INSERT INTO GroupTree (GroupNode, GroupName, GroupCode)
VALUES (@ParentHierId.GetDescendant(@Id, NULL),@GroupName, @GroupCode);

END
RETURN @@IDENTITY
END