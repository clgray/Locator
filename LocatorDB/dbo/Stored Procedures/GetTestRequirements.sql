CREATE PROCEDURE [dbo].[GetTestRequirements]
	@TestId int
AS
BEGIN
SELECT req.Requirement,tree.NodeId,test.TestName FROM CoreRequirements req
INNER JOIN CoreTests test on req.Requirement=test.TestId
INNER JOIN TestTree tree on req.Requirement=tree.TestId
WHERE req.TestId=@TestId 
END