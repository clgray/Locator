-- =============================================
-- Author:		Antony
-- Create date: 2009.06.07
-- Description: Нормализация ФИО (с большой
--    буквы, маленькими)
-- =============================================
CREATE PROCEDURE [dbo].[SetUsersFIONormalization] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Users
	Set 
		LastName	= case LEN(LastName) when 0 then '' else UPPER(SUBSTRING(LastName,1,1)) + LOWER(SUBSTRING(LastName,2,LEN(LastName)-1)) end
		,FirstName	= case LEN(FirstName) when 0 then '' else UPPER(SUBSTRING(FirstName,1,1)) + LOWER(SUBSTRING(FirstName,2,LEN(FirstName)-1)) end
		,SecondName	= case LEN(SecondName) when 0 then '' else UPPER(SUBSTRING(SecondName,1,1)) + LOWER(SUBSTRING(SecondName,2,LEN(SecondName)-1)) end
END