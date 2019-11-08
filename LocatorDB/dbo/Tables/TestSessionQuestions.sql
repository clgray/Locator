CREATE TABLE [dbo].[TestSessionQuestions] (
    [TestSessionQuestId] INT           IDENTITY (1, 1) NOT NULL,
    [QuestionIndex]      SMALLINT      NOT NULL,
    [TestSessionId]      INT           NOT NULL,
    [QuestionId]         INT           NOT NULL,
    [Answer]             VARCHAR (MAX) NULL,
    [IsRightAnswer]      BIT           NULL,
    CONSTRAINT [PK_TestSessionQuestions] PRIMARY KEY CLUSTERED ([TestSessionQuestId] ASC),
    CONSTRAINT [FK_TestSessionQuestions_CoreQuestions] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[CoreQuestions] ([QuestionId]),
    CONSTRAINT [FK_TestSessionQuestions_TestSessions] FOREIGN KEY ([TestSessionId]) REFERENCES [dbo].[TestSessions] ([TestSessionId])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_TestSessionQuestions_7_533576939__K4_K3]
    ON [dbo].[TestSessionQuestions]([QuestionId] ASC, [TestSessionId] ASC);

