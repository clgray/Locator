-- =============================================
-- Author:		Antony
-- Create date: 2009.06.06
-- Description:	Удаление дубликатов студентов 
--   с переносом результатов (Фамилия+Имя+Отчество)
-- =============================================
CREATE PROCEDURE [dbo].[RemoveDuplicateStudents] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
-- =============================================
-- Declare and using a READ_ONLY cursor
-- =============================================
DECLARE DoubleStudentsCur CURSOR
READ_ONLY
FOR 
Select TT.mId,TT.UserFIO,TT.CNT from 
(
SELECT 
      LOWER([LastName] + [FirstName] + [SecondName]) as UserFIO
      ,COUNT (LOWER([LastName] + [FirstName] + [SecondName])) as CNT
      ,MIN(U.UserId) as mId
   FROM [Users] as U
  Group BY LOWER([LastName] + [FirstName] + [SecondName])
) AS TT
Where TT.CNT > 1


DECLARE @stud_name nvarchar(450)
DECLARE @stud_new_id int
DECLARE @count int

DECLARE @ProcessedCount int
SET @ProcessedCount = 0


OPEN DoubleStudentsCur

FETCH NEXT FROM DoubleStudentsCur INTO @stud_new_id,@stud_name,@count
WHILE (@@fetch_status <> -1)
BEGIN
	IF (@@fetch_status <> -2)
	BEGIN
--		PRINT 'add user defined code here'
--		eg.

		
		UPDATE [TestSessions]
		SET [UserId] = @stud_new_id
		WHERE 
			[UserId] in
			(
			select UserId from Users
			where
				LOWER([LastName] + [FirstName] + [SecondName]) = @stud_name
				and UserId <> @stud_new_id
			)  
		
		
		
		DELETE FROM [UserGroups]
		WHERE [UserId] in
			(
			select UserId from Users
			where
				LOWER([LastName] + [FirstName] + [SecondName]) = @stud_name
				and UserId <> @stud_new_id
			) 
		
		
		DELETE FROM [Users]
		WHERE [UserId] in
			(
			select UserId from Users
			where
				LOWER([LastName] + [FirstName] + [SecondName]) = @stud_name
				and UserId <> @stud_new_id
			) 
		
		SET @ProcessedCount = @ProcessedCount + 1
		DECLARE @message varchar(100)
		SELECT @message = 'The Kill is: ' + @stud_name 
		PRINT @message
	END
	FETCH NEXT FROM DoubleStudentsCur INTO @stud_new_id,@stud_name,@count
END

CLOSE DoubleStudentsCur
DEALLOCATE DoubleStudentsCur

SELECT @ProcessedCount
RETURN @ProcessedCount

END