-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetTestTreeItemActivity] 
    @NodeId int, 
	@Activity bit
AS
BEGIN
	UPDATE TestTree SET IsActive=@Activity WHERE NodeId=@NodeId
END