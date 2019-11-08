CREATE PROCEDURE [dbo].[GetAppointedTests]
		@UserId int
AS
BEGIN
DECLARE @Id hierarchyid;

SELECT @Id=GroupNode FROM GroupTree 
INNER JOIN UserGroups ON GroupTree.GroupId=UserGroups.GroupId
WHERE UserGroups.UserId=@UserId

SELECT DISTINCT TestTree.NodeId,CoreTests.TestName, COUNT(TestSessions.IsPassed) AS PassedCount FROM GroupTree 
INNER JOIN TestGroups ON TestGroups.GroupId=GroupTree.GroupId 
INNER JOIN CoreTests ON CoreTests.TestId=TestGroups.TestId
INNER JOIN TestTree ON TestTree.TestId=CoreTests.TestId
LEFT OUTER JOIN TestSessions ON TestSessions.TestId=CoreTests.TestId AND TestSessions.UserId=@UserId
WHERE @Id.IsDescendantOf(GroupNode) = 1 AND CoreTests.IsActive=1 AND CoreTests.BeginTime<GETDATE() AND (GETDATE()<CoreTests.EndTime OR CoreTests.EndTime='0001-01-01 00:00:00.0000000')
AND CoreTests.IsDeleted=0
GROUP BY TestTree.NodeId,CoreTests.TestName
END