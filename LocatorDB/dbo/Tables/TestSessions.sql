CREATE TABLE [dbo].[TestSessions] (
    [TestSessionId]  INT          IDENTITY (1, 1) NOT NULL,
    [UserId]         INT          NOT NULL,
    [TestId]         INT          NOT NULL,
    [StartTime]      DATETIME     NOT NULL,
    [EndTime]        DATETIME     NULL,
    [MaxScore]       FLOAT (53)   NOT NULL,
    [Score]          FLOAT (53)   NULL,
    [IsPassed]       BIT          NOT NULL,
    [ClientIP]       VARCHAR (15) NOT NULL,
    [UniqId]         VARCHAR (15) NOT NULL,
    [AdditionalTime] SMALLINT     NULL,
    CONSTRAINT [PK_TestSessions] PRIMARY KEY CLUSTERED ([TestSessionId] ASC),
    CONSTRAINT [FK_TestSessions_CoreTests] FOREIGN KEY ([TestId]) REFERENCES [dbo].[CoreTests] ([TestId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TestSessions_1]
    ON [dbo].[TestSessions]([UserId] ASC, [TestId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TestSessions]
    ON [dbo].[TestSessions]([StartTime] ASC, [EndTime] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_TestSessions_7_405576483__K4D_K2_1_10]
    ON [dbo].[TestSessions]([StartTime] DESC, [UserId] ASC)
    INCLUDE([TestSessionId], [UniqId]);


GO
CREATE NONCLUSTERED INDEX [_dta_index_TestSessions_7_405576483__K2_K5_K1]
    ON [dbo].[TestSessions]([UserId] ASC, [EndTime] ASC, [TestSessionId] ASC);

