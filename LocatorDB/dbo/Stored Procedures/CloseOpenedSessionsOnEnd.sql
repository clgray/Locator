-- =============================================
-- Author:		Antony
-- Create date: 2009.06.11
-- Description:	Закрытие открытых сессий, у которых 
--   истекло время тестирования (если время неограничено,
--   то сессии также закрываются)
-- =============================================
CREATE PROCEDURE [dbo].[CloseOpenedSessionsOnEnd] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



-- =============================================
-- Declare and using a READ_ONLY cursor
-- =============================================
DECLARE OpenedSessions_cur CURSOR
READ_ONLY
FOR 
SELECT 
	--DATEADD(minute,Tst.TimeLimit,Ses.StartTime) as EndTime
	--,Ses.StartTime
	--,*
	Ses.[TestSessionId]
	,Tst.[PassingScore]  
FROM 
	[TestSessions] as Ses
	left join [CoreTests] as Tst on Ses.TestId = Tst.TestId 
WHERE
	[Score] = -1
	AND -- Те что старые и кончились по времени
	DATEADD(minute,Tst.TimeLimit,Ses.StartTime) <= GETDATE()

DECLARE @SessID int
DECLARE @PassingScore int

DECLARE @Score int

DECLARE @ProcessedCount int
SET @ProcessedCount = 0

OPEN OpenedSessions_cur

FETCH NEXT FROM OpenedSessions_cur INTO @SessID,@PassingScore
WHILE (@@fetch_status <> -1)
BEGIN
	IF (@@fetch_status <> -2)
	BEGIN
--		PRINT 'add user defined code here'
--		eg.
		DECLARE @message varchar(100)
		SELECT @message = 'Closed Session was: ' + CAST(@SessID as nvarchar)
		PRINT @message
		
		--Берем результат
		SELECT 
			--COUNT(*)
			@Score = SUM(CAST(ISNULL([IsRightAnswer],0) as int))
		FROM 
			[TestSessionQuestions]
		WHERE
			[TestSessionId] = @SessID
			
		UPDATE
			[TestSessions]
		SET
			[Score] = @Score
			,[IsPassed] = CASE WHEN @Score>=@PassingScore THEN 1 ELSE 0 END 
			,[EndTime] = GetDate()
		WHERE
			[TestSessionId] = @SessID	
		
		--select @SessID,@Score,@PassingScore,CASE WHEN @Score>=@PassingScore THEN 1 ELSE 0 END
		
		SET @ProcessedCount = @ProcessedCount + 1
	END
	FETCH NEXT FROM OpenedSessions_cur INTO @SessID,@PassingScore
END

CLOSE OpenedSessions_cur
DEALLOCATE OpenedSessions_cur

SELECT @ProcessedCount
RETURN @ProcessedCount

END