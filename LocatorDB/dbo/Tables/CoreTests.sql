CREATE TABLE [dbo].[CoreTests] (
    [TestId]                INT              IDENTITY (1, 1) NOT NULL,
    [TestName]              VARCHAR (150)    NOT NULL,
    [TestKey]               UNIQUEIDENTIFIER CONSTRAINT [DF_CoreTests_TestKey] DEFAULT (newid()) NOT NULL,
    [Description]           VARCHAR (MAX)    NOT NULL,
    [QuestionsNumber]       SMALLINT         NOT NULL,
    [VariantsMode]          BIT              NOT NULL,
    [PassagesNumber]        SMALLINT         NOT NULL,
    [PassingScore]          FLOAT (53)       NOT NULL,
    [TimeLimit]             INT              NOT NULL,
    [BeginTime]             DATETIME2 (7)    NOT NULL,
    [EndTime]               DATETIME2 (7)    NOT NULL,
    [AllowAdmitQuestions]   BIT              NOT NULL,
    [ShowTestResult]        BIT              NOT NULL,
    [ShowDetailsTestResult] BIT              NOT NULL,
    [ShowRightAnswersCount] BIT              NOT NULL,
    [IsActive]              BIT              NOT NULL,
    [IsMasterTest]          BIT              NOT NULL,
    [AdaptiveMode]          SMALLINT         NOT NULL,
    [IsDeleted]             BIT              NOT NULL,
    CONSTRAINT [PK_CoreTests] PRIMARY KEY CLUSTERED ([TestId] ASC)
);

