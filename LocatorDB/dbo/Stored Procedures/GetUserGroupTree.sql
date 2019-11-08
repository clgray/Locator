CREATE PROCEDURE [dbo].[GetUserGroupTree]
	@UserId int,  -- Id пользователя
	@ParentId int,  -- Id родителя, в случае NULL родителем будет корень дерева
    @IsAdmin bit,
	@Level int=NULL -- Число уровней, с которых берутся потомки
AS
BEGIN
SET @Level=@Level+1;

IF @UserId=0 BEGIN

EXEC GetGroupTreeByLevel @ParentId,@Level

END ELSE BEGIN

DECLARE @ProductTotals TABLE 
(
    [GroupId] [int] PRIMARY KEY NOT NULL,
	[GroupNode] [hierarchyid] NOT NULL,
	[GroupName] [varchar](250) NOT NULL,
	[GroupCode] [varchar](50) NOT NULL
)
DECLARE  @Id hierarchyid;
DECLARE @GroupId int;

DECLARE GroupsCur CURSOR FOR SELECT grp.GroupId
FROM UserGroups usr 
INNER JOIN GroupTree grp 
ON grp.GroupId=usr.GroupId WHERE usr.UserId=@UserId AND usr.IsAdministrator=@IsAdmin
OPEN GroupsCur
FETCH NEXT FROM GroupsCur INTO @GroupId
	WHILE @@FETCH_STATUS = 0
	BEGIN
	INSERT INTO @ProductTotals ([GroupId],[GroupNode],[GroupName],[GroupCode]) EXEC GetGroupTreeByLevel @GroupId,@Level
	  FETCH NEXT FROM GroupsCur INTO @GroupId
	END
CLOSE GroupsCur
DEALLOCATE GroupsCur

IF @ParentId IS NULL BEGIN
SELECT DISTINCT [GroupId],[GroupNode].ToString() AS 'GroupNode',[GroupName] FROM @ProductTotals
ORDER BY GroupNode
END ELSE BEGIN
SELECT @Id=GroupNode FROM GroupTree WHERE GroupId=@ParentId
SELECT DISTINCT [GroupId],[GroupNode].ToString() AS 'GroupNode',[GroupName] FROM @ProductTotals
WHERE GroupNode.IsDescendantOf(@Id) = 1
ORDER BY GroupNode
END
END
END