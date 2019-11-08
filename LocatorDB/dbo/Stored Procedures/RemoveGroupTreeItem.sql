-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <04.11.2008>
-- Description:	<RemoveGroupTreeItem>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveGroupTreeItem]
	@ItemId int
AS
BEGIN

DECLARE  @GroupId int=NULL;

DECLARE  @Id hierarchyid
SELECT @Id=GroupNode,@GroupId=GroupId FROM GroupTree WHERE GroupId=@ItemId

DELETE
FROM GroupTree
WHERE GroupNode.IsDescendantOf(@Id) = 1

RETURN @GroupId

END