-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGroupIdByCode]
	@GroupCode varchar(50)-- Код группы
AS
BEGIN
DECLARE @GID int;
SELECT @GID = GroupId FROM GroupTree WHERE GroupCode=@GroupCode
RETURn @GID
END