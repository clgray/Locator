CREATE PROCEDURE [dbo].[GetUserGroups]
	@UserId int
AS
BEGIN
SELECT grp.GroupId,grp.GroupName,usr.IsAdministrator FROM UserGroups usr INNER JOIN GroupTree grp ON grp.GroupId=usr.GroupId WHERE usr.UserId=@UserId 
END