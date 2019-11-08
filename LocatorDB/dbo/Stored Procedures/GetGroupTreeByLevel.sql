-- =============================================
-- Author:		<Sergey Pugachev>
-- Create date: <04.11.2008>
-- Description:	<GetGroupTreeByLevel>
-- =============================================
CREATE PROCEDURE [dbo].[GetGroupTreeByLevel]
	@ParentId int,  -- Id родителя, в случае NULL родителем будет корень дерева
	@Level int=NULL -- Число уровней, с которых берутся потомки
AS
BEGIN
DECLARE  @Id hierarchyid;

IF @ParentId IS NULL
BEGIN
SET @Id = hierarchyid::GetRoot()
END ELSE BEGIN
SELECT @Id=GroupNode FROM GroupTree WHERE GroupId=@ParentId
END


IF @Level IS NOT NULL
BEGIN
DECLARE  @RealLevel int
SET @RealLevel= (@Id.GetLevel()+@Level+1)

SELECT GroupId,GroupNode.ToString() AS 'GroupNode',GroupName, GroupCode
FROM GroupTree
WHERE GroupNode.IsDescendantOf(@Id) = 1 AND GroupNode.GetLevel()<@RealLevel AND 
GroupNode.GetLevel()>@Id.GetLevel() OR GroupNode=@Id ORDER BY GroupNode

END ELSE BEGIN

SELECT GroupId,GroupNode.ToString() AS 'GroupNode',GroupName, GroupCode
FROM GroupTree
WHERE GroupNode.IsDescendantOf(@Id) = 1 ORDER BY GroupNode

END
END